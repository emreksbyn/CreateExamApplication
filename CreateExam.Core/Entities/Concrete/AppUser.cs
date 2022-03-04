using CreateExam.Core.Entities.Interfaces;
using CreateExam.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace CreateExam.Core.Entities.Concrete
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        //public int ExamId { get; set; }
        //public Exam Exam { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}