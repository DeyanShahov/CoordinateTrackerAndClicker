using CoordinateTrackerAndClicker.UI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class ButtonHandler
    {
        private readonly Dictionary<Button, ButtonCommand> commands = new Dictionary<Button, ButtonCommand>();

        public ButtonHandler()
        {
            
        }

        public void AddNewButton(Button senderButton, Button[] buttonsToDisable, Button[] buttonsToEnable)
        {
            commands[senderButton] = new ButtonCommand(buttonsToDisable, buttonsToEnable);
        }

        public void ClickButtonMechanicsExecute(object sender)
        {
            if (sender is Button clickedButton && commands.ContainsKey(clickedButton)) commands[clickedButton].Execute();
        }
    }
}
