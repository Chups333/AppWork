using AppWork.BL.Controller;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace AppWork.CMD
{
    public sealed class Program
    {
        static void Main(string[] args)
        {
            IWebDriver web;
            // чтобы дописать поля в таблицы нужно
            //в Меню-Вид-Другие окна-Консоль диспетчера пакетов написать строку enable-migrations и add-migration AddGroupType и после update-database
            // эта строка разрешает совершать миграции программно - дописать поле таблицы (без ошибки)

            Console.WriteLine("Добро пожаловать в приложение Robot!!!");


            var logDateTimeOpen = DateTime.Now;

            var robotLogsController = new RobotLogsController(logDateTimeOpen);
            if (robotLogsController.IsNew)
            {
                var logTextOpen = "Открыл приложение";

                robotLogsController.SetNewData(logTextOpen);
            }
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - Вывести журнал");
                Console.WriteLine("A - Работа с HPSM");

                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var result = robotLogsController.RobotLogsList.OrderBy(p => p.LogDataTime);

                        foreach (var item in result)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{item.LogDataTime} - {item.LogText}");
                        }
                        break;
                    case ConsoleKey.A:

                        Console.WriteLine("Введите логин");
                        var LOGIN = Console.ReadLine();
                        Console.WriteLine("Введите пароль");
                        var PASS = Console.ReadLine();


                        web = new ChromeDriver();

                        web.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        web.Navigate().GoToUrl("https://support.rosatom.ru/sm");
                        web.Manage().Window.Maximize();

                        var findElement = web.FindElements(By.XPath("//span[@id='cwc_masthead_username']")).Count();
                        if (findElement == 0)
                        {
                            web.FindElement(By.XPath("//input[@id='username']")).SendKeys(LOGIN);
                            web.FindElement(By.XPath("//input[@id='password']")).SendKeys(PASS);
                            web.FindElement(By.XPath("//input[@id='SubmitCreds']")).Click();
                        }

                        

                        #region CommentConnect;
                        //try
                        //{
                        //    try
                        //    {
                        //        web.Navigate().GoToUrl("https://support.rosatom.ru/sm");
                        //    }
                        //    catch (Exception)
                        //    {

                        //        Console.WriteLine("Ошибка. Не удалось перейти по URL");
                        //    }

                        //    try
                        //    {
                        //        web.FindElement(By.XPath("//input[@id='username']")).SendKeys(LOGIN);
                        //    }
                        //    catch (Exception)
                        //    {
                        //        Console.WriteLine("Ошибка. Не удалось ввести логин");
                        //    }

                        //    try
                        //    {
                        //        web.FindElement(By.XPath("//input[@id='password']")).SendKeys(PASS);
                        //    }
                        //    catch (Exception)
                        //    {
                        //        Console.WriteLine("Ошибка. Не удалось ввести пароль");

                        //    }
                        //    try
                        //    {
                        //        web.FindElement(By.XPath("//input[@id='SubmitCreds']")).Click();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        Console.WriteLine("Ошибка. Не удалось нажать на кнопку ВОЙТИ");

                        //    }



                        //}
                        //catch (Exception)
                        //{


                        //}
                        #endregion


                        break;
                    case ConsoleKey.Q:

                        var logDateTimeClose = DateTime.Now;

                        robotLogsController = new RobotLogsController(logDateTimeClose);

                        if (robotLogsController.IsNew)
                        {
                            var logTextClose = "Закрыл приложение";

                            robotLogsController.SetNewData(logTextClose);
                        }

                        //web.Quit();
                        Environment.Exit(0);
                        break;
                }
            }
        }


    }
}
