using System.Data;

namespace Case_Study_YC.Classes
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    internal class Customer : Person
    {
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer(string firstName, string lastName, string email = "", string phone = "")
            : base(firstName, lastName)
        {
            Email = email;
            Phone = phone;
        }

        public DataTable AddCustomer()
        {
            string query = @"INSERT INTO Customers (FirstName, LastName, Email, Phone) VALUES (?, ?, ?, ?);";
            object[] parameters = { base.FirstName, base.LastName, Email, Phone };

            return DatabaseManager.ExecuteQuery(query, parameters);
        }
    }
}