using OpenQA.Selenium;

namespace Royale.Pages
{

    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav(IWebDriver driver)
        {
            Map = new HeaderNavMap(driver);
        }

        public void GotoCardsPage()
        {
            Map.CardsLink.Click();
        }
    }

    public class HeaderNavMap
    {
        private readonly IWebDriver _driver;

        public HeaderNavMap(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement CardsLink => _driver.FindElement(By.CssSelector("a[href='/cards']"));
    }
}