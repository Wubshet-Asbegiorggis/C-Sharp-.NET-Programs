using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Holds connection to DB
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["WpfApp1.Properties.Settings.DerekTutorialDBConnectionString"].ConnectionString;

            // Initialize connection
            sqlConnection = new SqlConnection(connectionString);

            // Call method that displays store names
            DisplayStores();

            // Method that displays every product in list
            DisplayAllProducts();
        }

        // Method that will display store names
        private void DisplayStores()
        {
            // Surround DB interacting code with try catch
            try
            {
                string query = "SELECT * FROM store";
                // Connect to DB, run query and then close DB connection
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                // Use our query and connection to populate the list
                // with store names
                using (sqlDataAdapter)
                {
                    // Acts as an interface between DB and this code
                    DataTable storeTable = new DataTable();

                    sqlDataAdapter.Fill(storeTable);

                    // Define the column we are displaying in listbox
                    storeList.DisplayMemberPath = "Name";

                    // Define what is unique about each item in the list
                    storeList.SelectedValuePath = "Id";

                    // The content we will use to populate the list
                    storeList.ItemsSource = storeTable.DefaultView;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Double click the list box to generate this
        private void storeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayStoreInventory();
        }

        // Displays the shoes the store has in inventory
        // Method that will display store names
        private void DisplayStoreInventory()
        {
            // Surround DB interacting code with try catch
            try
            {
                // Find shoes that match for the specific product
                // by using the store id clicked in the listbox
                string query = "SELECT * FROM Product p inner join StoreInventory si ON p.Id = si.ProductId WHERE si.StoreId = @StoreId";

                // To use the passed variable we must use SqlCommand
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // Connect to DB, run query and then close DB
                // connection
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Use our query and connection to populate the list
                // with store names
                using (sqlDataAdapter)
                {
                    // We need the ID clicked to perform our query
                    sqlCommand.Parameters.AddWithValue("@StoreId", storeList.SelectedValue);

                    // Acts as an interface between DB and this code
                    DataTable inventoryTable = new DataTable();

                    sqlDataAdapter.Fill(inventoryTable);

                    // Define the column we are displaying in listbox
                    storeInventory.DisplayMemberPath = "Brand";

                    // Define what is unique about each item in the list
                    storeInventory.SelectedValuePath = "Id";

                    // The content we will use to populate the list
                    storeInventory.ItemsSource = inventoryTable.DefaultView;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Method that will display all products
        private void DisplayAllProducts()
        {
            try
            {
                string query = "SELECT * FROM Product";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable productTable = new DataTable();

                    sqlDataAdapter.Fill(productTable);

                    productList.DisplayMemberPath = "Brand";

                    productList.SelectedValuePath = "Id";

                    productList.ItemsSource = productTable.DefaultView;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddStoreClick(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("AddStoreClicked");
            try
            {
                // Add list of parameters using textbox names
                // You also have to define data type
                List<SqlParameter> parameters = new List<SqlParameter>(){
                    new SqlParameter("@Name", SqlDbType.NVarChar) {Value = storeName.Text},
                    new SqlParameter("@Street", SqlDbType.NVarChar) {Value = storeStreet.Text},
                    new SqlParameter("@City", SqlDbType.NVarChar) {Value = storeCity.Text},
                    new SqlParameter("@State", SqlDbType.NChar) {Value = storeState.Text},
                    new SqlParameter("@Zip", SqlDbType.Int) {Value = storeZip.Text}
                };

                // Make sure they are in the same order as the DB
                string query = "INSERT INTO Store VALUES (@Name, @Street, @City, @State, @Zip)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                // Used to add a range of values
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                DataTable storeTable = new DataTable();

                // Abbreviated way to use adapter
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand)) adapter.Fill(storeTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayStores();
            }
        }

        private void AddInventoryClick(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("AddInventoryClicked");
            try
            {
                // Will be defining variable values using the
                // items selected in the list boxes
                string query = "INSERT INTO StoreInventory VALUES (@StoreId, @ProductId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@StoreId", storeList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@ProductId", productList.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayStoreInventory();
            }
        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("AddProductClicked");
            try
            {
                // Add list of parameters using textbox names
                // You also have to define data type
                List<SqlParameter> parameters = new List<SqlParameter>(){
                    new SqlParameter("@Manufacturer", SqlDbType.NVarChar) {Value = prodManu.Text},
                    new SqlParameter("@Brand", SqlDbType.NVarChar) {Value = prodBrand.Text}
                };

                // Make sure they are in the same order as the DB
                string query = "INSERT INTO Product VALUES (@Manufacturer, @Brand)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                // Used to add a range of values
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                DataTable productTable = new DataTable();

                // Abbreviated way to use adapter
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand)) adapter.Fill(productTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayAllProducts();
            }
        }


        private void DeleteStoreClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Store WHERE Id = @StoreId";

                // Simple way to execute a query without adapter
                // Open and close on our own
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                // Pass value for query
                sqlCommand.Parameters.AddWithValue("@StoreId", storeList.SelectedValue);

                // Execute query
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // This throws an error because the store inventory
                // list expects a default store selection
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                // Update the store listbox
                DisplayStores();
            }

            // We need to update StoreInventory so that when a
            // store is deleted entries in StoreInventory are also
            // deleted for the deleted store
            // Right Click -> StoreInventory in Server Explorer
            // Open Table Definition
            // Add ON DELETE CASCADE end of both Foreign Keys
        }

        private void DeleteInventoryClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM StoreInventory WHERE ProductId = @ProductId";

                // Simple way to execute a query without adapter
                // Open and close on our own
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                // Pass value for query
                sqlCommand.Parameters.AddWithValue("@ProductId", storeInventory.SelectedValue);

                // Execute query
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // This throws an error because the store inventory
                // list expects a default store selection
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayStoreInventory();
            }
        }

        private void DeleteProductClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Product WHERE Id = @ProductId";

                // Simple way to execute a query without adapter
                // Open and close on our own
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                // Pass value for query
                sqlCommand.Parameters.AddWithValue("@ProductId", productList.SelectedValue);

                // Execute query
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // This throws an error because the store inventory
                // list expects a default store selection
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                // Update the store listbox
                DisplayAllProducts();
            }
        }
    }
}

