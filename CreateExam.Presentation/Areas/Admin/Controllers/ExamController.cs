using CreateExam.Application.Models.Dtos;
using CreateExam.Application.Services.Interface;
using CreateExam.Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateExam.Presentation.Areas.Admin.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class ExamController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IWebRequestContentSiteService _webRequestContentSiteService;

        public ExamController(IQuestionService questionService, IWebRequestContentSiteService webRequestContentSiteService)
        {
            this._questionService = questionService;
            this._webRequestContentSiteService = webRequestContentSiteService;
        }

        public IActionResult Create() => View();


        [HttpPost]
        public  IActionResult Create(List<CreateQuestionDto> model)
        {
             _questionService.CreateMultiple(model);
            return RedirectToAction("Index", "Home");
        }
        public  async Task<IActionResult> List()
        {
            var exam = await  _questionService.GetQuestions();
            return View(exam);
        }


        public async Task<IActionResult> Update(int id) => View(await _questionService.GetQuestionById(id));

        [HttpPost]
        public async Task<IActionResult> Update(UpdateQuestionDto model)
        {
            if (ModelState.IsValid)
            {
                await _questionService.Update(model);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _questionService.Delete(id);
            return RedirectToAction("List");
        }
    }
}