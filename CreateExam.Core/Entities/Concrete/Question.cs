using CreateExam.Core.Entities.Interfaces;
using CreateExam.Core.Enums;
using System;

namespace CreateExam.Core.Entities.Concrete
{
    public class Question : IBaseEntity
    {
        public int QuesitonId { get; set; }
        public string Description { get; set; }
        public string AOption { get; set; }
        public string BOption { get; set; }
        public string COption { get; set; }
        public string DOption { get; set; }

        //public string Answer { get; set; }
        public string CorrectAnswer { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        //public int ExamId { get; set; }
        //public Exam Exam { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}