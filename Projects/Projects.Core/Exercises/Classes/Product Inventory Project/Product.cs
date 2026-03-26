using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Projects.Core.Exercises.Classes.Product_Inventory_Project
{
    public class Product
    {
        public Guid Id { get; } 
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product() {}

        public Product(string name, decimal pricePerItem)
        {
            Id = new Guid();
            Name = name;
            Price = pricePerItem;
        }

        internal ProductResult Buy(int quantity)
        {
            if(quantity >= 1)
            {
                Quantity += quantity;
                return new ProductResult
                {
                    IsSucces = true
                };
            }
            return new ProductResult
            {
                IsSucces = false,
                ErrorMessage = "Quantity to buy must be a positive number."
            };
        }

        internal ProductResult Sell(int quantity)
        {
            if (Quantity >= 1 && quantity <= Quantity)
            {
                Quantity -= quantity;
                return new ProductResult
                {
                    IsSucces = true
                };
            }
            return new ProductResult
            {
                IsSucces = false,
                ErrorMessage = "Quantity to sell must be a positive number."
            };
        }

        public override string ToString()
        {
            return $"{Name} (€{Price}): {Quantity}";
        }
    }
}
