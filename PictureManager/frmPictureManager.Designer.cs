namespace PictureManager
{
    partial class frmPictureManager
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.grbSettings = new System.Windows.Forms.GroupBox();
            this.ckbReplaceHrefWithSr = new System.Windows.Forms.CheckBox();
            this.ckbTargetBlank = new System.Windows.Forms.CheckBox();
            this.ckbAutoScale = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.grbSettings.SuspendLayout();
            this.grbProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(6, 104);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(186, 55);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // grbSettings
            // 
            this.grbSettings.Controls.Add(this.ckbReplaceHrefWithSr);
            this.grbSettings.Controls.Add(this.ckbTargetBlank);
            this.grbSettings.Controls.Add(this.ckbAutoScale);
            this.grbSettings.Location = new System.Drawing.Point(6, 20);
            this.grbSettings.Name = "grbSettings";
            this.grbSettings.Size = new System.Drawing.Size(188, 78);
            this.grbSettings.TabIndex = 1;
            this.grbSettings.TabStop = false;
            this.grbSettings.Text = "Settings";
            // 
            // ckbReplaceHrefWithSr
            // 
            this.ckbReplaceHrefWithSr.AutoSize = true;
            this.ckbReplaceHrefWithSr.Checked = true;
            this.ckbReplaceHrefWithSr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbReplaceHrefWithSr.Location = new System.Drawing.Point(7, 56);
            this.ckbReplaceHrefWithSr.Name = "ckbReplaceHrefWithSr";
            this.ckbReplaceHrefWithSr.Size = new System.Drawing.Size(150, 16);
            this.ckbReplaceHrefWithSr.TabIndex = 2;
            this.ckbReplaceHrefWithSr.Text = "replace href with src";
            this.ckbReplaceHrefWithSr.UseVisualStyleBackColor = true;
            // 
            // ckbTargetBlank
            // 
            this.ckbTargetBlank.AutoSize = true;
            this.ckbTargetBlank.Checked = true;
            this.ckbTargetBlank.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbTargetBlank.Location = new System.Drawing.Point(6, 18);
            this.ckbTargetBlank.Name = "ckbTargetBlank";
            this.ckbTargetBlank.Size = new System.Drawing.Size(180, 16);
            this.ckbTargetBlank.TabIndex = 1;
            this.ckbTargetBlank.Text = "open picture in new window";
            this.ckbTargetBlank.UseVisualStyleBackColor = true;
            // 
            // ckbAutoScale
            // 
            this.ckbAutoScale.AutoSize = true;
            this.ckbAutoScale.Checked = true;
            this.ckbAutoScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAutoScale.Location = new System.Drawing.Point(6, 39);
            this.ckbAutoScale.Name = "ckbAutoScale";
            this.ckbAutoScale.Size = new System.Drawing.Size(84, 16);
            this.ckbAutoScale.TabIndex = 0;
            this.ckbAutoScale.Text = "auto scale";
            this.ckbAutoScale.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnHelp.Location = new System.Drawing.Point(242, 62);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(51, 109);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "Online Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTranslate.Location = new System.Drawing.Point(13, 22);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(206, 57);
            this.btnTranslate.TabIndex = 3;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // grbProcess
            // 
            this.grbProcess.Controls.Add(this.grbSettings);
            this.grbProcess.Controls.Add(this.btnProcess);
            this.grbProcess.Location = new System.Drawing.Point(13, 96);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(206, 172);
            this.grbProcess.TabIndex = 4;
            this.grbProcess.TabStop = false;
            this.grbProcess.Text = "Process";
            // 
            // frmPictureManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 278);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.btnHelp);
            this.Name = "frmPictureManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPictureManager";
            this.Load += new System.EventHandler(this.frmPictureManager_Load);
            this.grbSettings.ResumeLayout(false);
            this.grbSettings.PerformLayout();
            this.grbProcess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.GroupBox grbSettings;
        private System.Windows.Forms.CheckBox ckbAutoScale;
        private System.Windows.Forms.CheckBox ckbTargetBlank;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.CheckBox ckbReplaceHrefWithSr;
        private System.Windows.Forms.GroupBox grbProcess;
    }
}