using CoordinateTrackerAndClicker.UI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class ButtonHandler
    {
        private readonly Dictionary<object, ButtonCommand> commands = new Dictionary<object, ButtonCommand>();

        public void AddNewButton(object sender, Button[] buttonsToDisable, Button[] buttonsToEnable)
        {
            CheckForNull(sender);

            if (commands.ContainsKey(sender)) throw new CustomException(LanguageManager.GetString(SAM.ADD_NEW_BUTTON_ERROR));

            commands[sender] = new ButtonCommand(buttonsToDisable, buttonsToEnable);
        }

        public void ClickButtonMechanicsExecute(object sender)
        {
            CheckForNull(sender);

            if (!commands.ContainsKey(sender)) throw new CustomException(LanguageManager.GetString(SAM.CLICK_BUTTON_MECHANICS_EXECUTE_ERROR));

            commands[sender].Execute();
        }

        private static void CheckForNull(object sender)
        {
            if (sender is null) throw new CustomException(LanguageManager.GetString(SAM.CHECK_FOR_NULL));
        }     
    }
}



