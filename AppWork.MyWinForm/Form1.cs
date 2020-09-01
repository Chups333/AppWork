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

            var logDateTimeOpen = DateTime.Now;

            var robotLogsController = new RobotLogsController(logDateTimeOpen);
            if (robotLogsController.IsNew)
            {
                var logTextOpen = "Открыл приложение";

                robotLogsController.SetNewData(logTextOpen);
            }

            var result = robotLogsController.RobotLogsList.OrderBy(p => p.LogDataTime);

            foreach (var item in result)
            {

                MAGAZINETEXT.AppendText($"{item.LogDataTime} - {item.LogText}" + Environment.NewLine);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var logDateTimeClose = DateTime.Now;

            var robotLogsController = new RobotLogsController(logDateTimeClose);

            if (robotLogsController.IsNew)
            {
                var logTextClose = "Закрыл приложение";

                robotLogsController.SetNewData(logTextClose);
            }
        }

        private void STARTBTN_Click(object sender, EventArgs e)
        {
            IWebDriver web;
            var zayvkiController = new ZayvkiController();

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
                    SetAllZayavki(web, zayvkiController);

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

                SetAllZayavki(web, zayvkiController);
            }

        }

        private void SetAllZayavki(IWebDriver web, ZayvkiController zayvkiController)
        {
            By by = By.XPath("//iframe[contains(@name,'mif-comp-ext-gen-top')]");

            //ждем фрейм пока загрузится
            web.SwitchTo().Frame(web.FindElement(by));
            Thread.Sleep(1000);
            var search = web.FindElements(By.CssSelector("#ext-gen-list-0-17 table")).Count();
            Thread.Sleep(1000);
            var collectionIncident = web.FindElements(By.CssSelector(".firstColumnColor"));

            foreach (var item in collectionIncident)
            {
                item.Click();

                Thread.Sleep(1000);
                var nomerNameZayavki = web.FindElements(By.CssSelector("#X3")).Count();
                Thread.Sleep(1000);
                var status = web.FindElements(By.CssSelector("#X209Border")).Count();
                Thread.Sleep(1000);
                //var logZayavok = new LogZayavok(nomerNameZayavki, status);
                // zayvkiController.Add(search, logZayavok);

                web.SwitchTo().Window(web.CurrentWindowHandle);

                Thread.Sleep(3000);

                var back = web.FindElement(By.XPath("//em/*[text()='Отмена']"));

                back.Click();

                web.SwitchTo().Frame(web.FindElement(by));
            }

            web.Quit();
            foreach (var item in zayvkiController.ListCountZayavok)
            {
                MAGAZINETEXT.AppendText($"{item.LogZayavok.NomerNameZayavki} - {item.LogZayavok.Status}" + Environment.NewLine);

            }
        }
    }
}
