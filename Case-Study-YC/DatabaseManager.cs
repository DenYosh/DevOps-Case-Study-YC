using System.Data;
using System.Data.SQLite;

namespace Case_Study_YC
{
    internal class DatabaseManager
    {
        private static readonly string fileLocation = @"..\..\..\Files\SQLite-Database-YC.db";
        private static readonly string connectionString = "Data Source=" + fileLocation + ";Version=3;";

        public static void CreateDatabase()
        {

            if (!File.Exists(fileLocation))
            {
                SQLiteConnection.CreateFile(fileLocation);

                using SQLiteConnection connection = new(connectionString);
                connection.Open();

                string createTableAndFillQuery = @"
                        CREATE TABLE Categories (
                            CategoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                            CategoryName TEXT NOT NULL
                        );

                        CREATE TABLE Products (
                            ProductID INTEGER PRIMARY KEY AUTOINCREMENT,
                            ProductName TEXT NOT NULL,
                            CategoryID INTEGER,
                            Price DECIMAL(10, 2) NOT NULL,
                            StockQuantity INTEGER NOT NULL,
                            FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
                        );

                        CREATE TABLE Customers (
                            CustomerID INTEGER PRIMARY KEY AUTOINCREMENT,
                            FirstName TEXT NOT NULL,
                            LastName TEXT NOT NULL,
                            Email TEXT,
                            Phone TEXT
                        );

                        INSERT INTO Categories (CategoryName) VALUES
                            ('Groente en Fruit'),
                            ('Dagelijkse Benodigdheden'),
                            ('Vlees en Vis'),
                            ('Zuivel en Eieren'),
                            ('Bakkerij'),
                            ('Dranken'),
                            ('Snoep en Snacks'),
                            ('Huishoudelijke Artikelen');

                        INSERT INTO Products (ProductName, CategoryID, Price, StockQuantity) VALUES
                            ('Appels', 1, 1.50, 100),
                            ('Brood', 5, 2.00, 50),
                            ('Melk', 4, 1.20, 75),
                            ('Kipfilet', 3, 5.00, 30),
                            ('Shampoo', 2, 3.50, 40),
                            ('Frisdrank', 6, 1.00, 120),
                            ('Chocolade', 7, 2.50, 60),
                            ('Wasmiddel', 8, 4.00, 25);

                        INSERT INTO Customers (FirstName, LastName, Email, Phone) VALUES
                            ('Jan', 'Jansen', 'jan.jansen@gmail.com', '0469852108'),
                            ('Maria', 'Smit', 'maria.smit@hotmail.com', '0685148520'),
                            ('Peter R', 'de Vries', 'peter.devries@outlook.com', '+3249185620'),
                            ('Eva', 'Bakker', 'eva.bakker@gmail.com', '0654789213'),
                            ('Michel', 'Hendriks', 'michel.hendriks@hotmail.com', '0612345678'),
                            ('Sophie', 'van Dijk', 'sophie.vandijk@yahoo.com', '0645896321');
                ";

                using SQLiteCommand command = new SQLiteCommand(createTableAndFillQuery, connection);
                command.ExecuteNonQuery();
            }
        }

        public static DataTable ExecuteQuery(string query, object[]? parameters = null)
        {
            DataTable dataTable = new DataTable();

            using SQLiteConnection connection = new SQLiteConnection(connectionString);

            try
            {
                connection.Open();

                using SQLiteCommand command = new SQLiteCommand(query, connection);

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", parameters[i]);
                    }
                }

                using SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }

            return dataTable;
        }

    }
}
