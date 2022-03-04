using CreateExam.Core.Entities.Concrete;
using CreateExam.Core.Repositories.Interface.EntityType;
using CreateExam.Infrastructure.Context;
using CreateExam.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CreateExam.Infrastructure.Repositories.Concrete.EntityTypeRepositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly AppDbContext _appDbContext;

        public ArticleRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public Article GetArticleAndQuestions(int articleId)
        {
            var result = _appDbContext.Articles
                            .Include(x => x.Questions)
                            .Where(x => x.ArticleId == articleId)
                            .FirstOrDefault();
            return result;
        }
    }
}