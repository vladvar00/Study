using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork1
{
    public class Form1 : Form
    {
        // Поля для ввода (z и as_9)
        private TextBox txtZ_var, txtAS9;
        // Поля только для чтения (координаты X и Y)
        private TextBox txtMouseX, txtMouseY;

        public Form1()
        {
            this.Text = "Вариант 13: Расчет Z";
            this.Size = new Size(400, 300);

            // Инициализация полей
            txtZ_var = new TextBox { Location = new Point(150, 20), Text = "1" };
            txtAS9 = new TextBox { Location = new Point(150, 50), Text = "1" };
            txtMouseX = new TextBox { Location = new Point(150, 80), ReadOnly = true };
            txtMouseY = new TextBox { Location = new Point(150, 110), ReadOnly = true };

            // Подписи
            this.Controls.Add(new Label { Text = "Переменная z:", Location = new Point(20, 20) });
            this.Controls.Add(new Label { Text = "Переменная as_9:", Location = new Point(20, 50) });
            this.Controls.Add(new Label { Text = "Координата X (x):", Location = new Point(20, 80) });
            this.Controls.Add(new Label { Text = "Координата Y (y):", Location = new Point(20, 110) });

            this.Controls.AddRange(new Control[] { txtZ_var, txtAS9, txtMouseX, txtMouseY });

            // Подписка на событие движения мыши
            this.MouseMove += new MouseEventHandler(CalculateVariant13);
        }

        private void CalculateVariant13(object sender, MouseEventArgs e)
        {
            // Отображаем текущие координаты
            txtMouseX.Text = e.X.ToString();
            txtMouseY.Text = e.Y.ToString();

            try
            {
                // 1. Считываем данные от пользователя
                double z = double.Parse(txtZ_var.Text);
                double as_9 = double.Parse(txtAS9.Text);

                // 2. Данные из координат мыши
                double x = e.X;
                double y = e.Y;

                // 3. Вычисление формулы:
                // Z = z * cos(y) + sqrt(e^7) - |x + cos(as_9 + y)|

                double term1 = z * Math.Cos(y);
                double term2 = Math.Sqrt(Math.Pow(Math.E, 7));
                double term3 = Math.Abs(x + Math.Cos(as_9 + y));

                double Z = term1 + term2 - term3;

                // Вывод результата в заголовок окна
                this.Text = $"Z = {Z:F4}";
            }
            catch
            {
                // Если в полях не числа
                this.Text = "ERROR";
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
