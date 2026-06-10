using System.Data.Common;
using System.Windows;
using DemoExam3.Classes;
using DemoExam3.Pages;
using DbConnection = DemoExam3.Classes.DbConnection;

namespace DemoExam3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DbConnection connection = new DbConnection();
        public static MainWindow Init;

        public MainWindow()
        {
            InitializeComponent();
            Init = this;

            frame.Navigate(new Main());
        }
    }
}