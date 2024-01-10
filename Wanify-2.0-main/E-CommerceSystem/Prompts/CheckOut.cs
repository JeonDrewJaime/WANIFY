
﻿using ComponentFactory.Krypton.Toolkit;
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace E_CommerceSystem
{
    public partial class CheckOut : KryptonForm
    {
        Config dbConfig;
        MySqlConnection conn;

        public CheckOut()
        {
            InitializeComponent();
            this.FormClosing += CheckOut_FormClosing;

        }
        public CheckOut(string user_id)
        {
            InitializeComponent();
            this.UserID = user_id;
            this.FormClosing += CheckOut_FormClosing;
        }

        public string UserID { get; set; }
        private void CheckOut_Load(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            referencePic.Visible = false;

            lbl_shipping_subtotal.Text = "P25";
            payment_method.Items.Add("Cash On Delivery");

            payment_method.SelectedIndex = 0;
            payment_method.Enabled = false;

            MySqlCommand selectDefaultAddress = new MySqlCommand("SELECT * FROM user_address WHERE userID = ('" + UserID + "')", conn);

            try
            {

                conn.Open();
                MySqlDataReader fetchDefaultAddress = selectDefaultAddress.ExecuteReader();
                fetchDefaultAddress.Read();

               if(fetchDefaultAddress.HasRows)
                {
                    AddressControl AddressList = new AddressControl(UserID, "Checkout");

                    AddressList.FullName = fetchDefaultAddress.GetString("FullName");
                    AddressList.Email = fetchDefaultAddress.GetString("Email");
                    AddressList.Regions = fetchDefaultAddress.GetString("Region");
                    AddressList.Province = fetchDefaultAddress.GetString("Province");
                    AddressList.City = fetchDefaultAddress.GetString("City");
                    AddressList.Barangay = fetchDefaultAddress.GetString("Barangay");
                    AddressList.Street = fetchDefaultAddress.GetString("StreetName");
                    AddressList.Postal = fetchDefaultAddress.GetString("PostalCode");

                    default_deliveryAddressFlowLayout.Controls.Add(AddressList);

                    fetchDefaultAddress.Close();

                    MySqlCommand selectChosenProducts = new MySqlCommand("SELECT picture_directory, productName, unitPrice, productQuantity, totalPrice, totalSummary FROM checked_products WHERE userID = ('" + UserID + "')", conn);
                    MySqlDataReader fetchAllChosenProducts = selectChosenProducts.ExecuteReader();

                    int totlMechandise_subtotal = 0;

                    while (fetchAllChosenProducts.Read())
                    {

                        long len = fetchAllChosenProducts.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchAllChosenProducts.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        ProductOrderCheckOut productOrderList = new ProductOrderCheckOut(UserID);

                        productOrderList.ProductNames = fetchAllChosenProducts.GetString("productName");
                        productOrderList.UnitPrice = fetchAllChosenProducts.GetString("unitPrice");
                        productOrderList.Amount = fetchAllChosenProducts.GetString("productQuantity");
                        productOrderList.Subtotal = fetchAllChosenProducts.GetString("totalSummary");
                        productOrderList.Photo = bitmpap;

                        product_ordersFlowLayout.Controls.Add(productOrderList);

                        totlMechandise_subtotal += fetchAllChosenProducts.GetInt32("totalSummary");
                    }
                    int totalPayment = totlMechandise_subtotal + 25;
                    lbl_total_payment.Text = $"P{totalPayment}";
                    lbl_merchandise_subtotal.Text = $"P{totlMechandise_subtotal}";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void CheckOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            try
            {

                MySqlCommand deleteCheckedProductsWhenClosed = new MySqlCommand("DELETE FROM checked_products WHERE userID = ('" + UserID + "')", conn);
                conn.Open();
                deleteCheckedProductsWhenClosed.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void insertToOrders(string productName, byte[] bitmap, string quantity, int total, string variant, string userID, string productID)
        {
            int orderCount = 0;

            orderCount++;

            dbConfig = new Config();
            conn = dbConfig.getConnection();
            MySqlCommand selectDefaultAddress = new MySqlCommand("SELECT * FROM user_address WHERE userID = ('" + UserID + "')", conn);

            try
            {
                conn.Open();
                MySqlDataReader fetchDefAddress = selectDefaultAddress.ExecuteReader();
                fetchDefAddress.Read();

                string Region = fetchDefAddress.GetString("Region");
                string Province = fetchDefAddress.GetString("Province");
                string City = fetchDefAddress.GetString("City");
                string Barangay = fetchDefAddress.GetString("Barangay");
                string StreetName = fetchDefAddress.GetString("StreetName");

                fetchDefAddress.Close();

                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy/MM/dd");

                MySqlCommand insertIntoOrders = new MySqlCommand("INSERT INTO orders (productName,variant ,picture_directory, productQuantity, total, date_ordered,orderStatus, Region, Province, City, Barangay, StreetName,isRated, isReported ,userID, productID) VALUES (@productName,@variant,@picture_directory, @productQuantity, @total, @date_ordered, @orderStatus, @Region, @Province, @City, @Barangay, @StreetName , @isRated, @isReported ,@userID, @productID)", conn);
                insertIntoOrders.Parameters.AddWithValue("@productName", productName);
                insertIntoOrders.Parameters.AddWithValue("@variant", variant);
                insertIntoOrders.Parameters.AddWithValue("@picture_directory", bitmap);
                insertIntoOrders.Parameters.AddWithValue("@productQuantity", quantity);
                insertIntoOrders.Parameters.AddWithValue("@total", total);
                insertIntoOrders.Parameters.AddWithValue("@date_ordered", formattedDate);
                insertIntoOrders.Parameters.AddWithValue("@orderStatus", "PREPARING");
                insertIntoOrders.Parameters.AddWithValue("@Region", Region);
                insertIntoOrders.Parameters.AddWithValue("@Province", Province);
                insertIntoOrders.Parameters.AddWithValue("@City", City);
                insertIntoOrders.Parameters.AddWithValue("@Barangay", Barangay);
                insertIntoOrders.Parameters.AddWithValue("@StreetName", StreetName);
                insertIntoOrders.Parameters.AddWithValue("@isRated", "false");
                insertIntoOrders.Parameters.AddWithValue("@isReported", "false");
                insertIntoOrders.Parameters.AddWithValue("@userID", userID);
                insertIntoOrders.Parameters.AddWithValue("@productID", productID);

                insertIntoOrders.ExecuteNonQuery();

                MessageBox.Show("ORDER PLACED!");

                DateTime monthToday = DateTime.Now;
                string month = monthToday.ToString("MMMM");

                MySqlCommand updateStock = new MySqlCommand("UPDATE products SET product_stock = product_stock - ('"+quantity+"') WHERE productID = ('"+productID+"')", conn);
                updateStock.ExecuteNonQuery();

                MySqlCommand updatePrdStatisticsOrders = new MySqlCommand("UPDATE product_sales_statistics SET number_of_orders = number_of_orders + ('"+quantity+"') WHERE productID = ('"+productID+"')", conn);
                updatePrdStatisticsOrders.ExecuteNonQuery();

                MySqlCommand deleteFromCheckedProducts = new MySqlCommand("DELETE FROM checked_products WHERE userID = ('" + UserID + "')", conn);
                deleteFromCheckedProducts.ExecuteNonQuery();

                MySqlCommand deleteFromCartWhenOrdered = new MySqlCommand("DELETE FROM cart WHERE userID = ('"+UserID+"') AND isChecked = 'true'", conn);
                deleteFromCartWhenOrdered.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void place_order_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand checkIfUserHasAddress = new MySqlCommand("SELECT * FROM user_address WHERE userID = ('"+UserID+"') AND isDefault = 'true'", conn);

            try
            {
                conn.Open();
                MySqlDataReader fetchResultCheckAddress = checkIfUserHasAddress.ExecuteReader();
                fetchResultCheckAddress.Read();

                if(fetchResultCheckAddress.HasRows) //meron
                {
                    //Randomize a rider name
                    string[] riders_name = { "John Doe", "Jane Doe", "Robert Amazon", "Jeon Jaime", "Charles Nilick", "Danny GGerman" };
                    Random getRandomRider = new Random();

                    fetchResultCheckAddress.Close();
                    MySqlCommand selectCheckedProducts = new MySqlCommand("SELECT picture_directory, productName, productQuantity, totalSummary,variant ,userID, productID FROM checked_products WHERE userID = ('" + UserID + "') ", conn);

                    try
                    {
                        MySqlDataReader insertFetchedProducts = selectCheckedProducts.ExecuteReader();

                        while (insertFetchedProducts.Read())
                        {
                            long len = insertFetchedProducts.GetBytes(0, 0, null, 0, 0);
                            byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                            insertFetchedProducts.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                            MemoryStream ms = new MemoryStream(array);
                            Bitmap bitmpap = new Bitmap(ms);

                            referencePic.Image = bitmpap;

                            MemoryStream msTeams = new MemoryStream();
                            referencePic.Image.Save(msTeams, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] arrImage = msTeams.GetBuffer();

                            string productName = insertFetchedProducts.GetString("productName");
                            string productQuantity = insertFetchedProducts.GetString("productQuantity");
                            int total = insertFetchedProducts.GetInt32("totalSummary") + 25;
                            string userID = insertFetchedProducts.GetString("userID");
                            string productID = insertFetchedProducts.GetString("productID");
                            string variant = insertFetchedProducts.GetString("variant");


                            insertToOrders(productName, arrImage, productQuantity, total, variant, userID, productID);
                        }
                        insertFetchedProducts.Close();

                        MessageBox.Show("ORDER PLACED!");

                        this.Hide();
                        new UserPrompt(UserID).Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else//wala
                {
                    fetchResultCheckAddress.Close();
                    string errorMessage = "SET UP YOUR ADDRESS FIRST!";
                    MBPopup(errorMessage);

                    new AddressEdit(UserID).Show();
                }

                conn.Close();

            }catch(Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }

            
        }
        public void MBPopup(string message)
        {
            Form form = new Form();
            using (CustomMessageBox mb = new CustomMessageBox())
            {
                form.StartPosition = FormStartPosition.Manual;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Opacity = .50d;
                form.BackColor = Color.Black;
                form.Size = this.Size;
                form.Location = this.Location;
                form.ShowInTaskbar = false;
                form.Show();
                mb.Owner = form;
                mb.Title = message;
                mb.ShowDialog();
                form.Dispose();
            }
        }

        private void kryptonLabel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Cart(UserID).Show();
        }
    }
}