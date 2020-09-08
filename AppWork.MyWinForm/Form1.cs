using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppWork.BL.Controller;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using AppWork.BL.Model;

namespace AppWork.MyWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 f2;
        Form4 f4;
        RabotnikiController rabontnikController;
        ZayvkiController zayvkiController;
        RobotLogsController robotLogsController;

        private void SetAllZayavki(IWebDriver web)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            var by = By.CssSelector("iframe[name^='mif-comp-ext-gen-top'");
            web.SwitchTo().Frame(web.FindElements(by)[0]);
            Thread.Sleep(1000);

            var search = web.FindElements(By.CssSelector("#ext-gen-list-0-17 table")).Count();

            for (int i = 0; i < search; i++)
            {
                Thread.Sleep(5000);
                var collectionIncident = web.FindElements(By.CssSelector(".firstColumnColor"));
                collectionIncident[i].Click();
                Thread.Sleep(5000);

                web.SwitchTo().DefaultContent();
                web.SwitchTo().Frame(web.FindElements(by)[1]);

                var nomerNameZayavki = web.FindElement(By.CssSelector("#X3")).GetAttribute("value");
                Thread.Sleep(1000);

                var status = web.FindElement(By.CssSelector("#X209Readonly")).GetAttribute("value");
                Thread.Sleep(1000);

                var iniciator = web.FindElement(By.CssSelector("#X230")).GetAttribute("value");
                Thread.Sleep(1000);

                var ispolnitel = web.FindElement(By.CssSelector("#X246")).GetAttribute("value");
                Thread.Sleep(1000);

                var shotOpisanie = web.FindElement(By.CssSelector("#X12")).GetAttribute("value");
                var collectionWordsShotOpis = shotOpisanie.Split(delimiterChars);
                Thread.Sleep(1000);

                var fullOpisanie = web.FindElement(By.CssSelector("#X14View")).Text;
                var collectionWordsFullOpis = fullOpisanie.Split(delimiterChars);
                Thread.Sleep(1000);

                //var union = collectionWordsShotOpis.Union(collectionWordsFullOpis);


                zayvkiController = new ZayvkiController(nomerNameZayavki, status);
                if (zayvkiController.IsNew)
                {
                    zayvkiController.Set(iniciator, ispolnitel, shotOpisanie, fullOpisanie);
                }
                Thread.Sleep(1000);

                web.SwitchTo().DefaultContent();
                Thread.Sleep(1000);

                var back = web.FindElement(By.XPath("//em/*[text()='Отмена']"));
                back.Click();
                Thread.Sleep(1000);

                web.SwitchTo().Frame(web.FindElements(by)[0]);

            }

            f4.INFOTEXT.Clear();
            foreach (var item in zayvkiController.ListLogZayavok)
            {
                f4.INFOTEXT.AppendText($"{item.NomerNameZayavki} -> {item.Status}" + Environment.NewLine);
                f4.INFOTEXT.AppendText($"{item.Iniciator} -> {item.Ispolnitel}" + Environment.NewLine);
                f4.INFOTEXT.AppendText($"{item.ShotOpisanie} -> {item.FullOpisanie}" + Environment.NewLine);
                //foreach (var word in union)
                //{
                //    f3.INFOTEXT.AppendText(word + Environment.NewLine);
                //}
                f4.INFOTEXT.AppendText(" " + Environment.NewLine);
            }

            web.Quit();

        }







        private void добавитьРаботникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f2 == null)
            {
                f2 = new Form2();
                f2.MdiParent = this;
                f2.FormClosed += F2_FormClosed;
                f2.ADDRABOTNIK.Click += ADDRABOTNIK_Click;
                f2.Show();
            }
            else
            {
                f2.Activate();
            }
        }

        private void ADDRABOTNIK_Click(object sender, EventArgs e)
        {
            if (f2.TEXTSURNAME.Text != "" && f2.TEXTNAME.Text != "" && f2.TEXTPATRONYMIC.Text != "" && f2.TEXTLOGIN.Text != "" && f2.TEXTONLINE.Text != "")
            {
                var surname = f2.TEXTSURNAME.Text;
                var name = f2.TEXTNAME.Text;
                var patronymic = f2.TEXTPATRONYMIC.Text;
                var login = f2.TEXTLOGIN.Text;
                var online = f2.TEXTONLINE.Text;

                rabontnikController = new RabotnikiController(surname, name, patronymic, login);

                if (rabontnikController.IsNew)
                {
                    rabontnikController.Set(online);
                }

                f2.Close();

            }
            else
            {
                MessageBox.Show("Введите все данные");
            }
        }

        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f2 = null;
        }



        private void работаСРоботомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f4 == null)
            {
                f4 = new Form4();
                f4.MdiParent = this;
                f4.FormClosing += F4_FormClosing;
                f4.STARTBTN.Click += STARTBTN_Click;
                f4.Shown += F4_Shown;
                f4.FormClosed += F4_FormClosed;
                f4.SHOWRABOTNIKI.Click += SHOWRABOTNIKI_Click;
                f4.checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
                f4.Show();
            }
            else
            {
                f4.Activate();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (f4.checkBox1.Checked)
            {
                f4.PASSTEXT.UseSystemPasswordChar = false;
            }
            else
            {
                f4.PASSTEXT.UseSystemPasswordChar = true;
            }

        }

        private void SHOWRABOTNIKI_Click(object sender, EventArgs e)
        {
            rabontnikController = new RabotnikiController();
            f4.TEXTRABOTNIKI.Clear();
            if (rabontnikController.ListRabotniki.Count == 0)
            {
                MessageBox.Show("У вас пока ноль работников");
            }
            else
            {
                foreach (var item in rabontnikController.ListRabotniki)
                {
                    f4.TEXTRABOTNIKI.AppendText($"{item.Surname} {item.Name} {item.Patronymic} - {item.Online}" + Environment.NewLine);
                }
            }

        }

        private void F4_FormClosed(object sender, FormClosedEventArgs e)
        {
            f4 = null;
        }

        private void F4_Shown(object sender, EventArgs e)
        {
            // чтобы дописать поля в таблицы нужно
            //в Меню-Вид-Другие окна-Консоль диспетчера пакетов написать строку enable-migrations и add-migration AddGroupType и после update-database
            // эта строка разрешает совершать миграции программно - дописать поле таблицы (без ошибки)

            var logDateTimeOpen = DateTime.Now;
            var logTextOpen = "Открыл приложение";

            f4.Text = f4.Text + "-" + Environment.UserName;

            robotLogsController = new RobotLogsController(logDateTimeOpen);

            if (robotLogsController.IsNew)
            {
                robotLogsController.Set(logTextOpen, Environment.UserName);
            }

            var result = robotLogsController.RobotLogsList.OrderBy(p => p.LogDataTime);

            foreach (var item in result)
            {

                f4.MAGAZINETEXT.AppendText($"{item.LogDataTime} - {item.LogText} - {item.UserName}" + Environment.NewLine);
            }

            f4.LOGINTEXT.Text = Environment.UserName;
            f4.PASSTEXT.UseSystemPasswordChar = true;
        }

        private void STARTBTN_Click(object sender, EventArgs e)
        {
            if (f4.LOGINTEXT.Text != "" && f4.PASSTEXT.Text != "")
            {
                IWebDriver web;

                //var options = new ChromeOptions();
                //options.AddArguments("--incognito");
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--lang=ru");

                web = new ChromeDriver(options);

                web.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                web.Navigate().GoToUrl("https://support.rosatom.ru/sm");
                web.Manage().Window.Maximize();

                //    //MessageBox.Show(search.Count.ToString());

                var findElementList = web.FindElements(By.XPath("//span[@id='cwc_masthead_username']"));
                var findElement = findElementList.Count();
                var flag = false;
                if (findElement == 0)
                {
                    web.FindElement(By.XPath("//input[@id='username']")).SendKeys(f4.LOGINTEXT.Text);
                    Thread.Sleep(1000);
                    web.FindElement(By.XPath("//input[@id='password']")).SendKeys(f4.PASSTEXT.Text);
                    Thread.Sleep(1000);
                    web.FindElement(By.XPath("//input[@id='SubmitCreds']")).Click();
                    flag = true;
                }

                if (flag)
                {
                    Thread.Sleep(1000);
                    findElementList = web.FindElements(By.XPath("//span[@id='cwc_masthead_username']"));
                    findElement = findElementList.Count();
                    if (findElement == 0)
                    {
                        web.Quit();
                        MessageBox.Show("Проверьте данные и повторите процедуру");
                    }
                    else
                    {
                        SetAllZayavki(web);

                    }
                }
                else
                {
                    #region comment
                    //By by = By.XPath("//iframe[contains(@name,'mif-comp-ext-gen-top')]");

                    ////ждем фрейм пока загрузится
                    //web.SwitchTo().Frame(web.FindElement(by));
                    //Thread.Sleep(1000);
                    //var search = web.FindElements(By.CssSelector("#ext-gen-list-0-17 table")).Count();
                    //var collectionIncident = web.FindElements(By.CssSelector(".firstColumnColor"));
                    //foreach (var item in collectionIncident)
                    //{
                    //    item.Click();
                    //    web.SwitchTo().Window(web.CurrentWindowHandle);
                    //    Thread.Sleep(3000);
                    //    var back = web.FindElement(By.XPath("//em/*[text()='Отмена']"));
                    //    back.Click();
                    //    web.SwitchTo().Frame(web.FindElement(by));
                    //}
                    #endregion

                    SetAllZayavki(web);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль");
            }

        }

        private void F4_FormClosing(object sender, FormClosingEventArgs e)
        {

            var logDateTimeClose = DateTime.Now;
            var logTextClose = "Закрыл приложение";

            robotLogsController = new RobotLogsController(logDateTimeClose);
            if (robotLogsController.IsNew)
            {
                robotLogsController.Set(logTextClose, Environment.UserName);
            }
            //robotLogsController.Add(logDateTimeClose, logTextClose, userController.CurrentUser);

        }


    }
}
