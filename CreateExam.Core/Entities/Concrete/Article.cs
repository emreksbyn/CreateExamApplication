using CreateExam.Core.Entities.Interfaces;
using CreateExam.Core.Enums;
using System;
using System.Collections.Generic;

namespace CreateExam.Core.Entities.Concrete
{
    public class Article : IBaseEntity
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}