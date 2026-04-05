using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Lab11VariantEmployee
{
    // Структура данных о сотрудниках
    struct Employee
    {
        public string Name;      // ФИО сотрудника
        public double Salary;    // Зарплата
        public double Tax;      // Сумма налога
        public string Skill;     // Навык (может быть пустым или "Нет")
        public string Email;     // E-mail (может быть пустым)
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filename = "staff.dat";

            // 1. Создаем файл с тестовыми данными
            CreateFile(filename);

            // 2. Выводим список сотрудников
            Console.WriteLine("Список сотрудников в файле:");
            PrintFile(filename);

            // 3. Выполняем анализ данных
            ProcessStaffData(filename);

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }

        static void CreateFile(string path)
        {
            Employee[] staff = new Employee[]
            {
                new Employee { Name = "Григорян И.И.", Salary = 85000, Tax = 11050, Skill = "C#", Email = "ivanov@co.ru" },
                new Employee { Name = "Степанов П.П.", Salary = 45000, Tax = 5850, Skill = "Нет", Email = "" },
                new Employee { Name = "Травин А.С.", Salary = 120000, Tax = 15600, Skill = "Management", Email = "sid@co.ru" },
                new Employee { Name = "Подопригора Д.В.", Salary = 55000, Tax = 7150, Skill = "Нет", Email = "kuz@co.ru" },
                new Employee { Name = "Гугаев Е.М.", Salary = 40000, Tax = 5200, Skill = "Design", Email = "" }
            };

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create), Encoding.UTF8))
            {
                foreach (var emp in staff)
                {
                    writer.Write(emp.Name);
                    writer.Write(emp.Salary);
                    writer.Write(emp.Tax);
                    writer.Write(emp.Skill);
                    writer.Write(emp.Email);
                }
            }
        }

        static void PrintFile(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.UTF8))
            {
                Console.WriteLine("{0,-15} | {1,-10} | {2,-10} | {3,-12} | {4,-15}",
                    "Сотрудник", "З/п", "Налог", "Навык", "E-mail");
                Console.WriteLine(new string('-', 70));

                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    double sal = reader.ReadDouble();
                    double tax = reader.ReadDouble();
                    string skill = reader.ReadString();
                    string email = reader.ReadString();

                    Console.WriteLine("{0,-15} | {1,-10:F2} | {2,-10:F2} | {3,-12} | {4,-15}",
                        name, sal, tax, skill, string.IsNullOrEmpty(email) ? "---" : email);
                }
            }
        }

        static void ProcessStaffData(string path)
        {
            // Переменные для расчетов
            double maxSalary = double.MinValue;
            double minSalary = double.MaxValue;
            string maxSalaryEmp = "";
            string minSalaryEmp = "";

            double sumSalNoSkill = 0;
            int countNoSkill = 0;

            int countNoEmail = 0;
            double totalTax = 0;

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.UTF8))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    double sal = reader.ReadDouble();
                    double tax = reader.ReadDouble();
                    string skill = reader.ReadString();
                    string email = reader.ReadString();

                    // 1. Поиск Макс и Мин з/п
                    if (sal > maxSalary) { maxSalary = sal; maxSalaryEmp = name; }
                    if (sal < minSalary) { minSalary = sal; minSalaryEmp = name; }

                    // 2. Сбор данных для средней з/п без навыка ("Нет" или пусто)
                    if (string.IsNullOrEmpty(skill) || skill.ToLower() == "нет")
                    {
                        sumSalNoSkill += sal;
                        countNoSkill++;
                    }

                    // 3. Подсчет без e-mail
                    if (string.IsNullOrEmpty(email)) countNoEmail++;

                    // 4. Суммарный налог
                    totalTax += tax;
                }
            }

            // Вывод результатов
            Console.WriteLine("\n--- ОТЧЕТ ПО СОТРУДНИКАМ ---");
            Console.WriteLine($"1. Максимальная з/п: {maxSalary:F2} ({maxSalaryEmp})");
            Console.WriteLine($"   Минимальная з/п:  {minSalary:F2} ({minSalaryEmp})");

            if (countNoSkill > 0)
                Console.WriteLine($"2. Средняя з/п сотрудников без навыка: {(sumSalNoSkill / countNoSkill):F2}");
            else
                Console.WriteLine("2. Сотрудников без навыков не найдено.");

            Console.WriteLine($"3. Количество сотрудников без e-mail: {countNoEmail}");
            Console.WriteLine($"4. Суммарный налог компании: {totalTax:F2}");
        }
    }
}