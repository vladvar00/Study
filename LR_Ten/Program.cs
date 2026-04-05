
using System;
using System.IO;
using LR_Ten;

namespace LR_Ten
{


    class Matrix
    {
        private float[,] matrix;
        public int Rows { get; private set; }      // m
        public int Cols { get; private set; }      // n

        // Конструктор
        public Matrix() { }

        // Конструктор с размерами
        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            matrix = new float[rows, cols];
        }

        // Генерация матрицы заданного размера
        public void GenerateMatrix(int M, int N)
        {
            Rows = M;
            Cols = N;

            Random r = new Random(DateTime.Now.Millisecond);
            matrix = new float[M, N];

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    matrix[i, j] = (float)r.Next(1000) / 973f;
        }

        // Сохранение сгенерированной матрицы в файл
        public void SaveMatrix(string pFileName)
        {
            if (matrix != null && matrix.Length > 0)
            {
                if (File.Exists(pFileName))
                    File.Delete(pFileName);

                using (StreamWriter sw = new StreamWriter(pFileName))
                {
                    sw.WriteLine(Rows.ToString());
                    sw.WriteLine(Cols.ToString());

                    for (int i = 0; i < Rows; i++)
                        for (int j = 0; j < Cols; j++)
                            sw.WriteLine($"{i} {j} {matrix[i, j].ToString("E10")}");
                }
            }
        }

        // Загрузка сохраненной матрицы из файла
        public bool LoadMatrix(string pFileName)
        {
            if (!File.Exists(pFileName))
                return false;

            try
            {
                using (StreamReader sr = new StreamReader(pFileName))
                {
                    Rows = Convert.ToInt32(sr.ReadLine());
                    Cols = Convert.ToInt32(sr.ReadLine());

                    matrix = new float[Rows, Cols];

                    for (int i = 0; i < Rows; i++)
                        for (int j = 0; j < Cols; j++)
                        {
                            string line = sr.ReadLine();
                            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            // parts[2] — это значение элемента матрицы
                            matrix[i, j] = float.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture);
                        }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Вывод матрицы в консоль
        public void PrintMatrix(string name = "Матрица")
        {
            if (matrix == null || matrix.Length == 0)
            {
                Console.WriteLine("Матрица не загружена или пуста");
                return;
            }

            Console.WriteLine($"{name} ({Rows}x{Cols}):");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write(matrix[i, j].ToString("E3") + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Метод для вычисления произведения ВСЕХ элементов матрицы
        public float ProductOfAllElements()
        {
            if (matrix == null || matrix.Length == 0)
                throw new InvalidOperationException("Матрица пуста");

            float product = 1.0f;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    product *= matrix[i, j];

            return product;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("=== Программа расчёта произведения элементов двух матриц ===\n");

            // Создаём две матрицы
            Matrix matrixA = new Matrix();
            Matrix matrixB = new Matrix();

            // Генерируем и сохраняем в файлы (для примера)
            Console.WriteLine("Генерация и сохранение матриц в файлы...");
            matrixA.GenerateMatrix(3, 4);  // можно поменять размер
            matrixB.GenerateMatrix(2, 5);

            matrixA.SaveMatrix("MatrixA.txt");
            matrixB.SaveMatrix("MatrixB.txt");
            Console.WriteLine("Матрицы сохранены в MatrixA.txt и MatrixB.txt\n");

            // Очищаем объекты (симуляция новой загрузки)
            matrixA = new Matrix();
            matrixB = new Matrix();

            // Загружаем матрицы из файлов
            Console.WriteLine("Загрузка матриц из файлов...");

            if (!matrixA.LoadMatrix("MatrixA.txt"))
            {
                Console.WriteLine("Ошибка загрузки MatrixA.txt");
                Console.ReadKey();
                return;
            }

            if (!matrixB.LoadMatrix("MatrixB.txt"))
            {
                Console.WriteLine("Ошибка загрузки MatrixB.txt");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Матрицы успешно загружены!\n");

            // Выводим обе матрицы
            matrixA.PrintMatrix("Матрица A");
            matrixB.PrintMatrix("Матрица B");

            // Вычисляем произведение элементов каждой матрицы
            float productA = matrixA.ProductOfAllElements();
            float productB = matrixB.ProductOfAllElements();

            // Выводим результаты
            Console.WriteLine("=== РЕЗУЛЬТАТЫ ===");
            Console.WriteLine($"Произведение всех элементов матрицы A: {productA:E6}");
            Console.WriteLine($"Произведение всех элементов матрицы B: {productB:E6}");
            Console.WriteLine($"\nОбщее произведение (A * B): {(productA * productB):E6}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}