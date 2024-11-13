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
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.FrequencyInput = new System.Windows.Forms.NumericUpDown();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.DurationInput = new System.Windows.Forms.NumericUpDown();
            this.StartClickingButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.labelTest = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountInput = new System.Windows.Forms.NumericUpDown();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.btnSaveMacro = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.chkReturnToOriginal = new System.Windows.Forms.CheckBox();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.btnExecuteMacro = new System.Windows.Forms.Button();
            this.lstMacros = new System.Windows.Forms.ListBox();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.textBoxMacroName = new System.Windows.Forms.TextBox();
            this.numericDelayBefore = new System.Windows.Forms.NumericUpDown();
            this.textBoxActionName = new System.Windows.Forms.TextBox();
            this.textBoxDisplayInfo = new System.Windows.Forms.TextBox();
            this.CurrentPositionLabel = new System.Windows.Forms.Label();
            this.LastClickLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.countMacroRepeat = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countMacroRepeat)).BeginInit();
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
            // FrequencyLabel
            // 
            this.FrequencyLabel.Location = new System.Drawing.Point(12, 224);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(120, 20);
            this.FrequencyLabel.TabIndex = 5;
            this.FrequencyLabel.Text = "Честота (секунди):";
            // 
            // FrequencyInput
            // 
            this.FrequencyInput.Location = new System.Drawing.Point(153, 224);
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
            1,
            0,
            0,
            0});
            // 
            // DurationLabel
            // 
            this.DurationLabel.Location = new System.Drawing.Point(12, 254);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(137, 20);
            this.DurationLabel.TabIndex = 7;
            this.DurationLabel.Text = "Продължителност (мин):";
            // 
            // DurationInput
            // 
            this.DurationInput.Location = new System.Drawing.Point(153, 254);
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
            this.StartClickingButton.Location = new System.Drawing.Point(756, 498);
            this.StartClickingButton.Name = "StartClickingButton";
            this.StartClickingButton.Size = new System.Drawing.Size(150, 30);
            this.StartClickingButton.TabIndex = 9;
            this.StartClickingButton.Text = "Започни автоматично кликане";
            this.StartClickingButton.Click += new System.EventHandler(this.StartClickingButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(753, 531);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(380, 20);
            this.StatusLabel.TabIndex = 10;
            // 
            // labelTest
            // 
            this.labelTest.Location = new System.Drawing.Point(204, 434);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(333, 171);
            this.labelTest.TabIndex = 12;
            this.labelTest.Text = "dfdfsdfsdf\\nfgdgdfgdfgdfgfdf";
            // 
            // CountLabel
            // 
            this.CountLabel.Location = new System.Drawing.Point(10, 284);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(120, 20);
            this.CountLabel.TabIndex = 13;
            this.CountLabel.Text = "Пъти на изпълнение:";
            // 
            // CountInput
            // 
            this.CountInput.Location = new System.Drawing.Point(153, 284);
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
            1,
            0,
            0,
            0});
            // 
            // btnAddAction
            // 
            this.btnAddAction.Location = new System.Drawing.Point(15, 453);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(100, 32);
            this.btnAddAction.TabIndex = 15;
            this.btnAddAction.Text = "Добави";
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // btnSaveMacro
            // 
            this.btnSaveMacro.Location = new System.Drawing.Point(490, 75);
            this.btnSaveMacro.Name = "btnSaveMacro";
            this.btnSaveMacro.Size = new System.Drawing.Size(100, 30);
            this.btnSaveMacro.TabIndex = 16;
            this.btnSaveMacro.Text = "Запамети";
            this.btnSaveMacro.UseVisualStyleBackColor = true;
            this.btnSaveMacro.Click += new System.EventHandler(this.btnSaveMacro_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(15, 128);
            this.txtX.Multiline = true;
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(62, 18);
            this.txtX.TabIndex = 17;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(94, 128);
            this.txtY.Multiline = true;
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(62, 18);
            this.txtY.TabIndex = 18;
            // 
            // cmbActionType
            // 
            this.cmbActionType.DisplayMember = "(none)";
            this.cmbActionType.FormattingEnabled = true;
            this.cmbActionType.Items.AddRange(new object[] {
            "Единичен килк",
            "Двоен клик",
            "Скролване"});
            this.cmbActionType.Location = new System.Drawing.Point(15, 181);
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.Size = new System.Drawing.Size(174, 21);
            this.cmbActionType.TabIndex = 19;
            // 
            // chkReturnToOriginal
            // 
            this.chkReturnToOriginal.AutoSize = true;
            this.chkReturnToOriginal.Location = new System.Drawing.Point(207, 185);
            this.chkReturnToOriginal.Name = "chkReturnToOriginal";
            this.chkReturnToOriginal.Size = new System.Drawing.Size(148, 17);
            this.chkReturnToOriginal.TabIndex = 20;
            this.chkReturnToOriginal.Text = "Return to Original Position";
            this.chkReturnToOriginal.UseVisualStyleBackColor = true;
            // 
            // numericDelay
            // 
            this.numericDelay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numericDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericDelay.Location = new System.Drawing.Point(207, 389);
            this.numericDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericDelay.Name = "numericDelay";
            this.numericDelay.Size = new System.Drawing.Size(62, 20);
            this.numericDelay.TabIndex = 21;
            this.numericDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnExecuteMacro
            // 
            this.btnExecuteMacro.Location = new System.Drawing.Point(806, 403);
            this.btnExecuteMacro.Name = "btnExecuteMacro";
            this.btnExecuteMacro.Size = new System.Drawing.Size(100, 30);
            this.btnExecuteMacro.TabIndex = 22;
            this.btnExecuteMacro.Text = "Изпълни Макро";
            this.btnExecuteMacro.UseVisualStyleBackColor = true;
            this.btnExecuteMacro.Click += new System.EventHandler(this.btnExecuteMacro_Click);
            // 
            // lstMacros
            // 
            this.lstMacros.FormattingEnabled = true;
            this.lstMacros.Location = new System.Drawing.Point(806, 75);
            this.lstMacros.Name = "lstMacros";
            this.lstMacros.Size = new System.Drawing.Size(206, 95);
            this.lstMacros.TabIndex = 23;
            this.lstMacros.SelectedIndexChanged += new System.EventHandler(this.lstMacros_SelectedIndexChanged);
            // 
            // lstActions
            // 
            this.lstActions.FormattingEnabled = true;
            this.lstActions.Location = new System.Drawing.Point(15, 510);
            this.lstActions.Name = "lstActions";
            this.lstActions.Size = new System.Drawing.Size(168, 95);
            this.lstActions.TabIndex = 24;
            this.lstActions.SelectedIndexChanged += new System.EventHandler(this.lstActions_SelectedIndexChanged);
            // 
            // textBoxMacroName
            // 
            this.textBoxMacroName.Location = new System.Drawing.Point(490, 49);
            this.textBoxMacroName.Name = "textBoxMacroName";
            this.textBoxMacroName.Size = new System.Drawing.Size(231, 20);
            this.textBoxMacroName.TabIndex = 25;
            this.textBoxMacroName.Text = "Име на Макрото";
            // 
            // numericDelayBefore
            // 
            this.numericDelayBefore.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericDelayBefore.Location = new System.Drawing.Point(207, 359);
            this.numericDelayBefore.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericDelayBefore.Name = "numericDelayBefore";
            this.numericDelayBefore.Size = new System.Drawing.Size(60, 20);
            this.numericDelayBefore.TabIndex = 26;
            this.numericDelayBefore.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // textBoxActionName
            // 
            this.textBoxActionName.Location = new System.Drawing.Point(13, 325);
            this.textBoxActionName.Name = "textBoxActionName";
            this.textBoxActionName.Size = new System.Drawing.Size(231, 20);
            this.textBoxActionName.TabIndex = 27;
            this.textBoxActionName.Text = "Име на действието";
            // 
            // textBoxDisplayInfo
            // 
            this.textBoxDisplayInfo.Location = new System.Drawing.Point(806, 181);
            this.textBoxDisplayInfo.Multiline = true;
            this.textBoxDisplayInfo.Name = "textBoxDisplayInfo";
            this.textBoxDisplayInfo.ReadOnly = true;
            this.textBoxDisplayInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDisplayInfo.Size = new System.Drawing.Size(270, 203);
            this.textBoxDisplayInfo.TabIndex = 28;
            this.textBoxDisplayInfo.Text = "Макро информация";
            // 
            // CurrentPositionLabel
            // 
            this.CurrentPositionLabel.Location = new System.Drawing.Point(12, 52);
            this.CurrentPositionLabel.Name = "CurrentPositionLabel";
            this.CurrentPositionLabel.Size = new System.Drawing.Size(318, 20);
            this.CurrentPositionLabel.TabIndex = 4;
            this.CurrentPositionLabel.Text = "Текуща позиция: ";
            // 
            // LastClickLabel
            // 
            this.LastClickLabel.Location = new System.Drawing.Point(12, 80);
            this.LastClickLabel.Name = "LastClickLabel";
            this.LastClickLabel.Size = new System.Drawing.Size(318, 25);
            this.LastClickLabel.TabIndex = 29;
            this.LastClickLabel.Text = "Последно кликане: ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Забавяне преди ( мили секунди ):";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Забавяне след ( мили секунди ):";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Запаметени X и Y";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(803, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Пъти на изпълнение:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(804, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Избери Макро от списъка:";
            // 
            // countMacroRepeat
            // 
            this.countMacroRepeat.Location = new System.Drawing.Point(929, 17);
            this.countMacroRepeat.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.countMacroRepeat.Name = "countMacroRepeat";
            this.countMacroRepeat.Size = new System.Drawing.Size(83, 20);
            this.countMacroRepeat.TabIndex = 35;
            this.countMacroRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1269, 621);
            this.Controls.Add(this.countMacroRepeat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LastClickLabel);
            this.Controls.Add(this.textBoxDisplayInfo);
            this.Controls.Add(this.textBoxActionName);
            this.Controls.Add(this.numericDelayBefore);
            this.Controls.Add(this.textBoxMacroName);
            this.Controls.Add(this.lstActions);
            this.Controls.Add(this.lstMacros);
            this.Controls.Add(this.btnExecuteMacro);
            this.Controls.Add(this.numericDelay);
            this.Controls.Add(this.chkReturnToOriginal);
            this.Controls.Add(this.cmbActionType);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.btnSaveMacro);
            this.Controls.Add(this.btnAddAction);
            this.Controls.Add(this.CountInput);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.ResetButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countMacroRepeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button StartButton;
        private Button StopButton;
        private Button ResetButton;
        private Label FrequencyLabel;
        private NumericUpDown FrequencyInput;
        private Label DurationLabel;
        private NumericUpDown DurationInput;
        private Button StartClickingButton;
        private Label StatusLabel;
        private Label labelTest;
        private Label CountLabel;
        private NumericUpDown CountInput;
        private Button btnAddAction;
        private Button btnSaveMacro;
        private TextBox txtX;
        private TextBox txtY;
        private ComboBox cmbActionType;
        private CheckBox chkReturnToOriginal;
        private NumericUpDown numericDelay;
        private Button btnExecuteMacro;
        private ListBox lstMacros;
        private ListBox lstActions;
        private TextBox textBoxMacroName;
        private NumericUpDown numericDelayBefore;
        private TextBox textBoxActionName;
        private TextBox textBoxDisplayInfo;
        private Label CurrentPositionLabel;
        private Label LastClickLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown countMacroRepeat;

        // Декларация на елементи
        //private TextBox txtX;
        //private TextBox txtY;
        //private ComboBox cmbActionType;
        //private CheckBox chkReturnToOriginal;
        //private NumericUpDown numericDelay;

        //private Button btnAddAction;
        //private Button btnSaveMacro;

        //private Button btnExecuteMacro;
        //private ListBox lstMacros;
        //private ListBox lstActions;
    }
}