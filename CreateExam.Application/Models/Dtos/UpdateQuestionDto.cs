using CreateExam.Core.Entities.Concrete;
using CreateExam.Core.Enums;
using System;

namespace CreateExam.Application.Models.Dtos
{
    public class UpdateQuestionDto
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public string AOption { get; set; }
        public string BOption { get; set; }
        public string COption { get; set; }
        public string DOption { get; set; }
        public string Answer { get; set; }
        public string CorrectAnswer { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        //public int ExamId { get; set; }
        //public Exam Exam { get; set; }

        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}