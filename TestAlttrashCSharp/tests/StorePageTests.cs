using System;
using System.Threading;
using Altom.AltDriver;
using alttrashcat_tests_csharp.pages;
using NUnit.Framework;

namespace alttrashcat_tests_csharp.tests
{
    public class StorePageTests
    {
        AltDriver altDriver;
        MainMenuPage mainMenuPage;
        StorePage storePage;

        [SetUp]
        public void Setup()
        {
            altDriver = new AltDriver();
            mainMenuPage = new MainMenuPage(altDriver);
            storePage = new StorePage(altDriver);
            storePage.LoadScene();
            mainMenuPage.PressStore();
        }

        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        public void TestAccessStoreAndIncreaseCoins()
        {
            storePage.IsDisplayed();
            storePage.PressStoreToIncreaseCoins();
            var coinsText = storePage.GetCoinsCounterText();
            Assert.True(Int32.Parse(coinsText) != 0); 
        }
        [Test]
        public void TestBuyNightTime()
        {
            storePage.PressThemes();
            Assert.NotNull(storePage.OwnedButtonText);
            Assert.NotNull(storePage.BuyButtonText);
            storePage.PressBuyNightTime();
            mainMenuPage.PressCloseStore();
            Assert.True(mainMenuPage.IsDisplayed());
            mainMenuPage.ThemeButtonsAreDisplayed();
            Assert.NotNull(mainMenuPage.ThemeName);
            Assert.AreEqual(mainMenuPage.GetThemeNameText(), "Day");
            mainMenuPage.PressNightTimeTheme();
            StringAssert.Contains("Night", mainMenuPage.GetThemeNameText());

            mainMenuPage.DeleteData();
        }
    }
}
