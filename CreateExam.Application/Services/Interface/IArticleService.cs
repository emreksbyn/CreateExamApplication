using CreateExam.Application.Models.Dtos;
using CreateExam.Application.Models.VMs;
using CreateExam.Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateExam.Application.Services.Interface
{
    public interface IArticleService
    {
        Task<List<GetArticleVM>> GetArticles();

        //Task<List<string>> GetAllByTitle();
        Task<Article> GetArticleById(int id);

        //Task<Article> GetArticleAndQuestions(int articleId);
        Task<string> GetByContent(int id);
        Task Create(CreateArticleDto model);

        //Task Update(Article article);
        Task Delete(int id);
    }
}