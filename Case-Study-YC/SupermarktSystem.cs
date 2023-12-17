using Case_Study_YC.Classes;
using System.Data;
using System.Globalization;

namespace Case_Study_YC
{
    public partial class SupermarktSystem : Form
    {
        public SupermarktSystem()
        {
            InitializeComponent();
        }

        private void EditProduct(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == allProducts.Columns["EditProduct"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = allProducts.Rows[e.RowIndex];

                string productName = selectedRow.Cells["Product Name"].Value?.ToString()!;
                string stockQuantity = selectedRow.Cells["Quantity"].Value?.ToString()!;
                string price = selectedRow.Cells["Price"].Value?.ToString()!;

                Form form = new()
                {
                    Name = "EditProductForm",
                    Text = "Edit Product",
                    AutoSize = true,
                    ClientSize = new System.Drawing.Size(200, 210),
                    StartPosition = FormStartPosition.CenterScreen,
                    MinimizeBox = false,
                    MaximizeBox = false,
                };
                Label productLabel = new()
                {
                    Text = $"Edit Product {productName}",
                    Dock = DockStyle.Top,
                    Width = 150,
                    TextAlign = ContentAlignment.MiddleCenter,
                };

                Label priceLabel = new()
                {
                    Text = "Edit Product Price:",
                    Location = new System.Drawing.Point(20, productLabel.Bottom + 10),
                    Width = 150,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                TextBox priceTextbox = new()
                {
                    Name = "textBox",
                    Text = price,
                    Location = new System.Drawing.Point(50, priceLabel.Bottom + 10),

                };

                Label quantityLabel = new()
                {
                    Text = "Edit Product Quantity:",
                    Location = new System.Drawing.Point(40, priceTextbox.Bottom + 10),
                    Width = 150,
                };
                TextBox quantityTextbox = new()
                {
                    Name = "textBox",
                    Text = stockQuantity,
                    Location = new System.Drawing.Point(50, quantityLabel.Bottom + 10),
                };


                Button buttonOk = new()
                {
                    Text = "Ok",
                    DialogResult = DialogResult.OK,
                    Dock = DockStyle.Bottom,
                    Location = new System.Drawing.Point(10, quantityTextbox.Bottom + 10),
                };
                Button buttonCancel = new()
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    Dock = DockStyle.Bottom,
                    Location = new System.Drawing.Point(buttonOk.Right + 10, quantityTextbox.Bottom + 10),
                };

                form.Controls.AddRange(new Control[] { productLabel, priceLabel, priceTextbox, quantityLabel, quantityTextbox, buttonOk, buttonCancel });
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;
                DialogResult dialogResult = form.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    string newPrice = priceTextbox.Text.Trim();
                    string newStockQuantity = quantityTextbox.Text.Trim();
                    newPrice = newPrice.Replace(',', '.');

                    if (float.TryParse(newPrice, NumberStyles.Float, CultureInfo.InvariantCulture, out float priceFloat) && int.TryParse(newStockQuantity, out int quantity))
                    {
                        string query = "UPDATE Products SET StockQuantity = ?, Price = ? WHERE ProductName = ?";
                        object[] parameters = { quantity, (decimal)priceFloat, productName };
                        DatabaseManager.ExecuteQuery(query, parameters);
                        GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter valid data.");
                    }
                }
            }
        }

        private void SupermarktSystem_Load(object sender, EventArgs e)
        {
            GetAllData();

            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.HeaderText = "Select Customer: ";
            dataGridViewButtonColumn.Text = "Select";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewButtonColumn.Name = "BtnSelect";

            AllCustomers.Columns.Add(dataGridViewButtonColumn);
            AllCustomers.CellContentClick += SelectUser!;

            DataGridViewButtonColumn allProductsButtonColumn = new DataGridViewButtonColumn();
            allProductsButtonColumn.HeaderText = "Edit Product";
            allProductsButtonColumn.Text = "Edit";
            allProductsButtonColumn.UseColumnTextForButtonValue = true;
            allProductsButtonColumn.Name = "EditProduct";

            allProducts.Columns.Add(allProductsButtonColumn);
            allProducts.CellContentClick += EditProduct!;
        }

