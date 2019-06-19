using System;
using System.IO;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;
// dotnet test --filter ice_spirit_is_on_cards_page
namespace Tests
{
    public class CardTests
    {
        string ROOT_PATH = Path.GetFullPath(@"../../../../");
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void BeforeEach()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(ROOT_PATH + "/_drivers", options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = "https://statsroyale.com";
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

        [Test]
        public void Ice_spirit_is_on_Cards_Page()
        {
            var cardsPage = new CardsPage(driver).Goto().GetCardByName("Ice Spirit");
            Assert.That(cardsPage.Displayed);
        }

        // [Test]
        // public void Ice_spirit_is_on_Cards_Page()
        // {
        //     driver.Url = "https://statsroyale.com/";
        //     driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
        //     Assert.That(driver.PageSource.Contains("Ice Spirit"));
        //     var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));

        // }

        static string[] cardNames = { "Ice Spirit", "Mirror" };

        [Test, Parallelizable(ParallelScope.Children)]
        [TestCaseSource("cardNames")]
        [Category("cards")]
        public void card_details_displayed(string cardName)
        {
            var card = new InMemoryCardService().GetCardByName(cardName);
            new CardsPage(driver).Goto().GetCardByName(cardName).Click();

            var cardOnPage = new CardDetailsPage(driver).GetBaseCard();


            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
        }
    }
}