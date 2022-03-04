using CreateExam.Application.Models.VMs;
using CreateExam.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateExam.Presentation.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IQuestionService _questionService;

        public AppUserController(IArticleService articleService, IQuestionService questionService)
        {
            this._articleService = articleService;
            this._questionService = questionService;
        }
        public  async Task<IActionResult> Exam(int articleId)
        {
            var exam = await _questionService.GetQuestionsByArticleId(articleId);
            return View(exam);
        }

        [HttpPost]
        public  IActionResult ExamResult(List<GetQuestionVM> list)
        {
           return   RedirectToAction("Exam", "AppUser");
        }
    }
}