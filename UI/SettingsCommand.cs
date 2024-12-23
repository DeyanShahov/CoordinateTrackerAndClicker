using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker.UI
{
    internal class SettingsCommand
    {
        public void ChangeThemes(MaterialSkinManager manager, bool isDarkThemes)
            => manager.Theme = isDarkThemes ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
    }
}
