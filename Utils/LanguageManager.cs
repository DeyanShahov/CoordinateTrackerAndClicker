using System.Globalization;
using System.Resources;
using System.Threading;

namespace CoordinateTrackerAndClicker.Utils
{
    public static class LanguageManager
    {
        private static readonly ResourceManager resourceManger = new ResourceManager("CoordinateTrackerAndClicker.Resources.Strings", typeof(LanguageManager).Assembly);

        public static void SetLanguage(string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureCode);
        }

        public static string GetString(string key)
        {
            return resourceManger.GetString(key);
        }
    }
}
