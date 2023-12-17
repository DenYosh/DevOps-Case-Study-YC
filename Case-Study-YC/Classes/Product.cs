
using System.Data;

namespace Case_Study_YC.Classes
{
    internal class Product
    {
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int StockQuantity { get; set; }
        public int Categorie { get; set; }

        public Product(string productName, float price, int stockQuantity, int categorieID)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException("Product name cannot be null or empty.", nameof(productName));
            }

            if (float.IsNaN(price))
            {
                throw new ArgumentException("Price name cannot be null or empty.", nameof(price));
            }

            if (stockQuantity < 0)
            {
                throw new ArgumentException("Stock Quantity cannot be empty or negative.", nameof(productName));
            }

            ProductName = productName;
            Price = price;
            StockQuantity = stockQuantity;
            Categorie = categorieID;
        }

        public DataTable AddProduct()
        {
            string query = @"INSERT INTO Products (ProductName, CategoryID, Price, StockQuantity) VALUES (?, ?, ?, ?);";
            object[] parameters = { this.ProductName, this.Categorie, (decimal)this.Price, this.StockQuantity };

            return DatabaseManager.ExecuteQuery(query, parameters);
        }
    }
}
