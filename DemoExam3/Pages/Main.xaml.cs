using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using DemoExam3.Elements;
using DemoExam3.Models;

namespace DemoExam3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            LoadMebels();

            
        }
        public void LoadMebels()
        {
            spItems.Children.Clear();
            foreach (Mebel m in MainWindow.connection.Mebels.ToList())
                spItems.Children.Add(new Item(m, this));

            var allMebels = MainWindow.connection.Mebels.ToList();

            foreach (Mebel m in allMebels)
            {
                var item = new Item(m, this);

                spItems.Children.Add(item);
            }
        }

        private void Add(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Add());
    }
}
