using System.Data;

namespace Case_Study_YC
{
    partial class SupermarktSystem
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            changeStockTap = new TabPage();
            searchProductBtn = new Button();
            searchProductLabel = new Label();
            searchProductTextBox = new TextBox();
            RefreshDataBtn = new Button();
            allProducts = new DataGridView();
            addDataTab = new TabPage();
            tabControlAddData = new TabControl();
            addProduct = new TabPage();
            addProductBtn = new Button();
            stockQuantityText = new TextBox();
            productName = new Label();
            stockQuantity = new Label();
            productNameText = new TextBox();
            priceText = new TextBox();
            categoryDropdown = new ComboBox();
            price = new Label();
            category = new Label();
            addCategorie = new TabPage();
            addCategoryButton = new Button();
            categoryNameText = new TextBox();
            label1 = new Label();
            addCustomer = new TabPage();
            AddCustomerBtn = new Button();
            LastNameText = new TextBox();
            PhoneText = new TextBox();
            label2 = new Label();
            label3 = new Label();
            FirstNameText = new TextBox();
            EmailText = new TextBox();
            label4 = new Label();
            label5 = new Label();
            makeTransactionTab = new TabPage();
            AllCustomers = new DataGridView();
            SearchUserBtn = new Button();
            label6 = new Label();
            SearchUserText = new TextBox();
            tabControl.SuspendLayout();
            changeStockTap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)allProducts).BeginInit();
            addDataTab.SuspendLayout();
            tabControlAddData.SuspendLayout();
            addProduct.SuspendLayout();
            addCategorie.SuspendLayout();
            addCustomer.SuspendLayout();
            makeTransactionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AllCustomers).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(changeStockTap);
            tabControl.Controls.Add(addDataTab);
            tabControl.Controls.Add(makeTransactionTab);
            tabControl.Location = new Point(1, 1);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(803, 446);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += RefreshData;
            // 
            // changeStockTap
            // 
            changeStockTap.Controls.Add(searchProductBtn);
            changeStockTap.Controls.Add(searchProductLabel);
            changeStockTap.Controls.Add(searchProductTextBox);
            changeStockTap.Controls.Add(RefreshDataBtn);
            changeStockTap.Controls.Add(allProducts);
            changeStockTap.Location = new Point(4, 24);
            changeStockTap.Name = "changeStockTap";
            changeStockTap.Padding = new Padding(3);
            changeStockTap.Size = new Size(795, 418);
            changeStockTap.TabIndex = 0;
            changeStockTap.Text = "View Stock: ";
            changeStockTap.UseVisualStyleBackColor = true;
            // 
            // searchProductBtn
            // 
            searchProductBtn.Location = new Point(139, 33);
            searchProductBtn.Name = "searchProductBtn";
            searchProductBtn.Size = new Size(103, 23);
            searchProductBtn.TabIndex = 5;
            searchProductBtn.Text = "Search";
            searchProductBtn.UseVisualStyleBackColor = true;
            searchProductBtn.Click += searchProductBtn_Click;
            // 
            // searchProductLabel
            // 
            searchProductLabel.AutoSize = true;
            searchProductLabel.Location = new Point(7, 15);
            searchProductLabel.Name = "searchProductLabel";
            searchProductLabel.Size = new Size(90, 15);
            searchProductLabel.TabIndex = 4;
            searchProductLabel.Text = "Search Product:";
            // 
            // searchProductTextBox
            // 
            searchProductTextBox.Location = new Point(7, 33);
            searchProductTextBox.Name = "searchProductTextBox";
            searchProductTextBox.Size = new Size(116, 23);
            searchProductTextBox.TabIndex = 3;
            // 
            // RefreshDataBtn
            // 
            RefreshDataBtn.Location = new Point(196, 357);
            RefreshDataBtn.Name = "RefreshDataBtn";
            RefreshDataBtn.Size = new Size(402, 39);
            RefreshDataBtn.TabIndex = 2;
            RefreshDataBtn.Text = "Refresh";
            RefreshDataBtn.UseVisualStyleBackColor = true;
            RefreshDataBtn.Click += RefreshData;
            // 
            // allProducts
            // 
            allProducts.AllowUserToAddRows = false;
            allProducts.AllowUserToDeleteRows = false;
            allProducts.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            allProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            allProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            allProducts.Location = new Point(3, 62);
            allProducts.Name = "allProducts";
            allProducts.ReadOnly = true;
            allProducts.Size = new Size(789, 289);
            allProducts.TabIndex = 0;
            // 
            // addDataTab
            // 
            addDataTab.Controls.Add(tabControlAddData);
            addDataTab.Location = new Point(4, 24);
            addDataTab.Name = "addDataTab";
            addDataTab.Padding = new Padding(3);
            addDataTab.Size = new Size(795, 418);
            addDataTab.TabIndex = 1;
            addDataTab.Text = "Add Data: ";
            addDataTab.UseVisualStyleBackColor = true;
            // 
            // tabControlAddData
            // 
            tabControlAddData.Controls.Add(addProduct);
            tabControlAddData.Controls.Add(addCategorie);
            tabControlAddData.Controls.Add(addCustomer);
            tabControlAddData.Location = new Point(-4, 3);
            tabControlAddData.Name = "tabControlAddData";
            tabControlAddData.SelectedIndex = 0;
            tabControlAddData.Size = new Size(793, 409);
            tabControlAddData.TabIndex = 10;
            tabControlAddData.SelectedIndexChanged += RefreshData;
            // 
            // addProduct
            // 
            addProduct.Controls.Add(addProductBtn);
            addProduct.Controls.Add(stockQuantityText);
            addProduct.Controls.Add(productName);
            addProduct.Controls.Add(stockQuantity);
            addProduct.Controls.Add(productNameText);
            addProduct.Controls.Add(priceText);
            addProduct.Controls.Add(categoryDropdown);
            addProduct.Controls.Add(price);
            addProduct.Controls.Add(category);
            addProduct.Location = new Point(4, 24);
            addProduct.Name = "addProduct";
            addProduct.Padding = new Padding(3);
            addProduct.Size = new Size(785, 381);
            addProduct.TabIndex = 0;
            addProduct.Text = "Product";
            addProduct.UseVisualStyleBackColor = true;
            // 
            // addProductBtn
            // 
            addProductBtn.Location = new Point(324, 222);
            addProductBtn.Name = "addProductBtn";
            addProductBtn.Size = new Size(99, 32);
            addProductBtn.TabIndex = 9;
            addProductBtn.Text = "Add Product";
            addProductBtn.UseVisualStyleBackColor = true;
            addProductBtn.Click += AddProductBtn_Click;
            // 
            // stockQuantityText
            // 
            stockQuantityText.Location = new Point(248, 175);
            stockQuantityText.Name = "stockQuantityText";
            stockQuantityText.Size = new Size(258, 23);
            stockQuantityText.TabIndex = 8;
            // 
            // productName
            // 
            productName.AutoSize = true;
            productName.Location = new Point(248, 25);
            productName.Name = "productName";
            productName.Size = new Size(90, 15);
            productName.TabIndex = 1;
            productName.Text = "Product Name: ";
            // 
            // stockQuantity
            // 
            stockQuantity.AutoSize = true;
            stockQuantity.Location = new Point(248, 157);
            stockQuantity.Name = "stockQuantity";
            stockQuantity.Size = new Size(91, 15);
            stockQuantity.TabIndex = 7;
            stockQuantity.Text = "Stock Quantity: ";
            // 
            // productNameText
            // 
            productNameText.Location = new Point(248, 43);
            productNameText.Name = "productNameText";
            productNameText.Size = new Size(258, 23);
            productNameText.TabIndex = 2;
            // 
            // priceText
            // 
            priceText.Location = new Point(248, 131);
            priceText.Name = "priceText";
            priceText.Size = new Size(258, 23);
            priceText.TabIndex = 6;
            // 
            // categoryDropdown
            // 
            categoryDropdown.FormattingEnabled = true;
            categoryDropdown.Location = new Point(248, 87);
            categoryDropdown.Name = "categoryDropdown";
            categoryDropdown.Size = new Size(258, 23);
            categoryDropdown.TabIndex = 3;
            // 
            // price
            // 
            price.AutoSize = true;
            price.Location = new Point(248, 113);
            price.Name = "price";
            price.Size = new Size(39, 15);
            price.TabIndex = 5;
            price.Text = "Price: ";
            // 
            // category
            // 
            category.AutoSize = true;
            category.Location = new Point(248, 69);
            category.Name = "category";
            category.Size = new Size(61, 15);
            category.TabIndex = 4;
            category.Text = "Category: ";
            // 
            // addCategorie
            // 
            addCategorie.Controls.Add(addCategoryButton);
            addCategorie.Controls.Add(categoryNameText);
            addCategorie.Controls.Add(label1);
            addCategorie.Location = new Point(4, 24);
            addCategorie.Name = "addCategorie";
            addCategorie.Padding = new Padding(3);
            addCategorie.Size = new Size(785, 381);
            addCategorie.TabIndex = 1;
            addCategorie.Text = "Categorie";
            addCategorie.UseVisualStyleBackColor = true;
            // 
            // addCategoryButton
            // 
            addCategoryButton.Location = new Point(293, 88);
            addCategoryButton.Name = "addCategoryButton";
            addCategoryButton.Size = new Size(122, 34);
            addCategoryButton.TabIndex = 2;
            addCategoryButton.Text = "Add Category";
            addCategoryButton.UseVisualStyleBackColor = true;
            addCategoryButton.Click += AddCategoryButton_Click;
            // 
            // categoryNameText
            // 
            categoryNameText.Location = new Point(245, 47);
            categoryNameText.Name = "categoryNameText";
            categoryNameText.Size = new Size(227, 23);
            categoryNameText.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 29);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Category Name: ";
            // 
            // addCustomer
            // 
            addCustomer.Controls.Add(AddCustomerBtn);
            addCustomer.Controls.Add(LastNameText);
            addCustomer.Controls.Add(PhoneText);
            addCustomer.Controls.Add(label2);
            addCustomer.Controls.Add(label3);
            addCustomer.Controls.Add(FirstNameText);
            addCustomer.Controls.Add(EmailText);
            addCustomer.Controls.Add(label4);
            addCustomer.Controls.Add(label5);
            addCustomer.Location = new Point(4, 24);
            addCustomer.Name = "addCustomer";
            addCustomer.Size = new Size(785, 381);
            addCustomer.TabIndex = 2;
            addCustomer.Text = "Customer";
            addCustomer.UseVisualStyleBackColor = true;
            // 
            // AddCustomerBtn
            // 
            AddCustomerBtn.Location = new Point(307, 216);
            AddCustomerBtn.Name = "AddCustomerBtn";
            AddCustomerBtn.Size = new Size(122, 34);
            AddCustomerBtn.TabIndex = 18;
            AddCustomerBtn.Text = "Add Customer";
            AddCustomerBtn.UseVisualStyleBackColor = true;
            AddCustomerBtn.Click += AddCustomerBtn_Click;
            // 
            // LastNameText
            // 
            LastNameText.Location = new Point(246, 85);
            LastNameText.Name = "LastNameText";
            LastNameText.Size = new Size(258, 23);
            LastNameText.TabIndex = 17;
            // 
            // PhoneText
            // 
            PhoneText.Location = new Point(246, 173);
            PhoneText.Name = "PhoneText";
            PhoneText.Size = new Size(258, 23);
            PhoneText.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 23);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 9;
            label2.Text = "First Name: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(246, 155);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 15;
            label3.Text = "Phone:";
            // 
            // FirstNameText
            // 
            FirstNameText.Location = new Point(246, 41);
            FirstNameText.Name = "FirstNameText";
            FirstNameText.Size = new Size(258, 23);
            FirstNameText.TabIndex = 10;
            // 
            // EmailText
            // 
            EmailText.Location = new Point(246, 129);
            EmailText.Name = "EmailText";
            EmailText.Size = new Size(258, 23);
            EmailText.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(246, 111);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 13;
            label4.Text = "Email: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 67);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 12;
            label5.Text = "Last Name:";
            // 
            // makeTransactionTab
            // 
            makeTransactionTab.Controls.Add(AllCustomers);
            makeTransactionTab.Controls.Add(SearchUserBtn);
            makeTransactionTab.Controls.Add(label6);
            makeTransactionTab.Controls.Add(SearchUserText);
            makeTransactionTab.Location = new Point(4, 24);
            makeTransactionTab.Name = "makeTransactionTab";
            makeTransactionTab.Padding = new Padding(3);
            makeTransactionTab.Size = new Size(795, 418);
            makeTransactionTab.TabIndex = 2;
            makeTransactionTab.Text = "Make Transaction: ";
            makeTransactionTab.UseVisualStyleBackColor = true;
            // 
            // AllCustomers
            // 
            AllCustomers.AllowUserToAddRows = false;
            AllCustomers.AllowUserToDeleteRows = false;
            AllCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            AllCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AllCustomers.Location = new Point(25, 87);
            AllCustomers.Name = "AllCustomers";
            AllCustomers.ReadOnly = true;
            AllCustomers.Size = new Size(728, 303);
            AllCustomers.TabIndex = 3;
            // 
            // SearchUserBtn
            // 
            SearchUserBtn.Location = new Point(157, 44);
            SearchUserBtn.Name = "SearchUserBtn";
            SearchUserBtn.Size = new Size(103, 23);
            SearchUserBtn.TabIndex = 2;
            SearchUserBtn.Text = "Search";
            SearchUserBtn.UseVisualStyleBackColor = true;
            SearchUserBtn.Click += SearchUserBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 26);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 1;
            label6.Text = "Search User:";
            // 
            // SearchUserText
            // 
            SearchUserText.Location = new Point(25, 44);
            SearchUserText.Name = "SearchUserText";
            SearchUserText.Size = new Size(116, 23);
            SearchUserText.TabIndex = 0;
            // 
            // SupermarktSystem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Name = "SupermarktSystem";
            Text = "Supermarkt system";
            Load += SupermarktSystem_Load;
            tabControl.ResumeLayout(false);
            changeStockTap.ResumeLayout(false);
            changeStockTap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)allProducts).EndInit();
            addDataTab.ResumeLayout(false);
            tabControlAddData.ResumeLayout(false);
            addProduct.ResumeLayout(false);
            addProduct.PerformLayout();
            addCategorie.ResumeLayout(false);
            addCategorie.PerformLayout();
            addCustomer.ResumeLayout(false);
            addCustomer.PerformLayout();
            makeTransactionTab.ResumeLayout(false);
            makeTransactionTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AllCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private TabControl tabControl;
        private TabPage changeStockTap;
        private TabPage addDataTab;
        private TabPage makeTransactionTab;
        private DataGridView allProducts;
        private TextBox stockQuantityText;
        private Label stockQuantity;
        private TextBox priceText;
        private Label price;
        private Label category;
        private ComboBox categoryDropdown;
        private TextBox productNameText;
        private Label productName;
        private Button addProductBtn;
        private TabControl tabControlAddData;
        private TabPage addCategorie;
        private TabPage addProduct;
        private TabPage addCustomer;
        private Button addCategoryButton;
        private TextBox categoryNameText;
        private Label label1;
        private TextBox LastNameText;
        private TextBox PhoneText;
        private Label label2;
        private Label label3;
        private TextBox FirstNameText;
        private TextBox EmailText;
        private Label label4;
        private Label label5;
        private Button AddCustomerBtn;
        private Button RefreshDataBtn;
        private Button SearchUserBtn;
        private Label label6;
        private TextBox SearchUserText;
        private DataGridView AllCustomers;
        private Button searchProductBtn;
        private Label searchProductLabel;
        private TextBox searchProductTextBox;
    }
}
