using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker
{
    public partial class FormAlert : Form
    {
        private enmActions actions;
        private int x, y;

        public FormAlert()
        {
            InitializeComponent();
        }

        public enum enmActions
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info,
            Empty
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            actions = enmActions.close;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.actions)
            {
                case enmActions.wait:
                    timer1.Interval = 5000;
                    actions = enmActions.close;
                    break;
                case enmActions.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X) this.Left--;
                    else
                    {
                        if (this.Opacity == 1.0) actions = enmActions.wait;
                    }
                    break;
                case enmActions.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        timer1.Stop();
                        timer1.Dispose();
                        base.Close();
                        base.Dispose();
                    }
                    break;
            }
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                FormAlert frm = (FormAlert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.pictureBox1.Image = Properties.Resources.icons8_done_52;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Warning:
                    this.pictureBox1.Image = Properties.Resources.icons8_info_64;
                    this.BackColor = Color.DarkOrange;
                    break;
                case enmType.Error:
                    this.pictureBox1.Image = Properties.Resources.icons8_error_64;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.pictureBox1.Image = Properties.Resources.icons8_info_64;
                    this.BackColor = Color.RoyalBlue;
                    break;
                default:
                    this.pictureBox1.Image = Properties.Resources.icons8_info_64;
                    this.BackColor = Color.RoyalBlue;
                    break;
            }

            this.lblMsg.Text = msg;
            this.Show();
            this.actions = enmActions.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }
    }
}
