using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.UI
{
    internal class ButtonCommand //: ICommand
    {
        public Button[] _buttonsToDisable;
        private readonly Button[] _buttonsToEnable;

        public ButtonCommand(Button[] buttonsToDisable, Button[] buttonsToEnable)
        {
            _buttonsToDisable = buttonsToDisable;
            _buttonsToEnable = buttonsToEnable;
        }

        public void Execute()
        {             
            foreach (var button in _buttonsToDisable)
            {
                button.Enabled = false;
            }

            foreach (var button in _buttonsToEnable)
            {
                button.Enabled = true;
            }
        }
    }
}
