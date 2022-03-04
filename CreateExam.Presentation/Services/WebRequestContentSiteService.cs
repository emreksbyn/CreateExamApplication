using CreateExam.Presentation.Helpers;
using CreateExam.Presentation.Models;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace CreateExam.Presentation.Services
{
    public class WebRequestContentSiteService : IWebRequestContentSiteService
    {
        private readonly string url = "https://www.wired.com/";
        List<string> titles = new();
        List<string> contents = new();

        public ArticleListModel LoadSite()
        {
            var web = new HtmlWeb();
            var document = web.Load(url);

            var mostRecent = $"{XPathTagElements.div}{XPathTagElements.ul}{XPathTagElements.li}";
            var title = $"{mostRecent}{XPathTagElements.h5}";
            var content = $"{XPathTagElements.paragraph}";

            for (int i = 0; i < 5; i++)
            {
                var titleItem = document.DocumentNode.SelectNodes(title);
                string link = document.DocumentNode.SelectNodes($"{mostRecent}{XPathTagElements.a}")[i].Attributes["href"].Value;
                link = url + link;
                document = web.Load(link);
                var contentItem = document.DocumentNode.SelectNodes(content);
                document = web.Load(url);

                titles.Add(titleItem[i].InnerText);
                contents.Add(contentItem[0].InnerText);
            }
            return new ArticleListModel()
            {
                Titles = titles,
                Contents = contents
            };
        }
    }
}