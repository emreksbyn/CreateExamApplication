using CreateExam.Core.Entities.Concrete;
using CreateExam.Core.Repositories.Interface.EntityType;
using CreateExam.Infrastructure.Context;
using CreateExam.Infrastructure.Repositories.Abstract;

namespace CreateExam.Infrastructure.Repositories.Concrete.EntityTypeRepositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}