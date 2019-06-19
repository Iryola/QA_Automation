using OpenQA.Selenium;

namespace Royale.Pages
{
    public class PageBase
    {
        public readonly HeaderNav HeaderNav;

        public PageBase(IWebDriver driver)
        {
            HeaderNav = new HeaderNav(driver);
        }
    }
}