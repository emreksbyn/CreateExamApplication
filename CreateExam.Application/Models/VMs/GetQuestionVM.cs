using CreateExam.Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace CreateExam.Application.Models.VMs
{
    public class GetQuestionVM
    {
        public int QuesitonId { get; set; }
        public string Description { get; set; }
        public string AOption { get; set; }
        public string BOption { get; set; }
        public string COption { get; set; }
        public string DOption { get; set; }
        public string CorrectAnswer { get; set; }
    }
}