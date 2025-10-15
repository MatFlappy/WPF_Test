using System;
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
using WPF_Test.Model;

namespace WPF_Test.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductMenu.xaml
    /// </summary>
    public partial class ProductMenu : Window
    {

        public List<Product> Products { get; private set; }

        public ProductMenu()
        {
            InitializeComponent();

            InitializeComponent();
            LoadProducts();
            DataContext = this;
        }

        private void LoadProducts()
        {
            try
            {
                Products = App.context.Product
                    .Include("Category")
                    .OrderBy(p => p.Name)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить товары: {ex.Message}",
                                "Ошибка загрузки",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                Products = new List<Product>();
            }
        }

    }
}
