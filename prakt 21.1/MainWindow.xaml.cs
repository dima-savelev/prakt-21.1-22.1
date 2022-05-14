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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prakt_21._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        WorkshopEntities db = WorkshopEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.ProductCatalogs.Load();
            db.ShopCatalogs.Load();
            db.Plans.Load();
            db.ProductGroups.Load();
            productCatalog.ItemsSource = db.ProductCatalogs.Local.ToBindingList();
            shopCatalog.ItemsSource = db.ShopCatalogs.Local.ToBindingList();
            plan.ItemsSource = db.Plans.Local.ToBindingList();
            productGroup.ItemsSource = db.ProductGroups.Local.ToBindingList();
        }
        ShopCatalog _shopCatalog;
        private void shopCatalog_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            _shopCatalog = (ShopCatalog)shopCatalog.CurrentCell.Item;
        }

        private void shopCatalog_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (((TextBox)(e.EditingElement)).Text == string.Empty)
            {
                MessageBox.Show("Введите цех", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel = true;
                return;
            }
            if (_shopCatalog == null)
            {
                _shopCatalog = new ShopCatalog();
                _shopCatalog.Name = ((TextBox)(e.EditingElement)).Text;
                db.ShopCatalogs.Add(_shopCatalog);
                db.SaveChanges();
            }
            else
            {
                _shopCatalog.Name = ((TextBox)(e.EditingElement)).Text;
                db.SaveChanges();
            }
        }

        private void Del_Workshop(object sender, RoutedEventArgs e)
        {
            try
            {
                ShopCatalog _shopCatalog = (ShopCatalog)shopCatalog.SelectedItem;
                if (_shopCatalog.ProductCatalogs.Count == 0)
                {
                    db.ShopCatalogs.Remove(_shopCatalog);
                    db.SaveChanges();
                    shopCatalog.Items.Refresh();
                }
                else MessageBox.Show("Цех используется");
            }
            catch
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }
        ProductGroup _productGroup;
        private void productGroup_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            _productGroup = (ProductGroup)productGroup.CurrentCell.Item;
        }

        private void productGroup_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (((TextBox)(e.EditingElement)).Text == string.Empty)
            {
                MessageBox.Show("Введите группу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel = true;
                return;
            }
            if (_productGroup == null)
            {
                _productGroup = new ProductGroup();
                _productGroup.Name = ((TextBox)(e.EditingElement)).Text;
                db.ProductGroups.Add(_productGroup);
                db.SaveChanges();
            }
            else
            {
                _productGroup.Name = ((TextBox)(e.EditingElement)).Text;
                db.SaveChanges();
            }
        }

        private void Del_Group(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductGroup _productGroup = (ProductGroup)productGroup.SelectedItem;
                if (_productGroup.ProductCatalogs.Count == 0)
                {
                    db.ProductGroups.Remove(_productGroup);
                    db.SaveChanges();
                    productGroup.Items.Refresh();
                }
                else MessageBox.Show("Цех используется");
            }
            catch
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
            productCatalog.Focus();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = productCatalog.SelectedIndex;
            if (indexRow != -1)
            {
                ProductCatalog row = (ProductCatalog)productCatalog.Items[indexRow];
                Transfer.Id = row.Id;
                EditProduct editProduct = new EditProduct(db);
                editProduct.ShowDialog();
                productCatalog.Items.Refresh();
                productCatalog.Focus();
            }
            else
            {
                MessageBox.Show("Сначало выберете строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductCatalog _productCatalog = (ProductCatalog)productCatalog.SelectedItem;
                if (_productCatalog.Plans.Count == 0)
                {
                    db.ProductCatalogs.Remove(_productCatalog);
                    db.SaveChanges();
                    productCatalog.Items.Refresh();
                }
                else MessageBox.Show("Продукт используется используется");
            }
            catch
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }

        private void AddPlan_Click(object sender, RoutedEventArgs e)
        {
            AddPlane addPlane = new AddPlane();
            addPlane.ShowDialog();
            plan.Focus();
        }

        private void EditPlane_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = plan.SelectedIndex;
            if (indexRow != -1)
            {
                Plan row = (Plan)plan.Items[indexRow];
                Transfer.Id = row.Id;
                EditPlane editPlane = new EditPlane();
                editPlane.ShowDialog();
                plan.Items.Refresh();
                plan.Focus();
            }
            else
            {
                MessageBox.Show("Сначало выберете строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeletePlane_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Plan _plan = (Plan)plan.SelectedItem;
                db.Plans.Remove(_plan);
                db.SaveChanges();
                plan.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }

        private void RequestOne(object sender, RoutedEventArgs e)
        {
            var request = from p in db.ProductCatalogs
                      join c in db.ShopCatalogs on p.Shop equals c.Id
                      group c by c.Name into g
                      select new {Shop = g.Key, Count = g.Count() };
            requestOne.ItemsSource = request.ToList();
        }

        private void RequestTwo(object sender, RoutedEventArgs e)
        {
            var request = from p in db.ProductGroups
                          join c in db.ProductCatalogs on p.Id equals c.ProductGroup into g
                          select new { Name = p.Name, Sum = g.Sum(c => c.Price) };
            request = request.Where(r => r.Sum != null);
            requestTwo.ItemsSource = request.ToList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.ShowDialog();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Савельев Дмитрий Александрович В13\nПрактическая работа №21\nСоздать базу данных «Цеха». Создать запросы. Реализовать поиск в отдельном окне.", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddGroupProduct(object sender, RoutedEventArgs e)
        {
            int number;
            if (nameText.Text != string.Empty)
            {
                number = db.Database.ExecuteSqlCommand($"INSERT INTO ProductGroup (Name) VALUES ('{nameText.Text}')");
                db = new WorkshopEntities();
                db.ProductGroups.Load();
                productGroup.ItemsSource = db.ProductGroups.Local.ToBindingList();
                productGroup.Items.Refresh();
                productGroup.Focus();
            }
            else MessageBox.Show("Введите наименование", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void PlanRequest(object sender, RoutedEventArgs e)
        {
            var request = from p in db.Plans
                          join c in db.ProductCatalogs on p.Product equals c.Id
                          join d in db.ProductGroups on c.ProductGroup equals d.Id
                          select new { Group = d.Name, Name = c.Name, Month = p.Month, Price = c.Price * p.Count };
            planRequest.ItemsSource = request.ToList();
        }

        private void IncreasePrice(object sender, RoutedEventArgs e)
        {
            int number;
            try
            {
                ProductCatalog catalog = (ProductCatalog)productCatalog.SelectedItem;
                number = db.Database.ExecuteSqlCommand($"UPDATE ProductCatalog SET Price = price * 1.15 WHERE Id={catalog.Id}");
                db = new WorkshopEntities();
                db.ProductCatalogs.Load();
                productCatalog.ItemsSource = db.ProductCatalogs.Local.ToBindingList();
                productCatalog.Items.Refresh();
                productCatalog.Focus();
            }
            catch
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }

        private void SumPlan(object sender, RoutedEventArgs e)
        {
            var request = from p in db.ProductCatalogs
                          join c in db.Plans on p.Id equals c.Product into g
                          select new { Name = p.Name, Count = g.Sum(c => c.Count) };
            request = request.Where(r => r.Count != null);
            sumData.ItemsSource = request.ToList();
        }

        private void WorkshopRequest(object sender, RoutedEventArgs e)
        {
            List<(double, string)> values = new List<(double, string)>();
            foreach (var item in db.ShopCatalogs)
            {
                var shopPlans = db.Plans.Where(p => p.ProductCatalog.Shop == item.Id);
                var value = shopPlans.Average(p => p.Count);
                if (value == null)
                {
                    continue;
                }
                values.Add((value.Value, item.Name));
            }

            List<POxuy> output = new List<POxuy>();
            foreach (var item in db.ShopCatalogs)
            {
                double item1 = values.Where(c => c.Item2 == item.Name).FirstOrDefault().Item1;
                var loldontnow = db.Plans.Where(p => p.ProductCatalog.Shop == item.Id).Where(p => p.Count < item1).ToList();
                output.Add(new POxuy() { BindList = loldontnow }); ;
            }

            workshopData.ItemsSource = output;


            var test = from s in db.ShopCatalogs
                       join p in db.ProductCatalogs on s.Id equals p.Shop
                       join pl in db.Plans on p.Id equals pl.Product
                       select new { Name = s.Id, Count = pl.Count };

            var averageShop = from shop in test
                              group shop by shop.Name into g
                              select new { g.Key, Avg = g.Average(t => t.Count) };

            var kek = from product in db.ProductCatalogs
                      join shop in averageShop on product.Shop equals shop.Key
                      join plan in db.Plans on product.Id equals plan.Product
                      where plan.Count < shop.Avg
                      select new { Name = product.Name, Count = plan.Count, Avg = shop.Avg };

            workshopData.ItemsSource = kek.ToList();
        }
    }


    public class POxuy
    {
        public POxuy()
        {

        }

        public List<Plan> BindList { get; set; }
    }
}
