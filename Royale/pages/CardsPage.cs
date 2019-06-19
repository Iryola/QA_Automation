using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardsPage : PageBase
    {
        public readonly CardsPageMap Map;

        public CardsPage(IWebDriver driver) : base(driver)
        {
            Map = new CardsPageMap(driver);
        }

        public CardsPage Goto()
        {
            HeaderNav.GotoCardsPage();
            return this;
        }

        public IWebElement GetCardByName(string name)
        {
            var split = name.Split();
            var cardName = string.Join("+", split);
            return Map.Card(cardName);
        }
    }

    public class CardsPageMap
    {
        private readonly IWebDriver _driver;

        public CardsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Card(string name) => _driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}