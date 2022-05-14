﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для EditPlane.xaml
    /// </summary>
    public partial class EditPlane : Window
    {
        public EditPlane()
        {
            InitializeComponent();
        }
        WorkshopEntities db = WorkshopEntities.GetContext();
        Plan plan;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.ProductCatalogs.Load();
            productText.ItemsSource = db.ProductCatalogs.Local.ToBindingList();
            plan = db.Plans.Find(Transfer.Id);
            var idProduct = db.ProductCatalogs.Where(p => plan.Product == p.Id).FirstOrDefault();
            productText.Text = idProduct.Name;
            countText.Text = Convert.ToString(plan.Count);
            monthText.Text = Convert.ToString(plan.Month);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //var idPlan = db.Plans.Where(p => productText.Text == p.ProductCatalog.Name).FirstOrDefault();
            //var idCombo = db.ProductCatalogs.Where(p => plan.Product == p.Id).FirstOrDefault();
            if (string.IsNullOrEmpty(productText.Text))
            {
                errors.AppendLine("Выберите продукцию");
            }
            //while (true)
            //{
            //    if (productText.Text != idCombo.Name)
            //    {
            //        if (idPlan != null)
            //        {
            //            errors.AppendLine("Выбранная продукция уже есть в плане");
            //            break;
            //        }
            //    }
            //    else break;
            //}
            if (!int.TryParse(countText.Text, out int count) || count <= 0)
            {
                errors.AppendLine("Количество введно неверно");
            }
            if (!byte.TryParse(monthText.Text, out byte month) || month <= 0 || month > 12)
            {
                errors.AppendLine("Номер месяца введен неверно");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var idProduct = db.ProductCatalogs.Where(p => productText.Text == p.Name).FirstOrDefault();
            plan.Product = idProduct.Id;
            plan.Count = count;
            plan.Month = month;
            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
