using System.Windows;
using LogicTier;

namespace PresentationTier
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Путь к файлу. Для VS Code лучше указывать так, 
            // если файл лежит в корне всей папки
            string path = "../cars.txt";
            DataContext = new CarManager(path);
            InitializeComponent();
        }
    }
}