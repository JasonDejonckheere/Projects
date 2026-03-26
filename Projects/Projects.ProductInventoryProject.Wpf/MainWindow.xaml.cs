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
            SetStartupUI();
            SetProductFeedback("", false);
            SetStockFeedback("", false);
        }

        private void BtnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            btnNewProduct.IsEnabled = false;
            txtProductName.IsEnabled = true;
            txtProductPrice.IsEnabled = true;
            btnSaveProduct.IsEnabled = true;
        }
        private void BtnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            string productPrice = txtProductPrice.Text;

            if (string.IsNullOrWhiteSpace(productName))
            {
                SetProductFeedback("Invalid product name.", true);
                return;
            }

            if (string.IsNullOrEmpty(productPrice))
            {
                SetProductFeedback("Invalid product price.", true);
                return;
            }

            if (inventory.ContainsProduct(new Product { Name = productName }))
            {
                SetProductFeedback("Product already in inventory.", true);
                return;
            }

            inventory.AddProduct(new Product
            {
                Name = txtProductName.Text,
                Price = decimal.Parse(txtProductPrice.Text)
            });

            txtProductName.Clear();
            txtProductName.IsEnabled = false;
            txtProductPrice.Clear();
            txtProductPrice.IsEnabled = false;
            btnSaveProduct.IsEnabled = false;
            btnNewProduct.IsEnabled = true;


            SetProductFeedback("Succesfully added product", false);
            RefreshUI();
        }

        private void SetStartupUI()
        {
            txtBuy.IsEnabled = false;
            btnBuy.IsEnabled = false;

            txtSell.IsEnabled = false;
            btnSell.IsEnabled = false;

            txtProductName.IsEnabled = false;
            txtProductPrice.IsEnabled = false;

            btnSaveProduct.IsEnabled = false;
        }

        private void RefreshUI()
        {
            int selectedIndex = lstProducts.SelectedIndex;
            lstProducts.ItemsSource = null;
            lstProducts.ItemsSource = inventory.ProductsInInventory;
            lstProducts.SelectedIndex = selectedIndex;
        }

        public void SetProductFeedback(string message, bool IsErrorMessage)
        {
            lblFeedback.Content = message;
            if (IsErrorMessage)
            {
                lblFeedback.Foreground = Brushes.Red;
                return;
            }

            lblFeedback.Foreground = Brushes.Green;
        }

        public void SetStockFeedback(string message, bool IsErrorMessage)
        {
            lblStockFeedback.Content = message;
            if (IsErrorMessage)
            {
                lblStockFeedback.Foreground = Brushes.Red;
                return;
            }

            lblStockFeedback.Foreground = Brushes.Green;
        }

        private void LstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstProducts.SelectedIndex == -1) 
            {
                txtBuy.IsEnabled = false;
                btnBuy.IsEnabled = false;
                txtSell.IsEnabled = false;
                btnSell.IsEnabled = false;
            }

            txtBuy.IsEnabled = true;
            btnBuy.IsEnabled = true;
            txtSell.IsEnabled = true;
            btnSell.IsEnabled = true;
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            //todo validate txtbuy.text input if decimal parseable
            Product selectedProduct = (Product)lstProducts.SelectedItem;
            var result = inventory.Buy(selectedProduct, int.Parse(txtBuy.Text));
            if (!result.IsSucces)
            {
                SetStockFeedback(result.ErrorMessage, true);
            }
            SetStockFeedback($"Succesfull transaction. (buy: {txtBuy.Text}x {selectedProduct.Name}", false);
            txtBuy.Text = "0";
            RefreshUI();
        }

        private void BtnSell_Click(object sender, RoutedEventArgs e)
        {
            //todo validate txtbuy.text input if decimal parseable
            Product selectedProduct = (Product)lstProducts.SelectedItem;
            var result = inventory.Sell(selectedProduct, int.Parse(txtBuy.Text));
            if (!result.IsSucces)
            {
                SetStockFeedback(result.ErrorMessage, true);
            }
            SetStockFeedback($"Succesfull transaction. (sell: {txtBuy.Text}x {selectedProduct.Name}", false);
            txtSell.Text = "0";
            RefreshUI();
        }
    }
}