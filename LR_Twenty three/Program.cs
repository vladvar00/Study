using System;
using System.Threading;

namespace Lab23_Variant13
{
    // Структура для передачи размеров матрицы в поток
    public struct MatrixDimensions
    {
        public int Rows;
        public int Cols;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторная работа №23 (Вариант 13) ===");
            
            try
            {
                // 1. Ввод размеров матрицы пользователем
                Console.Write("Введите количество строк: ");
                int r = int.Parse(Console.ReadLine());

                Console.Write("Введите количество столбцов: ");
                int c = int.Parse(Console.ReadLine());

                MatrixDimensions dims = new MatrixDimensions { Rows = r, Cols = c };

                // 2. Создание потока с использованием ParameterizedThreadStart
                Thread workerThread = new Thread(new ParameterizedThreadStart(FindMinMaxDifference));

                Console.WriteLine("\n[Main]: Запуск потока вычислений...");
                workerThread.Start(dims);

                // Ожидаем завершения потока
                workerThread.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }

            Console.WriteLine("\n[Main]: Программа завершена. Нажмите любую клавишу...");
            Console.ReadKey();
        }

        // Метод для выполнения в отдельном потоке
        static void FindMinMaxDifference(object obj)
        {
            MatrixDimensions d = (MatrixDimensions)obj;
            Random rnd = new Random();
            
            int[,] matrix = new int[d.Rows, d.Cols];
            
            // Инициализируем min и max первым возможным значением или пределами int
            int minVal = int.MaxValue;
            int maxVal = int.MinValue;

            Console.WriteLine($"[Thread]: Матрица {d.Rows}x{d.Cols}:");

            // Заполнение матрицы и поиск экстремумов
            for (int i = 0; i < d.Rows; i++)
            {
                for (int j = 0; j < d.Cols; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 101); // Случайные числа от -100 до 100
                    
                    if (matrix[i, j] < minVal) minVal = matrix[i, j];
                    if (matrix[i, j] > maxVal) maxVal = matrix[i, j];

                    // Вывод матрицы в консоль
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int difference = maxVal - minVal;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"[Thread]: Максимальный элемент: {maxVal}");
            Console.WriteLine($"[Thread]: Минимальный элемент: {minVal}");
            Console.WriteLine($"[Thread]: Разница (Max - Min) = {difference}");
        }
    }
}
