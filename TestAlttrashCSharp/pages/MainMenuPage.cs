using Altom.AltDriver;
using System.Collections.Generic;

namespace alttrashcat_tests_csharp.pages
{
    public class MainMenuPage : BasePage
    {
        public MainMenuPage(AltDriver driver) : base(driver)
        {
        }
        public void LoadScene()
        {
            Driver.LoadScene("Main");
        }

        public AltObject StoreButton { get => Driver.WaitForObject(By.NAME, "StoreButton", timeout: 10); }
        public AltObject LeaderBoardButton { get => Driver.WaitForObject(By.NAME, "OpenLeaderboard", timeout: 10); }
        public AltObject SettingsButton { get => Driver.WaitForObject(By.NAME, "SettingButton", timeout: 10); }
        public AltObject MissionButton { get => Driver.WaitForObject(By.NAME, "MissionButton", timeout: 10); }
        public AltObject RunButton { get => Driver.WaitForObject(By.NAME, "StartButton", timeout: 10); }
        public AltObject CharacterName { get => Driver.WaitForObject(By.NAME, "CharName", timeout: 10); }
        public AltObject ThemeName { get => Driver.WaitForObject(By.NAME, "ThemeZone", timeout: 10); }
        public AltObject LeaderBoardText { get => Driver.WaitForObject(By.PATH, "/UICamera/Leaderboard/Background/Text", timeout: 10); }
        public AltObject CloseLeaderBoardButton { get => Driver.WaitForObject(By.PATH, "/UICamera/Leaderboard/Background/Button", timeout: 10); }
        public AltObject MissionsText { get => Driver.WaitForObject(By.PATH, "/UICamera/Loadout/MissionPopup/MissionBackground/Text", timeout: 10); }
        public List<AltObject> MissionsList { get => Driver.FindObjects(By.PATH,
            "/UICamera/Loadout/MissionPopup/MissionBackground/MissionsContainer/Scroll View/Viewport/Content/MissionEntry(Clone)"); }
        public AltObject CloseMissionsButton { get => Driver.WaitForObject(By.PATH, "/UICamera/Loadout/MissionPopup/MissionBackground/CloseButton", timeout: 10); }
        public bool IsDisplayed()
        {
            if (StoreButton != null && LeaderBoardButton != null && SettingsButton != null && MissionButton != null && RunButton != null && CharacterName != null && ThemeName != null)
                return true;
            return false;
        }
        public void PressRun()
        {
            RunButton.Tap();
        }
        public void PressLeaderboard()
        {
            LeaderBoardButton.Tap();
        }
        public string GetLeaderboardText()
        {
            return LeaderBoardText.GetText();
        }
        public void PressCloseLeaderboard()
        {
            CloseLeaderBoardButton.Tap();
        }
        public void PressMissions()
        {
            MissionButton.Tap();
        }
        public string GetMissionsText()
        {
            return MissionsText.GetText();
        }
        public void PressCloseMissions()
        {
            CloseMissionsButton.Tap();
        }

    }
}