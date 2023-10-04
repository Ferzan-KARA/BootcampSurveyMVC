using AutoMapper;
using BootcampSurveyMVC.Models.DTOs;
using BootcampSurveyMVC.Models.Entities;
using BootcampSurveyMVC.Models.ViewModel;

namespace BootcampSurveyMVC.AutoMapper.Config
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<UserSignUpDTO, AppUser>().ForMember(
                des=>des.UserId,
                opt=>opt.MapFrom(src=>src.UserId));
            CreateMap<UserSignInDTO, AppUser>().ReverseMap();
            CreateMap<GuestAddDTO, Guest>().ReverseMap();
            CreateMap<GuestSurveyDTO, Survey>().ReverseMap();
            CreateMap<Guest, Survey>()
           .ForMember(dest => dest.GuestMakerId, opt => opt.MapFrom(src => src.GuestId))
           .ForMember(dest => dest.QuestionAmount, opt => opt.MapFrom(src => src.Surveys.Count))
           .ReverseMap();
            CreateMap<QuestionPool, QuestionViewModel>()
            .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.QuestionId))
            .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.QuestionText))
            .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => new List<AnswerViewModel>()));
            CreateMap<AnswerViewModel, Form>()
            .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrect));
        }
    }
}
