﻿using System;

namespace CreateExam.Application.Models.VMs
{
    public class GetArticleVM
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
    }
}