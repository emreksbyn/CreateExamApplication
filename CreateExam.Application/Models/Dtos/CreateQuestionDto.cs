using CreateExam.Core.Enums;
using System;

namespace CreateExam.Application.Models.Dtos
{
    public class CreateQuestionDto
    {
        public string Description { get; set; }
        public string AOption { get; set; }
        public string BOption { get; set; }
        public string COption { get; set; }
        public string DOption { get; set; }
        public string CorrectAnswer { get; set; }

        //public string Answer { get; set; }

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //public Article Article { get; set; }


        //public int ExamId { get; set; }
        //public List<Exam> Exam { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}