using CreateExam.Application.Models.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CreateExam.Presentation.Models
{
    public class CorrectAnswerModel
    {
        public List<CreateQuestionDto> CreateQuestionDtos { get; set; }
        public List<SelectListItem> CorrectAnswers { set; get; }
    }
}