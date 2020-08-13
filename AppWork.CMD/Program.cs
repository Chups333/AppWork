using AppWork.BL.Controller;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.CMD
{
    public sealed class Program
    {
        static void Main(string[] args)
        {

            // чтобы дописать поля в таблицы нужно
            //в Меню-Вид-Другие окна-Консоль диспетчера пакетов написать строку enable-migrations и add-migration AddGroupType и после update-database
            // эта строка разрешает совершать миграции программно - дописать поле таблицы (без ошибки)

            Console.WriteLine("Добро пожаловать в приложение Robot!!!");
           

            var logDateTime = DateTime.Now;
            var logText = "Открыл приложение";
            var robotLogsController = new RobotLogsController(logDateTime,logText);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - Вывести журнал");
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
                    case ConsoleKey.Q:

                        logDateTime = DateTime.Now;
                        logText = "Закрыл приложение";
                        robotLogsController = new RobotLogsController(logDateTime,logText);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
