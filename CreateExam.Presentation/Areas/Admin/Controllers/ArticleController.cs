using CreateExam.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CreateExam.Presentation.Areas.Admin.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            this._articleService = articleService;
        }
        public async Task<IActionResult> List()
        {
            var articles = await _articleService.GetArticles();
            return View(articles);
        }

        public IActionResult Delete(int articleId)
        {
            _articleService.Delete(articleId);
            return RedirectToAction("List", "Article");
        }
    }
}