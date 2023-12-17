
namespace Case_Study_YC.Classes
{
    internal class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public required Customer Customer { get; set; }

        public Transaction(Customer customer)
        {
            TransactionDate = DateTime.Now.Date;
            Customer = customer;
        }
    }
}
