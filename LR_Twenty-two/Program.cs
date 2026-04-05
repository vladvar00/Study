using System;
using System.Threading;
using System.Threading.Tasks;

namespace LR_Twentytwo
{
    class Program
    {
        // 1. Объявление ПОЛЬЗОВАТЕЛЬСКОГО делегата (согласно заданию)
        // Принимает два параметра (размеры матрицы) и возвращает int (кол-во нечетных)
        public delegate int MatrixOddCounterDelegate(int rows, int cols);

        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №22. Вариант 13.");

            // Ввод параметров
            Console.Write("Введите количество строк матрицы: ");
            int rows = int.TryParse(Console.ReadLine(), out int r) ? r : 3;

            Console.Write("Введите количество столбцов матрицы: ");
            int cols = int.TryParse(Console.ReadLine(), out int c) ? c : 3;

            // 2. Инициализация делегата методом (используем именованный метод)
            MatrixOddCounterDelegate del = CountOddElements;

            Console.WriteLine("\nЗапуск асинхронной операции...");

            // 3. Асинхронный запуск через Task (современная замена BeginInvoke)
            Task<int> task = Task.Run(() => del(rows, cols));

            // 4. Мониторинг процесса в главном потоке
            while (!task.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }

            // 5. Получение и вывод результата
            int result = task.Result;
            Console.WriteLine($"\n\nГотово! Количество нечетных элементов в матрице: {result}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Метод, соответствующий сигнатуре делегата
        static int CountOddElements(int rows, int cols)
        {
            Console.WriteLine($"[Поток] Генерация матрицы {rows}x{cols}...");
            Random rnd = new Random();
            int oddCount = 0;

            // Имитация задержки для наглядности асинхронности
            Thread.Sleep(3000);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int val = rnd.Next(1, 101); // Случайное число от 1 до 100
                    if (val % 2 != 0)
                    {
                        oddCount++;
                    }
                }
            }

            return oddCount;
        }
    }
}
