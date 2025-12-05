using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for DataTemplate.xaml
    /// </summary>
    public partial class DataTemplate : Window
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public DataTemplate()
        {
            InitializeComponent();
            Products.Add(new Product { Name = "Anand", Price = 100, Category = "Developer" });
            Products.Add(new Product { Name = "Mahesh", Price = 200, Category = "Developer" });
            Products.Add(new Product { Name = "Sandeep", Price = 300, Category = "QA" });
            Products.Add(new Product { Name = "Nilesh", Price = 400, Category = "QA" });
            Products.Add(new Product { Name = "Anand", Price = 100, Category = "Developer" });
            Products.Add(new Product { Name = "Mahesh", Price = 200, Category = "Developer" });
            Products.Add(new Product { Name = "Sandeep", Price = 300, Category = "QA" });
            Products.Add(new Product { Name = "Nilesh", Price = 400, Category = "QA" });
            this.DataContext= this;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

}
