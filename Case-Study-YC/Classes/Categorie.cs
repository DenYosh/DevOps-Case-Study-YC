
using System.Data;

namespace Case_Study_YC.Classes
{
    internal class Categorie
    {
        public string CategorieName { get; set; }

        public Categorie(string? name)
        {
            CategorieName = name!;
        }

        public DataTable? AddCategorie()
        {
            if (!string.IsNullOrEmpty(CategorieName))
            {
                string query = @"INSERT INTO Categories (CategoryName) VALUES (?);";
                object[] parameters = [CategorieName];

                return DatabaseManager.ExecuteQuery(query, parameters);
            }

            return null;
        }
    }
}
