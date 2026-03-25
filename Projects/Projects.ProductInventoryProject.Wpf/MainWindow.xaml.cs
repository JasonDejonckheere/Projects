using Projects.Core.Exercises.Classes.Product_Inventory_Project;
using Projects.Core.Exercises.Classes.Product_Inventory_Project.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projects.ProductInventoryProject.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Inventory inventory;
        private InventoryService _inventoryService;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            inventory = new Inventory();
            _inventoryService = new InventoryService(inventory);

            lblInventoryCount.Content = $"# of items in inventory: {_inventoryService.GetAmountOfProducts()}";
        }

        private void BtnNewProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}