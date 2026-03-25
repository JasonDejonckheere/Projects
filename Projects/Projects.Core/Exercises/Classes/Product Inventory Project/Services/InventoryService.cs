using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Core.Exercises.Classes.Product_Inventory_Project.Services
{
    public class InventoryService
    {
        private readonly Inventory _inventory;
        public InventoryService(Inventory inventory)
        {
            _inventory = inventory;
        }
        public int GetAmountOfProducts()
        {
            return _inventory
                .ProductsInInventory
                .Count();
        }
    }
}
