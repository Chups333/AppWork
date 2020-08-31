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

            web = new ChromeDriver();

            web.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            web.Navigate().GoToUrl("https://support.rosatom.ru/sm");
            web.Manage().Window.Maximize();

            var findElementList = web.FindElements(By.XPath("//span[@id='cwc_masthead_username']"));
            var findElement = findElementList.Count();
            while (findElement == 0)
            {
                web.FindElement(By.XPath("//input[@id='username']")).SendKeys(LOGINTEXT.Text);
                web.FindElement(By.XPath("//input[@id='password']")).SendKeys(PASSTEXT.Text);
                web.FindElement(By.XPath("//input[@id='SubmitCreds']")).Click();
                findElement = 1;
            }


            //var elements = web.FindElements(By.CssSelector("#ext-gen-list-0-17 table")).ToList();

            //MAGAZINETEXT.AppendText(elements.Count().ToString());

            Thread.Sleep(20000);
            var search = web.FindElement(By.XPath("//em/button[@id='ext-gen-top365']")).Location;
            var actiomClick = new Actions(web);
            actiomClick.MoveByOffset(search.X,search.Y+240).Click();
            actiomClick.Build().Perform();

            //MAGAZINETEXT.AppendText(search.X.ToString()+" "+search.Y.ToString());
            //var actiomClick = new Actions(web).Click(search);)
            //actiomClick.Build().Perform();
            //web.Quit();




        }


    }
}
