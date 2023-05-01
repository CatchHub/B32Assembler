namespace B32Assembler
{
    partial class frmMainForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtSourceFileName = new TextBox();
            txtOutputFileName = new TextBox();
            txtOrigin = new TextBox();
            btnAssemble = new Button();
            btnSourceBrowse = new Button();
            btnOutputBrowse = new Button();
            fdDestinationFile = new OpenFileDialog();
            fdSourceFile = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 23);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Source File:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(14, 49);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 1;
            label2.Text = "Output File:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(40, 76);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Origin:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(84, 77);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 3;
            label4.Text = "$";
            label4.Click += label4_Click;
            // 
            // txtSourceFileName
            // 
            txtSourceFileName.BorderStyle = BorderStyle.None;
            txtSourceFileName.Location = new Point(97, 18);
            txtSourceFileName.Margin = new Padding(0);
            txtSourceFileName.Name = "txtSourceFileName";
            txtSourceFileName.Size = new Size(100, 20);
            txtSourceFileName.TabIndex = 4;
            // 
            // txtOutputFileName
            // 
            txtOutputFileName.BorderStyle = BorderStyle.None;
            txtOutputFileName.Location = new Point(97, 45);
            txtOutputFileName.Margin = new Padding(0);
            txtOutputFileName.Name = "txtOutputFileName";
            txtOutputFileName.Size = new Size(100, 20);
            txtOutputFileName.TabIndex = 5;
            txtOutputFileName.TextChanged += txtOutputFileName_TextChanged;
            // 
            // txtOrigin
            // 
            txtOrigin.BorderStyle = BorderStyle.None;
            txtOrigin.Location = new Point(97, 72);
            txtOrigin.Margin = new Padding(0);
            txtOrigin.Name = "txtOrigin";
            txtOrigin.Size = new Size(100, 20);
            txtOrigin.TabIndex = 6;
            txtOrigin.Text = "''";
            // 
            // btnAssemble
            // 
            btnAssemble.Anchor = AnchorStyles.None;
            btnAssemble.AutoSize = true;
            btnAssemble.BackColor = SystemColors.Window;
            btnAssemble.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btnAssemble.Location = new Point(109, 119);
            btnAssemble.Margin = new Padding(0);
            btnAssemble.Name = "btnAssemble";
            btnAssemble.Size = new Size(75, 25);
            btnAssemble.TabIndex = 7;
            btnAssemble.Text = "Assemble!";
            btnAssemble.UseVisualStyleBackColor = false;
            btnAssemble.Click += btnAssemble_Click;
            // 
            // btnSourceBrowse
            // 
            btnSourceBrowse.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btnSourceBrowse.Location = new Point(207, 18);
            btnSourceBrowse.Margin = new Padding(1);
            btnSourceBrowse.Name = "btnSourceBrowse";
            btnSourceBrowse.Size = new Size(70, 20);
            btnSourceBrowse.TabIndex = 8;
            btnSourceBrowse.Text = "Browse…";
            btnSourceBrowse.UseVisualStyleBackColor = true;
            btnSourceBrowse.Click += btnSourceBrowse_Click;
            // 
            // btnOutputBrowse
            // 
            btnOutputBrowse.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btnOutputBrowse.Location = new Point(207, 45);
            btnOutputBrowse.Name = "btnOutputBrowse";
            btnOutputBrowse.Size = new Size(70, 20);
            btnOutputBrowse.TabIndex = 7;
            btnOutputBrowse.Text = "Browse...";
            btnOutputBrowse.UseVisualStyleBackColor = true;
            btnOutputBrowse.Click += btnOutputBrowse_Click;
            // 
            // fdDestinationFile
            // 
            fdDestinationFile.DefaultExt = "B32";
            fdDestinationFile.Filter = "B32 Files|*.B32";
            fdDestinationFile.FileOk += openFileDialog1_FileOk;
            // 
            // fdSourceFile
            // 
            fdSourceFile.DefaultExt = "asm";
            fdSourceFile.Filter = "B32 Assembly Files|*.asm";
            // 
            // frmMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 153);
            Controls.Add(btnOutputBrowse);
            Controls.Add(btnSourceBrowse);
            Controls.Add(btnAssemble);
            Controls.Add(txtOrigin);
            Controls.Add(txtOutputFileName);
            Controls.Add(txtSourceFileName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmMainForm";
            Text = "Form1";
            Load += frmMainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSourceFileName;
        private TextBox txtOutputFileName;
        private TextBox txtOrigin;
        private Button btnAssemble;
        private Button btnSourceBrowse;
        public Button btnOutputBrowse;
        private OpenFileDialog fdDestinationFile;
        private OpenFileDialog fdSourceFile;
    }
}