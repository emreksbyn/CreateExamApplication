using Autofac;
using AutoMapper;
using CreateExam.Application.AutoMapper;
using CreateExam.Application.Models.Dtos;
using CreateExam.Application.Services.Concrete;
using CreateExam.Application.Services.Interface;
using CreateExam.Application.ValidationRules.FluentValidation;
using CreateExam.Core.UnitOfWork.Interfaces;
using CreateExam.Infrastructure.UnitOfWork;
using FluentValidation;

namespace CreateExam.Application.DependencyResolvers.Autofac
{
    public  class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ArticleService>().As<IArticleService>().InstancePerLifetimeScope();
            //builder.RegisterType<ExamService>().As<IExamService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();

            builder.RegisterType<LoginValidation>().As<IValidator<LoginDto>>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterValidation>().As<IValidator<RegisterDto>>().InstancePerLifetimeScope();

            builder.Register(content => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}