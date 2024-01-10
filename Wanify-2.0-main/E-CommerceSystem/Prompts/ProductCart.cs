using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AutoCloseMessageBox;

namespace E_CommerceSystem
{
    public partial class ProductCart : UserControl
    {
        Config dbConfig;
        MySqlConnection conn;
        int quantityCount = 1;
        int currentUnitPrice;

        Cart cartRefresh;
        public ProductCart()
        {
            InitializeComponent();
        }

        public ProductCart(string user_id, string requestName)
        {
            InitializeComponent();
            this.UserID = user_id;
            this.RequestName = requestName;
        }

        public string UserID { get; set; }
        public string RequestName { get; set; }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();
            referenceID.Visible = false;

            if (RequestName.Equals("checkout"))
            {
                addQuantity_button.Visible = true;
                minusQuantity_button.Visible = true;
                product_quantity.Visible = true;
                add_list.Visible = true;
                delete_item.Visible = true;
                order_received.Visible = false;

                MySqlCommand selectProductsOnLoad = new MySqlCommand("SELECT * FROM cart WHERE productID = ('" + ProductID + "')", conn);
                MySqlCommand selectProductStock = new MySqlCommand("SELECT * FROM products WHERE productID = ('" + ProductID + "')", conn);

                try
                {
                    conn.Open();
                    MySqlDataReader fetchCartPrd = selectProductsOnLoad.ExecuteReader();
                    fetchCartPrd.Read();

                    string updatedTotalPrice = fetchCartPrd.GetString("totalPrice");
                    quantityCount = fetchCartPrd.GetInt32("productQuantity");
                    string isChecked = fetchCartPrd.GetString("isChecked");

                    fetchCartPrd.Close();

                    MySqlDataReader fetchProductStock = selectProductStock.ExecuteReader();
                    fetchProductStock.Read();
                    int productStock = fetchProductStock.GetInt32("product_stock");
                    fetchProductStock.Close();

                    if (quantityCount == 1)
                    {

                        product_price.Text = $"P{updatedTotalPrice}";
                        product_quantity.Text = quantityCount.ToString();
                        minusQuantity_button.Enabled = false;
                    }
                    else if (quantityCount >= productStock)
                    {
                        product_price.Text = $"P{updatedTotalPrice}";
                        product_quantity.Text = quantityCount.ToString();
                        addQuantity_button.Enabled = false;

                    }
                    else if (quantityCount < productStock || quantityCount != 1)
                    {

                        product_price.Text = $"P{updatedTotalPrice}";
                        product_quantity.Text = quantityCount.ToString();
                        addQuantity_button.Enabled = true;
                        minusQuantity_button.Enabled = true;

                    }

                    if (isChecked.Equals("true"))
                    {
                        add_list.Checked = true;
                        delete_item.Enabled = false;

                    }
                    else
                    {
                        add_list.Checked = false;
                        delete_item.Enabled = true;

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (RequestName.Equals("ordered"))
            {
                addQuantity_button.Visible = false;
                minusQuantity_button.Visible = false;
                product_quantity.Visible = false;
                add_list.Visible = false;
                delete_item.Visible = false;
                order_received.Visible = false;

            }
            else if (RequestName.Equals("DELIVERY"))
            {
                addQuantity_button.Visible = false;
                minusQuantity_button.Visible = false;
                product_quantity.Visible = false;
                add_list.Visible = false;
                delete_item.Visible = false;
                order_received.Visible = true;
            }
            else
            {
                addQuantity_button.Visible = false;
                minusQuantity_button.Visible = false;
                product_quantity.Visible = false;
                add_list.Visible = false;
                delete_item.Visible = false;
                order_received.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        #region Properties

        public string _productName;
        public string _price;
        public string _quantity;
        public string _prdID;
        public Image _icon;

        [Category("Custom Props")]
        public string ProdName
        {
            get { return _productName; }
            set { _productName = value; product_name.Text = value; }
        }

        [Category("Custom Props")]
        public string Price { get { return _price; } set { _price = value; product_price.Text = value; } }


        [Category("Custom Props")]
        public string Quantity { get { return _quantity; } set { _quantity = value; product_quantity.Text = value; } }


        [Category("Custom Props")]
        public string ProductID { get { return _prdID; } set { _prdID = value; referenceID.Text = value; } }

        [Category("Custom Props")]
        public Image Photo { get { return _icon; } set { _icon = value; productPic.Image = value; } }

        #endregion

        private void addQuantity_button_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            if (add_list.Checked)
            {
                quantityCount++;

                MySqlCommand updateWhileChecked = new MySqlCommand("SELECT * FROM cart WHERE productID = ('" + ProductID + "')", conn);

                try
                {
                    conn.Open();

                    MySqlDataReader fetchProductByID = updateWhileChecked.ExecuteReader();
                    fetchProductByID.Read();

                    currentUnitPrice = fetchProductByID.GetInt32("unitPrice");
                    int currentTotalPrice = fetchProductByID.GetInt32("totalPrice");

                    int updatedAdded = currentTotalPrice += currentUnitPrice;
                    fetchProductByID.Close();

                    MySqlCommand updateTempAdd = new MySqlCommand("UPDATE cart SET productQuantity = ('" + quantityCount + "'), totalPrice = ('" + updatedAdded + "') WHERE productID = ('" + ProductID + "') ", conn);
                    updateTempAdd.ExecuteNonQuery();

                    MySqlCommand selectSummaryPrice = new MySqlCommand("SELECT unitPrice, totalSummary FROM cart WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "') ", conn);
                    MySqlDataReader fetchSummaryPrice = selectSummaryPrice.ExecuteReader();
                    fetchSummaryPrice.Read();

                    int previousSummaryPrice = fetchSummaryPrice.GetInt32("unitPrice") + fetchSummaryPrice.GetInt32("totalSummary");
                    updateTotalSummary(previousSummaryPrice);

                    fetchSummaryPrice.Close();

                    MySqlCommand checkIfProductExistsAndChecked = new MySqlCommand("SELECT * FROM checked_products WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "')", conn);

                    try
                    {

                        MySqlDataReader fetchResults = checkIfProductExistsAndChecked.ExecuteReader();
                        fetchResults.Read();

                        if (fetchResults.HasRows)
                        {
                            fetchResults.Close();
                            MySqlCommand updateCurrentValuesInCheckredProducts = new MySqlCommand("UPDATE checked_products SET productQuantity = ('" + quantityCount + "'), totalPrice = ('" + previousSummaryPrice + "'), totalSummary = ('" + previousSummaryPrice + "') WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "')", conn);
                            updateCurrentValuesInCheckredProducts.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    AutoClosingMessageBox.Show("Loading", "Loading", 10);


                    UserControl1_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                quantityCount++;

                MySqlCommand getCurrentPrdID = new MySqlCommand("SELECT * FROM cart WHERE productID = ('" + ProductID + "')", conn);
                try
                {
                    conn.Open();

                    MySqlDataReader fetchProductByID = getCurrentPrdID.ExecuteReader();
                    fetchProductByID.Read();

                    currentUnitPrice = fetchProductByID.GetInt32("unitPrice");
                    int currentTotalPrice = fetchProductByID.GetInt32("totalPrice");

                    int updatedAdded = currentTotalPrice += currentUnitPrice;
                    fetchProductByID.Close();

                    MySqlCommand updateTempAdd = new MySqlCommand("UPDATE cart SET productQuantity = ('" + quantityCount + "'), totalPrice = ('" + updatedAdded + "') WHERE productID = ('" + ProductID + "') AND userID = ('" + UserID + "') ", conn);
                    updateTempAdd.ExecuteNonQuery();

                    UserControl1_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void minusQuantity_button_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            if (add_list.Checked)
            {
                quantityCount--;

                MySqlCommand updateWhileChecked = new MySqlCommand("SELECT * FROM cart WHERE productID = ('" + ProductID + "')", conn);

                try
                {
                    conn.Open();
                    MySqlDataReader fetchProductByID = updateWhileChecked.ExecuteReader();
                    fetchProductByID.Read();

                    currentUnitPrice = fetchProductByID.GetInt32("unitPrice");
                    int currentTotalPrice = fetchProductByID.GetInt32("totalPrice");

                    int updatedAdded = currentTotalPrice -= currentUnitPrice;
                    fetchProductByID.Close();

                    MySqlCommand updateTempAdd = new MySqlCommand("UPDATE cart SET productQuantity = ('" + quantityCount + "'), totalPrice = ('" + updatedAdded + "') WHERE productID = ('" + ProductID + "') ", conn);
                    updateTempAdd.ExecuteNonQuery();

                    MySqlCommand selectSummaryPrice = new MySqlCommand("SELECT unitPrice, totalSummary FROM cart WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "') ", conn);
                    MySqlDataReader fetchSummaryPrice = selectSummaryPrice.ExecuteReader();
                    fetchSummaryPrice.Read();

                    int previousSummaryPrice = fetchSummaryPrice.GetInt32("totalSummary") - fetchSummaryPrice.GetInt32("unitPrice");
                    updateTotalSummary(previousSummaryPrice);

                    fetchSummaryPrice.Close();


                    MySqlCommand checkIfProductExistsAndChecked = new MySqlCommand("SELECT * FROM checked_products WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "')", conn);

                    try
                    {

                        MySqlDataReader fetchResults = checkIfProductExistsAndChecked.ExecuteReader();
                        fetchResults.Read();

                        if (fetchResults.HasRows)
                        {
                            fetchResults.Close();
                            MySqlCommand updateCurrentValuesInCheckredProducts = new MySqlCommand("UPDATE checked_products SET productQuantity = ('" + quantityCount + "'), totalPrice = ('" + previousSummaryPrice + "'), totalSummary = ('" + previousSummaryPrice + "') WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "')", conn);
                            updateCurrentValuesInCheckredProducts.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    AutoClosingMessageBox.Show("Loading", "Loading", 10);


                    UserControl1_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                quantityCount--;

                MySqlCommand getCurrentPrdID = new MySqlCommand("SELECT * FROM cart WHERE productID = ('" + ProductID + "')", conn);

                try
                {
                    conn.Open();
                    MySqlDataReader fetchProductByID = getCurrentPrdID.ExecuteReader();
                    fetchProductByID.Read();

                    currentUnitPrice = fetchProductByID.GetInt32("unitPrice");
                    int currentTotalPrice = fetchProductByID.GetInt32("totalPrice");

                    int updatedAdded = currentTotalPrice -= currentUnitPrice;
                    fetchProductByID.Close();

                    MySqlCommand updateTempAdd = new MySqlCommand("UPDATE cart SET productQuantity = ('" + quantityCount + "'), totalPrice = ('" + updatedAdded + "') WHERE productID = ('" + ProductID + "') AND userID = ('" + UserID + "') ", conn);
                    updateTempAdd.ExecuteNonQuery();

                    UserControl1_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void add_list_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            if (add_list.Checked)
            {
                conn.Open();

                MySqlCommand updateCheckState = new MySqlCommand("UPDATE cart SET isChecked = 'true' WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "')", conn);
                updateCheckState.ExecuteNonQuery();

                MySqlCommand selectSummaryPrice = new MySqlCommand("SELECT picture_directory, unitPrice, productQuantity, productName, totalPrice, totalSummary, variant FROM cart WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "') ", conn);

                try
                {
                    MySqlDataReader fetchSummaryPrice = selectSummaryPrice.ExecuteReader();
                    fetchSummaryPrice.Read();

                    string productName = fetchSummaryPrice.GetString("productName");
                    int unitPrice = fetchSummaryPrice.GetInt32("unitPrice");
                    int productQuantity = fetchSummaryPrice.GetInt32("productQuantity");
                    int totalPrice = fetchSummaryPrice.GetInt32("totalPrice");
                    string variant = fetchSummaryPrice.GetString("variant");

                    int previousSummaryPrice = fetchSummaryPrice.GetInt32("totalPrice") + fetchSummaryPrice.GetInt32("totalSummary");
                    updateTotalSummary(previousSummaryPrice);

                    fetchSummaryPrice.Close();

                    MemoryStream ms = new MemoryStream();
                    productPic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();

                    MySqlCommand checkIfItExists = new MySqlCommand("SELECT * FROM checked_products WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "')", conn);

                    try
                    {
                        MySqlDataReader fetchCheckResult = checkIfItExists.ExecuteReader();
                        fetchCheckResult.Read();

                        if (fetchCheckResult.HasRows) //update the checked products table if a product is already checked to avoid duplication
                        {
                            fetchCheckResult.Close();
                            MySqlCommand updateIfCheckedAlready = new MySqlCommand("UPDATE checked_products SET productQuantity = ('" + productQuantity + "'), totalPrice = ('" + totalPrice + "'), totalSummary = ('" + previousSummaryPrice + "') WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "') ", conn);
                            updateCheckState.ExecuteNonQuery();
                        }
                        else //insert new product when there is no existing product
                        {
                            fetchCheckResult.Close();

                            MySqlCommand insertIfChecked = new MySqlCommand("INSERT INTO checked_products (productName,variant ,picture_directory, unitPrice, productQuantity, totalPrice, totalSummary, userID, productID) VALUES (@productName,@variant ,@picture_directory, @unitPrice, @productQuantity, @totalPrice, @totalSummary, @userID, @productID)", conn);
                            insertIfChecked.Parameters.AddWithValue("@productName", productName);
                            insertIfChecked.Parameters.AddWithValue("@variant", variant);
                            insertIfChecked.Parameters.AddWithValue("@picture_directory", arrImage);
                            insertIfChecked.Parameters.AddWithValue("@unitPrice", unitPrice);
                            insertIfChecked.Parameters.AddWithValue("@productQuantity", productQuantity);
                            insertIfChecked.Parameters.AddWithValue("@totalPrice", totalPrice);
                            insertIfChecked.Parameters.AddWithValue("@totalSummary", previousSummaryPrice);
                            insertIfChecked.Parameters.AddWithValue("@userID", UserID);
                            insertIfChecked.Parameters.AddWithValue("@productID", ProductID);

                            insertIfChecked.ExecuteNonQuery();
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    AutoClosingMessageBox.Show("Loading", "Loading", 10);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {

                MySqlCommand selectSummaryPrice = new MySqlCommand("SELECT totalPrice, totalSummary FROM cart WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "') ", conn);

                try
                {
                    conn.Open();
                    MySqlDataReader fetchSummaryPrice = selectSummaryPrice.ExecuteReader();
                    fetchSummaryPrice.Read();

                    int previousSummaryPrice = fetchSummaryPrice.GetInt32("totalSummary") - fetchSummaryPrice.GetInt32("totalPrice");
                    updateTotalSummary(previousSummaryPrice);

                    fetchSummaryPrice.Close();

                    MySqlCommand updateCheckState = new MySqlCommand("UPDATE cart SET isChecked = 'false' WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "')", conn);
                    updateCheckState.ExecuteNonQuery();


                    MySqlCommand insertIfChecked = new MySqlCommand("DELETE FROM checked_products WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "')", conn);

                    insertIfChecked.ExecuteNonQuery();

                    AutoClosingMessageBox.Show("Loading", "Loading", 10);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void updateTotalSummary(int summaryPrice)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();


            MySqlCommand updateSummary = new MySqlCommand("UPDATE cart SET totalSummary = ('" + summaryPrice + "') WHERE userID = ('" + UserID + "') AND productID = ('" + ProductID + "') ", conn);

            conn.Open();
            updateSummary.ExecuteNonQuery();

        }

        private void delete_item_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand deleteFromCart = new MySqlCommand("DELETE FROM cart WHERE productID = ('" + ProductID + "') AND userID = ('" + UserID + "')", conn);

            try
            {
                conn.Open();
                deleteFromCart.ExecuteNonQuery();

                AutoClosingMessageBox.Show("Loading", "Loading", 10);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void order_received_Click(object sender, EventArgs e)
        {

            int orderCount = 0;
            orderCount++;

            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand selectProductID = new MySqlCommand("SELECT * FROM orders WHERE productName = ('" + ProdName + "')", conn);

            DateTime monthToday = DateTime.Now;
            string month = monthToday.ToString("MMMM");

            try
            {
                conn.Open();
                MySqlDataReader fetchProductIDOrders = selectProductID.ExecuteReader();
                fetchProductIDOrders.Read();

                string productIdFromOrders = fetchProductIDOrders.GetString("productID");
                int total = fetchProductIDOrders.GetInt32("total");
                fetchProductIDOrders.Close();

                MySqlCommand updateStatusWhenReceived = new MySqlCommand("UPDATE orders SET orderStatus = 'RECEIVED' WHERE userID = ('" + UserID + "') AND productID = ('" + productIdFromOrders + "')", conn);
                updateStatusWhenReceived.ExecuteNonQuery();

                MySqlCommand updateCurrentMonthRevenueAndOrders = new MySqlCommand("UPDATE sales_statistics SET total_revenue = total_revenue + ('" + total + "'), total_orders = total_orders + ('" + orderCount + "') WHERE Month = ('" + month + "') ", conn);
                updateCurrentMonthRevenueAndOrders.ExecuteNonQuery();

                AutoClosingMessageBox.Show("Loading", "Loading", 10);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void product_quantity_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
