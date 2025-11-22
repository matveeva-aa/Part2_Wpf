using System.Collections.ObjectModel;
using System.Windows;

namespace Task_8_1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; } =
            new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();

            Products.Add(new Product
            {
                Name = "Яблоки",
                Price = 299.99m,
                ImagePath = "Images/apple.jpg",
                Category = ProductCategory.Food
            });

            Products.Add(new Product
            {
                Name = "Холодильник",
                Price = 59999.99m,
                ImagePath = "Images/fridge.jpg",
                Category = ProductCategory.Appliances
            });

            Products.Add(new Product
            {
                Name = "Бананы",
                Price = 199.99m,
                ImagePath = "Images/bananas.png",
                Category = ProductCategory.Food
            });

            DataContext = this;
        }
    }
}
