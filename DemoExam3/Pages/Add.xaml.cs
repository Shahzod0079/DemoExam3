using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DemoExam3.Models;

namespace DemoExam3.Pages
{
    public partial class Add : Page
    {

        public Mebel mebel = null;

        public Add(Mebel mebel = null)
        {
            InitializeComponent();

            this.mebel = mebel;

            var categories = MainWindow.connection.Categories.ToList();

            foreach (Category cat in categories)
            {
                tCategory.Items.Add(cat.Name);
            }

            if(mebel != null)
            {
                int index = categories.FindIndex(x => x.Id == mebel.IdCategory);

                if (index >= 0)
                {
                    tCategory.SelectedIndex = index;

                }

                tName.Text = mebel.Name;
                tDescription.Text = mebel.Description;
                tMaterial.Text = mebel.Material;
                tWeight.Text = mebel.Weight.ToString();
                tSize.Text = mebel.Size.ToString();
                tCost.Text = mebel.Cost.ToString();

            }
        }

        private void Back(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Main());

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tName.Text))
                {
                    MessageBox.Show("Введите наименование");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tDescription.Text))
                {
                    MessageBox.Show("Введите описание");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tMaterial.Text))
                {
                    MessageBox.Show("Введите материал");
                    return;
                }

                if(!decimal.TryParse(tWeight.Text, out decimal weight))
                {
                    MessageBox.Show("Вес должен быть числом");
                    return;
                }
                if (!decimal.TryParse(tSize.Text, out decimal size))
                {
                    MessageBox.Show("Размер должен быть числом");
                    return;
                }

                if (!decimal.TryParse(tCost.Text, out decimal cost))
                {
                    MessageBox.Show("Стоимость должна быть числом");
                    return;
                }

                if(tCategory.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите категорию");
                    return;
                }

                if(mebel == null)
                {
                    mebel = new Mebel();
                    MainWindow.connection.Mebels.Add(mebel);
                }

                mebel.Name = tName.Text;
                mebel.Description = tDescription.Text;
                mebel.Material = tMaterial.Text;
                mebel.Weight = weight;
                mebel.Size = size;
                mebel.Cost = cost;

                var selectedCat = MainWindow.connection.Categories.ToList()[tCategory.SelectedIndex];

                mebel.IdCategory = selectedCat.Id;

                MainWindow.connection.SaveChanges();
                MessageBox.Show("Данные сохранены");
                Back(null, null);
            }
            catch (Exception exp)
            {
                MessageBox.Show($"Ошибка: {exp.Message}");
            }
        }
    }
}
