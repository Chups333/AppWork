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
        Form3 f3;
        Form5 f5;
        Form6 f6;
        RabotnikiController rabontnikController;
        ZayvkiController zayvkiController;
        RobotLogsController robotLogsController;
        HistorysController historysController;
        KeysAndPrioritetsController keysAndPrioritetsController;

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


                zayvkiController = new ZayvkiController();

                zayvkiController.Add(nomerNameZayavki, status, iniciator, ispolnitel, shotOpisanie, fullOpisanie);

                Thread.Sleep(1000);

                web.SwitchTo().DefaultContent();
                Thread.Sleep(1000);

                var back = web.FindElement(By.XPath("//em/*[text()='Отмена']"));
                back.Click();
                Thread.Sleep(1000);

                web.SwitchTo().Frame(web.FindElements(by)[0]);

            }
            web.SwitchTo().DefaultContent();
            Thread.Sleep(1000);

            zayvkiController = new ZayvkiController();
            if (zayvkiController.ListLogZayavok.Count == 0)
            {
                f4.INFOTEXT.Clear();
                f4.INFOTEXT.AppendText("На данный момент заявок нет");
            }
            else
            {
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
            }


        }

        private void Raspihivanye(IWebDriver web)
        {


            var by = By.CssSelector("iframe[name^='mif-comp-ext-gen-top'");
            web.SwitchTo().Frame(web.FindElements(by)[0]);
            Thread.Sleep(1000);

            var search = web.FindElements(By.CssSelector(".x-grid3-scroller table")).Count();

            for (int i = 0; i < search; i++)
            {
                Thread.Sleep(5000);
                var collectionIncident = web.FindElements(By.CssSelector(".firstColumnColor"));
                collectionIncident[search - 1 - i].Click();
                Thread.Sleep(5000);

                web.SwitchTo().DefaultContent();
                web.SwitchTo().Frame(web.FindElements(by)[1]);

                var nomerNameZayavki = web.FindElement(By.CssSelector("#X3")).GetAttribute("value");


                var ispolnitel = web.FindElement(By.CssSelector("#X246"));
                ispolnitel.Click();
                Thread.Sleep(1000);

                rabontnikController = new RabotnikiController();
                historysController = new HistorysController();
                zayvkiController = new ZayvkiController();

                if (historysController.ListHistorys.Count != 0)
                {

                    rabontnikController = new RabotnikiController();
                    var result = rabontnikController.ListRabotniki.OrderBy(p => p.Count).ToList();
                    foreach (var newitem in result)
                    {
                        if (newitem.Online == "На работе")
                        {
                            var newispolnitel = web.FindElement(By.XPath($"//div/div/*[text()='{newitem.Surname} {newitem.Name} {newitem.Patronymic} ({newitem.Login})']"));
                            newispolnitel.Click();
                            Thread.Sleep(1000);
                            historysController.AddUpdateLoginDataTime(newitem.Login, nomerNameZayavki, DateTime.Now);
                            zayvkiController.UpdateObrabotka(nomerNameZayavki);
                            zayvkiController.UpdateIspolnitel(nomerNameZayavki, $"{newitem.Surname} {newitem.Name} {newitem.Patronymic} ({newitem.Login})");
                            break;

                        }
                    }

                    foreach (var item in rabontnikController.ListRabotniki)
                    {

                        var collichectvo = historysController.ListHistorys.Where(a => a.Login == item.Login).ToList().Count;
                        var rabotnikUpdate = rabontnikController.ListRabotniki.SingleOrDefault(b => b.Login == item.Login);
                        if (rabotnikUpdate != null)
                        {
                            rabontnikController.UpdateCount(item.Login, collichectvo);
                        }

                    }

                }
                else
                {
                    var result = rabontnikController.ListRabotniki.ToList();
                    foreach (var newitem in result)
                    {
                        if (newitem.Online == "На работе")
                        {
                            var newispolnitel = web.FindElement(By.XPath($"//div/div/*[text()='{newitem.Surname} {newitem.Name} {newitem.Patronymic} ({newitem.Login})']"));
                            newispolnitel.Click();
                            Thread.Sleep(1000);
                            historysController.AddUpdateLoginDataTime(newitem.Login, nomerNameZayavki, DateTime.Now);
                            zayvkiController.UpdateObrabotka(nomerNameZayavki);
                            zayvkiController.UpdateIspolnitel(nomerNameZayavki, $"{newitem.Surname} {newitem.Name} {newitem.Patronymic} ({newitem.Login})");
                            break;
                        }
                    }
                }


                web.SwitchTo().DefaultContent();
                Thread.Sleep(1000);

                var saveButton = web.FindElement(By.XPath("//em/*[text()='Сохранить и выйти']"));
                saveButton.Click();
                Thread.Sleep(1000);

                web.SwitchTo().Frame(web.FindElements(by)[0]);

            }

            zayvkiController = new ZayvkiController();
            if (zayvkiController.ListLogZayavok.Count == 0)
            {
                f4.INFOTEXT.Clear();
                f4.INFOTEXT.AppendText("На данный момент заявок нет");
            }
            else
            {
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
                f2.Shown += F2_Shown;
                f2.Show();
            }
            else
            {
                f2.Activate();
            }
        }

        private void F2_Shown(object sender, EventArgs e)
        {
            f2.COMBOXONLINE.Text = "";
            f2.COMBOXONLINE.Items.AddRange(new string[] { "На работе", "Не на месте" });
        }

        private void ADDRABOTNIK_Click(object sender, EventArgs e)
        {
            if (f2.TEXTSURNAME.Text != "" && f2.TEXTNAME.Text != "" && f2.TEXTPATRONYMIC.Text != "" && f2.TEXTLOGIN.Text != "" && f2.COMBOXONLINE.Text != "")
            {
                var surname = f2.TEXTSURNAME.Text;
                var name = f2.TEXTNAME.Text;
                var patronymic = f2.TEXTPATRONYMIC.Text;
                var login = f2.TEXTLOGIN.Text;
                var online = f2.COMBOXONLINE.Text;

                rabontnikController = new RabotnikiController();

                rabontnikController.Add(surname, name, patronymic, login, online);

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
                f4.UPDATERABOTNIKI.Click += UPDATERABOTNIKI_Click;
                f4.DELETERABOTNIK.Click += DELETERABOTNIK_Click;
                f4.Show();
            }
            else
            {
                f4.Activate();
            }
        }

        private void DELETERABOTNIK_Click(object sender, EventArgs e)
        {
            if (f5 == null)
            {
                f5 = new Form5();
                f5.MdiParent = this;
                f5.FormClosed += F5_FormClosed;
                f5.DELETERABOTNIKOK.Click += DELETERABOTNIKOK_Click;
                f5.Shown += F5_Shown;
                f5.Show();
            }
            else
            {
                f5.Activate();
            }
        }

        private void DELETERABOTNIKOK_Click(object sender, EventArgs e)
        {
            if (f5.COMBOXLOGINOK.Text != "")
            {
                rabontnikController = new RabotnikiController();
                var deleteitem = rabontnikController.ListRabotniki.SingleOrDefault(a => a.Login == f5.COMBOXLOGINOK.Text);
                if (deleteitem != null)
                {
                    rabontnikController.DeleteItem(deleteitem.Login);
                    f4.TEXTRABOTNIKI.Clear();
                    f5.Close();

                }
                else
                {
                    MessageBox.Show("Таких нет");
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
            }
        }

        private void F5_Shown(object sender, EventArgs e)
        {
            rabontnikController = new RabotnikiController();
            if (rabontnikController.ListRabotniki.Count == 0)
            {
                MessageBox.Show("У вас нет работников. Добавте хотя бы одного работника");
            }
            f5.COMBOXLOGINOK.Text = "";
            foreach (var item in rabontnikController.ListRabotniki)
            {
                f5.COMBOXLOGINOK.Items.Add($"{item.Login}");
            }
        }

        private void F5_FormClosed(object sender, FormClosedEventArgs e)
        {
            f5 = null;
        }

        private void UPDATERABOTNIKI_Click(object sender, EventArgs e)
        {

            if (f3 == null)
            {
                f3 = new Form3();
                f3.MdiParent = this;
                f3.FormClosed += F3_FormClosed; ;
                f3.LOGINOK.Click += LOGINOK_Click;
                f3.UPDATERABOTNIK.Click += UPDATERABOTNIK_Click;
                f3.Shown += F3_Shown;
                f3.Show();
            }
            else
            {
                f3.Activate();
            }
        }

        private void F3_Shown(object sender, EventArgs e)
        {
            rabontnikController = new RabotnikiController();
            if (rabontnikController.ListRabotniki.Count == 0)
            {
                MessageBox.Show("У вас нет работников. Добавте хотя бы одного работника");
            }
            f3.COMBOXONLINE.Text = "";
            f3.COMBOXLOGINOK.Text = "";
            foreach (var item in rabontnikController.ListRabotniki)
            {
                f3.COMBOXLOGINOK.Items.Add($"{item.Login}");
            }
            f3.COMBOXONLINE.Items.AddRange(new string[] { "На работе", "Не на месте" });
        }

        private void UPDATERABOTNIK_Click(object sender, EventArgs e)
        {

            if (f3.TEXTSURNAME.Text != "" && f3.TEXTNAME.Text != "" && f3.TEXTPATRONYMIC.Text != "" && f3.TEXTLOGIN.Text != "" && f3.COMBOXONLINE.Text != "")
            {
                rabontnikController = new RabotnikiController();
                rabontnikController.UpdateItem(f3.TEXTSURNAME.Text, f3.TEXTNAME.Text, f3.TEXTPATRONYMIC.Text, f3.TEXTLOGIN.Text, f3.COMBOXONLINE.Text);
                f4.TEXTRABOTNIKI.Clear();
                f3.Close();

            }
            else
            {
                MessageBox.Show("Введите все данные");
            }
        }

        private void LOGINOK_Click(object sender, EventArgs e)
        {
            if (f3.COMBOXLOGINOK.Text != "")
            {
                rabontnikController = new RabotnikiController();
                var updateitem = rabontnikController.ListRabotniki.SingleOrDefault(a => a.Login == f3.COMBOXLOGINOK.Text);
                if (updateitem != null)
                {
                    f3.TEXTSURNAME.Text = updateitem.Surname;
                    f3.TEXTNAME.Text = updateitem.Name;
                    f3.TEXTPATRONYMIC.Text = updateitem.Patronymic;
                    f3.TEXTLOGIN.Text = updateitem.Login;
                    f3.COMBOXONLINE.Text = updateitem.Online;

                }
                else
                {
                    MessageBox.Show("Таких нет");
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
            }
        }

        private void F3_FormClosed(object sender, FormClosedEventArgs e)
        {
            f3 = null;
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

            f4.Text = f4.Text + " - " + Environment.UserName;

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
                web.Navigate().GoToUrl("https://support.rosatom.ru/sm/index.do");
                web.Manage().Window.Maximize();

                //    //MessageBox.Show(search.Count.ToString());

                var findElementList = web.FindElements(By.XPath("//span[@id='cwc_masthead_username']"));
                var findElement = findElementList.Count();
                var flag = false;
                if (findElement == 0)
                {
                    web.Navigate().GoToUrl("https://" + f4.LOGINTEXT.Text + ":" + f4.PASSTEXT.Text + "@" + "support.rosatom.ru/sm/index.do");
                    #region Нужно мне авторизация
                    //web.FindElement(By.XPath("//input[@id='username']")).SendKeys(f4.LOGINTEXT.Text);
                    //Thread.Sleep(1000);
                    //web.FindElement(By.XPath("//input[@id='password']")).SendKeys(f4.PASSTEXT.Text);
                    //Thread.Sleep(1000);
                    //web.FindElement(By.XPath("//input[@id='SubmitCreds']")).Click();
                    #endregion
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
                        Raspihivanye(web);
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
                    Raspihivanye(web);
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

        private void настройкаКлючейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f6 == null)
            {
                f6 = new Form6();
                f6.MdiParent = this;
                f6.Shown += F6_Shown;
                f6.FormClosed += F6_FormClosed;
                f6.BTNADD.Click += BTNADD_Click;
                f6.BTNUPD.Click += BTNUPD_Click;
                f6.BTNDEL.Click += BTNDEL_Click;
                f6.BTNSHOW.Click += BTNSHOW_Click;
                f6.Show();
            }
            else
            {
                f6.Activate();
            }
        }

        private void BTNSHOW_Click(object sender, EventArgs e)
        {
            f6.TEXTSHOWKEYS.Clear();
            if (f6.COMBOXLOGIN.Text == "")
            {
                keysAndPrioritetsController = new KeysAndPrioritetsController();
                foreach (var item in keysAndPrioritetsController.ListKeysAndPrioritets)
                {
                    f6.TEXTSHOWKEYS.AppendText($"{item.Login} - {item.NameKey} - {item.Prioritet}" + Environment.NewLine);
                }
            }
            else
            {
                keysAndPrioritetsController = new KeysAndPrioritetsController();
                var newList = keysAndPrioritetsController.ListKeysAndPrioritets.Where(a => a.Login == f6.COMBOXLOGIN.Text).ToList();
                foreach (var item in newList)
                {
                    f6.TEXTSHOWKEYS.AppendText($"{item.Login} - {item.NameKey} - {item.Prioritet}" + Environment.NewLine);
                }
            }
        }

        private void BTNDEL_Click(object sender, EventArgs e)
        {
            if (f6.COMBOXLOGIN.Text != "" && f6.COMBOXKEY.Text != "")
            {
                keysAndPrioritetsController = new KeysAndPrioritetsController();
                var deleteitem = keysAndPrioritetsController.ListKeysAndPrioritets.SingleOrDefault(a => a.Login == f6.COMBOXLOGIN.Text && a.NameKey == f6.COMBOXKEY.Text);
                if (deleteitem != null)
                {
                    keysAndPrioritetsController.DeleteItem(deleteitem.Login, deleteitem.NameKey);
                    f6.Close();

                }
                else
                {
                    MessageBox.Show("Таких нет");
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
            }
        }

        private void BTNUPD_Click(object sender, EventArgs e)
        {
            if (f6.COMBOXLOGIN.Text != "" && f6.COMBOXKEY.Text != "")
            {
                keysAndPrioritetsController = new KeysAndPrioritetsController();
                if (f6.CHECKBOXPRIOR.Checked == true)
                {
                    keysAndPrioritetsController.UpdateItem(f6.COMBOXLOGIN.Text, f6.COMBOXKEY.Text, 1);
                }
                else
                {
                    keysAndPrioritetsController.UpdateItem(f6.COMBOXLOGIN.Text, f6.COMBOXKEY.Text, 0);
                }
                f6.Close();
            }
            else
            {
                MessageBox.Show("Введите все данные");
            }
        }

        private void BTNADD_Click(object sender, EventArgs e)
        {
            if (f6.COMBOXLOGIN.Text != "" && f6.COMBOXKEY.Text != "")
            {
                keysAndPrioritetsController = new KeysAndPrioritetsController();
                if (f6.CHECKBOXPRIOR.Checked == true)
                {
                    keysAndPrioritetsController.Add(f6.COMBOXLOGIN.Text, f6.COMBOXKEY.Text, 1);
                }
                else
                {
                    keysAndPrioritetsController.Add(f6.COMBOXLOGIN.Text, f6.COMBOXKEY.Text, 0);
                }
                f6.Close();
            }
            else
            {
                MessageBox.Show("Введите все данные");
            }
        }

        private void F6_Shown(object sender, EventArgs e)
        {
            rabontnikController = new RabotnikiController();
            keysAndPrioritetsController = new KeysAndPrioritetsController();
            f6.COMBOXLOGIN.Text = "";
            f6.COMBOXKEY.Text = "";
            foreach (var item in rabontnikController.ListRabotniki)
            {
                f6.COMBOXLOGIN.Items.Add($"{item.Login}");
            }
            foreach (var item in keysAndPrioritetsController.ListKeysAndPrioritets)
            {
                f6.COMBOXKEY.Items.Add($"{item.NameKey}");
            }

            object[] items = f6.COMBOXKEY.Items.OfType<String>().Distinct().ToArray();
            f6.COMBOXKEY.Items.Clear();
            f6.COMBOXKEY.Items.AddRange(items);

        }

        private void F6_FormClosed(object sender, FormClosedEventArgs e)
        {
            f6 = null;
        }
    }
}
