using System.Linq;
using Framework.Models;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardDetailsPage
    {
        public readonly CardDetailsPageMap Map;

        public CardDetailsPage(IWebDriver driver)
        {
            Map = new CardDetailsPageMap(driver);
        }

        public Card GetBaseCard()
        {
            var (category, arena) = GetCardCategory();

            return new Card
            {
                Name = Map.CardName.Text,
                Rarity = Map.CardRarity.Text.Split('\n').Last(),
                Type = category,
                Arena = arena
            };
        }

        public (string Type, string Arena) GetCardCategory()
        {
            var categories = Map.CardCategory.Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }
    }

    public class CardDetailsPageMap
    {
        private readonly IWebDriver _driver;

        public CardDetailsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CardName => _driver.FindElement(By.CssSelector("[class*='cardName']"));

        public IWebElement CardRarity => _driver.FindElement(By.CssSelector("[class*='rarityCaption']"));

        public IWebElement CardCategory => _driver.FindElement(By.CssSelector(".card__rarity"));


    }
}