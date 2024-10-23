using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker
{
    public partial class Form1
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mouseTrackTimer != null)
                {
                    mouseTrackTimer.Stop();
                    mouseTrackTimer.Dispose();
                }
                if (autoClickTimer != null)
                {
                    autoClickTimer.Stop();
                    autoClickTimer.Dispose();
                }
                if (hookHandle != IntPtr.Zero)
                {
                    UnhookWindowsHookEx(hookHandle);
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.CoordinatesLabel = new System.Windows.Forms.Label();
            this.CurrentPositionLabel = new System.Windows.Forms.Label();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.FrequencyInput = new System.Windows.Forms.NumericUpDown();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.DurationInput = new System.Windows.Forms.NumericUpDown();
            this.StartClickingButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMacro = new System.Windows.Forms.RadioButton();
            this.radioButtonDoubleClick = new System.Windows.Forms.RadioButton();
            this.radioButtonSingleClick = new System.Windows.Forms.RadioButton();
            this.labelTest = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(10, 10);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 30);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Старт запис";
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(120, 10);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(100, 30);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Стоп запис";
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(230, 10);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(100, 30);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Ресет";
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // CoordinatesLabel
            // 
            this.CoordinatesLabel.Location = new System.Drawing.Point(10, 50);
            this.CoordinatesLabel.Name = "CoordinatesLabel";
            this.CoordinatesLabel.Size = new System.Drawing.Size(320, 70);
            this.CoordinatesLabel.TabIndex = 3;
            this.CoordinatesLabel.Text = "Запазени координати:\nПърви: Няма\nВтори: Няма";
            // 
            // CurrentPositionLabel
            // 
            this.CurrentPositionLabel.Location = new System.Drawing.Point(10, 120);
            this.CurrentPositionLabel.Name = "CurrentPositionLabel";
            this.CurrentPositionLabel.Size = new System.Drawing.Size(380, 20);
            this.CurrentPositionLabel.TabIndex = 4;
            this.CurrentPositionLabel.Text = "Текуща позиция: ";
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.Location = new System.Drawing.Point(10, 150);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(120, 20);
            this.FrequencyLabel.TabIndex = 5;
            this.FrequencyLabel.Text = "Честота (секунди):";
            // 
            // FrequencyInput
            // 
            this.FrequencyInput.Location = new System.Drawing.Point(151, 150);
            this.FrequencyInput.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.FrequencyInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FrequencyInput.Name = "FrequencyInput";
            this.FrequencyInput.Size = new System.Drawing.Size(60, 20);
            this.FrequencyInput.TabIndex = 6;
            this.FrequencyInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // DurationLabel
            // 
            this.DurationLabel.Location = new System.Drawing.Point(10, 180);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(137, 20);
            this.DurationLabel.TabIndex = 7;
            this.DurationLabel.Text = "Продължителност (мин):";
            // 
            // DurationInput
            // 
            this.DurationInput.Location = new System.Drawing.Point(151, 180);
            this.DurationInput.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.DurationInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DurationInput.Name = "DurationInput";
            this.DurationInput.Size = new System.Drawing.Size(60, 20);
            this.DurationInput.TabIndex = 8;
            this.DurationInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // StartClickingButton
            // 
            this.StartClickingButton.Location = new System.Drawing.Point(10, 250);
            this.StartClickingButton.Name = "StartClickingButton";
            this.StartClickingButton.Size = new System.Drawing.Size(150, 30);
            this.StartClickingButton.TabIndex = 9;
            this.StartClickingButton.Text = "Започни автоматично кликане";
            this.StartClickingButton.Click += new System.EventHandler(this.StartClickingButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(7, 283);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(380, 20);
            this.StatusLabel.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonMacro);
            this.groupBox1.Controls.Add(this.radioButtonDoubleClick);
            this.groupBox1.Controls.Add(this.radioButtonSingleClick);
            this.groupBox1.Location = new System.Drawing.Point(336, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 139);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioButtonMacro
            // 
            this.radioButtonMacro.AutoSize = true;
            this.radioButtonMacro.Location = new System.Drawing.Point(16, 78);
            this.radioButtonMacro.Name = "radioButtonMacro";
            this.radioButtonMacro.Size = new System.Drawing.Size(58, 17);
            this.radioButtonMacro.TabIndex = 2;
            this.radioButtonMacro.Text = "Макро";
            this.radioButtonMacro.UseVisualStyleBackColor = true;
            this.radioButtonMacro.CheckedChanged += new System.EventHandler(this.radioButtonMacro_CheckedChanged);
            // 
            // radioButtonDoubleClick
            // 
            this.radioButtonDoubleClick.AutoSize = true;
            this.radioButtonDoubleClick.Location = new System.Drawing.Point(16, 53);
            this.radioButtonDoubleClick.Name = "radioButtonDoubleClick";
            this.radioButtonDoubleClick.Size = new System.Drawing.Size(85, 17);
            this.radioButtonDoubleClick.TabIndex = 1;
            this.radioButtonDoubleClick.Text = "Двоен клик";
            this.radioButtonDoubleClick.UseVisualStyleBackColor = true;
            this.radioButtonDoubleClick.CheckedChanged += new System.EventHandler(this.radioButtonDoubleClick_CheckedChanged);
            // 
            // radioButtonSingleClick
            // 
            this.radioButtonSingleClick.AutoSize = true;
            this.radioButtonSingleClick.Checked = true;
            this.radioButtonSingleClick.Location = new System.Drawing.Point(16, 30);
            this.radioButtonSingleClick.Name = "radioButtonSingleClick";
            this.radioButtonSingleClick.Size = new System.Drawing.Size(100, 17);
            this.radioButtonSingleClick.TabIndex = 0;
            this.radioButtonSingleClick.TabStop = true;
            this.radioButtonSingleClick.Text = "Единичен клик";
            this.radioButtonSingleClick.UseVisualStyleBackColor = true;
            this.radioButtonSingleClick.CheckedChanged += new System.EventHandler(this.radioButtonSingleClick_CheckedChanged);
            // 
            // labelTest
            // 
            this.labelTest.Location = new System.Drawing.Point(338, 167);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(142, 50);
            this.labelTest.TabIndex = 12;
            this.labelTest.Text = "dfdfsdfsdf\\nfgdgdfgdfgdfgfdf";
            // 
            // CountLabel
            // 
            this.CountLabel.Location = new System.Drawing.Point(8, 210);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(120, 20);
            this.CountLabel.TabIndex = 13;
            this.CountLabel.Text = "Пъти на изпълнение:";
            // 
            // CountInput
            // 
            this.CountInput.Location = new System.Drawing.Point(151, 210);
            this.CountInput.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.CountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CountInput.Name = "CountInput";
            this.CountInput.Size = new System.Drawing.Size(60, 20);
            this.CountInput.TabIndex = 14;
            this.CountInput.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(492, 331);
            this.Controls.Add(this.CountInput);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.CoordinatesLabel);
            this.Controls.Add(this.CurrentPositionLabel);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.FrequencyInput);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.DurationInput);
            this.Controls.Add(this.StartClickingButton);
            this.Controls.Add(this.StatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Координатен тракер и кликер";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationInput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).EndInit();
            this.ResumeLayout(false);

        }

        private Button StartButton;
        private Button StopButton;
        private Button ResetButton;
        private Label CoordinatesLabel;
        private Label CurrentPositionLabel;
        private Label FrequencyLabel;
        private NumericUpDown FrequencyInput;
        private Label DurationLabel;
        private NumericUpDown DurationInput;
        private Button StartClickingButton;
        private Label StatusLabel;
        private GroupBox groupBox1;
        private RadioButton radioButtonMacro;
        private RadioButton radioButtonDoubleClick;
        private RadioButton radioButtonSingleClick;
        private Label labelTest;
        private Label CountLabel;
        private NumericUpDown CountInput;
    }
}