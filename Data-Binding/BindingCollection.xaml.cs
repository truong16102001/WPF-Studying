using System.Collections.ObjectModel;
using System.Windows;


namespace Data_Binding
{
    /// <summary>
    /// Interaction logic for BindingCollection.xaml
    /// </summary>
    public partial class BindingCollection : Window
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public BindingCollection()
        {
            InitializeComponent();
            InitializeCategories();
            InitializeProducts();
            cbCategory.ItemsSource = Categories;
            cbCategory.SelectedIndex = 0;
            lvProducts.ItemsSource = Products;
        }

        private void InitializeCategories()
        {
            Categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Books" },
                new Category { CategoryId = 3, CategoryName = "Clothing" },
                new Category { CategoryId = 4, CategoryName = "Home & Kitchen" },
                new Category { CategoryId = 5, CategoryName = "Sports" }
            };
        }

        private void InitializeProducts()
        {
            Products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop", CategoryId = 1, Category = Categories.FirstOrDefault(c => c.CategoryId == 1) },
                new Product { ProductId = 2, ProductName = "Smartphone", CategoryId = 1, Category = Categories.FirstOrDefault(c => c.CategoryId == 1) },
                new Product { ProductId = 3, ProductName = "Fiction Book", CategoryId = 2, Category = Categories.FirstOrDefault(c => c.CategoryId == 2) },
                new Product { ProductId = 4, ProductName = "Non-Fiction Book", CategoryId = 2, Category = Categories.FirstOrDefault(c => c.CategoryId == 2) },
                new Product { ProductId = 5, ProductName = "T-Shirt", CategoryId = 3, Category = Categories.FirstOrDefault(c => c.CategoryId == 3) },
                new Product { ProductId = 6, ProductName = "Jeans", CategoryId = 3, Category = Categories.FirstOrDefault(c => c.CategoryId == 3) },
                new Product { ProductId = 7, ProductName = "Blender", CategoryId = 4, Category = Categories.FirstOrDefault(c => c.CategoryId == 4) },
                new Product { ProductId = 8, ProductName = "Microwave", CategoryId = 4, Category = Categories.FirstOrDefault(c => c.CategoryId == 4) },
                new Product { ProductId = 9, ProductName = "Tennis Racket", CategoryId = 5, Category = Categories.FirstOrDefault(c => c.CategoryId == 5) },
                new Product { ProductId = 10, ProductName = "Soccer Ball", CategoryId = 5, Category = Categories.FirstOrDefault(c => c.CategoryId == 5) }
            };
        }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

    }
}
