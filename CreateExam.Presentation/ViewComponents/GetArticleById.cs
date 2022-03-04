using CreateExam.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CreateExam.Presentation.ViewComponents
{
    public class GetArticleById : ViewComponent
    {
        private readonly IArticleService _articleService;

        public GetArticleById(IArticleService articleService)
        {
            this._articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var article = _articleService.GetArticleById(1);
            return View(article);
        }
    }
}