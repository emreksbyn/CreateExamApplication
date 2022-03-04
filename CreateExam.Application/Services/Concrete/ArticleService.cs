using AutoMapper;
using CreateExam.Application.Models.Dtos;
using CreateExam.Application.Models.VMs;
using CreateExam.Application.Services.Interface;
using CreateExam.Core.Entities.Concrete;
using CreateExam.Core.Enums;
using CreateExam.Core.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CreateExam.Application.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task Create(CreateArticleDto model)
        {
            var article = _mapper.Map<Article>(model);
            await _unitOfWork.ArticleRepository.Add(article);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            var article = await _unitOfWork.ArticleRepository.Get(x => x.ArticleId == id);
            article.Status = Status.Passive;
            article.DeleteDate = DateTime.Now;
            await _unitOfWork.Commit();
        }

        //public Task<List<string>> GetAllByTitle()
        //{
        //    var titles = _unitOfWork.ArticleRepository.GetList().Select(x=>x.ti).
        //}

        //public Task<Article> GetArticleAndQuestions(int articleId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Article> GetArticleById(int id)
        {
            var article = await _unitOfWork.ArticleRepository.Get(x => x.ArticleId == id);
            return article;
        }

        //public async Task<List<Article>> GetArticles()
        //{
        //    var articles = await _unitOfWork.ArticleRepository.GetList(x => x.Status != Status.Passive);
        //    return articles;
        //}

        public async Task<string> GetByContent(int id)
        {
            var article = await _unitOfWork.ArticleRepository.Get(x => x.ArticleId == id);
            return article.Content;
        }

        //public async Task Update(Article article)
        //{
        //    _unitOfWork.ArticleRepository.Update(article);
        //    await _unitOfWork.Commit();
        //}

        public async Task<List<GetArticleVM>> GetArticles()
        {
            var articles = await _unitOfWork.ArticleRepository.GetList(x => x.Status != Status.Passive);
            var articleVM = _mapper.Map<List<GetArticleVM>>(articles);
            return articleVM;
        }
    }
}