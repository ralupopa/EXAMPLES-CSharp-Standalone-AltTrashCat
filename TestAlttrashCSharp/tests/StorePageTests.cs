using System;
using System.Threading;
using Altom.AltDriver;
using alttrashcat_tests_csharp.pages;
using NUnit.Framework;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace alttrashcat_tests_csharp.tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Store")]
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
            storePage.PressStoreToIncreaseCoins();
        }

        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public void TestAccessStoreAndIncreaseCoins()
        {
            storePage.IsDisplayed();
            storePage.PressStoreToIncreaseCoins();
            var coinsText = storePage.GetCoinsCounterText();
            Assert.True(Int32.Parse(coinsText) != 0);
        }

        [Test(Author = "Ralu", Description = "Can Buy Night theme")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TestBuyNightTime()
        {
            storePage.PressThemes();
            Assert.NotNull(storePage.OwnedButtonText);
            Assert.NotNull(storePage.BuyButtonText);
            storePage.PressBuyNightTime();
            storePage.PressCloseStore();
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
