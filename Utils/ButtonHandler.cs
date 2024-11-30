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

            if (commands.ContainsKey(sender)) throw new CustomException("Ключа вече съществува в колекцията. Действието се пропуска.");

            commands[sender] = new ButtonCommand(buttonsToDisable, buttonsToEnable);
        }

        public void ClickButtonMechanicsExecute(object sender)
        {
            CheckForNull(sender);

            if (!commands.ContainsKey(sender)) throw new CustomException("Предоставения ключ не съществува в колекцията.");

            commands[sender].Execute();
        }

        private static void CheckForNull(object sender)
        {
            if (sender is null) throw new CustomException("Изпращача не може да е празен.");
        }     
    }
}



