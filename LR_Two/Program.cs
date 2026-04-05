using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace LR_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №2");
            Console.WriteLine("Выполнил: Варяница Владислав Геннадьевич");
            Console.WriteLine("Группа: ИДПО-ИСИТ-З-У-24/1");
            Console.WriteLine("Наименование ЛР: ПЕРЕНАПРАВЛЕНИЕ ПОТОКОВ ВВОДА-ВЫВОДА");
            Console.WriteLine("ДАЛЕЕ ВЫПОЛНИЛ ЗАДАНИЯ С ФУНКЦИЕЙ");


            double epoch, drive, city, birth, age, user, pwd;


            Console.WriteLine("Веедите значение переменных age:");
            age = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Веедите значение переменных birth:");
            birth = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Веедите значение переменных city:");
            city = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Веедите значение переменных drive:");
            drive = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Веедите значение переменных epoch:");
            epoch = Convert.ToDouble(Console.ReadLine());

            if ((age < 0) || (age > 100000) || (birth < 0) || (birth > 100000) || (city < 0) || (city > 100000) || (drive < 0) || (drive > 100000) || (epoch < 0) || (epoch > 100000))
                Console.WriteLine("ERROR");

            else
            {
                user = ((age / Math.Sqrt(birth)) + (city / Math.Sqrt(drive)));
                pwd = Math.Sqrt(city - Math.Sqrt(drive - Math.Sqrt(epoch)));
                Console.WriteLine(String.Format("Занчение    выражения user: {0:0.00}", user));
                Console.WriteLine(String.Format("Занчение выражения pwd: {0:0.00}", pwd));
            }
            Console.WriteLine("для завершения работы программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}