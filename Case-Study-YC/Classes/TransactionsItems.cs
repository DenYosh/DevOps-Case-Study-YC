
namespace Case_Study_YC.Classes
{
    internal class TransactionsItems
    {
        public required List<Product> Products { get; set; }
        public required Transaction Transactions { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }

        TransactionsItems(Transaction transaction, int quantity, float totalPrice)
        {
            Products = new List<Product>();
            Transactions = transaction;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
