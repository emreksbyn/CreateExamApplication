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

namespace CreateExam.Application.Services.Concrete
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task Create(CreateQuestionDto model)
        {
            var question = _mapper.Map<Question>(model);
            await _unitOfWork.QuestionRepository.Add(question);
            await _unitOfWork.Commit();
        }

        public async Task CreateMultiple(List<CreateQuestionDto> createQuestionDtos)
        {
            var questions = await _mapper.Map<Task<List<Question>>>(createQuestionDtos);
            foreach (var question in questions)
            {
               await _unitOfWork.QuestionRepository.Add(question);
            }
        }

        public async Task Delete(int id)
        {
            var question = await _unitOfWork.QuestionRepository.Get(x => x.QuesitonId == id);
            question.Status = Status.Passive;
            question.DeleteDate = DateTime.Now;
            await _unitOfWork.Commit();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            var question = await _unitOfWork.QuestionRepository.Get(x => x.QuesitonId == id);
            return question;
        }

        public async Task<List<Question>> GetQuestions()
        {
            var questions = await _unitOfWork.QuestionRepository.GetList(x => x.Status != Status.Passive);
            return questions;
        }

        public async Task<List<GetQuestionVM>> GetQuestionsByArticleId(int articleId)
        {
            var questions = await _unitOfWork.QuestionRepository.GetList(x => x.ArticleId == articleId);
            var questionsVM = await _mapper.Map<Task<List<GetQuestionVM>>>(questions);
            return questionsVM;
        }

        public async Task Update(UpdateQuestionDto model)
        {
            var question = _mapper.Map<Question>(model);
            _unitOfWork.QuestionRepository.Update(question);
            await _unitOfWork.Commit();
        }
    }
}