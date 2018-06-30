namespace INIsConf
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonApplyConf = new System.Windows.Forms.Button();
            this.textBoxRunExeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDelConf = new System.Windows.Forms.Button();
            this.textBoxNewConfName = new System.Windows.Forms.TextBox();
            this.buttonSaveConf = new System.Windows.Forms.Button();
            this.listBoxConf = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSaveCurrent = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxSection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewInI = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.listViewInI);
            this.splitContainer1.Size = new System.Drawing.Size(959, 693);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonApplyConf);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxRunExeName);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.buttonDelConf);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxNewConfName);
            this.splitContainer2.Panel1.Controls.Add(this.buttonSaveConf);
            this.splitContainer2.Panel1.Controls.Add(this.listBoxConf);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBoxFiles);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(291, 693);
            this.splitContainer2.SplitterDistance = 418;
            this.splitContainer2.TabIndex = 0;
            // 
            // buttonApplyConf
            // 
            this.buttonApplyConf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonApplyConf.Location = new System.Drawing.Point(139, 313);
            this.buttonApplyConf.Name = "buttonApplyConf";
            this.buttonApplyConf.Size = new System.Drawing.Size(109, 23);
            this.buttonApplyConf.TabIndex = 7;
            this.buttonApplyConf.Text = "Save";
            this.buttonApplyConf.UseVisualStyleBackColor = true;
            this.buttonApplyConf.Click += new System.EventHandler(this.buttonApplyConf_Click);
            // 
            // textBoxRunExeName
            // 
            this.textBoxRunExeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRunExeName.Location = new System.Drawing.Point(139, 378);
            this.textBoxRunExeName.Name = "textBoxRunExeName";
            this.textBoxRunExeName.Size = new System.Drawing.Size(147, 20);
            this.textBoxRunExeName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "run";
            // 
            // buttonDelConf
            // 
            this.buttonDelConf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelConf.Location = new System.Drawing.Point(4, 313);
            this.buttonDelConf.Name = "buttonDelConf";
            this.buttonDelConf.Size = new System.Drawing.Size(126, 23);
            this.buttonDelConf.TabIndex = 4;
            this.buttonDelConf.Text = "delete";
            this.buttonDelConf.UseVisualStyleBackColor = true;
            this.buttonDelConf.Click += new System.EventHandler(this.buttonDelConf_Click);
            // 
            // textBoxNewConfName
            // 
            this.textBoxNewConfName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewConfName.Location = new System.Drawing.Point(136, 345);
            this.textBoxNewConfName.Name = "textBoxNewConfName";
            this.textBoxNewConfName.Size = new System.Drawing.Size(150, 20);
            this.textBoxNewConfName.TabIndex = 3;
            // 
            // buttonSaveConf
            // 
            this.buttonSaveConf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveConf.Location = new System.Drawing.Point(4, 342);
            this.buttonSaveConf.Name = "buttonSaveConf";
            this.buttonSaveConf.Size = new System.Drawing.Size(126, 23);
            this.buttonSaveConf.TabIndex = 2;
            this.buttonSaveConf.Text = "Save as";
            this.buttonSaveConf.UseVisualStyleBackColor = true;
            this.buttonSaveConf.Click += new System.EventHandler(this.buttonSaveConf_Click);
            // 
            // listBoxConf
            // 
            this.listBoxConf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxConf.FormattingEnabled = true;
            this.listBoxConf.Location = new System.Drawing.Point(3, 30);
            this.listBoxConf.Name = "listBoxConf";
            this.listBoxConf.Size = new System.Drawing.Size(283, 277);
            this.listBoxConf.TabIndex = 1;
            this.listBoxConf.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxConf_MouseClick);
            this.listBoxConf.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxConf_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configurtions";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(3, 22);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(283, 225);
            this.listBoxFiles.TabIndex = 1;
            this.listBoxFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxFiles_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "files in Configurtions";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonSaveCurrent);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDescription);
            this.panel1.Controls.Add(this.textBoxValue);
            this.panel1.Controls.Add(this.textBoxKey);
            this.panel1.Controls.Add(this.textBoxSection);
            this.panel1.Location = new System.Drawing.Point(3, 542);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 146);
            this.panel1.TabIndex = 2;
            // 
            // buttonSaveCurrent
            // 
            this.buttonSaveCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveCurrent.Location = new System.Drawing.Point(487, 120);
            this.buttonSaveCurrent.Name = "buttonSaveCurrent";
            this.buttonSaveCurrent.Size = new System.Drawing.Size(151, 23);
            this.buttonSaveCurrent.TabIndex = 5;
            this.buttonSaveCurrent.Text = "Save and apply";
            this.buttonSaveCurrent.UseVisualStyleBackColor = true;
            this.buttonSaveCurrent.Click += new System.EventHandler(this.buttonSaveCurrent_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 91);
            this.label4.TabIndex = 4;
            this.label4.Text = "Section\r\n\r\nKey\r\n\r\nValue\r\n\r\ncomment";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(128, 96);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(510, 20);
            this.textBoxDescription.TabIndex = 3;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxValue.Location = new System.Drawing.Point(270, 70);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(368, 20);
            this.textBoxValue.TabIndex = 2;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKey.Location = new System.Drawing.Point(270, 44);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(368, 20);
            this.textBoxKey.TabIndex = 1;
            // 
            // textBoxSection
            // 
            this.textBoxSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSection.Location = new System.Drawing.Point(91, 17);
            this.textBoxSection.Name = "textBoxSection";
            this.textBoxSection.Size = new System.Drawing.Size(547, 20);
            this.textBoxSection.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "what is in the cConfigurtion";
            // 
            // listViewInI
            // 
            this.listViewInI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewInI.Location = new System.Drawing.Point(3, 30);
            this.listViewInI.Name = "listViewInI";
            this.listViewInI.Size = new System.Drawing.Size(656, 506);
            this.listViewInI.TabIndex = 0;
            this.listViewInI.UseCompatibleStateImageBehavior = false;
            this.listViewInI.SelectedIndexChanged += new System.EventHandler(this.listViewInI_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 693);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBoxConf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button buttonDelConf;
        private System.Windows.Forms.TextBox textBoxNewConfName;
        private System.Windows.Forms.Button buttonSaveConf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewInI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxSection;
        private System.Windows.Forms.Button buttonSaveCurrent;
        private System.Windows.Forms.TextBox textBoxRunExeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonApplyConf;
    }
}

