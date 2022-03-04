using CreateExam.Presentation.Models;

namespace CreateExam.Presentation.Services
{
    public interface IWebRequestContentSiteService
    {
        ArticleListModel LoadSite();
    }
}