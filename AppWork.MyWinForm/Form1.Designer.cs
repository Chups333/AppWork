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
            this.MAGAZINEBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.INFOTEXT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // STARTBTN
            // 
            this.STARTBTN.Location = new System.Drawing.Point(619, 284);
            this.STARTBTN.Name = "STARTBTN";
            this.STARTBTN.Size = new System.Drawing.Size(286, 101);
            this.STARTBTN.TabIndex = 0;
            this.STARTBTN.Text = "START";
            this.STARTBTN.UseVisualStyleBackColor = true;
            this.STARTBTN.Click += new System.EventHandler(this.STARTBTN_Click);
            // 
            // LOGINTEXT
            // 
            this.LOGINTEXT.Location = new System.Drawing.Point(443, 47);
            this.LOGINTEXT.Name = "LOGINTEXT";
            this.LOGINTEXT.Size = new System.Drawing.Size(205, 20);
            this.LOGINTEXT.TabIndex = 3;
            // 
            // PASSTEXT
            // 
            this.PASSTEXT.Location = new System.Drawing.Point(443, 89);
            this.PASSTEXT.Name = "PASSTEXT";
            this.PASSTEXT.Size = new System.Drawing.Size(205, 20);
            this.PASSTEXT.TabIndex = 4;
            // 
            // MAGAZINETEXT
            // 
            this.MAGAZINETEXT.Location = new System.Drawing.Point(69, 132);
            this.MAGAZINETEXT.Multiline = true;
            this.MAGAZINETEXT.Name = "MAGAZINETEXT";
            this.MAGAZINETEXT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MAGAZINETEXT.Size = new System.Drawing.Size(428, 101);
            this.MAGAZINETEXT.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(357, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(357, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пароль";
            // 
            // MAGAZINEBTN
            // 
            this.MAGAZINEBTN.Location = new System.Drawing.Point(619, 132);
            this.MAGAZINEBTN.Name = "MAGAZINEBTN";
            this.MAGAZINEBTN.Size = new System.Drawing.Size(286, 101);
            this.MAGAZINEBTN.TabIndex = 8;
            this.MAGAZINEBTN.Text = "Показать журнал";
            this.MAGAZINEBTN.UseVisualStyleBackColor = true;
            this.MAGAZINEBTN.Click += new System.EventHandler(this.MAGAZINEBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(64, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Журнал";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(64, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Информация";
            // 
            // INFOTEXT
            // 
            this.INFOTEXT.Location = new System.Drawing.Point(69, 284);
            this.INFOTEXT.Multiline = true;
            this.INFOTEXT.Name = "INFOTEXT";
            this.INFOTEXT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.INFOTEXT.Size = new System.Drawing.Size(428, 101);
            this.INFOTEXT.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 443);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.INFOTEXT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MAGAZINEBTN);
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
        private System.Windows.Forms.Button MAGAZINEBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox INFOTEXT;
    }
}

