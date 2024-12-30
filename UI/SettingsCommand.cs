using MaterialSkin;

namespace CoordinateTrackerAndClicker.UI
{
    internal class SettingsCommand
    {
        public void ChangeThemes(MaterialSkinManager manager, bool isDarkThemes)
            => manager.Theme = isDarkThemes ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
    }
}
