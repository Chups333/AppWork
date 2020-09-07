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

        private void Form1_Shown(object sender, EventArgs e)
        {

            // чтобы дописать поля в таблицы нужно
            //в Меню-Вид-Другие окна-Консоль диспетчера пакетов написать строку enable-migrations и add-migration AddGroupType и после update-database
            // эта строка разрешает совершать миграции программно - дописать поле таблицы (без ошибки)

            STARTBTN.Enabled = false;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LOGINTEXT.Text != "" && PASSTEXT.Text != "")
            {
                var logDateTimeClose = DateTime.Now;
                var logTextClose = "Закрыл приложение";
                var userController = new UserController(LOGINTEXT.Text);

                if (userController.IsNewUser)
                {
                    userController.SetNewUserData(PASSTEXT.Text);
                }


                var robotLogsController = new RobotLogsController(logDateTimeClose);
                if (robotLogsController.IsNew)
                {
                    robotLogsController.Set(logTextClose);
                }
                //robotLogsController.Add(logDateTimeClose, logTextClose, userController.CurrentUser);
            }
        }

        private void STARTBTN_Click(object sender, EventArgs e)
        {
            if (LOGINTEXT.Text != "" && PASSTEXT.Text != "")
            {
                IWebDriver web;

                var userController = new UserController(LOGINTEXT.Text);

                if (userController.IsNewUser)
                {
                    userController.SetNewUserData(PASSTEXT.Text);
                }
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
                    web.FindElement(By.XPath("//input[@id='username']")).SendKeys(LOGINTEXT.Text);
                    Thread.Sleep(1000);
                    web.FindElement(By.XPath("//input[@id='password']")).SendKeys(PASSTEXT.Text);
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

                var union = collectionWordsShotOpis.Union(collectionWordsFullOpis);
                

                var zayvkiController = new ZayvkiController(nomerNameZayavki, status);
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
                INFOTEXT.Clear();
                foreach (var item in zayvkiController.ListLogZayavok)
                {
                    INFOTEXT.AppendText($"{item.NomerNameZayavki} -> {item.Status}" + Environment.NewLine);
                    INFOTEXT.AppendText($"{item.Iniciator} -> {item.Ispolnitel}" + Environment.NewLine);
                    INFOTEXT.AppendText($"{item.ShotOpisanie} -> {item.FullOpisanie}" + Environment.NewLine);
                    foreach(var word in union)
                    {
                        INFOTEXT.AppendText(word + Environment.NewLine);
                    }
                    INFOTEXT.AppendText(" " + Environment.NewLine);
                }
            }
            

            web.Quit();

        }

        private void MAGAZINEBTN_Click(object sender, EventArgs e)
        {
            if (LOGINTEXT.Text != "" && PASSTEXT.Text != "")
            {
                var logDateTimeOpen = DateTime.Now;
                var logTextOpen = "Открыл приложение";
                var userController = new UserController(LOGINTEXT.Text);

                if (userController.IsNewUser)
                {
                    userController.SetNewUserData(PASSTEXT.Text);
                }

                this.Text = this.Text + "-" + userController.CurrentUser.Login;


                var robotLogsController = new RobotLogsController(logDateTimeOpen);

                if (robotLogsController.IsNew)
                {
                    robotLogsController.Set(logTextOpen);
                }

                var result = robotLogsController.RobotLogsList.OrderBy(p => p.LogDataTime);

                foreach (var item in result)
                {

                    MAGAZINETEXT.AppendText($"{item.LogDataTime} - {item.LogText}" + Environment.NewLine);
                }

                MAGAZINEBTN.Enabled = false;
                STARTBTN.Enabled = true;
            }
            else
            {
                MessageBox.Show("Введите логин и пароль");
            }
        }
    }
}
