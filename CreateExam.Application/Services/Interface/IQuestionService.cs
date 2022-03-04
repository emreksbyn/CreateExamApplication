using CreateExam.Application.Models.Dtos;
using CreateExam.Application.Models.VMs;
using CreateExam.Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateExam.Application.Services.Interface
{
    public interface IQuestionService
    {
        Task<List<Question>> GetQuestions();
        Task<Question> GetQuestionById(int id);
        Task<List<GetQuestionVM>> GetQuestionsByArticleId(int articleId);
        Task CreateMultiple(List<CreateQuestionDto> createQuestionDtos);
        Task Create(CreateQuestionDto model);
        Task Update(UpdateQuestionDto model);
        Task Delete(int id);
    }
}