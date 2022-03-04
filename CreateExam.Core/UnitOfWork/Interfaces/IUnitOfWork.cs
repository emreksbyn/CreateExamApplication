using CreateExam.Core.Repositories.Interface.EntityType;
using System;
using System.Threading.Tasks;

namespace CreateExam.Core.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAppUserRepository AppUserRepository { get; }
        IArticleRepository ArticleRepository { get; }
        //IExamRepository ExamRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        Task Commit();
    }
}