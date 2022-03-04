using AutoMapper;
using CreateExam.Application.Models.Dtos;
using CreateExam.Application.Models.VMs;
using CreateExam.Core.Entities.Concrete;

namespace CreateExam.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();

            CreateMap<Article, CreateArticleDto>().ReverseMap();
            CreateMap<Article, GetArticleVM>().ReverseMap();
            CreateMap<GetArticleVM, Article>().ReverseMap();
            CreateMap<Article, CreateQuestionDto>().ReverseMap();

            //CreateMap<Exam, CreateExamDto>().ReverseMap();
            //CreateMap<Exam, UpdateExamDto>().ReverseMap();

            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<CreateQuestionDto, Question>().ReverseMap();

            CreateMap<Question, UpdateQuestionDto>().ReverseMap();
            CreateMap<Question, GetQuestionVM>().ReverseMap();
            CreateMap<GetQuestionVM, Question>().ReverseMap();
        }
    }
}