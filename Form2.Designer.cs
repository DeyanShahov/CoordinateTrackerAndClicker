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
            this.btnCloseCardActionInfo = new MaterialSkin.Controls.MaterialButton();
            this.groupBoxActionInfo = new System.Windows.Forms.GroupBox();
            this.TextBoxlabelDisplayActionInfo = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.CountInputSlider = new MaterialSkin.Controls.MaterialSlider();
            this.DurationInputSlider = new MaterialSkin.Controls.MaterialSlider();
            this.FrequencyInputSlider = new MaterialSkin.Controls.MaterialSlider();
            this.chkReturnMouseToOriginal = new MaterialSkin.Controls.MaterialCheckbox();
            this.StatusLabel2 = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.txtY = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtX = new MaterialSkin.Controls.MaterialTextBox2();
            this.numericDelaySlider = new MaterialSkin.Controls.MaterialSlider();
            this.numericDelayBeforeSlider = new MaterialSkin.Controls.MaterialSlider();
            this.btnCreateMacro = new MaterialSkin.Controls.MaterialButton();
            this.textBoxMacroName = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.btnActionDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnMoveDownAction = new MaterialSkin.Controls.MaterialButton();
            this.btnMoveUpAction = new MaterialSkin.Controls.MaterialButton();
            this.lstAvailableActions = new MaterialSkin.Controls.MaterialListBox();
            this.btnAddAction = new MaterialSkin.Controls.MaterialButton();
            this.textBoxActionName = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.cmbActionType = new MaterialSkin.Controls.MaterialComboBox();
            this.LastClickLabel = new MaterialSkin.Controls.MaterialLabel();
            this.CurrentPositionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.btnStopRecording = new MaterialSkin.Controls.MaterialButton();
            this.btnStartRecording = new MaterialSkin.Controls.MaterialButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBoxLogInfo = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.ProgressBarExecuteMacros = new MaterialSkin.Controls.MaterialProgressBar();
            this.countAllMacroRepeatSlider = new MaterialSkin.Controls.MaterialSlider();
            this.btnNewSavePath = new MaterialSkin.Controls.MaterialButton();
            this.btnMacroDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnMacroSave = new MaterialSkin.Controls.MaterialButton();
            this.StatusLabel = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.btnStopMacro = new MaterialSkin.Controls.MaterialButton();
            this.btnExecuteMacro = new MaterialSkin.Controls.MaterialButton();
            this.chkAllMacrosToExecute = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnMacroForExecuteDelete = new MaterialSkin.Controls.MaterialButton();
            this.lstMacrosForExecute = new MaterialSkin.Controls.MaterialListBox();
            this.textBoxDisplayMacroInfo = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.lstAvailableMacros = new MaterialSkin.Controls.MaterialListBox();
            this.SliderMacroForExecuteSlot1 = new MaterialSkin.Controls.MaterialSlider();
            this.SliderMacroForExecuteSlot2 = new MaterialSkin.Controls.MaterialSlider();
            this.SliderMacroForExecuteSlot3 = new MaterialSkin.Controls.MaterialSlider();
            this.SliderMacroForExecuteSlot4 = new MaterialSkin.Controls.MaterialSlider();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.CheckboxInfo = new MaterialSkin.Controls.MaterialCheckbox();
            this.CheckboxSuccess = new MaterialSkin.Controls.MaterialCheckbox();
            this.CheckboxError = new MaterialSkin.Controls.MaterialCheckbox();
            this.BtnSwitchModalAlert = new MaterialSkin.Controls.MaterialSwitch();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioButtonBase = new MaterialSkin.Controls.MaterialRadioButton();
            this.RadioButtonBlue = new MaterialSkin.Controls.MaterialRadioButton();
            this.RadioButtonGreen = new MaterialSkin.Controls.MaterialRadioButton();
            this.RadioButtonOrange = new MaterialSkin.Controls.MaterialRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnSwitchTheme = new MaterialSkin.Controls.MaterialSwitch();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxActionInfo.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(837, 613);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.ImageKey = "icons8-home-page-32.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(829, 570);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Влизане";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxActionInfo);
            this.tabPage2.Controls.Add(this.CountInputSlider);
            this.tabPage2.Controls.Add(this.DurationInputSlider);
            this.tabPage2.Controls.Add(this.FrequencyInputSlider);
            this.tabPage2.Controls.Add(this.chkReturnMouseToOriginal);
            this.tabPage2.Controls.Add(this.StatusLabel2);
            this.tabPage2.Controls.Add(this.txtY);
            this.tabPage2.Controls.Add(this.txtX);
            this.tabPage2.Controls.Add(this.numericDelaySlider);
            this.tabPage2.Controls.Add(this.numericDelayBeforeSlider);
            this.tabPage2.Controls.Add(this.btnCreateMacro);
            this.tabPage2.Controls.Add(this.textBoxMacroName);
            this.tabPage2.Controls.Add(this.btnActionDelete);
            this.tabPage2.Controls.Add(this.btnMoveDownAction);
            this.tabPage2.Controls.Add(this.btnMoveUpAction);
            this.tabPage2.Controls.Add(this.lstAvailableActions);
            this.tabPage2.Controls.Add(this.btnAddAction);
            this.tabPage2.Controls.Add(this.textBoxActionName);
            this.tabPage2.Controls.Add(this.cmbActionType);
            this.tabPage2.Controls.Add(this.LastClickLabel);
            this.tabPage2.Controls.Add(this.CurrentPositionLabel);
            this.tabPage2.Controls.Add(this.btnStopRecording);
            this.tabPage2.Controls.Add(this.btnStartRecording);
            this.tabPage2.ImageKey = "icons8-tune-32.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(829, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Създай макро";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCloseCardActionInfo
            // 
            this.btnCloseCardActionInfo.AutoSize = false;
            this.btnCloseCardActionInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCloseCardActionInfo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCloseCardActionInfo.Depth = 0;
            this.btnCloseCardActionInfo.HighEmphasis = true;
            this.btnCloseCardActionInfo.Icon = null;
            this.btnCloseCardActionInfo.Location = new System.Drawing.Point(261, 0);
            this.btnCloseCardActionInfo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCloseCardActionInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCloseCardActionInfo.Name = "btnCloseCardActionInfo";
            this.btnCloseCardActionInfo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCloseCardActionInfo.Size = new System.Drawing.Size(25, 25);
            this.btnCloseCardActionInfo.TabIndex = 0;
            this.btnCloseCardActionInfo.Text = "X";
            this.btnCloseCardActionInfo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCloseCardActionInfo.UseAccentColor = false;
            this.btnCloseCardActionInfo.UseVisualStyleBackColor = true;
            this.btnCloseCardActionInfo.Click += new System.EventHandler(this.BtnCloseCardActionInfo_Click);
            // 
            // groupBoxActionInfo
            // 
            this.groupBoxActionInfo.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxActionInfo.Controls.Add(this.btnCloseCardActionInfo);
            this.groupBoxActionInfo.Controls.Add(this.TextBoxlabelDisplayActionInfo);
            this.groupBoxActionInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxActionInfo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxActionInfo.Location = new System.Drawing.Point(115, 202);
            this.groupBoxActionInfo.Name = "groupBoxActionInfo";
            this.groupBoxActionInfo.Size = new System.Drawing.Size(297, 240);
            this.groupBoxActionInfo.TabIndex = 4;
            this.groupBoxActionInfo.TabStop = false;
            this.groupBoxActionInfo.Text = "Информация действие ━━━━━━━━━━━━━━━━━              ";
            this.groupBoxActionInfo.Visible = false;
            // 
            // TextBoxlabelDisplayActionInfo
            // 
            this.TextBoxlabelDisplayActionInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TextBoxlabelDisplayActionInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxlabelDisplayActionInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBoxlabelDisplayActionInfo.Depth = 0;
            this.TextBoxlabelDisplayActionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxlabelDisplayActionInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxlabelDisplayActionInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TextBoxlabelDisplayActionInfo.Location = new System.Drawing.Point(3, 31);
            this.TextBoxlabelDisplayActionInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.TextBoxlabelDisplayActionInfo.Name = "TextBoxlabelDisplayActionInfo";
            this.TextBoxlabelDisplayActionInfo.ReadOnly = true;
            this.TextBoxlabelDisplayActionInfo.Size = new System.Drawing.Size(291, 206);
            this.TextBoxlabelDisplayActionInfo.TabIndex = 3;
            this.TextBoxlabelDisplayActionInfo.Text = " .  .  . ";
            // 
            // CountInputSlider
            // 
            this.CountInputSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CountInputSlider.Depth = 0;
            this.CountInputSlider.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CountInputSlider.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.CountInputSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CountInputSlider.Location = new System.Drawing.Point(40, 402);
            this.CountInputSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.CountInputSlider.Name = "CountInputSlider";
            this.CountInputSlider.RangeMin = 1;
            this.CountInputSlider.Size = new System.Drawing.Size(328, 40);
            this.CountInputSlider.TabIndex = 52;
            this.CountInputSlider.Text = "Пъти на изпълнение             ";
            this.CountInputSlider.Value = 1;
            this.CountInputSlider.ValueMax = 100;
            this.CountInputSlider.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.CountInputSlider_onValueChanged);
            // 
            // DurationInputSlider
            // 
            this.DurationInputSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DurationInputSlider.Depth = 0;
            this.DurationInputSlider.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DurationInputSlider.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.DurationInputSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DurationInputSlider.Location = new System.Drawing.Point(40, 362);
            this.DurationInputSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.DurationInputSlider.Name = "DurationInputSlider";
            this.DurationInputSlider.RangeMin = 1;
            this.DurationInputSlider.Size = new System.Drawing.Size(328, 40);
            this.DurationInputSlider.TabIndex = 51;
            this.DurationInputSlider.Text = "Продължителност (мин)     ";
            this.DurationInputSlider.Value = 1;
            this.DurationInputSlider.ValueMax = 100;
            this.DurationInputSlider.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.DurationInputSlider_onValueChanged);
            // 
            // FrequencyInputSlider
            // 
            this.FrequencyInputSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FrequencyInputSlider.Depth = 0;
            this.FrequencyInputSlider.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FrequencyInputSlider.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.FrequencyInputSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FrequencyInputSlider.Location = new System.Drawing.Point(40, 322);
            this.FrequencyInputSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.FrequencyInputSlider.Name = "FrequencyInputSlider";
            this.FrequencyInputSlider.RangeMin = 1;
            this.FrequencyInputSlider.Size = new System.Drawing.Size(328, 40);
            this.FrequencyInputSlider.TabIndex = 49;
            this.FrequencyInputSlider.Text = "Честота (секунди)                  ";
            this.FrequencyInputSlider.Value = 1;
            this.FrequencyInputSlider.ValueMax = 100;
            this.FrequencyInputSlider.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.FrequencyInputSlider_onValueChanged);
            // 
            // chkReturnMouseToOriginal
            // 
            this.chkReturnMouseToOriginal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkReturnMouseToOriginal.Depth = 0;
            this.chkReturnMouseToOriginal.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkReturnMouseToOriginal.Location = new System.Drawing.Point(40, 282);
            this.chkReturnMouseToOriginal.Margin = new System.Windows.Forms.Padding(0);
            this.chkReturnMouseToOriginal.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkReturnMouseToOriginal.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkReturnMouseToOriginal.Name = "chkReturnMouseToOriginal";
            this.chkReturnMouseToOriginal.ReadOnly = false;
            this.chkReturnMouseToOriginal.Ripple = true;
            this.chkReturnMouseToOriginal.Size = new System.Drawing.Size(328, 40);
            this.chkReturnMouseToOriginal.TabIndex = 27;
            this.chkReturnMouseToOriginal.Text = "Завръщане на оригиналната позиция";
            this.chkReturnMouseToOriginal.UseVisualStyleBackColor = true;
            // 
            // StatusLabel2
            // 
            this.StatusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.StatusLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusLabel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StatusLabel2.Depth = 0;
            this.StatusLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusLabel2.Hint = "Полседно действие:";
            this.StatusLabel2.Location = new System.Drawing.Point(40, 540);
            this.StatusLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.StatusLabel2.Name = "StatusLabel2";
            this.StatusLabel2.ReadOnly = true;
            this.StatusLabel2.Size = new System.Drawing.Size(706, 35);
            this.StatusLabel2.TabIndex = 58;
            this.StatusLabel2.Text = "";
            // 
            // txtY
            // 
            this.txtY.AnimateReadOnly = false;
            this.txtY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtY.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtY.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtY.Depth = 0;
            this.txtY.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtY.HideSelection = true;
            this.txtY.Hint = "кординат  Y";
            this.txtY.LeadingIcon = null;
            this.txtY.Location = new System.Drawing.Point(208, 148);
            this.txtY.MaxLength = 32767;
            this.txtY.MouseState = MaterialSkin.MouseState.OUT;
            this.txtY.Name = "txtY";
            this.txtY.PasswordChar = '\0';
            this.txtY.PrefixSuffixText = null;
            this.txtY.ReadOnly = true;
            this.txtY.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtY.SelectedText = "";
            this.txtY.SelectionLength = 0;
            this.txtY.SelectionStart = 0;
            this.txtY.ShortcutsEnabled = true;
            this.txtY.Size = new System.Drawing.Size(160, 48);
            this.txtY.TabIndex = 57;
            this.txtY.TabStop = false;
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtY.TrailingIcon = null;
            this.txtY.UseSystemPasswordChar = false;
            // 
            // txtX
            // 
            this.txtX.AnimateReadOnly = false;
            this.txtX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtX.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtX.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtX.Depth = 0;
            this.txtX.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtX.HideSelection = true;
            this.txtX.Hint = "кординат X ";
            this.txtX.LeadingIcon = null;
            this.txtX.Location = new System.Drawing.Point(40, 148);
            this.txtX.MaxLength = 32767;
            this.txtX.MouseState = MaterialSkin.MouseState.OUT;
            this.txtX.Name = "txtX";
            this.txtX.PasswordChar = '\0';
            this.txtX.PrefixSuffixText = null;
            this.txtX.ReadOnly = true;
            this.txtX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtX.SelectedText = "";
            this.txtX.SelectionLength = 0;
            this.txtX.SelectionStart = 0;
            this.txtX.ShortcutsEnabled = true;
            this.txtX.Size = new System.Drawing.Size(160, 48);
            this.txtX.TabIndex = 56;
            this.txtX.TabStop = false;
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtX.TrailingIcon = null;
            this.txtX.UseSystemPasswordChar = false;
            // 
            // numericDelaySlider
            // 
            this.numericDelaySlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericDelaySlider.Depth = 0;
            this.numericDelaySlider.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericDelaySlider.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.numericDelaySlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numericDelaySlider.Location = new System.Drawing.Point(419, 119);
            this.numericDelaySlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.numericDelaySlider.Name = "numericDelaySlider";
            this.numericDelaySlider.RangeMax = 10000;
            this.numericDelaySlider.RangeMin = 1000;
            this.numericDelaySlider.Size = new System.Drawing.Size(328, 40);
            this.numericDelaySlider.TabIndex = 54;
            this.numericDelaySlider.Text = "Забавяне след (мс)               ";
            this.numericDelaySlider.Value = 1000;
            this.numericDelaySlider.ValueMax = 10000;
            this.numericDelaySlider.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.numericDelaySlider_onValueChanged);
            this.numericDelaySlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numericDelaySlider_MouseUp);
            // 
            // numericDelayBeforeSlider
            // 
            this.numericDelayBeforeSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericDelayBeforeSlider.Depth = 0;
            this.numericDelayBeforeSlider.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericDelayBeforeSlider.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.numericDelayBeforeSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numericDelayBeforeSlider.Location = new System.Drawing.Point(419, 79);
            this.numericDelayBeforeSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.numericDelayBeforeSlider.Name = "numericDelayBeforeSlider";
            this.numericDelayBeforeSlider.RangeMax = 10000;
            this.numericDelayBeforeSlider.RangeMin = 1000;
            this.numericDelayBeforeSlider.Size = new System.Drawing.Size(328, 40);
            this.numericDelayBeforeSlider.TabIndex = 53;
            this.numericDelayBeforeSlider.Text = "Забавяне преди (мс)            ";
            this.numericDelayBeforeSlider.Value = 1000;
            this.numericDelayBeforeSlider.ValueMax = 10000;
            this.numericDelayBeforeSlider.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.numericDelayBeforeSlider_onValueChanged);
            this.numericDelayBeforeSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NumericDelayBeforeSlider_MouseUp);
            // 
            // btnCreateMacro
            // 
            this.btnCreateMacro.AutoSize = false;
            this.btnCreateMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateMacro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateMacro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCreateMacro.Depth = 0;
            this.btnCreateMacro.HighEmphasis = true;
            this.btnCreateMacro.Icon = null;
            this.btnCreateMacro.Location = new System.Drawing.Point(418, 483);
            this.btnCreateMacro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCreateMacro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreateMacro.Name = "btnCreateMacro";
            this.btnCreateMacro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCreateMacro.Size = new System.Drawing.Size(328, 48);
            this.btnCreateMacro.TabIndex = 48;
            this.btnCreateMacro.Text = "Създай Макрото";
            this.btnCreateMacro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCreateMacro.UseAccentColor = false;
            this.btnCreateMacro.UseVisualStyleBackColor = true;
            this.btnCreateMacro.Click += new System.EventHandler(this.BtnCreateMacro_Click);
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
            this.textBoxMacroName.Location = new System.Drawing.Point(40, 483);
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
            // btnActionDelete
            // 
            this.btnActionDelete.AutoSize = false;
            this.btnActionDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActionDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActionDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActionDelete.Depth = 0;
            this.btnActionDelete.HighEmphasis = true;
            this.btnActionDelete.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_delete_32;
            this.btnActionDelete.Location = new System.Drawing.Point(419, 334);
            this.btnActionDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActionDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActionDelete.Name = "btnActionDelete";
            this.btnActionDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActionDelete.Size = new System.Drawing.Size(40, 40);
            this.btnActionDelete.TabIndex = 46;
            this.btnActionDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnActionDelete.UseAccentColor = false;
            this.btnActionDelete.UseVisualStyleBackColor = true;
            this.btnActionDelete.Click += new System.EventHandler(this.BtnActionDelete_Click);
            // 
            // btnMoveDownAction
            // 
            this.btnMoveDownAction.AutoSize = false;
            this.btnMoveDownAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveDownAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveDownAction.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMoveDownAction.Depth = 0;
            this.btnMoveDownAction.HighEmphasis = true;
            this.btnMoveDownAction.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_down_32;
            this.btnMoveDownAction.Location = new System.Drawing.Point(418, 285);
            this.btnMoveDownAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMoveDownAction.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveDownAction.Name = "btnMoveDownAction";
            this.btnMoveDownAction.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMoveDownAction.Size = new System.Drawing.Size(40, 40);
            this.btnMoveDownAction.TabIndex = 45;
            this.btnMoveDownAction.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMoveDownAction.UseAccentColor = false;
            this.btnMoveDownAction.UseVisualStyleBackColor = true;
            this.btnMoveDownAction.Click += new System.EventHandler(this.BtnMoveDownAction_Click);
            // 
            // btnMoveUpAction
            // 
            this.btnMoveUpAction.AutoSize = false;
            this.btnMoveUpAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveUpAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveUpAction.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMoveUpAction.Depth = 0;
            this.btnMoveUpAction.HighEmphasis = true;
            this.btnMoveUpAction.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_up_32;
            this.btnMoveUpAction.Location = new System.Drawing.Point(418, 237);
            this.btnMoveUpAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMoveUpAction.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveUpAction.Name = "btnMoveUpAction";
            this.btnMoveUpAction.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMoveUpAction.Size = new System.Drawing.Size(40, 40);
            this.btnMoveUpAction.TabIndex = 44;
            this.btnMoveUpAction.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMoveUpAction.UseAccentColor = false;
            this.btnMoveUpAction.UseVisualStyleBackColor = true;
            this.btnMoveUpAction.Click += new System.EventHandler(this.BtnMoveUpAction_Click);
            // 
            // lstAvailableActions
            // 
            this.lstAvailableActions.BackColor = System.Drawing.Color.White;
            this.lstAvailableActions.BorderColor = System.Drawing.Color.LightGray;
            this.lstAvailableActions.Depth = 0;
            this.lstAvailableActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstAvailableActions.Location = new System.Drawing.Point(466, 237);
            this.lstAvailableActions.MouseState = MaterialSkin.MouseState.HOVER;
            this.lstAvailableActions.Name = "lstAvailableActions";
            this.lstAvailableActions.SelectedIndex = -1;
            this.lstAvailableActions.SelectedItem = null;
            this.lstAvailableActions.Size = new System.Drawing.Size(280, 205);
            this.lstAvailableActions.TabIndex = 43;
            this.lstAvailableActions.SelectedIndexChanged += new MaterialSkin.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.lstAvailableActions_SelectedIndexChanged);
            this.lstAvailableActions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstAvailableActions_MouseDoubleClick);
            // 
            // btnAddAction
            // 
            this.btnAddAction.AutoSize = false;
            this.btnAddAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAction.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddAction.Depth = 0;
            this.btnAddAction.HighEmphasis = true;
            this.btnAddAction.Icon = null;
            this.btnAddAction.Location = new System.Drawing.Point(418, 173);
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
            this.btnAddAction.Click += new System.EventHandler(this.BtnAddAction_Click);
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
            this.textBoxActionName.Location = new System.Drawing.Point(418, 19);
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
            this.cmbActionType.Location = new System.Drawing.Point(40, 217);
            this.cmbActionType.MaxDropDownItems = 4;
            this.cmbActionType.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.Size = new System.Drawing.Size(328, 49);
            this.cmbActionType.StartIndex = 0;
            this.cmbActionType.TabIndex = 26;
            // 
            // LastClickLabel
            // 
            this.LastClickLabel.Depth = 0;
            this.LastClickLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LastClickLabel.Location = new System.Drawing.Point(41, 109);
            this.LastClickLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.LastClickLabel.Name = "LastClickLabel";
            this.LastClickLabel.Size = new System.Drawing.Size(328, 19);
            this.LastClickLabel.TabIndex = 23;
            this.LastClickLabel.Text = "Последно кликане: ";
            this.LastClickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentPositionLabel
            // 
            this.CurrentPositionLabel.Depth = 0;
            this.CurrentPositionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CurrentPositionLabel.Location = new System.Drawing.Point(41, 79);
            this.CurrentPositionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.CurrentPositionLabel.Name = "CurrentPositionLabel";
            this.CurrentPositionLabel.Size = new System.Drawing.Size(328, 19);
            this.CurrentPositionLabel.TabIndex = 22;
            this.CurrentPositionLabel.Text = "Текуща позиция . . .";
            this.CurrentPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.AutoSize = false;
            this.btnStopRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStopRecording.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnStopRecording.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.AutoSize = false;
            this.btnStartRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartRecording.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnStartRecording.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBoxLogInfo);
            this.tabPage3.Controls.Add(this.ProgressBarExecuteMacros);
            this.tabPage3.Controls.Add(this.countAllMacroRepeatSlider);
            this.tabPage3.Controls.Add(this.btnNewSavePath);
            this.tabPage3.Controls.Add(this.btnMacroDelete);
            this.tabPage3.Controls.Add(this.btnMacroSave);
            this.tabPage3.Controls.Add(this.StatusLabel);
            this.tabPage3.Controls.Add(this.btnStopMacro);
            this.tabPage3.Controls.Add(this.btnExecuteMacro);
            this.tabPage3.Controls.Add(this.chkAllMacrosToExecute);
            this.tabPage3.Controls.Add(this.btnMacroForExecuteDelete);
            this.tabPage3.Controls.Add(this.lstMacrosForExecute);
            this.tabPage3.Controls.Add(this.textBoxDisplayMacroInfo);
            this.tabPage3.Controls.Add(this.lstAvailableMacros);
            this.tabPage3.Controls.Add(this.SliderMacroForExecuteSlot1);
            this.tabPage3.Controls.Add(this.SliderMacroForExecuteSlot2);
            this.tabPage3.Controls.Add(this.SliderMacroForExecuteSlot3);
            this.tabPage3.Controls.Add(this.SliderMacroForExecuteSlot4);
            this.tabPage3.ImageKey = "icons8-work-32.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(829, 570);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Използвай макро";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLogInfo
            // 
            this.richTextBoxLogInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.richTextBoxLogInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxLogInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxLogInfo.Depth = 0;
            this.richTextBoxLogInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richTextBoxLogInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBoxLogInfo.Location = new System.Drawing.Point(409, 428);
            this.richTextBoxLogInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.richTextBoxLogInfo.Name = "richTextBoxLogInfo";
            this.richTextBoxLogInfo.ReadOnly = true;
            this.richTextBoxLogInfo.Size = new System.Drawing.Size(319, 169);
            this.richTextBoxLogInfo.TabIndex = 70;
            this.richTextBoxLogInfo.Text = "Хронология . . .";
            // 
            // ProgressBarExecuteMacros
            // 
            this.ProgressBarExecuteMacros.Depth = 0;
            this.ProgressBarExecuteMacros.Location = new System.Drawing.Point(409, 334);
            this.ProgressBarExecuteMacros.MouseState = MaterialSkin.MouseState.HOVER;
            this.ProgressBarExecuteMacros.Name = "ProgressBarExecuteMacros";
            this.ProgressBarExecuteMacros.Size = new System.Drawing.Size(319, 5);
            this.ProgressBarExecuteMacros.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBarExecuteMacros.TabIndex = 60;
            // 
            // countAllMacroRepeatSlider
            // 
            this.countAllMacroRepeatSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.countAllMacroRepeatSlider.Depth = 0;
            this.countAllMacroRepeatSlider.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.countAllMacroRepeatSlider.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.countAllMacroRepeatSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.countAllMacroRepeatSlider.Location = new System.Drawing.Point(409, 16);
            this.countAllMacroRepeatSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.countAllMacroRepeatSlider.Name = "countAllMacroRepeatSlider";
            this.countAllMacroRepeatSlider.RangeMin = 1;
            this.countAllMacroRepeatSlider.Size = new System.Drawing.Size(319, 40);
            this.countAllMacroRepeatSlider.TabIndex = 59;
            this.countAllMacroRepeatSlider.Text = "Пъти на изпълнение";
            this.countAllMacroRepeatSlider.Value = 1;
            this.countAllMacroRepeatSlider.ValueMax = 100;
            this.countAllMacroRepeatSlider.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.countAllMacroRepeatSlider_onValueChanged);
            // 
            // btnNewSavePath
            // 
            this.btnNewSavePath.AutoSize = false;
            this.btnNewSavePath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewSavePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewSavePath.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNewSavePath.Depth = 0;
            this.btnNewSavePath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewSavePath.HighEmphasis = true;
            this.btnNewSavePath.Icon = null;
            this.btnNewSavePath.Location = new System.Drawing.Point(285, 383);
            this.btnNewSavePath.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNewSavePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNewSavePath.Name = "btnNewSavePath";
            this.btnNewSavePath.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNewSavePath.Size = new System.Drawing.Size(78, 30);
            this.btnNewSavePath.TabIndex = 57;
            this.btnNewSavePath.Text = "Локация";
            this.btnNewSavePath.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNewSavePath.UseAccentColor = false;
            this.btnNewSavePath.UseVisualStyleBackColor = true;
            this.btnNewSavePath.Click += new System.EventHandler(this.BtnNewSavePath_Click);
            // 
            // btnMacroDelete
            // 
            this.btnMacroDelete.AutoSize = false;
            this.btnMacroDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMacroDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMacroDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMacroDelete.Depth = 0;
            this.btnMacroDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMacroDelete.HighEmphasis = true;
            this.btnMacroDelete.Icon = null;
            this.btnMacroDelete.Location = new System.Drawing.Point(169, 383);
            this.btnMacroDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMacroDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMacroDelete.Name = "btnMacroDelete";
            this.btnMacroDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMacroDelete.Size = new System.Drawing.Size(78, 30);
            this.btnMacroDelete.TabIndex = 56;
            this.btnMacroDelete.Text = "Изтрии";
            this.btnMacroDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMacroDelete.UseAccentColor = false;
            this.btnMacroDelete.UseVisualStyleBackColor = true;
            this.btnMacroDelete.Click += new System.EventHandler(this.BtnMacroDeleteFromDB_Click);
            // 
            // btnMacroSave
            // 
            this.btnMacroSave.AutoSize = false;
            this.btnMacroSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMacroSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMacroSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMacroSave.Depth = 0;
            this.btnMacroSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMacroSave.HighEmphasis = true;
            this.btnMacroSave.Icon = null;
            this.btnMacroSave.Location = new System.Drawing.Point(44, 383);
            this.btnMacroSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMacroSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMacroSave.Name = "btnMacroSave";
            this.btnMacroSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMacroSave.Size = new System.Drawing.Size(78, 30);
            this.btnMacroSave.TabIndex = 55;
            this.btnMacroSave.Text = "Запази";
            this.btnMacroSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMacroSave.UseAccentColor = false;
            this.btnMacroSave.UseVisualStyleBackColor = true;
            this.btnMacroSave.Click += new System.EventHandler(this.BtnMacroSaveToDB_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StatusLabel.Depth = 0;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusLabel.Hint = "Полседно действие:";
            this.StatusLabel.Location = new System.Drawing.Point(409, 349);
            this.StatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.ReadOnly = true;
            this.StatusLabel.Size = new System.Drawing.Size(319, 64);
            this.StatusLabel.TabIndex = 53;
            this.StatusLabel.Text = "";
            // 
            // btnStopMacro
            // 
            this.btnStopMacro.AutoSize = false;
            this.btnStopMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStopMacro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopMacro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStopMacro.Depth = 0;
            this.btnStopMacro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopMacro.HighEmphasis = true;
            this.btnStopMacro.Icon = null;
            this.btnStopMacro.Location = new System.Drawing.Point(580, 285);
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
            this.btnStopMacro.Click += new System.EventHandler(this.BtnStopMacro_Click);
            // 
            // btnExecuteMacro
            // 
            this.btnExecuteMacro.AutoSize = false;
            this.btnExecuteMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExecuteMacro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecuteMacro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExecuteMacro.Depth = 0;
            this.btnExecuteMacro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExecuteMacro.HighEmphasis = true;
            this.btnExecuteMacro.Icon = null;
            this.btnExecuteMacro.Location = new System.Drawing.Point(409, 285);
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
            this.btnExecuteMacro.Click += new System.EventHandler(this.BtnExecuteMacro_Click);
            // 
            // chkAllMacrosToExecute
            // 
            this.chkAllMacrosToExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAllMacrosToExecute.Depth = 0;
            this.chkAllMacrosToExecute.Location = new System.Drawing.Point(460, 235);
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
            this.chkAllMacrosToExecute.CheckedChanged += new System.EventHandler(this.ChkAllMacrosToExecute_CheckedChanged);
            // 
            // btnMacroForExecuteDelete
            // 
            this.btnMacroForExecuteDelete.AutoSize = false;
            this.btnMacroForExecuteDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMacroForExecuteDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMacroForExecuteDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMacroForExecuteDelete.Depth = 0;
            this.btnMacroForExecuteDelete.HighEmphasis = true;
            this.btnMacroForExecuteDelete.Icon = global::CoordinateTrackerAndClicker.Properties.Resources.icons8_delete_32;
            this.btnMacroForExecuteDelete.Location = new System.Drawing.Point(409, 234);
            this.btnMacroForExecuteDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMacroForExecuteDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMacroForExecuteDelete.Name = "btnMacroForExecuteDelete";
            this.btnMacroForExecuteDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMacroForExecuteDelete.Size = new System.Drawing.Size(40, 40);
            this.btnMacroForExecuteDelete.TabIndex = 49;
            this.btnMacroForExecuteDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMacroForExecuteDelete.UseAccentColor = false;
            this.btnMacroForExecuteDelete.UseVisualStyleBackColor = true;
            this.btnMacroForExecuteDelete.Click += new System.EventHandler(this.BtnMacroForExecuteDelete_Click);
            // 
            // lstMacrosForExecute
            // 
            this.lstMacrosForExecute.AccessibleDescription = "";
            this.lstMacrosForExecute.BackColor = System.Drawing.Color.White;
            this.lstMacrosForExecute.BorderColor = System.Drawing.Color.LightGray;
            this.lstMacrosForExecute.Depth = 0;
            this.lstMacrosForExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstMacrosForExecute.Location = new System.Drawing.Point(409, 65);
            this.lstMacrosForExecute.MouseState = MaterialSkin.MouseState.HOVER;
            this.lstMacrosForExecute.Name = "lstMacrosForExecute";
            this.lstMacrosForExecute.SelectedIndex = -1;
            this.lstMacrosForExecute.SelectedItem = null;
            this.lstMacrosForExecute.Size = new System.Drawing.Size(186, 160);
            this.lstMacrosForExecute.TabIndex = 37;
            this.lstMacrosForExecute.SelectedIndexChanged += new MaterialSkin.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.LstMacrosForExecute_SelectedIndexChanged);
            // 
            // textBoxDisplayMacroInfo
            // 
            this.textBoxDisplayMacroInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxDisplayMacroInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDisplayMacroInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxDisplayMacroInfo.Depth = 0;
            this.textBoxDisplayMacroInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDisplayMacroInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxDisplayMacroInfo.Location = new System.Drawing.Point(44, 428);
            this.textBoxDisplayMacroInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxDisplayMacroInfo.Name = "textBoxDisplayMacroInfo";
            this.textBoxDisplayMacroInfo.ReadOnly = true;
            this.textBoxDisplayMacroInfo.Size = new System.Drawing.Size(319, 169);
            this.textBoxDisplayMacroInfo.TabIndex = 2;
            this.textBoxDisplayMacroInfo.Text = "Макро информация:";
            // 
            // lstAvailableMacros
            // 
            this.lstAvailableMacros.BackColor = System.Drawing.Color.White;
            this.lstAvailableMacros.BorderColor = System.Drawing.Color.LightGray;
            this.lstAvailableMacros.Depth = 0;
            this.lstAvailableMacros.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstAvailableMacros.Location = new System.Drawing.Point(44, 16);
            this.lstAvailableMacros.MouseState = MaterialSkin.MouseState.HOVER;
            this.lstAvailableMacros.Name = "lstAvailableMacros";
            this.lstAvailableMacros.SelectedIndex = -1;
            this.lstAvailableMacros.SelectedItem = null;
            this.lstAvailableMacros.Size = new System.Drawing.Size(319, 352);
            this.lstAvailableMacros.TabIndex = 0;
            this.lstAvailableMacros.SelectedIndexChanged += new MaterialSkin.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.LstAvailableMacros_SelectedIndexChanged);
            this.lstAvailableMacros.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstAvailableMacros_MouseDoubleClick);
            // 
            // SliderMacroForExecuteSlot1
            // 
            this.SliderMacroForExecuteSlot1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SliderMacroForExecuteSlot1.Depth = 0;
            this.SliderMacroForExecuteSlot1.Enabled = false;
            this.SliderMacroForExecuteSlot1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SliderMacroForExecuteSlot1.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.SliderMacroForExecuteSlot1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SliderMacroForExecuteSlot1.Location = new System.Drawing.Point(593, 65);
            this.SliderMacroForExecuteSlot1.MouseState = MaterialSkin.MouseState.HOVER;
            this.SliderMacroForExecuteSlot1.Name = "SliderMacroForExecuteSlot1";
            this.SliderMacroForExecuteSlot1.RangeMin = 1;
            this.SliderMacroForExecuteSlot1.Size = new System.Drawing.Size(138, 40);
            this.SliderMacroForExecuteSlot1.TabIndex = 65;
            this.SliderMacroForExecuteSlot1.Text = "";
            this.SliderMacroForExecuteSlot1.Value = 1;
            this.SliderMacroForExecuteSlot1.ValueMax = 100;
            this.SliderMacroForExecuteSlot1.Visible = false;
            this.SliderMacroForExecuteSlot1.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.SliderMacroForExecuteSlot1_onValueChanged);
            // 
            // SliderMacroForExecuteSlot2
            // 
            this.SliderMacroForExecuteSlot2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SliderMacroForExecuteSlot2.Depth = 0;
            this.SliderMacroForExecuteSlot2.Enabled = false;
            this.SliderMacroForExecuteSlot2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SliderMacroForExecuteSlot2.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.SliderMacroForExecuteSlot2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SliderMacroForExecuteSlot2.Location = new System.Drawing.Point(593, 105);
            this.SliderMacroForExecuteSlot2.MouseState = MaterialSkin.MouseState.HOVER;
            this.SliderMacroForExecuteSlot2.Name = "SliderMacroForExecuteSlot2";
            this.SliderMacroForExecuteSlot2.RangeMin = 1;
            this.SliderMacroForExecuteSlot2.Size = new System.Drawing.Size(138, 40);
            this.SliderMacroForExecuteSlot2.TabIndex = 66;
            this.SliderMacroForExecuteSlot2.Text = "";
            this.SliderMacroForExecuteSlot2.Value = 1;
            this.SliderMacroForExecuteSlot2.ValueMax = 100;
            this.SliderMacroForExecuteSlot2.Visible = false;
            this.SliderMacroForExecuteSlot2.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.SliderMacroForExecuteSlot2_onValueChanged);
            // 
            // SliderMacroForExecuteSlot3
            // 
            this.SliderMacroForExecuteSlot3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SliderMacroForExecuteSlot3.Depth = 0;
            this.SliderMacroForExecuteSlot3.Enabled = false;
            this.SliderMacroForExecuteSlot3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SliderMacroForExecuteSlot3.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.SliderMacroForExecuteSlot3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SliderMacroForExecuteSlot3.Location = new System.Drawing.Point(593, 145);
            this.SliderMacroForExecuteSlot3.MouseState = MaterialSkin.MouseState.HOVER;
            this.SliderMacroForExecuteSlot3.Name = "SliderMacroForExecuteSlot3";
            this.SliderMacroForExecuteSlot3.RangeMin = 1;
            this.SliderMacroForExecuteSlot3.Size = new System.Drawing.Size(138, 40);
            this.SliderMacroForExecuteSlot3.TabIndex = 68;
            this.SliderMacroForExecuteSlot3.Text = "";
            this.SliderMacroForExecuteSlot3.Value = 1;
            this.SliderMacroForExecuteSlot3.ValueMax = 100;
            this.SliderMacroForExecuteSlot3.Visible = false;
            this.SliderMacroForExecuteSlot3.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.SliderMacroForExecuteSlot3_onValueChanged);
            // 
            // SliderMacroForExecuteSlot4
            // 
            this.SliderMacroForExecuteSlot4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SliderMacroForExecuteSlot4.Depth = 0;
            this.SliderMacroForExecuteSlot4.Enabled = false;
            this.SliderMacroForExecuteSlot4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SliderMacroForExecuteSlot4.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.SliderMacroForExecuteSlot4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SliderMacroForExecuteSlot4.Location = new System.Drawing.Point(593, 185);
            this.SliderMacroForExecuteSlot4.MouseState = MaterialSkin.MouseState.HOVER;
            this.SliderMacroForExecuteSlot4.Name = "SliderMacroForExecuteSlot4";
            this.SliderMacroForExecuteSlot4.RangeMin = 1;
            this.SliderMacroForExecuteSlot4.Size = new System.Drawing.Size(138, 40);
            this.SliderMacroForExecuteSlot4.TabIndex = 67;
            this.SliderMacroForExecuteSlot4.Text = "";
            this.SliderMacroForExecuteSlot4.Value = 1;
            this.SliderMacroForExecuteSlot4.ValueMax = 100;
            this.SliderMacroForExecuteSlot4.Visible = false;
            this.SliderMacroForExecuteSlot4.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.SliderMacroForExecuteSlot4_onValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.ImageKey = "icons8-settings-32.png";
            this.tabPage4.Location = new System.Drawing.Point(4, 39);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(829, 570);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Настройки";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.materialLabel2);
            this.groupBox3.Controls.Add(this.CheckboxInfo);
            this.groupBox3.Controls.Add(this.CheckboxSuccess);
            this.groupBox3.Controls.Add(this.CheckboxError);
            this.groupBox3.Controls.Add(this.BtnSwitchModalAlert);
            this.groupBox3.Location = new System.Drawing.Point(228, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 169);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Модални прозорци";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(21, 27);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(55, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Спрени";
            // 
            // CheckboxInfo
            // 
            this.CheckboxInfo.Depth = 0;
            this.CheckboxInfo.Location = new System.Drawing.Point(98, 127);
            this.CheckboxInfo.Margin = new System.Windows.Forms.Padding(0);
            this.CheckboxInfo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckboxInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckboxInfo.Name = "CheckboxInfo";
            this.CheckboxInfo.ReadOnly = false;
            this.CheckboxInfo.Ripple = true;
            this.CheckboxInfo.Size = new System.Drawing.Size(195, 36);
            this.CheckboxInfo.TabIndex = 11;
            this.CheckboxInfo.Text = "Информация";
            this.CheckboxInfo.UseVisualStyleBackColor = true;
            // 
            // CheckboxSuccess
            // 
            this.CheckboxSuccess.Depth = 0;
            this.CheckboxSuccess.Location = new System.Drawing.Point(98, 91);
            this.CheckboxSuccess.Margin = new System.Windows.Forms.Padding(0);
            this.CheckboxSuccess.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckboxSuccess.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckboxSuccess.Name = "CheckboxSuccess";
            this.CheckboxSuccess.ReadOnly = false;
            this.CheckboxSuccess.Ripple = true;
            this.CheckboxSuccess.Size = new System.Drawing.Size(195, 36);
            this.CheckboxSuccess.TabIndex = 10;
            this.CheckboxSuccess.Text = "Успехи";
            this.CheckboxSuccess.UseVisualStyleBackColor = true;
            // 
            // CheckboxError
            // 
            this.CheckboxError.Depth = 0;
            this.CheckboxError.Location = new System.Drawing.Point(98, 55);
            this.CheckboxError.Margin = new System.Windows.Forms.Padding(0);
            this.CheckboxError.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckboxError.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckboxError.Name = "CheckboxError";
            this.CheckboxError.ReadOnly = false;
            this.CheckboxError.Ripple = true;
            this.CheckboxError.Size = new System.Drawing.Size(195, 36);
            this.CheckboxError.TabIndex = 9;
            this.CheckboxError.Text = "Грешки";
            this.CheckboxError.UseVisualStyleBackColor = true;
            // 
            // BtnSwitchModalAlert
            // 
            this.BtnSwitchModalAlert.AutoSize = true;
            this.BtnSwitchModalAlert.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSwitchModalAlert.Depth = 0;
            this.BtnSwitchModalAlert.Location = new System.Drawing.Point(78, 18);
            this.BtnSwitchModalAlert.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSwitchModalAlert.MouseLocation = new System.Drawing.Point(-1, -1);
            this.BtnSwitchModalAlert.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnSwitchModalAlert.Name = "BtnSwitchModalAlert";
            this.BtnSwitchModalAlert.Ripple = true;
            this.BtnSwitchModalAlert.Size = new System.Drawing.Size(120, 37);
            this.BtnSwitchModalAlert.TabIndex = 8;
            this.BtnSwitchModalAlert.Text = "Пуснати";
            this.BtnSwitchModalAlert.UseVisualStyleBackColor = false;
            this.BtnSwitchModalAlert.CheckedChanged += new System.EventHandler(this.BtnSwitchModalAlert_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadioButtonBase);
            this.groupBox2.Controls.Add(this.RadioButtonBlue);
            this.groupBox2.Controls.Add(this.RadioButtonGreen);
            this.groupBox2.Controls.Add(this.RadioButtonOrange);
            this.groupBox2.Location = new System.Drawing.Point(228, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 97);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цветови варианти";
            // 
            // RadioButtonBase
            // 
            this.RadioButtonBase.AutoSize = true;
            this.RadioButtonBase.Depth = 0;
            this.RadioButtonBase.Location = new System.Drawing.Point(127, 55);
            this.RadioButtonBase.Margin = new System.Windows.Forms.Padding(0);
            this.RadioButtonBase.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RadioButtonBase.MouseState = MaterialSkin.MouseState.HOVER;
            this.RadioButtonBase.Name = "RadioButtonBase";
            this.RadioButtonBase.Ripple = true;
            this.RadioButtonBase.Size = new System.Drawing.Size(80, 37);
            this.RadioButtonBase.TabIndex = 7;
            this.RadioButtonBase.TabStop = true;
            this.RadioButtonBase.Text = "Базов";
            this.RadioButtonBase.UseVisualStyleBackColor = true;
            this.RadioButtonBase.CheckedChanged += new System.EventHandler(this.RadioButtonBase_CheckedChanged);
            // 
            // RadioButtonBlue
            // 
            this.RadioButtonBlue.AutoSize = true;
            this.RadioButtonBlue.Depth = 0;
            this.RadioButtonBlue.Location = new System.Drawing.Point(127, 18);
            this.RadioButtonBlue.Margin = new System.Windows.Forms.Padding(0);
            this.RadioButtonBlue.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RadioButtonBlue.MouseState = MaterialSkin.MouseState.HOVER;
            this.RadioButtonBlue.Name = "RadioButtonBlue";
            this.RadioButtonBlue.Ripple = true;
            this.RadioButtonBlue.Size = new System.Drawing.Size(63, 37);
            this.RadioButtonBlue.TabIndex = 6;
            this.RadioButtonBlue.TabStop = true;
            this.RadioButtonBlue.Text = "Син";
            this.RadioButtonBlue.UseVisualStyleBackColor = true;
            this.RadioButtonBlue.CheckedChanged += new System.EventHandler(this.RadioButtonBlue_CheckedChanged);
            // 
            // RadioButtonGreen
            // 
            this.RadioButtonGreen.AutoSize = true;
            this.RadioButtonGreen.Depth = 0;
            this.RadioButtonGreen.Location = new System.Drawing.Point(8, 52);
            this.RadioButtonGreen.Margin = new System.Windows.Forms.Padding(0);
            this.RadioButtonGreen.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RadioButtonGreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.RadioButtonGreen.Name = "RadioButtonGreen";
            this.RadioButtonGreen.Ripple = true;
            this.RadioButtonGreen.Size = new System.Drawing.Size(79, 37);
            this.RadioButtonGreen.TabIndex = 6;
            this.RadioButtonGreen.TabStop = true;
            this.RadioButtonGreen.Text = "Зелен";
            this.RadioButtonGreen.UseVisualStyleBackColor = true;
            this.RadioButtonGreen.CheckedChanged += new System.EventHandler(this.RadioButtonGreen_CheckedChanged);
            // 
            // RadioButtonOrange
            // 
            this.RadioButtonOrange.AutoSize = true;
            this.RadioButtonOrange.Depth = 0;
            this.RadioButtonOrange.Location = new System.Drawing.Point(8, 18);
            this.RadioButtonOrange.Margin = new System.Windows.Forms.Padding(0);
            this.RadioButtonOrange.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RadioButtonOrange.MouseState = MaterialSkin.MouseState.HOVER;
            this.RadioButtonOrange.Name = "RadioButtonOrange";
            this.RadioButtonOrange.Ripple = true;
            this.RadioButtonOrange.Size = new System.Drawing.Size(102, 37);
            this.RadioButtonOrange.TabIndex = 6;
            this.RadioButtonOrange.TabStop = true;
            this.RadioButtonOrange.Text = "Оранжев";
            this.RadioButtonOrange.UseVisualStyleBackColor = true;
            this.RadioButtonOrange.CheckedChanged += new System.EventHandler(this.RadioButtonOrange_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.btnSwitchTheme);
            this.groupBox1.Location = new System.Drawing.Point(227, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 85);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тема";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(77, 36);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(51, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "Тъмна";
            // 
            // btnSwitchTheme
            // 
            this.btnSwitchTheme.AutoSize = true;
            this.btnSwitchTheme.BackColor = System.Drawing.SystemColors.Control;
            this.btnSwitchTheme.Depth = 0;
            this.btnSwitchTheme.Location = new System.Drawing.Point(137, 27);
            this.btnSwitchTheme.Margin = new System.Windows.Forms.Padding(0);
            this.btnSwitchTheme.MouseLocation = new System.Drawing.Point(-1, -1);
            this.btnSwitchTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSwitchTheme.Name = "btnSwitchTheme";
            this.btnSwitchTheme.Ripple = true;
            this.btnSwitchTheme.Size = new System.Drawing.Size(111, 37);
            this.btnSwitchTheme.TabIndex = 4;
            this.btnSwitchTheme.Text = "Светла";
            this.btnSwitchTheme.UseVisualStyleBackColor = false;
            this.btnSwitchTheme.CheckedChanged += new System.EventHandler(this.BtnSwitchTheme_CheckedChanged);
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 680);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(840, 680);
            this.MinimumSize = new System.Drawing.Size(840, 680);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 3, 3);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кликер";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBoxActionInfo.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage4;
        private MaterialSkin.Controls.MaterialComboBox cmbActionType;
        private MaterialSkin.Controls.MaterialLabel LastClickLabel;
        private MaterialSkin.Controls.MaterialLabel CurrentPositionLabel;
        private MaterialSkin.Controls.MaterialButton btnStopRecording;
        private MaterialSkin.Controls.MaterialButton btnStartRecording;
        private MaterialSkin.Controls.MaterialMaskedTextBox textBoxActionName;
        private MaterialSkin.Controls.MaterialButton btnAddAction;
        private MaterialSkin.Controls.MaterialListBox lstAvailableActions;
        private MaterialSkin.Controls.MaterialButton btnMoveUpAction;
        private MaterialSkin.Controls.MaterialButton btnActionDelete;
        private MaterialSkin.Controls.MaterialButton btnMoveDownAction;
        private MaterialSkin.Controls.MaterialMaskedTextBox textBoxMacroName;
        private MaterialSkin.Controls.MaterialButton btnCreateMacro;
        private MaterialSkin.Controls.MaterialListBox lstAvailableMacros;
        private MaterialSkin.Controls.MaterialMultiLineTextBox textBoxDisplayMacroInfo;
        private MaterialSkin.Controls.MaterialListBox lstMacrosForExecute;
        private MaterialSkin.Controls.MaterialButton btnMacroForExecuteDelete;
        private MaterialSkin.Controls.MaterialCheckbox chkAllMacrosToExecute;
        private MaterialSkin.Controls.MaterialButton btnStopMacro;
        private MaterialSkin.Controls.MaterialButton btnExecuteMacro;
        private MaterialSkin.Controls.MaterialMultiLineTextBox StatusLabel;
        private MaterialSkin.Controls.MaterialButton btnNewSavePath;
        private MaterialSkin.Controls.MaterialButton btnMacroDelete;
        private MaterialSkin.Controls.MaterialButton btnMacroSave;
        private MaterialSkin.Controls.MaterialSlider countAllMacroRepeatSlider;
        private MaterialSkin.Controls.MaterialSlider numericDelayBeforeSlider;
        private MaterialSkin.Controls.MaterialSlider numericDelaySlider;
        private MaterialSkin.Controls.MaterialTextBox2 txtX;
        private MaterialSkin.Controls.MaterialTextBox2 txtY;
        private MaterialSkin.Controls.MaterialProgressBar ProgressBarExecuteMacros;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSwitch btnSwitchTheme;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialRadioButton RadioButtonBlue;
        private MaterialSkin.Controls.MaterialRadioButton RadioButtonGreen;
        private MaterialSkin.Controls.MaterialRadioButton RadioButtonOrange;
        private MaterialSkin.Controls.MaterialRadioButton RadioButtonBase;
        private MaterialSkin.Controls.MaterialSwitch BtnSwitchModalAlert;
        private System.Windows.Forms.GroupBox groupBox3;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxInfo;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxSuccess;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxError;
        private MaterialSkin.Controls.MaterialMultiLineTextBox StatusLabel2;
        private MaterialSkin.Controls.MaterialSlider SliderMacroForExecuteSlot1;
        private MaterialSkin.Controls.MaterialSlider SliderMacroForExecuteSlot2;
        private MaterialSkin.Controls.MaterialSlider SliderMacroForExecuteSlot3;
        private MaterialSkin.Controls.MaterialSlider SliderMacroForExecuteSlot4;
        private MaterialSkin.Controls.MaterialMultiLineTextBox richTextBoxLogInfo;
        private MaterialSkin.Controls.MaterialCheckbox chkReturnMouseToOriginal;
        private MaterialSkin.Controls.MaterialSlider FrequencyInputSlider;
        private MaterialSkin.Controls.MaterialSlider DurationInputSlider;
        private MaterialSkin.Controls.MaterialSlider CountInputSlider;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton btnCloseCardActionInfo;
        private MaterialSkin.Controls.MaterialMultiLineTextBox TextBoxlabelDisplayActionInfo;
        private System.Windows.Forms.GroupBox groupBoxActionInfo;
    }
}