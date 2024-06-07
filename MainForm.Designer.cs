namespace TestOne.BinaryReader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            readButton = new Button();
            basicInfoListView = new ListView();
            testResultListView = new ListView();
            schemaComboBox = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            openFileButton = new Button();
            showReservedCheckBox = new CheckBox();
            filePathLabel = new Label();
            SuspendLayout();
            // 
            // readButton
            // 
            readButton.Location = new Point(22, 21);
            readButton.Name = "readButton";
            readButton.Size = new Size(191, 51);
            readButton.TabIndex = 0;
            readButton.Text = "Read";
            readButton.UseVisualStyleBackColor = true;
            readButton.Click += readButton_Click;
            // 
            // basicInfoListView
            // 
            basicInfoListView.Location = new Point(12, 88);
            basicInfoListView.Name = "basicInfoListView";
            basicInfoListView.Size = new Size(667, 608);
            basicInfoListView.TabIndex = 1;
            basicInfoListView.UseCompatibleStateImageBehavior = false;
            // 
            // testResultListView
            // 
            testResultListView.Location = new Point(685, 88);
            testResultListView.Name = "testResultListView";
            testResultListView.Size = new Size(467, 608);
            testResultListView.TabIndex = 2;
            testResultListView.UseCompatibleStateImageBehavior = false;
            // 
            // schemaComboBox
            // 
            schemaComboBox.FormattingEnabled = true;
            schemaComboBox.Items.AddRange(new object[] { "BasicMap" });
            schemaComboBox.Location = new Point(975, 54);
            schemaComboBox.Name = "schemaComboBox";
            schemaComboBox.Size = new Size(177, 28);
            schemaComboBox.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "|*.bin";
            openFileDialog1.FileOk += fileOpened_FileOk;
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(244, 21);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(191, 51);
            openFileButton.TabIndex = 5;
            openFileButton.Text = "Open Bin File";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButton_Click;
            // 
            // showReservedCheckBox
            // 
            showReservedCheckBox.AutoSize = true;
            showReservedCheckBox.Location = new Point(975, 22);
            showReservedCheckBox.Name = "showReservedCheckBox";
            showReservedCheckBox.Size = new Size(177, 24);
            showReservedCheckBox.TabIndex = 6;
            showReservedCheckBox.Text = "Show Reserved Values";
            showReservedCheckBox.UseVisualStyleBackColor = true;
            showReservedCheckBox.CheckedChanged += showReserved_CheckedChanged;
            // 
            // filePathLabel
            // 
            filePathLabel.Location = new Point(462, 36);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(383, 20);
            filePathLabel.TabIndex = 7;
            filePathLabel.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 708);
            Controls.Add(filePathLabel);
            Controls.Add(showReservedCheckBox);
            Controls.Add(openFileButton);
            Controls.Add(schemaComboBox);
            Controls.Add(testResultListView);
            Controls.Add(basicInfoListView);
            Controls.Add(readButton);
            Name = "MainForm";
            Text = "Reader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button readButton;
        private ListView basicInfoListView;
        private ListView testResultListView;
        private ComboBox schemaComboBox;
        private OpenFileDialog openFileDialog1;
        private Button openFileButton;
        private CheckBox showReservedCheckBox;
        private Label filePathLabel;
    }
}
