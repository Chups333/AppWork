namespace AppWork.MyWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.STARTBTN = new System.Windows.Forms.Button();
            this.LOGINTEXT = new System.Windows.Forms.TextBox();
            this.PASSTEXT = new System.Windows.Forms.TextBox();
            this.MAGAZINETEXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // STARTBTN
            // 
            this.STARTBTN.Location = new System.Drawing.Point(54, 136);
            this.STARTBTN.Name = "STARTBTN";
            this.STARTBTN.Size = new System.Drawing.Size(286, 23);
            this.STARTBTN.TabIndex = 0;
            this.STARTBTN.Text = "START";
            this.STARTBTN.UseVisualStyleBackColor = true;
            this.STARTBTN.Click += new System.EventHandler(this.STARTBTN_Click);
            // 
            // LOGINTEXT
            // 
            this.LOGINTEXT.Location = new System.Drawing.Point(135, 49);
            this.LOGINTEXT.Name = "LOGINTEXT";
            this.LOGINTEXT.Size = new System.Drawing.Size(205, 20);
            this.LOGINTEXT.TabIndex = 3;
            // 
            // PASSTEXT
            // 
            this.PASSTEXT.Location = new System.Drawing.Point(135, 93);
            this.PASSTEXT.Name = "PASSTEXT";
            this.PASSTEXT.Size = new System.Drawing.Size(205, 20);
            this.PASSTEXT.TabIndex = 4;
            // 
            // MAGAZINETEXT
            // 
            this.MAGAZINETEXT.Location = new System.Drawing.Point(360, 44);
            this.MAGAZINETEXT.Multiline = true;
            this.MAGAZINETEXT.Name = "MAGAZINETEXT";
            this.MAGAZINETEXT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MAGAZINETEXT.Size = new System.Drawing.Size(428, 234);
            this.MAGAZINETEXT.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(49, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(49, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пароль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 306);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MAGAZINETEXT);
            this.Controls.Add(this.PASSTEXT);
            this.Controls.Add(this.LOGINTEXT);
            this.Controls.Add(this.STARTBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Robot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button STARTBTN;
        private System.Windows.Forms.TextBox LOGINTEXT;
        private System.Windows.Forms.TextBox PASSTEXT;
        private System.Windows.Forms.TextBox MAGAZINETEXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

