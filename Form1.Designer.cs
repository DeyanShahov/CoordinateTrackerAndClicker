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
                if (autoClickTimer != null)
                {
                    autoClickTimer.Stop();
                    autoClickTimer.Dispose();
                }             
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.FrequencyInput = new System.Windows.Forms.NumericUpDown();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.DurationInput = new System.Windows.Forms.NumericUpDown();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.labelDisplayActionInfo = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountInput = new System.Windows.Forms.NumericUpDown();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.btnCreateMacro = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.chkReturnToOriginal = new System.Windows.Forms.CheckBox();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.btnExecuteMacro = new System.Windows.Forms.Button();
            this.lstAvailableMacros = new System.Windows.Forms.ListBox();
            this.lstAvailableActions = new System.Windows.Forms.ListBox();
            this.textBoxMacroName = new System.Windows.Forms.TextBox();
            this.numericDelayBefore = new System.Windows.Forms.NumericUpDown();
            this.textBoxActionName = new System.Windows.Forms.TextBox();
            this.textBoxDisplayMacroInfo = new System.Windows.Forms.TextBox();
            this.CurrentPositionLabel = new System.Windows.Forms.Label();
            this.LastClickLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.countMacroRepeat = new System.Windows.Forms.NumericUpDown();
            this.btnPauseMacro = new System.Windows.Forms.Button();
            this.btnContinueMacro = new System.Windows.Forms.Button();
            this.btnStopMacro = new System.Windows.Forms.Button();
            this.btnActionDelete = new System.Windows.Forms.Button();
            this.btnMoveUpAction = new System.Windows.Forms.Button();
            this.btnMoveDownAction = new System.Windows.Forms.Button();
            this.lstMacrosForExecute = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMacroForExecuteDelete = new System.Windows.Forms.Button();
            this.richTextBoxLogInfo = new System.Windows.Forms.RichTextBox();
            this.btnMoveUpMacro = new System.Windows.Forms.Button();
            this.btnMoveDownMacro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countMacroRepeat)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.Location = new System.Drawing.Point(10, 10);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(100, 30);
            this.btnStartRecording.TabIndex = 0;
            this.btnStartRecording.Text = "Старт запис";
            this.btnStartRecording.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Enabled = false;
            this.btnStopRecording.Location = new System.Drawing.Point(120, 10);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(100, 30);
            this.btnStopRecording.TabIndex = 1;
            this.btnStopRecording.Text = "Стоп запис";
            this.btnStopRecording.Click += new System.EventHandler(this.StopButton_Click);
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
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.Location = new System.Drawing.Point(759, 436);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(465, 63);
            this.StatusLabel.TabIndex = 10;
            this.StatusLabel.Text = "Полседно действие:";
            // 
            // labelDisplayActionInfo
            // 
            this.labelDisplayActionInfo.Location = new System.Drawing.Point(237, 434);
            this.labelDisplayActionInfo.Name = "labelDisplayActionInfo";
            this.labelDisplayActionInfo.Size = new System.Drawing.Size(333, 171);
            this.labelDisplayActionInfo.TabIndex = 12;
            this.labelDisplayActionInfo.Text = "dfdfsdfsdf\\nfgdgdfgdfgdfgfdf";
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
            this.btnAddAction.Enabled = false;
            this.btnAddAction.Location = new System.Drawing.Point(15, 453);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(100, 32);
            this.btnAddAction.TabIndex = 15;
            this.btnAddAction.Text = "Добави";
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // btnCreateMacro
            // 
            this.btnCreateMacro.Enabled = false;
            this.btnCreateMacro.Location = new System.Drawing.Point(399, 75);
            this.btnCreateMacro.Name = "btnCreateMacro";
            this.btnCreateMacro.Size = new System.Drawing.Size(116, 30);
            this.btnCreateMacro.TabIndex = 16;
            this.btnCreateMacro.Text = "Създаи Макрото";
            this.btnCreateMacro.UseVisualStyleBackColor = true;
            this.btnCreateMacro.Click += new System.EventHandler(this.btnCreateMacro_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(15, 128);
            this.txtX.Multiline = true;
            this.txtX.Name = "txtX";
            this.txtX.ReadOnly = true;
            this.txtX.Size = new System.Drawing.Size(62, 18);
            this.txtX.TabIndex = 17;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(94, 128);
            this.txtY.Multiline = true;
            this.txtY.Name = "txtY";
            this.txtY.ReadOnly = true;
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
            "Скролване",
            "Десен бутон"});
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
            this.btnExecuteMacro.Enabled = false;
            this.btnExecuteMacro.Location = new System.Drawing.Point(806, 403);
            this.btnExecuteMacro.Name = "btnExecuteMacro";
            this.btnExecuteMacro.Size = new System.Drawing.Size(100, 30);
            this.btnExecuteMacro.TabIndex = 22;
            this.btnExecuteMacro.Text = "Изпълни";
            this.btnExecuteMacro.UseVisualStyleBackColor = true;
            this.btnExecuteMacro.Click += new System.EventHandler(this.btnExecuteMacro_Click);
            // 
            // lstAvailableMacros
            // 
            this.lstAvailableMacros.FormattingEnabled = true;
            this.lstAvailableMacros.Location = new System.Drawing.Point(642, 75);
            this.lstAvailableMacros.Name = "lstAvailableMacros";
            this.lstAvailableMacros.Size = new System.Drawing.Size(200, 95);
            this.lstAvailableMacros.TabIndex = 23;
            this.lstAvailableMacros.SelectedIndexChanged += new System.EventHandler(this.lstMacros_SelectedIndexChanged);
            this.lstAvailableMacros.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstAvailableMacros_MouseDoubleClick);
            // 
            // lstAvailableActions
            // 
            this.lstAvailableActions.FormattingEnabled = true;
            this.lstAvailableActions.Location = new System.Drawing.Point(15, 497);
            this.lstAvailableActions.Name = "lstAvailableActions";
            this.lstAvailableActions.Size = new System.Drawing.Size(168, 108);
            this.lstAvailableActions.TabIndex = 24;
            this.lstAvailableActions.SelectedIndexChanged += new System.EventHandler(this.lstActions_SelectedIndexChanged);
            // 
            // textBoxMacroName
            // 
            this.textBoxMacroName.Location = new System.Drawing.Point(399, 49);
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
            // textBoxDisplayMacroInfo
            // 
            this.textBoxDisplayMacroInfo.Location = new System.Drawing.Point(806, 224);
            this.textBoxDisplayMacroInfo.Multiline = true;
            this.textBoxDisplayMacroInfo.Name = "textBoxDisplayMacroInfo";
            this.textBoxDisplayMacroInfo.ReadOnly = true;
            this.textBoxDisplayMacroInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDisplayMacroInfo.Size = new System.Drawing.Size(270, 160);
            this.textBoxDisplayMacroInfo.TabIndex = 28;
            this.textBoxDisplayMacroInfo.Text = "Макро информация";
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
            this.label4.Location = new System.Drawing.Point(859, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Пъти на изпълнение:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(639, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Списък с Макрота:";
            // 
            // countMacroRepeat
            // 
            this.countMacroRepeat.Location = new System.Drawing.Point(979, 16);
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
            // btnPauseMacro
            // 
            this.btnPauseMacro.Enabled = false;
            this.btnPauseMacro.Location = new System.Drawing.Point(912, 403);
            this.btnPauseMacro.Name = "btnPauseMacro";
            this.btnPauseMacro.Size = new System.Drawing.Size(100, 30);
            this.btnPauseMacro.TabIndex = 36;
            this.btnPauseMacro.Text = "Пауза";
            this.btnPauseMacro.UseVisualStyleBackColor = true;
            this.btnPauseMacro.Click += new System.EventHandler(this.btnPauseMacro_Click);
            // 
            // btnContinueMacro
            // 
            this.btnContinueMacro.Enabled = false;
            this.btnContinueMacro.Location = new System.Drawing.Point(1018, 403);
            this.btnContinueMacro.Name = "btnContinueMacro";
            this.btnContinueMacro.Size = new System.Drawing.Size(100, 30);
            this.btnContinueMacro.TabIndex = 37;
            this.btnContinueMacro.Text = "Продължи";
            this.btnContinueMacro.UseVisualStyleBackColor = true;
            this.btnContinueMacro.Click += new System.EventHandler(this.btnContinueMacro_Click);
            // 
            // btnStopMacro
            // 
            this.btnStopMacro.Enabled = false;
            this.btnStopMacro.Location = new System.Drawing.Point(1124, 403);
            this.btnStopMacro.Name = "btnStopMacro";
            this.btnStopMacro.Size = new System.Drawing.Size(100, 30);
            this.btnStopMacro.TabIndex = 38;
            this.btnStopMacro.Text = "Спри";
            this.btnStopMacro.UseVisualStyleBackColor = true;
            this.btnStopMacro.Click += new System.EventHandler(this.btnStopMacro_Click);
            // 
            // btnActionDelete
            // 
            this.btnActionDelete.Enabled = false;
            this.btnActionDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnActionDelete.Location = new System.Drawing.Point(189, 575);
            this.btnActionDelete.Name = "btnActionDelete";
            this.btnActionDelete.Size = new System.Drawing.Size(30, 30);
            this.btnActionDelete.TabIndex = 40;
            this.btnActionDelete.Text = "🐇";
            this.btnActionDelete.UseVisualStyleBackColor = true;
            this.btnActionDelete.Click += new System.EventHandler(this.btnActionDelete_Click);
            // 
            // btnMoveUpAction
            // 
            this.btnMoveUpAction.Location = new System.Drawing.Point(190, 497);
            this.btnMoveUpAction.Name = "btnMoveUpAction";
            this.btnMoveUpAction.Size = new System.Drawing.Size(30, 30);
            this.btnMoveUpAction.TabIndex = 41;
            this.btnMoveUpAction.Text = "UP";
            this.btnMoveUpAction.UseVisualStyleBackColor = true;
            this.btnMoveUpAction.Click += new System.EventHandler(this.btnMoveUpAction_Click);
            // 
            // btnMoveDownAction
            // 
            this.btnMoveDownAction.Location = new System.Drawing.Point(189, 533);
            this.btnMoveDownAction.Name = "btnMoveDownAction";
            this.btnMoveDownAction.Size = new System.Drawing.Size(30, 30);
            this.btnMoveDownAction.TabIndex = 42;
            this.btnMoveDownAction.Text = "D";
            this.btnMoveDownAction.UseVisualStyleBackColor = true;
            this.btnMoveDownAction.Click += new System.EventHandler(this.btnMoveDownAction_Click);
            // 
            // lstMacrosForExecute
            // 
            this.lstMacrosForExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstMacrosForExecute.FormattingEnabled = true;
            this.lstMacrosForExecute.ItemHeight = 20;
            this.lstMacrosForExecute.Location = new System.Drawing.Point(862, 75);
            this.lstMacrosForExecute.Name = "lstMacrosForExecute";
            this.lstMacrosForExecute.Size = new System.Drawing.Size(200, 144);
            this.lstMacrosForExecute.TabIndex = 43;
            this.lstMacrosForExecute.SelectedIndexChanged += new System.EventHandler(this.lstMacrosForExecute_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(859, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Макро за изпълнение:";
            // 
            // btnMacroForExecuteDelete
            // 
            this.btnMacroForExecuteDelete.Enabled = false;
            this.btnMacroForExecuteDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMacroForExecuteDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMacroForExecuteDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMacroForExecuteDelete.Location = new System.Drawing.Point(1068, 158);
            this.btnMacroForExecuteDelete.Name = "btnMacroForExecuteDelete";
            this.btnMacroForExecuteDelete.Size = new System.Drawing.Size(37, 61);
            this.btnMacroForExecuteDelete.TabIndex = 45;
            this.btnMacroForExecuteDelete.Text = "𓀃";
            this.btnMacroForExecuteDelete.UseVisualStyleBackColor = true;
            this.btnMacroForExecuteDelete.Click += new System.EventHandler(this.btnMacroForExecuteDelete_Click);
            // 
            // richTextBoxLogInfo
            // 
            this.richTextBoxLogInfo.Location = new System.Drawing.Point(759, 516);
            this.richTextBoxLogInfo.Name = "richTextBoxLogInfo";
            this.richTextBoxLogInfo.ReadOnly = true;
            this.richTextBoxLogInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLogInfo.Size = new System.Drawing.Size(465, 95);
            this.richTextBoxLogInfo.TabIndex = 46;
            this.richTextBoxLogInfo.Text = "Хронология . . .";
            // 
            // btnMoveUpMacro
            // 
            this.btnMoveUpMacro.Location = new System.Drawing.Point(1068, 75);
            this.btnMoveUpMacro.Name = "btnMoveUpMacro";
            this.btnMoveUpMacro.Size = new System.Drawing.Size(30, 30);
            this.btnMoveUpMacro.TabIndex = 47;
            this.btnMoveUpMacro.Text = "UP";
            this.btnMoveUpMacro.UseVisualStyleBackColor = true;
            this.btnMoveUpMacro.Click += new System.EventHandler(this.btnMoveUpMacro_Click);
            // 
            // btnMoveDownMacro
            // 
            this.btnMoveDownMacro.Location = new System.Drawing.Point(1068, 111);
            this.btnMoveDownMacro.Name = "btnMoveDownMacro";
            this.btnMoveDownMacro.Size = new System.Drawing.Size(30, 30);
            this.btnMoveDownMacro.TabIndex = 48;
            this.btnMoveDownMacro.Text = "D";
            this.btnMoveDownMacro.UseVisualStyleBackColor = true;
            this.btnMoveDownMacro.Click += new System.EventHandler(this.btnMoveDownMacro_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1269, 621);
            this.Controls.Add(this.btnMoveDownMacro);
            this.Controls.Add(this.btnMoveUpMacro);
            this.Controls.Add(this.richTextBoxLogInfo);
            this.Controls.Add(this.btnMacroForExecuteDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstMacrosForExecute);
            this.Controls.Add(this.btnMoveDownAction);
            this.Controls.Add(this.btnMoveUpAction);
            this.Controls.Add(this.btnActionDelete);
            this.Controls.Add(this.btnStopMacro);
            this.Controls.Add(this.btnContinueMacro);
            this.Controls.Add(this.btnPauseMacro);
            this.Controls.Add(this.countMacroRepeat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LastClickLabel);
            this.Controls.Add(this.textBoxDisplayMacroInfo);
            this.Controls.Add(this.textBoxActionName);
            this.Controls.Add(this.numericDelayBefore);
            this.Controls.Add(this.textBoxMacroName);
            this.Controls.Add(this.lstAvailableActions);
            this.Controls.Add(this.lstAvailableMacros);
            this.Controls.Add(this.btnExecuteMacro);
            this.Controls.Add(this.numericDelay);
            this.Controls.Add(this.chkReturnToOriginal);
            this.Controls.Add(this.cmbActionType);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.btnCreateMacro);
            this.Controls.Add(this.btnAddAction);
            this.Controls.Add(this.CountInput);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.labelDisplayActionInfo);
            this.Controls.Add(this.btnStartRecording);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.CurrentPositionLabel);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.FrequencyInput);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.DurationInput);
            this.Controls.Add(this.StatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1285, 660);
            this.MinimumSize = new System.Drawing.Size(1285, 660);
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

        private Button btnStartRecording;
        private Button btnStopRecording;
        private Button ResetButton;
        private Label FrequencyLabel;
        private NumericUpDown FrequencyInput;
        private Label DurationLabel;
        private NumericUpDown DurationInput;
        private Label StatusLabel;
        private Label labelDisplayActionInfo;
        private Label CountLabel;
        private NumericUpDown CountInput;
        private Button btnAddAction;
        private Button btnCreateMacro;
        private TextBox txtX;
        private TextBox txtY;
        private ComboBox cmbActionType;
        private CheckBox chkReturnToOriginal;
        private NumericUpDown numericDelay;
        private Button btnExecuteMacro;
        private ListBox lstAvailableMacros;
        private ListBox lstAvailableActions;
        private TextBox textBoxMacroName;
        private NumericUpDown numericDelayBefore;
        private TextBox textBoxActionName;
        private TextBox textBoxDisplayMacroInfo;
        private Label CurrentPositionLabel;
        private Label LastClickLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown countMacroRepeat;
        private Button btnPauseMacro;
        private Button btnContinueMacro;
        private Button btnStopMacro;
        private Button btnActionDelete;
        private Button btnMoveUpAction;
        private Button btnMoveDownAction;
        private ListBox lstMacrosForExecute;
        private Label label6;
        private Button btnMacroForExecuteDelete;
        private RichTextBox richTextBoxLogInfo;
        private Button btnMoveUpMacro;
        private Button btnMoveDownMacro;

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