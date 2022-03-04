using CreateExam.Core.Entities.Concrete;
using CreateExam.Core.Enums;
using System;
using System.Collections.Generic;

namespace CreateExam.Application.Models.Dtos
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}