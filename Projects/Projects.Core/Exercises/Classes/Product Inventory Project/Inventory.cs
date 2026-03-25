using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Core.Exercises.Classes.Product_Inventory_Project
{
    public class Inventory
    {
        public List<Product> ProductsInInventory { get; }
        public Inventory() 
        {
            ProductsInInventory = new List<Product>();
        }

        public ProductResult AddProduct(Product product)
        {
            if(product == null)
            {
                return new ProductResult
                {
                    IsSucces = false,
                    ErrorMessage = "Invalid product given."
                };
            }


            if (ProductsInInventory.Contains(product))
            {
                return new ProductResult
                {
                    IsSucces = false,
                    ErrorMessage = "Product already in inventory. Buy quantity instead."
                };
            }

            ProductsInInventory.Add(product);
            return new ProductResult
            {
                IsSucces = true
            };
        }
        public ProductResult Buy(Product product, int quantity)
        {
            if (product == null)
            {
                return new ProductResult
                {
                    IsSucces = false,
                    ErrorMessage = "Product not set."
                };
            }
            return product.Buy(quantity);
        }

        public ProductResult Sell(Product product, int quantity)
        {
            if (product == null)
            {
                return new ProductResult
                {
                    IsSucces = false,
                    ErrorMessage = "Product not set"
                };
            }
            return product.Buy(quantity);
        }
    }
}
