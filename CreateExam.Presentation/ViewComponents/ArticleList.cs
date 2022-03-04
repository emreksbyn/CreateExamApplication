using CreateExam.Application.Models.Dtos;
using CreateExam.Application.Services.Interface;
using CreateExam.Presentation.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreateExam.Presentation.ViewComponents
{
    public class ArticleList : ViewComponent
    {
        private readonly IWebRequestContentSiteService _webRequestContentSiteService;
        private readonly IArticleService _articleService;

        public ArticleList(IWebRequestContentSiteService webRequestContentSiteService, IArticleService articleService)
        {
            this._webRequestContentSiteService = webRequestContentSiteService;
            this._articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _webRequestContentSiteService.LoadSite();
            for (int i = 0; i < 5; i++)
            {
                CreateArticleDto createArticleDto = new()
                {
                    Content = model.Contents[i],
                    Title = model.Titles[i]
                };
                _articleService.Create(createArticleDto);
            }
            ViewBag.Content = _articleService.GetByContent(1);
            return View(model);
        }
    }
}