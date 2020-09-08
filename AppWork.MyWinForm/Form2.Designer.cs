namespace AppWork.MyWinForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TEXTSURNAME = new System.Windows.Forms.TextBox();
            this.TEXTNAME = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TEXTPATRONYMIC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TEXTLOGIN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TEXTONLINE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ADDRABOTNIK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(64, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // TEXTSURNAME
            // 
            this.TEXTSURNAME.Location = new System.Drawing.Point(185, 49);
            this.TEXTSURNAME.Name = "TEXTSURNAME";
            this.TEXTSURNAME.Size = new System.Drawing.Size(143, 20);
            this.TEXTSURNAME.TabIndex = 1;
            // 
            // TEXTNAME
            // 
            this.TEXTNAME.Location = new System.Drawing.Point(185, 98);
            this.TEXTNAME.Name = "TEXTNAME";
            this.TEXTNAME.Size = new System.Drawing.Size(143, 20);
            this.TEXTNAME.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(64, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя";
            // 
            // TEXTPATRONYMIC
            // 
            this.TEXTPATRONYMIC.Location = new System.Drawing.Point(185, 153);
            this.TEXTPATRONYMIC.Name = "TEXTPATRONYMIC";
            this.TEXTPATRONYMIC.Size = new System.Drawing.Size(143, 20);
            this.TEXTPATRONYMIC.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(64, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отчество";
            // 
            // TEXTLOGIN
            // 
            this.TEXTLOGIN.Location = new System.Drawing.Point(533, 50);
            this.TEXTLOGIN.Name = "TEXTLOGIN";
            this.TEXTLOGIN.Size = new System.Drawing.Size(143, 20);
            this.TEXTLOGIN.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(412, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Логин";
            // 
            // TEXTONLINE
            // 
            this.TEXTONLINE.Location = new System.Drawing.Point(533, 99);
            this.TEXTONLINE.Name = "TEXTONLINE";
            this.TEXTONLINE.Size = new System.Drawing.Size(143, 20);
            this.TEXTONLINE.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(412, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Статус";
            // 
            // ADDRABOTNIK
            // 
            this.ADDRABOTNIK.Location = new System.Drawing.Point(417, 153);
            this.ADDRABOTNIK.Name = "ADDRABOTNIK";
            this.ADDRABOTNIK.Size = new System.Drawing.Size(259, 23);
            this.ADDRABOTNIK.TabIndex = 10;
            this.ADDRABOTNIK.Text = "Добавить";
            this.ADDRABOTNIK.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 213);
            this.Controls.Add(this.ADDRABOTNIK);
            this.Controls.Add(this.TEXTONLINE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TEXTLOGIN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TEXTPATRONYMIC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TEXTNAME);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TEXTSURNAME);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form2";
            this.Text = "Добавление работника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TEXTSURNAME;
        public System.Windows.Forms.TextBox TEXTNAME;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TEXTPATRONYMIC;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TEXTLOGIN;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TEXTONLINE;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button ADDRABOTNIK;
    }
}