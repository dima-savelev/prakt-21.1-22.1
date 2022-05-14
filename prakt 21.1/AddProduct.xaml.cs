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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        WorkshopEntities db = WorkshopEntities.GetContext();
        ProductCatalog catalog;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.ShopCatalogs.Load();
            db.ProductGroups.Load();
            shopText.ItemsSource = db.ShopCatalogs.Local.ToBindingList();
            groupText.ItemsSource = db.ProductGroups.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            var idPlan = db.ProductCatalogs.Where(p => nameText.Text.ToLower() == p.Name.ToLower()).FirstOrDefault();
            if (nameText.Text == string.Empty)
            {
                errors.AppendLine("Введите наименование продукта");
            }
            if (idPlan != null)
            {
                errors.AppendLine("Данный продукт уже есть в базе");
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
            catalog = new ProductCatalog();
            catalog.Name = nameText.Text;
            catalog.Unit = unitText.Text;
            var idShop = db.ShopCatalogs.Where(p => shopText.Text == p.Name).FirstOrDefault();
            catalog.Shop = idShop.Id;
            var idGroup = db.ProductGroups.Where(p => groupText.Text == p.Name).FirstOrDefault();
            catalog.ProductGroup = idGroup.Id;
            catalog.Price = price;
            try
            {
                db.ProductCatalogs.Add(catalog);
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
    }
}
