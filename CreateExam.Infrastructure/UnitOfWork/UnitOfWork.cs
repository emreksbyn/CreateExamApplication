using CreateExam.Core.Repositories.Interface.EntityType;
using CreateExam.Core.UnitOfWork.Interfaces;
using CreateExam.Infrastructure.Context;
using CreateExam.Infrastructure.Repositories.Concrete.EntityTypeRepositories;
using System;
using System.Threading.Tasks;

namespace CreateExam.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this._db = appDbContext;
        }

        private IAppUserRepository _appUserRepository;
        public IAppUserRepository AppUserRepository
        {
            get
            {
                if (_appUserRepository == null)
                {
                    _appUserRepository = new AppUserRepository(_db);
                }
                return _appUserRepository;
            }
        }

        private IArticleRepository _articleRepository;
        public IArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(_db);
                }
                return _articleRepository;
            }
        }

        //private IExamRepository _examRepository;
        //public IExamRepository ExamRepository
        //{
        //    get
        //    {
        //        if (_examRepository == null)
        //        {
        //            _examRepository = new ExamRepository(_db);
        //        }
        //        return _examRepository;
        //    }
        //}

        private IQuestionRepository _questionRepositor;
        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepositor == null)
                {
                    _questionRepositor = new QuestionRepository(_db);
                }
                return _questionRepositor;
            }
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }

        private bool isDisposed = false;

        public async ValueTask DisposeAsync()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);
            }
        }

        protected async Task DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _db.DisposeAsync();
            }
        }
    }
}