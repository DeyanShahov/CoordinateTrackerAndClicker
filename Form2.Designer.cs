namespace CoordinateTrackerAndClicker
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CountInput = new System.Windows.Forms.NumericUpDown();
            this.FrequencyInput = new System.Windows.Forms.NumericUpDown();
            this.DurationInput = new System.Windows.Forms.NumericUpDown();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.chkReturnMouseToOriginal = new MaterialSkin.Controls.MaterialCheckbox();
            this.cmbActionType = new MaterialSkin.Controls.MaterialComboBox();
            this.txtY = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.txtX = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.LastClickLabel = new MaterialSkin.Controls.MaterialLabel();
            this.CurrentPositionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.btnStopRecording = new MaterialSkin.Controls.MaterialButton();
            this.btnStartRecording = new MaterialSkin.Controls.MaterialButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBoxActionName = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.numericDelayBefore = new System.Windows.Forms.NumericUpDown();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.btnAddAction = new MaterialSkin.Controls.MaterialButton();
            this.lstAvailableActions = new MaterialSkin.Controls.MaterialListBox();
            this.btnActionDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnMoveDownAction = new MaterialSkin.Controls.MaterialButton();
            this.btnMoveUpAction = new MaterialSkin.Controls.MaterialButton();
            this.textBoxMacroName = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.btnCreateMacro = new MaterialSkin.Controls.MaterialButton();
            this.lstAvailableMacros = new MaterialSkin.Controls.MaterialListBox();
            this.textBoxDisplayMacroInfo = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.countAllMacroRepeat = new System.Windows.Forms.NumericUpDown();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.lstMacrosForExecute = new MaterialSkin.Controls.MaterialListBox();
            this.btnMacroForExecuteDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnMoveDownMacro = new MaterialSkin.Controls.MaterialButton();
            this.btnMoveUpMacro = new MaterialSkin.Controls.MaterialButton();
            this.chkAllMacrosToExecute = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnStopMacro = new MaterialSkin.Controls.MaterialButton();
            this.btnExecuteMacro = new MaterialSkin.Controls.MaterialButton();
            this.StatusLabel = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.richTextBoxLogInfo = new System.Windows.Forms.RichTextBox();
            this.materialTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationInput)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countAllMacroRepeat)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(50, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(387, 883);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.ImageKey = "icons8-home-page-32.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 74);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(379, 835);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Влизане";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCreateMacro);
            this.tabPage2.Controls.Add(this.textBoxMacroName);
            this.tabPage2.Controls.Add(this.btnActionDelete);
            this.tabPage2.Controls.Add(this.btnMoveDownAction);
            this.tabPage2.Controls.Add(this.btnMoveUpAction);
            this.tabPage2.Controls.Add(this.lstAvailableActions);
            this.tabPage2.Controls.Add(this.btnAddAction);
            this.tabPage2.Controls.Add(this.numericDelayBefore);
            this.tabPage2.Controls.Add(this.numericDelay);
            this.tabPage2.Controls.Add(this.materialLabel4);
            this.tabPage2.Controls.Add(this.materialLabel5);
            this.tabPage2.Controls.Add(this.textBoxActionName);
            this.tabPage2.Controls.Add(this.CountInput);
            this.tabPage2.Controls.Add(this.FrequencyInput);
            this.tabPage2.Controls.Add(this.DurationInput);
            this.tabPage2.Controls.Add(this.materialLabel3);
            this.tabPage2.Controls.Add(this.materialLabel2);
            this.tabPage2.Controls.Add(this.materialLabel1);
            this.tabPage2.Controls.Add(this.chkReturnMouseToOriginal);
            this.tabPage2.Controls.Add(this.cmbActionType);
            this.tabPage2.Controls.Add(this.txtY);
            this.tabPage2.Controls.Add(this.txtX);
            this.tabPage2.Controls.Add(this.LastClickLabel);
            this.tabPage2.Controls.Add(this.CurrentPositionLabel);
            this.tabPage2.Controls.Add(this.btnStopRecording);
            this.tabPage2.Controls.Add(this.btnStartRecording);
            this.tabPage2.ImageKey = "icons8-tune-32.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 74);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 805);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Създай макро";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CountInput
            // 
            this.CountInput.Location = new System.Drawing.Point(250, 386);
            this.CountInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.CountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CountInput.Name = "CountInput";
            this.CountInput.Size = new System.Drawing.Size(60, 22);
            this.CountInput.TabIndex = 36;
            this.CountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrequencyInput
            // 
            this.FrequencyInput.Location = new System.Drawing.Point(250, 318);
            this.FrequencyInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.FrequencyInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FrequencyInput.Name = "FrequencyInput";
            this.FrequencyInput.Size = new System.Drawing.Size(60, 22);
            this.FrequencyInput.TabIndex = 34;
            this.FrequencyInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DurationInput
            // 
            this.DurationInput.Location = new System.Drawing.Point(250, 352);
            this.DurationInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.DurationInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DurationInput.Name = "DurationInput";
            this.DurationInput.Size = new System.Drawing.Size(60, 22);
            this.DurationInput.TabIndex = 35;
            this.DurationInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // materialLabel3
            // 
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(38, 352);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(234, 22);
            this.materialLabel3.TabIndex = 33;
            this.materialLabel3.Text = "Продължителност (мин):";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(38, 386);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(234, 22);
            this.materialLabel2.TabIndex = 32;
            this.materialLabel2.Text = "Пъти на изпълнение:";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(38, 318);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(234, 22);
            this.materialLabel1.TabIndex = 31;
            this.materialLabel1.Text = "Честота (секунди):";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkReturnMouseToOriginal
            // 
            this.chkReturnMouseToOriginal.Depth = 0;
            this.chkReturnMouseToOriginal.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkReturnMouseToOriginal.Location = new System.Drawing.Point(41, 272);
            this.chkReturnMouseToOriginal.Margin = new System.Windows.Forms.Padding(0);
            this.chkReturnMouseToOriginal.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkReturnMouseToOriginal.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkReturnMouseToOriginal.Name = "chkReturnMouseToOriginal";
            this.chkReturnMouseToOriginal.ReadOnly = false;
            this.chkReturnMouseToOriginal.Ripple = true;
            this.chkReturnMouseToOriginal.Size = new System.Drawing.Size(327, 37);
            this.chkReturnMouseToOriginal.TabIndex = 27;
            this.chkReturnMouseToOriginal.Text = "Завръщане на оригиналната позиция";
            this.chkReturnMouseToOriginal.UseVisualStyleBackColor = true;
            // 
            // cmbActionType
            // 
            this.cmbActionType.AutoResize = false;
            this.cmbActionType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbActionType.Depth = 0;
            this.cmbActionType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbActionType.DropDownHeight = 174;
            this.cmbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionType.DropDownWidth = 121;
            this.cmbActionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbActionType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbActionType.FormattingEnabled = true;
            this.cmbActionType.IntegralHeight = false;
            this.cmbActionType.ItemHeight = 43;
            this.cmbActionType.Items.AddRange(new object[] {
            "Единичен килк",
            "Двоен клик",
            "Скролване",
            "Десен бутон"});
            this.cmbActionType.Location = new System.Drawing.Point(40, 220);
            this.cmbActionType.MaxDropDownItems = 4;
            this.cmbActionType.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.Size = new System.Drawing.Size(328, 49);
            this.cmbActionType.StartIndex = 0;
            this.cmbActionType.TabIndex = 26;
            // 
            // txtY
            // 
            this.txtY.AllowPromptAsInput = true;
            this.txtY.AnimateReadOnly = false;
            this.txtY.AsciiOnly = false;
            this.txtY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtY.BeepOnError = false;
            this.txtY.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtY.Depth = 0;
            this.txtY.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtY.HidePromptOnLeave = false;
            this.txtY.HideSelection = true;
            this.txtY.Hint = "кординат Y";
            this.txtY.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtY.LeadingIcon = null;
            this.txtY.Location = new System.Drawing.Point(230, 154);
            this.txtY.Mask = "";
            this.txtY.MaxLength = 32767;
            this.txtY.MouseState = MaterialSkin.MouseState.OUT;
            this.txtY.Name = "txtY";
            this.txtY.PasswordChar = '\0';
            this.txtY.PrefixSuffixText = null;
            this.txtY.PromptChar = '_';
            this.txtY.ReadOnly = false;
            this.txtY.RejectInputOnFirstFailure = false;
            this.txtY.ResetOnPrompt = true;
            this.txtY.ResetOnSpace = true;
            this.txtY.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtY.SelectedText = "";
            this.txtY.SelectionLength = 0;
            this.txtY.SelectionStart = 0;
            this.txtY.ShortcutsEnabled = true;
            this.txtY.Size = new System.Drawing.Size(119, 48);
            this.txtY.SkipLiterals = true;
            this.txtY.TabIndex = 25;
            this.txtY.TabStop = false;
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtY.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtY.TrailingIcon = null;
            this.txtY.UseSystemPasswordChar = false;
            this.txtY.ValidatingType = null;
            // 
            // txtX
            // 
            this.txtX.AllowPromptAsInput = true;
            this.txtX.AnimateReadOnly = false;
            this.txtX.AsciiOnly = false;
            this.txtX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtX.BeepOnError = false;
            this.txtX.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtX.Depth = 0;
            this.txtX.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtX.HidePromptOnLeave = false;
            this.txtX.HideSelection = true;
            this.txtX.Hint = "кординат Х";
            this.txtX.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtX.LeadingIcon = null;
            this.txtX.Location = new System.Drawing.Point(65, 154);
            this.txtX.Mask = "";
            this.txtX.MaxLength = 32767;
            this.txtX.MouseState = MaterialSkin.MouseState.OUT;
            this.txtX.Name = "txtX";
            this.txtX.PasswordChar = '\0';
            this.txtX.PrefixSuffixText = null;
            this.txtX.PromptChar = '_';
            this.txtX.ReadOnly = false;
            this.txtX.RejectInputOnFirstFailure = false;
            this.txtX.ResetOnPrompt = true;
            this.txtX.ResetOnSpace = true;
            this.txtX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtX.SelectedText = "";
            this.txtX.SelectionLength = 0;
            this.txtX.SelectionStart = 0;
            this.txtX.ShortcutsEnabled = true;
            this.txtX.Size = new System.Drawing.Size(119, 48);
            this.txtX.SkipLiterals = true;
            this.txtX.TabIndex = 24;
            this.txtX.TabStop = false;
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtX.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtX.TrailingIcon = null;
            this.txtX.UseSystemPasswordChar = false;
            this.txtX.ValidatingType = null;
            // 
            // LastClickLabel
            // 
            this.LastClickLabel.Depth = 0;
            this.LastClickLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LastClickLabel.Location = new System.Drawing.Point(38, 120);
            this.LastClickLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.LastClickLabel.Name = "LastClickLabel";
            this.LastClickLabel.Size = new System.Drawing.Size(330, 19);
            this.LastClickLabel.TabIndex = 23;
            this.LastClickLabel.Text = "Последно кликане: ";
            this.LastClickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentPositionLabel
            // 
            this.CurrentPositionLabel.Depth = 0;
            this.CurrentPositionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CurrentPositionLabel.Location = new System.Drawing.Point(38, 82);
            this.CurrentPositionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.CurrentPositionLabel.Name = "CurrentPositionLabel";
            this.CurrentPositionLabel.Size = new System.Drawing.Size(330, 19);
            this.CurrentPositionLabel.TabIndex = 22;
            this.CurrentPositionLabel.Text = "Текуща позиция . . .";
            this.CurrentPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.AutoSize = false;
            this.btnStopRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStopRecording.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStopRecording.Depth = 0;
            this.btnStopRecording.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopRecording.HighEmphasis = true;
            this.btnStopRecording.Icon = null;
            this.btnStopRecording.Location = new System.Drawing.Point(208, 19);
            this.btnStopRecording.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStopRecording.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStopRecording.Size = new System.Drawing.Size(160, 40);
            this.btnStopRecording.TabIndex = 21;
            this.btnStopRecording.Text = "Стоп запис";
            this.btnStopRecording.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStopRecording.UseAccentColor = false;
            this.btnStopRecording.UseVisualStyleBackColor = true;
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.AutoSize = false;
            this.btnStartRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartRecording.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStartRecording.Depth = 0;
            this.btnStartRecording.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartRecording.HighEmphasis = true;
            this.btnStartRecording.Icon = null;
            this.btnStartRecording.Location = new System.Drawing.Point(40, 19);
            this.btnStartRecording.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStartRecording.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStartRecording.Size = new System.Drawing.Size(160, 40);
            this.btnStartRecording.TabIndex = 20;
            this.btnStartRecording.Text = "Старт запис";
            this.btnStartRecording.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStartRecording.UseAccentColor = false;
            this.btnStartRecording.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBoxLogInfo);
            this.tabPage3.Controls.Add(this.StatusLabel);
            this.tabPage3.Controls.Add(this.btnStopMacro);
            this.tabPage3.Controls.Add(this.btnExecuteMacro);
            this.tabPage3.Controls.Add(this.chkAllMacrosToExecute);
            this.tabPage3.Controls.Add(this.btnMacroForExecuteDelete);
            this.tabPage3.Controls.Add(this.btnMoveDownMacro);
            this.tabPage3.Controls.Add(this.btnMoveUpMacro);
            this.tabPage3.Controls.Add(this.lstMacrosForExecute);
            this.tabPage3.Controls.Add(this.countAllMacroRepeat);
            this.tabPage3.Controls.Add(this.materialLabel6);
            this.tabPage3.Controls.Add(this.textBoxDisplayMacroInfo);
            this.tabPage3.Controls.Add(this.lstAvailableMacros);
            this.tabPage3.ImageKey = "icons8-work-32.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 74);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(379, 805);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Използвай макро";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.ImageKey = "icons8-settings-32.png";
            this.tabPage4.Location = new System.Drawing.Point(4, 74);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(379, 835);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Настройки";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-home-page-32.png");
            this.imageList1.Images.SetKeyName(1, "icons8-tune-32.png");
            this.imageList1.Images.SetKeyName(2, "icons8-settings-32.png");
            this.imageList1.Images.SetKeyName(3, "icons8-work-32.png");
            this.imageList1.Images.SetKeyName(4, "icons8-delete-32.png");
            this.imageList1.Images.SetKeyName(5, "icons8-down-32.png");
            this.imageList1.Images.SetKeyName(6, "icons8-up-32.png");
            // 
            // textBoxActionName
            // 
            this.textBoxActionName.AllowPromptAsInput = true;
            this.textBoxActionName.AnimateReadOnly = false;
            this.textBoxActionName.AsciiOnly = false;
            this.textBoxActionName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxActionName.BeepOnError = false;
            this.textBoxActionName.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.textBoxActionName.Depth = 0;
            this.textBoxActionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxActionName.HidePromptOnLeave = false;
            this.textBoxActionName.HideSelection = true;
            this.textBoxActionName.Hint = "Въведете име за действието";
            this.textBoxActionName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.textBoxActionName.LeadingIcon = null;
            this.textBoxActionName.Location = new System.Drawing.Point(40, 424);
            this.textBoxActionName.Mask = "";
            this.textBoxActionName.MaxLength = 32767;
            this.textBoxActionName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxActionName.Name = "textBoxActionName";
            this.textBoxActionName.PasswordChar = '\0';
            this.textBoxActionName.PrefixSuffixText = null;
            this.textBoxActionName.PromptChar = '_';
            this.textBoxActionName.ReadOnly = false;
            this.textBoxActionName.RejectInputOnFirstFailure = false;
            this.textBoxActionName.ResetOnPrompt = true;
            this.textBoxActionName.ResetOnSpace = true;
            this.textBoxActionName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxActionName.SelectedText = "";
            this.textBoxActionName.SelectionLength = 0;
            this.textBoxActionName.SelectionStart = 0;
            this.textBoxActionName.ShortcutsEnabled = true;
            this.textBoxActionName.Size = new System.Drawing.Size(328, 48);
            this.textBoxActionName.SkipLiterals = true;
            this.textBoxActionName.TabIndex = 37;
            this.textBoxActionName.TabStop = false;
            this.textBoxActionName.Text = "Действие 1";
            this.textBoxActionName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxActionName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.textBoxActionName.TrailingIcon = null;
            this.textBoxActionName.UseSystemPasswordChar = false;
            this.textBoxActionName.ValidatingType = null;
            // 
            // materialLabel4
            // 
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(38, 523);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(234, 22);
            this.materialLabel4.TabIndex = 39;
            this.materialLabel4.Text = "Забавяне след (мс.):";
            this.materialLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel5
            // 
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(38, 489);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(234, 22);
            this.materialLabel5.TabIndex = 38;
            this.materialLabel5.Text = "Забавяне преди (мс.):";
            this.materialLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericDelayBefore
            // 
            this.numericDelayBefore.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericDelayBefore.Location = new System.Drawing.Point(250, 489);
            this.numericDelayBefore.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericDelayBefore.Name = "numericDelayBefore";
            this.numericDelayBefore.Size = new System.Drawing.Size(60, 22);
            this.numericDelayBefore.TabIndex = 41;
            this.numericDelayBefore.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numericDelay
            // 
            this.numericDelay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numericDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericDelay.Location = new System.Drawing.Point(250, 523);
            this.numericDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericDelay.Name = "numericDelay";
            this.numericDelay.Size = new System.Drawing.Size(60, 22);
            this.numericDelay.TabIndex = 40;
            this.numericDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnAddAction
            // 
            this.btnAddAction.AutoSize = false;
            this.btnAddAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddAction.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddAction.Depth = 0;
            this.btnAddAction.HighEmphasis = true;
            this.btnAddAction.Icon = null;
            this.btnAddAction.Location = new System.Drawing.Point(40, 563);
            this.btnAddAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddAction.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddAction.Size = new System.Drawing.Size(328, 40);
            this.btnAddAction.TabIndex = 42;
            this.btnAddAction.Text = "Добави като ново действие";
            this.btnAddAction.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddAction.UseAccentColor = false;
            this.btnAddAction.UseVisualStyleBackColor = true;
            // 
            // lstAvailableActions
            // 
            this.lstAvailableActions.BackColor = System.Drawing.Color.White;
            this.lstAvailableActions.BorderColor = System.Drawing.Color.LightGray;
            this.lstAvailableActions.Depth = 0;
            this.lstAvailableActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstAvailableActions.Location = new System.Drawing.Point(88, 622);
            this.lstAvailableActions.MouseState = MaterialSkin.MouseState.HOVER;
            this.lstAvailableActions.Name = "lstAvailableActions";
            this.lstAvailableActions.SelectedIndex = -1;
            this.lstAvailableActions.SelectedItem = null;
            this.lstAvailableActions.Size = new System.Drawing.Size(280, 137);
            this.lstAvailableActions.TabIndex = 43;
            // 
            // btnActionDelete
            // 
            this.btnActionDelete.AutoSize = false;
            this.btnActionDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActionDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActionDelete.Depth = 0;
            this.btnActionDelete.HighEmphasis = true;
            this.btnActionDelete.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_delete_32;
            this.btnActionDelete.Location = new System.Drawing.Point(41, 719);
            this.btnActionDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActionDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActionDelete.Name = "btnActionDelete";
            this.btnActionDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActionDelete.Size = new System.Drawing.Size(40, 40);
            this.btnActionDelete.TabIndex = 46;
            this.btnActionDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnActionDelete.UseAccentColor = false;
            this.btnActionDelete.UseVisualStyleBackColor = true;
            // 
            // btnMoveDownAction
            // 
            this.btnMoveDownAction.AutoSize = false;
            this.btnMoveDownAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveDownAction.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMoveDownAction.Depth = 0;
            this.btnMoveDownAction.HighEmphasis = true;
            this.btnMoveDownAction.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_down_32;
            this.btnMoveDownAction.Location = new System.Drawing.Point(40, 670);
            this.btnMoveDownAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMoveDownAction.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveDownAction.Name = "btnMoveDownAction";
            this.btnMoveDownAction.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMoveDownAction.Size = new System.Drawing.Size(40, 40);
            this.btnMoveDownAction.TabIndex = 45;
            this.btnMoveDownAction.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMoveDownAction.UseAccentColor = false;
            this.btnMoveDownAction.UseVisualStyleBackColor = true;
            // 
            // btnMoveUpAction
            // 
            this.btnMoveUpAction.AutoSize = false;
            this.btnMoveUpAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveUpAction.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMoveUpAction.Depth = 0;
            this.btnMoveUpAction.HighEmphasis = true;
            this.btnMoveUpAction.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_up_32;
            this.btnMoveUpAction.Location = new System.Drawing.Point(40, 622);
            this.btnMoveUpAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMoveUpAction.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveUpAction.Name = "btnMoveUpAction";
            this.btnMoveUpAction.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMoveUpAction.Size = new System.Drawing.Size(40, 40);
            this.btnMoveUpAction.TabIndex = 44;
            this.btnMoveUpAction.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMoveUpAction.UseAccentColor = false;
            this.btnMoveUpAction.UseVisualStyleBackColor = true;
            // 
            // textBoxMacroName
            // 
            this.textBoxMacroName.AllowPromptAsInput = true;
            this.textBoxMacroName.AnimateReadOnly = false;
            this.textBoxMacroName.AsciiOnly = false;
            this.textBoxMacroName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxMacroName.BeepOnError = false;
            this.textBoxMacroName.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.textBoxMacroName.Depth = 0;
            this.textBoxMacroName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxMacroName.HidePromptOnLeave = false;
            this.textBoxMacroName.HideSelection = true;
            this.textBoxMacroName.Hint = "Име на Макрото";
            this.textBoxMacroName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.textBoxMacroName.LeadingIcon = null;
            this.textBoxMacroName.Location = new System.Drawing.Point(40, 777);
            this.textBoxMacroName.Mask = "";
            this.textBoxMacroName.MaxLength = 32767;
            this.textBoxMacroName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxMacroName.Name = "textBoxMacroName";
            this.textBoxMacroName.PasswordChar = '\0';
            this.textBoxMacroName.PrefixSuffixText = null;
            this.textBoxMacroName.PromptChar = '_';
            this.textBoxMacroName.ReadOnly = false;
            this.textBoxMacroName.RejectInputOnFirstFailure = false;
            this.textBoxMacroName.ResetOnPrompt = true;
            this.textBoxMacroName.ResetOnSpace = true;
            this.textBoxMacroName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxMacroName.SelectedText = "";
            this.textBoxMacroName.SelectionLength = 0;
            this.textBoxMacroName.SelectionStart = 0;
            this.textBoxMacroName.ShortcutsEnabled = true;
            this.textBoxMacroName.Size = new System.Drawing.Size(328, 48);
            this.textBoxMacroName.SkipLiterals = true;
            this.textBoxMacroName.TabIndex = 47;
            this.textBoxMacroName.TabStop = false;
            this.textBoxMacroName.Text = "Макро 1";
            this.textBoxMacroName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxMacroName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.textBoxMacroName.TrailingIcon = null;
            this.textBoxMacroName.UseSystemPasswordChar = false;
            this.textBoxMacroName.ValidatingType = null;
            // 
            // btnCreateMacro
            // 
            this.btnCreateMacro.AutoSize = false;
            this.btnCreateMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateMacro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCreateMacro.Depth = 0;
            this.btnCreateMacro.HighEmphasis = true;
            this.btnCreateMacro.Icon = null;
            this.btnCreateMacro.Location = new System.Drawing.Point(40, 837);
            this.btnCreateMacro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCreateMacro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreateMacro.Name = "btnCreateMacro";
            this.btnCreateMacro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCreateMacro.Size = new System.Drawing.Size(328, 40);
            this.btnCreateMacro.TabIndex = 48;
            this.btnCreateMacro.Text = "Създай Макрото";
            this.btnCreateMacro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCreateMacro.UseAccentColor = false;
            this.btnCreateMacro.UseVisualStyleBackColor = true;
            // 
            // lstAvailableMacros
            // 
            this.lstAvailableMacros.BackColor = System.Drawing.Color.White;
            this.lstAvailableMacros.BorderColor = System.Drawing.Color.LightGray;
            this.lstAvailableMacros.Depth = 0;
            this.lstAvailableMacros.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstAvailableMacros.Location = new System.Drawing.Point(44, 19);
            this.lstAvailableMacros.MouseState = MaterialSkin.MouseState.HOVER;
            this.lstAvailableMacros.Name = "lstAvailableMacros";
            this.lstAvailableMacros.SelectedIndex = -1;
            this.lstAvailableMacros.SelectedItem = null;
            this.lstAvailableMacros.Size = new System.Drawing.Size(319, 102);
            this.lstAvailableMacros.TabIndex = 0;
            // 
            // textBoxDisplayMacroInfo
            // 
            this.textBoxDisplayMacroInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxDisplayMacroInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDisplayMacroInfo.Depth = 0;
            this.textBoxDisplayMacroInfo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDisplayMacroInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxDisplayMacroInfo.Location = new System.Drawing.Point(44, 137);
            this.textBoxDisplayMacroInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxDisplayMacroInfo.Name = "textBoxDisplayMacroInfo";
            this.textBoxDisplayMacroInfo.ReadOnly = true;
            this.textBoxDisplayMacroInfo.Size = new System.Drawing.Size(319, 149);
            this.textBoxDisplayMacroInfo.TabIndex = 2;
            this.textBoxDisplayMacroInfo.Text = "Макро информация:";
            // 
            // countAllMacroRepeat
            // 
            this.countAllMacroRepeat.Location = new System.Drawing.Point(256, 301);
            this.countAllMacroRepeat.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.countAllMacroRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countAllMacroRepeat.Name = "countAllMacroRepeat";
            this.countAllMacroRepeat.Size = new System.Drawing.Size(60, 22);
            this.countAllMacroRepeat.TabIndex = 36;
            this.countAllMacroRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // materialLabel6
            // 
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(44, 301);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(234, 22);
            this.materialLabel6.TabIndex = 35;
            this.materialLabel6.Text = "Пъти на изпълнение:";
            this.materialLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstMacrosForExecute
            // 
            this.lstMacrosForExecute.AccessibleDescription = "";
            this.lstMacrosForExecute.BackColor = System.Drawing.Color.White;
            this.lstMacrosForExecute.BorderColor = System.Drawing.Color.LightGray;
            this.lstMacrosForExecute.Depth = 0;
            this.lstMacrosForExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstMacrosForExecute.Location = new System.Drawing.Point(92, 341);
            this.lstMacrosForExecute.MouseState = MaterialSkin.MouseState.HOVER;
            this.lstMacrosForExecute.Name = "lstMacrosForExecute";
            this.lstMacrosForExecute.SelectedIndex = -1;
            this.lstMacrosForExecute.SelectedItem = null;
            this.lstMacrosForExecute.Size = new System.Drawing.Size(186, 137);
            this.lstMacrosForExecute.TabIndex = 37;
            // 
            // btnMacroForExecuteDelete
            // 
            this.btnMacroForExecuteDelete.AutoSize = false;
            this.btnMacroForExecuteDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMacroForExecuteDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMacroForExecuteDelete.Depth = 0;
            this.btnMacroForExecuteDelete.HighEmphasis = true;
            this.btnMacroForExecuteDelete.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_delete_32;
            this.btnMacroForExecuteDelete.Location = new System.Drawing.Point(47, 438);
            this.btnMacroForExecuteDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMacroForExecuteDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMacroForExecuteDelete.Name = "btnMacroForExecuteDelete";
            this.btnMacroForExecuteDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMacroForExecuteDelete.Size = new System.Drawing.Size(40, 40);
            this.btnMacroForExecuteDelete.TabIndex = 49;
            this.btnMacroForExecuteDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMacroForExecuteDelete.UseAccentColor = false;
            this.btnMacroForExecuteDelete.UseVisualStyleBackColor = true;
            // 
            // btnMoveDownMacro
            // 
            this.btnMoveDownMacro.AutoSize = false;
            this.btnMoveDownMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveDownMacro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMoveDownMacro.Depth = 0;
            this.btnMoveDownMacro.HighEmphasis = true;
            this.btnMoveDownMacro.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_down_32;
            this.btnMoveDownMacro.Location = new System.Drawing.Point(47, 390);
            this.btnMoveDownMacro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMoveDownMacro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveDownMacro.Name = "btnMoveDownMacro";
            this.btnMoveDownMacro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMoveDownMacro.Size = new System.Drawing.Size(40, 40);
            this.btnMoveDownMacro.TabIndex = 48;
            this.btnMoveDownMacro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMoveDownMacro.UseAccentColor = false;
            this.btnMoveDownMacro.UseVisualStyleBackColor = true;
            // 
            // btnMoveUpMacro
            // 
            this.btnMoveUpMacro.AutoSize = false;
            this.btnMoveUpMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveUpMacro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMoveUpMacro.Depth = 0;
            this.btnMoveUpMacro.HighEmphasis = true;
            this.btnMoveUpMacro.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_up_32;
            this.btnMoveUpMacro.Location = new System.Drawing.Point(47, 341);
            this.btnMoveUpMacro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMoveUpMacro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveUpMacro.Name = "btnMoveUpMacro";
            this.btnMoveUpMacro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMoveUpMacro.Size = new System.Drawing.Size(40, 40);
            this.btnMoveUpMacro.TabIndex = 47;
            this.btnMoveUpMacro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMoveUpMacro.UseAccentColor = false;
            this.btnMoveUpMacro.UseVisualStyleBackColor = true;
            // 
            // chkAllMacrosToExecute
            // 
            this.chkAllMacrosToExecute.Depth = 0;
            this.chkAllMacrosToExecute.Location = new System.Drawing.Point(92, 484);
            this.chkAllMacrosToExecute.Margin = new System.Windows.Forms.Padding(0);
            this.chkAllMacrosToExecute.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkAllMacrosToExecute.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkAllMacrosToExecute.Name = "chkAllMacrosToExecute";
            this.chkAllMacrosToExecute.ReadOnly = false;
            this.chkAllMacrosToExecute.Ripple = true;
            this.chkAllMacrosToExecute.Size = new System.Drawing.Size(271, 40);
            this.chkAllMacrosToExecute.TabIndex = 50;
            this.chkAllMacrosToExecute.Text = "Изпълни всички от списъка ";
            this.chkAllMacrosToExecute.UseVisualStyleBackColor = true;
            // 
            // btnStopMacro
            // 
            this.btnStopMacro.AutoSize = false;
            this.btnStopMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStopMacro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStopMacro.Depth = 0;
            this.btnStopMacro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopMacro.HighEmphasis = true;
            this.btnStopMacro.Icon = null;
            this.btnStopMacro.Location = new System.Drawing.Point(212, 539);
            this.btnStopMacro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStopMacro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStopMacro.Name = "btnStopMacro";
            this.btnStopMacro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStopMacro.Size = new System.Drawing.Size(150, 40);
            this.btnStopMacro.TabIndex = 52;
            this.btnStopMacro.Text = "Спри";
            this.btnStopMacro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStopMacro.UseAccentColor = false;
            this.btnStopMacro.UseVisualStyleBackColor = true;
            // 
            // btnExecuteMacro
            // 
            this.btnExecuteMacro.AutoSize = false;
            this.btnExecuteMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExecuteMacro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExecuteMacro.Depth = 0;
            this.btnExecuteMacro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExecuteMacro.HighEmphasis = true;
            this.btnExecuteMacro.Icon = null;
            this.btnExecuteMacro.Location = new System.Drawing.Point(44, 539);
            this.btnExecuteMacro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExecuteMacro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExecuteMacro.Name = "btnExecuteMacro";
            this.btnExecuteMacro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExecuteMacro.Size = new System.Drawing.Size(150, 40);
            this.btnExecuteMacro.TabIndex = 51;
            this.btnExecuteMacro.Text = "Изпълни";
            this.btnExecuteMacro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExecuteMacro.UseAccentColor = false;
            this.btnExecuteMacro.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusLabel.Depth = 0;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusLabel.Location = new System.Drawing.Point(43, 598);
            this.StatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(319, 64);
            this.StatusLabel.TabIndex = 53;
            this.StatusLabel.Text = "Полседно действие:";
            // 
            // richTextBoxLogInfo
            // 
            this.richTextBoxLogInfo.Location = new System.Drawing.Point(42, 685);
            this.richTextBoxLogInfo.Name = "richTextBoxLogInfo";
            this.richTextBoxLogInfo.ReadOnly = true;
            this.richTextBoxLogInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLogInfo.Size = new System.Drawing.Size(320, 141);
            this.richTextBoxLogInfo.TabIndex = 54;
            this.richTextBoxLogInfo.Text = "Хронология . . .";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 950);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form2";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кликер";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationInput)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countAllMacroRepeat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage4;
        private MaterialSkin.Controls.MaterialCheckbox chkReturnMouseToOriginal;
        private MaterialSkin.Controls.MaterialComboBox cmbActionType;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtY;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtX;
        private MaterialSkin.Controls.MaterialLabel LastClickLabel;
        private MaterialSkin.Controls.MaterialLabel CurrentPositionLabel;
        private MaterialSkin.Controls.MaterialButton btnStopRecording;
        private MaterialSkin.Controls.MaterialButton btnStartRecording;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.NumericUpDown CountInput;
        private System.Windows.Forms.NumericUpDown FrequencyInput;
        private System.Windows.Forms.NumericUpDown DurationInput;
        private MaterialSkin.Controls.MaterialMaskedTextBox textBoxActionName;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.NumericUpDown numericDelayBefore;
        private System.Windows.Forms.NumericUpDown numericDelay;
        private MaterialSkin.Controls.MaterialButton btnAddAction;
        private MaterialSkin.Controls.MaterialListBox lstAvailableActions;
        private MaterialSkin.Controls.MaterialButton btnMoveUpAction;
        private MaterialSkin.Controls.MaterialButton btnActionDelete;
        private MaterialSkin.Controls.MaterialButton btnMoveDownAction;
        private MaterialSkin.Controls.MaterialMaskedTextBox textBoxMacroName;
        private MaterialSkin.Controls.MaterialButton btnCreateMacro;
        private MaterialSkin.Controls.MaterialListBox lstAvailableMacros;
        private MaterialSkin.Controls.MaterialMultiLineTextBox textBoxDisplayMacroInfo;
        private System.Windows.Forms.NumericUpDown countAllMacroRepeat;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialListBox lstMacrosForExecute;
        private MaterialSkin.Controls.MaterialButton btnMacroForExecuteDelete;
        private MaterialSkin.Controls.MaterialButton btnMoveDownMacro;
        private MaterialSkin.Controls.MaterialButton btnMoveUpMacro;
        private MaterialSkin.Controls.MaterialCheckbox chkAllMacrosToExecute;
        private MaterialSkin.Controls.MaterialButton btnStopMacro;
        private MaterialSkin.Controls.MaterialButton btnExecuteMacro;
        private MaterialSkin.Controls.MaterialMultiLineTextBox StatusLabel;
        private System.Windows.Forms.RichTextBox richTextBoxLogInfo;
    }
}