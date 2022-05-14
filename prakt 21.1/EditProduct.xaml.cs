using System;
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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {

        public EditProduct(WorkshopEntities workshopEntities)
        {
            InitializeComponent();
            db = workshopEntities;
        }
        WorkshopEntities db;
        ProductCatalog catalog;
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            var idPlan = db.ProductCatalogs.Where(p => nameText.Text.ToLower() == p.Name.ToLower()).FirstOrDefault();
            if (nameText.Text == string.Empty)
            {
                errors.AppendLine("Введите наименование продукта");
            }
            while (true)
            {
                if (nameText.Text.ToLower() != catalog.Name.ToLower())
                {
                    if (idPlan != null)
                    {
                        errors.AppendLine("Введенный продукт уже есть в базе");
                        break;
                    }
                }
                else break;
            }
            if (unitText.Text == string.Empty)
            {
                errors.AppendLine("Введите единицы измерения");
            }
            if (string.IsNullOrEmpty(shopText.Text))
            {
                errors.AppendLine("Выберите цех");
            }
            if (string.IsNullOrEmpty(groupText.Text))
            {
                errors.AppendLine("Выберите группу продукции");
            }
            if (!decimal.TryParse(priceText.Text, out decimal price) || price <= 0)
            {
                errors.AppendLine("Данные цены введены неверно");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catalog.Name = nameText.Text;
            catalog.Unit = unitText.Text;
            var idShop = db.ShopCatalogs.Where(p => shopText.Text == p.Name).FirstOrDefault();
            catalog.Shop = idShop.Id;
            var idGroup = db.ProductGroups.Where(p => groupText.Text == p.Name).FirstOrDefault();
            catalog.ProductGroup = idGroup.Id;
            catalog.Price = price;
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.ShopCatalogs.Load();
            db.ProductGroups.Load();
            shopText.ItemsSource = db.ShopCatalogs.Local.ToBindingList();
            groupText.ItemsSource = db.ProductGroups.Local.ToBindingList();
            catalog = db.ProductCatalogs.Find(Transfer.Id);
            nameText.Text = catalog.Name;
            unitText.Text = catalog.Unit;
            var idShop = db.ShopCatalogs.Where(p => catalog.Shop == p.Id).FirstOrDefault();
            shopText.Text = idShop.Name;
            var idGroup = db.ProductGroups.Where(p => catalog.ProductGroup == p.Id).FirstOrDefault();
            groupText.Text = idGroup.Name;
            priceText.Text = Convert.ToString(catalog.Price);
        }
    }
}