// 1ST PART SETTING UP SQL SERVER

// Create WPF application
// New Project -> WPF Application (.NET)

// Create Database
// Right click table and add a new table
// A key is automatically added but we want it to be the
// primary key
// Select it and then under properties change Is Identity
// under Identity Specification to True

// Change table name to Store
// Add Name as nvarchar(100) <- Variable length
// Add Street as nvarchar(100)
// Add City as nvarchar(50)
// Add State as nchar(2) <- Max length 2 characters
// Add Zip as int
// Click Update and Refresh

// Right Click Store in Server Explorer
// Click Show Table Data
// Enter store information

// Click Data Source on the left
// If Error :
// View -> Solution Explorer -> Right click on Project
// Add New Data Source -> Database -> Dataset
// Choose Data Connection -> Check Yes, include ...
// Check Yes save connection -> Copy connection string
// DerekTutorialDBConnectionString
// Check Tables -> Finish

// Open Data Source Tab -> Right click Store
// -> Edit DataSet with Designer (Shows Tables)

// 2ND PART SETTING UP SQL SERVER

// Right click References in Search Solution Explorer
// on the right -> Add reference
// -> Check Assemblies Tab -> System.Configuration
// Add using System.Configuration;

// Add more tables
/*
 CREATE TABLE [dbo].Product
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Manufacturer] NVARCHAR(100) NOT NULL,
    [Brand] NVARCHAR(100) NOT NULL
)

Nike Air Force 1
Nike Air Max 270
Adidas NMD R1
Brooks Ghost
Cole Haan Zerogrand
UGG Tasman
New Balance 327

Create a Table that will relate the Products to the Stores

CREATE TABLE [dbo].StoreInventory
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [StoreId] INT NOT NULL,
    [ProductId] INT NOT NULL,
)

Update Data Source
Select Solution Explorer -> Alt Shift D
Right Click DB Under Data Sources Tab
Configure Data Source with Wizard
Select Product and Store Inventory ENTER

Right click StoreInventory -> Open Table Definition
Create Product and Store Foreign Keys

CREATE TABLE [dbo].StoreInventory
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [StoreId] INT NOT NULL,
    [ProductId] INT NOT NULL,
    CONSTRAINT [StoreFK] FOREIGN KEY (StoreID) REFERENCES Store(Id),
    CONSTRAINT [ProductFK] FOREIGN KEY (ProductID) REFERENCES Product(Id)
)
Update

Right Click StoreInventory -> Show Table Data
Add Store Ids with multiple products per store

Right click DB -> New Query

SELECT * FROM Product

SELECT p.Brand FROM Product p
INNER JOIN StoreInventory si ON p.Id = si.ProductId
WHERE si.StoreId = 1

*/