        private void GetAllData()
        {
            string query = @"SELECT 
                    Products.ProductName as 'Product Name',
                    Categories.CategoryName as 'Category Name',
                    Products.Price,
                    Products.StockQuantity as 'Quantity'
                    FROM Products JOIN Categories ON
                    Products.CategoryID = Categories.CategoryID";
            allProducts.DataSource = DatabaseManager.ExecuteQuery(query);


            query = "SELECT * FROM Categories;";
            DataTable categories = DatabaseManager.ExecuteQuery(query, null);
            List<Categorie> list = new();
            foreach (DataRow categorie in categories.Rows)
            {
                list.Add(new Categorie(categorie["CategoryName"].ToString()));
            }

            categoryDropdown.DataSource = list;
            categoryDropdown.ValueMember = "CategorieName";

            query = "SELECT FirstName as 'First Name', LastName as 'Last Name', Email as 'E-Mail', Phone FROM Customers;";
            AllCustomers.DataSource = DatabaseManager.ExecuteQuery(query, null);

            SearchUserText.Text = "";
        }

        private void AddProductBtn_Click(object sender, EventArgs e)
        {
            string productName = productNameText.Text.Trim();
            string priceTextValue = priceText.Text.Trim();
            string stockQuantityTextValue = stockQuantityText.Text.Trim();

            if (float.TryParse(priceTextValue, NumberStyles.Float, CultureInfo.InvariantCulture, out float price) && !string.IsNullOrEmpty(productName) && int.TryParse(stockQuantityTextValue, out int quantity))
            {
                Product product = new(productName, price, quantity, categoryDropdown.SelectedIndex + 1);
                product.AddProduct();

                productNameText.Text = "";
                priceText.Text = "";
                stockQuantityText.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid data.");
            }
        }


        private void RefreshData(object sender, EventArgs e)
        {
            GetAllData();
        }


        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            string categoryName = categoryNameText.Text.Trim();

