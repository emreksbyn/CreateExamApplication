namespace CreateExam.Presentation.Helpers
{
    public static class XPathTagElements
    {
        public static string div = "//div/*[@class='secondary-grid-component']";
        public static string ul = "//ul/*[@class='post-listing-component__list']";
        public static string li = "//li/*[@class='post-listing-list-item__post']";
        public static string h5 = "//h5/*[@class='post-listing-list-item__title']";

        public static string a = "//a/*[@class='post-listing-list-item__link']";
        public static string paragraph = "//p/*";
        public static string paragraphClassAttr = "//p/*[@class='paywall']";
    }
}