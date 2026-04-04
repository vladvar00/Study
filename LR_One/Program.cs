using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR_One
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №1");
            Console.WriteLine(" Дата рождения студента: 15.06.2004");
            Console.WriteLine("Выполнил: Варяница Владислав Геннадьевич");
            Console.WriteLine("Группа: ИДПО-ИСИТ-З-У-24/1");
            Console.WriteLine("Наименование ЛР: Разработка консольного приложения");
            Console.WriteLine("Населенный пункт постоянного места жительства студента: Ставрополь");

            Console.WriteLine("Любимый предмет в школе: Физкультура");
            Console.WriteLine("Краткое описание увлечений, хобби, интересов: Игра на гитаре");
            Console.WriteLine("ДАЛЕЕ ВЫПОЛНИЛ ЗАДАНИЯ С ФУНКЦИЕЙ");
            int f = 10;
            int y = 16;
            float Zze = (35 / f) + (y * f) - ((f + y) / 4);
            Console.WriteLine("Значение функции ее: {0}", Zze);

            Console.WriteLine("Для завершения работы программы нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}