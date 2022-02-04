using Altom.AltUnityDriver;

namespace alttrashcat_tests_csharp.pages
{
    public class StartPage : BasePage
    {
        public StartPage(AltUnityDriver driver) : base(driver)
        {
        }

        public void Load()
        {
            Driver.LoadScene("Start");
        }
        public AltUnityObject StartButton { get => Driver.WaitForObject(By.NAME, "StartButton", timeout: 5); }
        public AltUnityObject StartText { get => Driver.WaitForObject(By.NAME, "StartText", timeout: 5); }
        public AltUnityObject LogoImage { get => Driver.WaitForObject(By.NAME, "LogoImage", timeout: 5); }
        public AltUnityObject UnityUrlButton { get => Driver.WaitForObject(By.NAME, "UnityURLButton", timeout: 5); }
        public bool IsDisplayed()
        {
            if (StartButton != null && StartText != null && LogoImage != null && UnityUrlButton != null)
                return true;
            return false;
        }
        public void PressStart()
        {
            StartButton.Tap();
        }
        public string GetStartButtonText()
        {
            return StartButton.GetText();
        }
    }
}