            if (!string.IsNullOrEmpty(categoryName))
            {
                Categorie categorie = new(categoryName);
                categorie.AddCategorie();
                categoryNameText.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid data.");
            }
        }

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            string firstNameText = FirstNameText.Text.Trim();
            string lastNameText = LastNameText.Text.Trim();
            string phone = PhoneText.Text.Trim();
            string email = EmailText.Text.Trim();

            if (!string.IsNullOrEmpty(firstNameText) && !string.IsNullOrEmpty(lastNameText))
            {
                Customer newCustomer = new Customer(firstNameText, lastNameText, email, phone);
                newCustomer.AddCustomer();

                FirstNameText.Text = "";
                LastNameText.Text = "";
                PhoneText.Text = "";
                EmailText.Text = "";

            }
            else
            {
                MessageBox.Show("Please enter both first name and last name.");
            }
        }

        private void SearchUserBtn_Click(object sender, EventArgs e)
        {
            string query = @"SELECT FirstName as 'First Name', LastName as 'Last Name', Email as 'E-Mail', Phone FROM Customers WHERE
                FirstName LIKE ? OR
                LastName LIKE ? OR
                Email LIKE ? OR
                Phone Like ?;";
            string searchTerm = "%" + SearchUserText.Text.Trim() + "%"; ;
            object[] parameters = [searchTerm, searchTerm, searchTerm, searchTerm];
            AllCustomers.DataSource = DatabaseManager.ExecuteQuery(query, parameters);
        }

        private void searchProductBtn_Click(object sender, EventArgs e)
        {
            string query = @"SELECT 
                                Products.ProductName as 'Product Name',
                                Categories.CategoryName as 'Category Name',
                                Products.Price,
                                Products.StockQuantity as 'Quantity'
                            FROM Products 
                            JOIN Categories ON Products.CategoryID = Categories.CategoryID 
                            WHERE
                                Products.ProductName LIKE ? OR
                                Categories.CategoryName LIKE ? OR
                                Products.Price = ? OR
                                Products.StockQuantity = ?;";

            string searchTerm = "%" + searchProductTextBox.Text.Trim() + "%";
            object[] parameters;

            if (decimal.TryParse(searchProductTextBox.Text.Trim(), out decimal parsedSearch))
            {
                parameters = [searchTerm, searchTerm, parsedSearch, parsedSearch];

            }
            else
            {
                parameters = [searchTerm, searchTerm, searchTerm, searchTerm];
            }

            allProducts.DataSource = DatabaseManager.ExecuteQuery(query, parameters);
        }

        private void SelectUser(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == AllCustomers.Columns["BtnSelect"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = AllCustomers.Rows[e.RowIndex];

                string firstName = selectedRow.Cells["First Name"].Value?.ToString()!;
                string lastName = selectedRow.Cells["Last Name"].Value?.ToString()!;
                string email = selectedRow.Cells["E-mail"].Value?.ToString()!;
                string phone = selectedRow.Cells["Phone"].Value?.ToString()!;

                Customer customer = new(firstName!, lastName!, email!, phone!);

                StartSelectingProducts(customer);

            }
        }

        private BindingSource productsBindingSource = [];
        private DataGridView? dataGridViewProducts;
        private void StartSelectingProducts(Customer customer)
        {

            string customerName = $"{customer.FirstName} {customer.LastName}";
            Label labelName = new()
            {
                Text = $"Customer: {customerName}",
                Dock = DockStyle.Top,
                Name = "labelName",
                Width = ClientSize.Width,
            };
            this.Controls.Add(labelName);

            // DataGridView to display products
            dataGridViewProducts = new DataGridView();
            string query = @"SELECT 
                Products.ProductName,
                Categories.CategoryName,
                Products.Price
                FROM Products JOIN Categories ON
                Products.CategoryID = Categories.CategoryID
                WHERE Products.StockQuantity > 0;";
            dataGridViewProducts.DataSource = DatabaseManager.ExecuteQuery(query);
            dataGridViewProducts.Width = ClientSize.Width;
            dataGridViewProducts.Height = 250;
            dataGridViewProducts.Location = new System.Drawing.Point(10, labelName.Bottom + 10);
            dataGridViewProducts.Name = "dataGridViewProducts";


            productsBindingSource.DataSource = dataGridViewProducts.DataSource;

            this.Controls.Add(dataGridViewProducts);

            // TextBox for quantity
            TextBox textBoxQuantity = new()
            {
                Location = new System.Drawing.Point(10, dataGridViewProducts.Bottom + 10),
                Name = "textBoxQuantity",
            };
            this.Controls.Add(textBoxQuantity);

            // Button to add product
            Button buttonAddProduct = new()
            {
                Text = "Add Product",
                Location = new System.Drawing.Point(textBoxQuantity.Right + 10, textBoxQuantity.Top),
                Name = "buttonAddProduct",
            };

            buttonAddProduct.Click += (sender, e) => AddProduct(textBoxQuantity.Text);
            this.Controls.Add(buttonAddProduct);

            Label labelAddedProduct = new()
            {
                Text = "Added to the list:",
                Location = new System.Drawing.Point(10, textBoxQuantity.Bottom + 10),
                Name = "labelAddedProduct",
                Width = ClientSize.Width,
            };
            this.Controls.Add(labelAddedProduct);

            // Label to display total price
            Label labelTotalPrice = new()
            {
                Text = "Total Price: $0.00",
                Location = new System.Drawing.Point(10, labelAddedProduct.Bottom + 10),
                Name = "labelTotalPrice",
            };
            this.Controls.Add(labelTotalPrice);

            Button checkOutBtn = new()
            {
                Text = "Checkout",
                Location = new System.Drawing.Point(10, labelTotalPrice.Bottom + 10),
                Name = "checkOutBtn",
            };
            checkOutBtn.Click += CheckOutBtn_Click!;
            this.Controls.Add(checkOutBtn);

            tabControl.Visible = false;

        }

        private decimal TotalPrice = 0;
        string allItems = "Added to the list: \n";

        private void AddProduct(string quantityText)
        {
            int quantity;
            if (int.TryParse(quantityText, out quantity) && quantity > 0)
            {
                // Use the CurrentCell property to get the selected cell

                if (dataGridViewProducts != null && dataGridViewProducts.CurrentCell != null)
                {
                    DataGridViewCell selectedCell = dataGridViewProducts.CurrentCell;
                    DataGridViewRow selectedRow = selectedCell.OwningRow;

                    // Access the data from the selected row
                    string productName = selectedRow.Cells["ProductName"].Value.ToString()!;

                    string query = @"SELECT StockQuantity FROM Products WHERE ProductName = ?";
                    object[] parameters = [productName];
                    DataTable Currentquantity = DatabaseManager.ExecuteQuery(query, parameters);

                    if (Currentquantity.Rows.Count > 0)
                    {
                        int currentQuantity = Convert.ToInt32(Currentquantity.Rows[0]["StockQuantity"]);
                        if ((currentQuantity - quantity) < 0)
                        {
                            MessageBox.Show("Not enough stock.");
                            return;
                        }
                        else
                        {
                            query = "UPDATE Products SET StockQuantity = ? WHERE ProductName = ?";
                            object[] parametersUpd = { (currentQuantity - quantity), productName };
                            DatabaseManager.ExecuteQuery(query, parametersUpd);
                        }
                    }

                    decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                    decimal totalPrice = this.TotalPrice + (quantity * price);
                    this.TotalPrice = totalPrice;

                    Label totalLabel = Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelTotalPrice")!;
                    Label addedProduct = Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelAddedProduct")!;

                    if (totalLabel != null)
                    {
                        totalLabel.Text = $"Total Price: ${totalPrice:F2}";
                    }

                    if (addedProduct != null)
                    {
                        addedProduct.Text = $"Added to the list: {productName} ({quantity:F2} x {price:C})";
                    }

                    allItems += $"{productName} ({quantity:F2} x {price:C})\n";

                    query = @"SELECT 
                        Products.ProductName,
                        Categories.CategoryName,
                        Products.Price
                        FROM Products JOIN Categories ON
                        Products.CategoryID = Categories.CategoryID
                        WHERE Products.StockQuantity > 0;";
                    this.dataGridViewProducts.DataSource = DatabaseManager.ExecuteQuery(query);


                }
                else
                {
                    MessageBox.Show("Please select a product from the list.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity (a positive integer).");
            }
        }

        private void CheckOutBtn_Click(object sender, EventArgs e)
        {
            List<string> controlsToDelete = new List<string> {
                "labelName",
                "dataGridViewProducts",
                "textBoxQuantity",
                "buttonAddProduct",
                "checkOutBtn",
                "labelAddedProduct",
                "labelTotalPrice",
            };
            List<Control> controlsToRemove = new List<Control>();

            foreach (Control control in Controls)
            {
                if (controlsToDelete.Contains(control.Name))
                {
                    controlsToRemove.Add(control);
                }
            }

            foreach (Control controlToRemove in controlsToRemove)
            {
                Controls.Remove(controlToRemove);
                controlToRemove.Dispose();
            }

            Label allProducts = new()
            {
                Text = $"{this.allItems}",
                Name = "allProducts",
                Width = ClientSize.Width,
                Location = new System.Drawing.Point(10, 0),
                Dock = DockStyle.Top,
                AutoSize = true,
            };

            this.Controls.Add(allProducts);

            Label totalPrice = new()
            {
                Text = $"Total price: {this.TotalPrice:C}",
                Location = new System.Drawing.Point(10, allProducts.Bottom + 10),
                Name = "totalPrice",
                Width = ClientSize.Width,
            };

            this.Controls.Add(totalPrice);

            Button payBtn = new()
            {
                Text = "Pay",
                Location = new System.Drawing.Point(10, totalPrice.Bottom + 10),
                Name = "payBtn",
            };
            payBtn.Click += (sender, e) =>
            {
                List<string> controlsToDelete = new List<string> {
                    "allProducts",
                    "totalPrice",
                    "payBtn",
                };

                List<Control> controlsToRemove = new List<Control>();

                foreach (Control control in Controls)
                {
                    if (controlsToDelete.Contains(control.Name))
                    {
                        controlsToRemove.Add(control);
                    }
                }

                foreach (Control controlToRemove in controlsToRemove)
                {
                    Controls.Remove(controlToRemove);
                    controlToRemove.Dispose();
                }

                GetAllData();
                this.allItems = "Added to the list: \n";
                tabControl.Visible = true;
            };

            this.Controls.Add(payBtn);


            this.TotalPrice = 0;
            this.productsBindingSource = [];
        }


    }
}
