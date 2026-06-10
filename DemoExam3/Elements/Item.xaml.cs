using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DemoExam3.Models;
using DemoExam3.Pages;

namespace DemoExam3.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Mebel mebel;
        public Main Main;

        public Item(Mebel mebelItem, Main main)
        {
            InitializeComponent();
            this.mebel = mebelItem;
            this.Main = main;


            lName.Content = $"Наименование: {mebel.Name}";

            lDescription.Content = $"Описание: {mebel.Description}";

            lMaterial.Content = $"Материал: {mebel.Material}";

            lWeight.Content = $"Вес: {mebel.Weight:F2} кг";

            lSize.Content = $"Размер: {mebel.Size:F2} см";

            lCost.Content = $"Стоимость: {mebel.Cost:F2} руб";

            var category = MainWindow.connection.Categories.FirstOrDefault(x => x.Id == mebel.IdCategory);
            string categoryName = category?.Name ?? "Не указана";
            lCategory.Content = $"Категория: {categoryName}";


        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить эт мебель?", "Подтверждение удаления",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow.connection.Mebels.Remove(mebel);
                MainWindow.connection.SaveChanges();
                Main.spItems.Children.Remove(this);
            }
        }

        private void Update(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Add(mebel));
    }
}
