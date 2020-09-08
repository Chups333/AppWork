namespace AppWork.MyWinForm
{
    partial class Form5
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
            this.COMBOXLOGINOK = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DELETERABOTNIKOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // COMBOXLOGINOK
            // 
            this.COMBOXLOGINOK.FormattingEnabled = true;
            this.COMBOXLOGINOK.Location = new System.Drawing.Point(124, 27);
            this.COMBOXLOGINOK.Name = "COMBOXLOGINOK";
            this.COMBOXLOGINOK.Size = new System.Drawing.Size(139, 21);
            this.COMBOXLOGINOK.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Введите логин";
            // 
            // DELETERABOTNIKOK
            // 
            this.DELETERABOTNIKOK.Location = new System.Drawing.Point(269, 27);
            this.DELETERABOTNIKOK.Name = "DELETERABOTNIKOK";
            this.DELETERABOTNIKOK.Size = new System.Drawing.Size(75, 23);
            this.DELETERABOTNIKOK.TabIndex = 24;
            this.DELETERABOTNIKOK.Text = "Удалить";
            this.DELETERABOTNIKOK.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 77);
            this.Controls.Add(this.COMBOXLOGINOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DELETERABOTNIKOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form5";
            this.Text = "Удаление работника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox COMBOXLOGINOK;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button DELETERABOTNIKOK;
    }
}