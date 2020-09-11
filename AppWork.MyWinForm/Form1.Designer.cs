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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.дейсвтияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьРаботникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСРоботомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаКлючейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дейсвтияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1002, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // дейсвтияToolStripMenuItem
            // 
            this.дейсвтияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьРаботникаToolStripMenuItem,
            this.работаСРоботомToolStripMenuItem,
            this.настройкаКлючейToolStripMenuItem});
            this.дейсвтияToolStripMenuItem.Name = "дейсвтияToolStripMenuItem";
            this.дейсвтияToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.дейсвтияToolStripMenuItem.Text = "Меню";
            // 
            // добавитьРаботникаToolStripMenuItem
            // 
            this.добавитьРаботникаToolStripMenuItem.Name = "добавитьРаботникаToolStripMenuItem";
            this.добавитьРаботникаToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.добавитьРаботникаToolStripMenuItem.Text = "Добавить работника";
            this.добавитьРаботникаToolStripMenuItem.Click += new System.EventHandler(this.добавитьРаботникаToolStripMenuItem_Click);
            // 
            // работаСРоботомToolStripMenuItem
            // 
            this.работаСРоботомToolStripMenuItem.Name = "работаСРоботомToolStripMenuItem";
            this.работаСРоботомToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.работаСРоботомToolStripMenuItem.Text = "Работа с роботом";
            this.работаСРоботомToolStripMenuItem.Click += new System.EventHandler(this.работаСРоботомToolStripMenuItem_Click);
            // 
            // настройкаКлючейToolStripMenuItem
            // 
            this.настройкаКлючейToolStripMenuItem.Name = "настройкаКлючейToolStripMenuItem";
            this.настройкаКлючейToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.настройкаКлючейToolStripMenuItem.Text = "Настройка ключей";
            this.настройкаКлючейToolStripMenuItem.Click += new System.EventHandler(this.настройкаКлючейToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 443);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Robot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem дейсвтияToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem добавитьРаботникаToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem работаСРоботомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаКлючейToolStripMenuItem;
    }
}

