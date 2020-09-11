namespace AppWork.MyWinForm
{
    partial class Form6
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
            this.COMBOXLOGIN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.COMBOXKEY = new System.Windows.Forms.ComboBox();
            this.CHECKBOXPRIOR = new System.Windows.Forms.CheckBox();
            this.BTNADD = new System.Windows.Forms.Button();
            this.BTNUPD = new System.Windows.Forms.Button();
            this.BTNDEL = new System.Windows.Forms.Button();
            this.TEXTSHOWKEYS = new System.Windows.Forms.TextBox();
            this.BTNSHOW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(60, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // COMBOXLOGIN
            // 
            this.COMBOXLOGIN.FormattingEnabled = true;
            this.COMBOXLOGIN.Location = new System.Drawing.Point(134, 51);
            this.COMBOXLOGIN.Name = "COMBOXLOGIN";
            this.COMBOXLOGIN.Size = new System.Drawing.Size(121, 21);
            this.COMBOXLOGIN.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(284, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя ключа";
            // 
            // COMBOXKEY
            // 
            this.COMBOXKEY.FormattingEnabled = true;
            this.COMBOXKEY.Location = new System.Drawing.Point(407, 49);
            this.COMBOXKEY.Name = "COMBOXKEY";
            this.COMBOXKEY.Size = new System.Drawing.Size(121, 21);
            this.COMBOXKEY.TabIndex = 3;
            // 
            // CHECKBOXPRIOR
            // 
            this.CHECKBOXPRIOR.AutoSize = true;
            this.CHECKBOXPRIOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CHECKBOXPRIOR.Location = new System.Drawing.Point(568, 46);
            this.CHECKBOXPRIOR.Name = "CHECKBOXPRIOR";
            this.CHECKBOXPRIOR.Size = new System.Drawing.Size(135, 29);
            this.CHECKBOXPRIOR.TabIndex = 5;
            this.CHECKBOXPRIOR.Text = "Приоритет";
            this.CHECKBOXPRIOR.UseVisualStyleBackColor = true;
            // 
            // BTNADD
            // 
            this.BTNADD.Location = new System.Drawing.Point(134, 107);
            this.BTNADD.Name = "BTNADD";
            this.BTNADD.Size = new System.Drawing.Size(121, 23);
            this.BTNADD.TabIndex = 6;
            this.BTNADD.Text = "Добавить";
            this.BTNADD.UseVisualStyleBackColor = true;
            // 
            // BTNUPD
            // 
            this.BTNUPD.Location = new System.Drawing.Point(309, 107);
            this.BTNUPD.Name = "BTNUPD";
            this.BTNUPD.Size = new System.Drawing.Size(121, 23);
            this.BTNUPD.TabIndex = 7;
            this.BTNUPD.Text = "Изменить";
            this.BTNUPD.UseVisualStyleBackColor = true;
            // 
            // BTNDEL
            // 
            this.BTNDEL.Location = new System.Drawing.Point(483, 107);
            this.BTNDEL.Name = "BTNDEL";
            this.BTNDEL.Size = new System.Drawing.Size(121, 23);
            this.BTNDEL.TabIndex = 8;
            this.BTNDEL.Text = "Удалить";
            this.BTNDEL.UseVisualStyleBackColor = true;
            // 
            // TEXTSHOWKEYS
            // 
            this.TEXTSHOWKEYS.Location = new System.Drawing.Point(147, 167);
            this.TEXTSHOWKEYS.Multiline = true;
            this.TEXTSHOWKEYS.Name = "TEXTSHOWKEYS";
            this.TEXTSHOWKEYS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TEXTSHOWKEYS.Size = new System.Drawing.Size(484, 114);
            this.TEXTSHOWKEYS.TabIndex = 9;
            // 
            // BTNSHOW
            // 
            this.BTNSHOW.Location = new System.Drawing.Point(331, 299);
            this.BTNSHOW.Name = "BTNSHOW";
            this.BTNSHOW.Size = new System.Drawing.Size(121, 23);
            this.BTNSHOW.TabIndex = 10;
            this.BTNSHOW.Text = "Показать ключи";
            this.BTNSHOW.UseVisualStyleBackColor = true;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 348);
            this.Controls.Add(this.BTNSHOW);
            this.Controls.Add(this.TEXTSHOWKEYS);
            this.Controls.Add(this.BTNDEL);
            this.Controls.Add(this.BTNUPD);
            this.Controls.Add(this.BTNADD);
            this.Controls.Add(this.CHECKBOXPRIOR);
            this.Controls.Add(this.COMBOXKEY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.COMBOXLOGIN);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form6";
            this.Text = "Настройка ключей";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox COMBOXLOGIN;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox COMBOXKEY;
        public System.Windows.Forms.CheckBox CHECKBOXPRIOR;
        public System.Windows.Forms.Button BTNADD;
        public System.Windows.Forms.Button BTNUPD;
        public System.Windows.Forms.Button BTNDEL;
        public System.Windows.Forms.TextBox TEXTSHOWKEYS;
        public System.Windows.Forms.Button BTNSHOW;
    }
}