﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prakt_21._1
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }
        WorkshopEntities db = WorkshopEntities.GetContext();
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (nameText.Text != string.Empty)
            {
                var request = db.ProductCatalogs.Where(p => nameText.Text.ToLower() == p.Name.ToLower()).FirstOrDefault();

                if (request == null)
                {
                    MessageBox.Show("Данный продукт не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                groupText.Text = request.ProductGroup1.Name;
            }
            else MessageBox.Show("Введите название продукта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
