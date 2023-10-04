using System;
using System.Collections.Generic;
using BootcampSurveyMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BootcampSurveyMVC.Models;

public partial class SurveyerContext : DbContext
{
    public SurveyerContext()
    {
    }

    public SurveyerContext(DbContextOptions<SurveyerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppAdmin> Admins { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<QuestionPool> QuestionPools { get; set; }

    public virtual DbSet<Scoreboard> Scoreboards { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<AppUser> Users { get; set; }

    public virtual DbSet<UserMadeQuestion> UserMadeQuestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SurveyerDB;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppAdmin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("pk_admin");

            entity.HasIndex(e => e.AdminMail, "ck_admail").IsUnique();

            entity.Property(e => e.AdminId)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("adminId");
            entity.Property(e => e.AdminMail)
                .HasMaxLength(50)
                .HasColumnName("adminMail");
            entity.Property(e => e.AdminName)
                .HasMaxLength(50)
                .HasColumnName("adminName");
            entity.Property(e => e.AdminPass)
                .HasMaxLength(20)
                .HasColumnName("adminPass");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Answer)
                .HasMaxLength(50)
                .HasColumnName("answer");
            entity.Property(e => e.AnswerLocation).HasColumnName("answerLocation");
            entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");
            entity.Property(e => e.QuestionId).HasColumnName("questionId");
            entity.Property(e => e.SurveyId).HasColumnName("surveyId");
            entity.Property(e => e.UsrQid).HasColumnName("usrQId");

            entity.HasOne(d => d.Question).WithMany()
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_question");

            entity.HasOne(d => d.Survey).WithMany()
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_survey");

            entity.HasOne(d => d.UsrQ).WithMany()
                .HasForeignKey(d => d.UsrQid)
                .HasConstraintName("fk_usrQ");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("pk_guest");

            entity.Property(e => e.GuestId).HasColumnName("guestId");
            entity.Property(e => e.GuestName)
                .HasMaxLength(50)
                .HasColumnName("guestName");
        });

        modelBuilder.Entity<QuestionPool>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("pk_question");

            entity.ToTable("QuestionPool");

            entity.Property(e => e.QuestionId).HasColumnName("questionId");
            entity.Property(e => e.QuestionText)
                .HasMaxLength(100)
                .HasColumnName("questionText");
        });

        modelBuilder.Entity<Scoreboard>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Scoreboard");

            entity.Property(e => e.CorrectAmount).HasColumnName("correctAmount");
            entity.Property(e => e.GuestId).HasColumnName("guestId");
            entity.Property(e => e.SurveyId).HasColumnName("surveyId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Guest).WithMany()
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("fk_guestScore");

            entity.HasOne(d => d.Survey).WithMany()
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("fk_surveyScore");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_userScore");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.SurveyId).HasName("pk_survey");

            entity.Property(e => e.SurveyId).HasColumnName("surveyId");
            entity.Property(e => e.GuestMakerId).HasColumnName("guestMakerId");
            entity.Property(e => e.QuestionAmount).HasColumnName("questionAmount");
            entity.Property(e => e.UserMakerId).HasColumnName("userMakerId");

            entity.HasOne(d => d.GuestMaker).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.GuestMakerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_guest");

            entity.HasOne(d => d.UserMaker).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.UserMakerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_user");

            entity.HasIndex(e => e.UserMail, "ck_usermail").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("lastName");
            entity.Property(e => e.Pass)
                .HasMaxLength(20)
                .HasColumnName("pass");
            entity.Property(e => e.UserMail)
                .HasMaxLength(50)
                .HasColumnName("userMail");
        });

        modelBuilder.Entity<UserMadeQuestion>(entity =>
        {
            entity.HasKey(e => e.UsrQuestId).HasName("pk_usrQuest");

            entity.Property(e => e.UsrQuestId).HasColumnName("usrQuestId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UsrQuestText)
                .HasMaxLength(50)
                .HasColumnName("usrQuestText");

            entity.HasOne(d => d.User).WithMany(p => p.UserMadeQuestions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_userU");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
