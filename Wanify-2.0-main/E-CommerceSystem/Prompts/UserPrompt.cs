using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml.Serialization;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;

namespace E_CommerceSystem
{
    public partial class UserPrompt : KryptonForm
    {

        Config dbConfig;
        MySqlConnection conn;
        Products product;
        string cartCount;
        public UserPrompt()
        {
            InitializeComponent();

        }
        public UserPrompt(string user_id)
        {
            InitializeComponent();
            this.UserID = user_id;
        }
        public string UserID { get; set; }
        public void UserPrompt_Load(object sender, EventArgs e)
        {

            products.Enabled = false;
            about_panel.Visible = false;
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand fetchDateOrderedDay = new MySqlCommand("SELECT * FROM orders WHERE userID = ('" + UserID + "')", conn);

            try
            {
                conn.Open();

                MySqlDataReader dateFetch = fetchDateOrderedDay.ExecuteReader();
                dateFetch.Read();

                if (dateFetch.HasRows)
                {
                    DateTime dateOrdered = dateFetch.GetDateTime("date_ordered");
                    string dayOrdered = dateOrdered.ToString("dd");

                    DateTime dayToday = DateTime.Now;
                    string DayToday = dayToday.ToString("dd");

                    dateFetch.Close();

                    if (DayToday != dayOrdered)
                    {

                        MySqlCommand selectAllUnReceivedProducts = new MySqlCommand("SELECT * FROM orders WHERE orderStatus = 'RECEIVE' AND userID = ('" + UserID + "') ", conn);
                        MySqlDataReader fetchAllUnrecevedProducts = selectAllUnReceivedProducts.ExecuteReader();

                        int orderCount = 0;
                        int total = 0;

                        DateTime monthToday = DateTime.Now;
                        string month = monthToday.ToString("MMMM");

                        while (fetchAllUnrecevedProducts.Read())
                        {
                            orderCount++;
                            total += fetchAllUnrecevedProducts.GetInt32("total");
                        }
                        fetchAllUnrecevedProducts.Close();

                        MySqlCommand updateAutomatically = new MySqlCommand("UPDATE orders SET orderStatus = 'RECEIVED' WHERE orderStatus = 'RECEIVE' AND userID = ('" + UserID + "')", conn);
                        updateAutomatically.ExecuteNonQuery();

                        MySqlCommand updateCurrentMonthRevenueAndOrders = new MySqlCommand("UPDATE sales_statistics SET total_revenue = total_revenue + ('" + total + "'), total_orders = total_orders + ('" + orderCount + "') WHERE Month = ('" + month + "') ", conn);
                        updateCurrentMonthRevenueAndOrders.ExecuteNonQuery();

                    }
                }
                conn.Close();

                getImage();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

           
        }

        public void getImage ()
        {
            MySqlCommand getUserImage = new MySqlCommand("SELECT picture_directory FROM users WHERE userID = ('" + UserID + "')", conn);
            try
            {
                conn.Open();
                MySqlDataReader fetchUserImage = getUserImage.ExecuteReader();
                fetchUserImage.Read();

                //  display the image based on the fetched id
                long len = fetchUserImage.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                fetchUserImage.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                MemoryStream ms = new MemoryStream(array);
                Bitmap bitmpap = new Bitmap(ms);
                user_pic.Image = bitmpap;

                fetchProductsByCateg();
                lblRef.Hide();

                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }

        private void user_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
            new ProductDescription().Close();
            new Login().Show();
        }

        private void user_profile_Click(object sender, EventArgs e)
        {
            this.Close();
            new Profile(UserID).Show();
        }

        //flow layout shit item add
        private void fetchAllItems()
        {
            product_FlowLayout.Controls.Clear();
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand fetchByCateg = new MySqlCommand("SELECT image, product_name, price, product_stock FROM products WHERE product_stock > 0 AND product_name  LIKE '" + searchField.Text + "%' ORDER BY product_name", conn);
            try
            {
                conn.Open();
                MySqlDataReader fetchCategResult = fetchByCateg.ExecuteReader();
                while (fetchCategResult.Read())
                {

                    long len = fetchCategResult.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                    fetchCategResult.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                    MemoryStream ms = new MemoryStream(array);
                    Bitmap bitmpap = new Bitmap(ms);
                    product = new Products(UserID, "user");

                    product.ProdName = fetchCategResult.GetString("product_name");
                    product.Price = $"₱{fetchCategResult.GetString("price")}";
                    product.Photo = bitmpap;
                    product.Stock = fetchCategResult.GetInt32("product_stock");

                    product_FlowLayout.Controls.Add(product);


                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void fetchProductsByCateg()
        {
            product_FlowLayout.Controls.Clear();
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand fetchAll = new MySqlCommand("SELECT image, product_name, price FROM products WHERE  category = ('" + lblRef.Text + "')", conn);
            try
            {
                conn.Open();
                MySqlDataReader fetchAllPrd = fetchAll.ExecuteReader();
                if (!fetchAllPrd.Read())
                {
                    fetchAllPrd.Close();
                    fetchAllItems();
                }
                else
                {
                    fetchAllPrd.Close();
                    MySqlCommand fetchByCateg = new MySqlCommand("SELECT image, product_name, price, product_stock FROM products WHERE product_stock > 0 AND category = ('" + lblRef.Text + "')", conn);
                    MySqlDataReader fetchCategResult = fetchByCateg.ExecuteReader();
                    while (fetchCategResult.Read())
                    {
                        long len = fetchCategResult.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchCategResult.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));


                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);
                        product = new Products(UserID, "user");

                        product.ProdName = fetchCategResult.GetString("product_name");
                        product.Price = $"₱{fetchCategResult.GetString("price")}";
                        product.Photo = bitmpap;
                        product.Stock = fetchCategResult.GetInt32("product_stock");
                        product_FlowLayout.Controls.Add(product);
                    }

                    fetchCategResult.Close();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            this.Close();
            new Profile(UserID).Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            conn = dbConfig.getConnection();

            try
            {

                conn.Open();

                MySqlCommand logOutUser = new MySqlCommand("UPDATE comment_center SET isPriority = 'false' WHERE userID = '" + UserID + "'", conn);
                logOutUser.ExecuteNonQuery();

                conn.Close();

                new Login().Show();

                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void searchField_TextChanged(object sender, EventArgs e)
        {
            fetchAllItems();
        }

        private void user_pic_Click(object sender, EventArgs e)
        {

            if (user_picPanel.Visible == false)
            {
                user_picture_box.Visible = true;
                user_picPanel.Visible = true;
            }

            else
            {
                user_picture_box.Visible = false;
                user_picPanel.Visible = false;
            }
        }
        private void products_Click(object sender, EventArgs e)
        {
            products_panel.Visible = true;
            about_panel.Visible = false;
            about_us.Enabled = true;
            products.Enabled = false;
            user_header.Text = "PRODUCTS";
        }

        private void about_us_Click(object sender, EventArgs e)
        {
            products_panel.Visible = false;
            about_panel.Visible = true;
            about_us.Enabled = false;
            products.Enabled = true;
            user_header.Text = "ABOUT US";
        }

        private void UserPrompt_Activated_1(object sender, EventArgs e)
        {
            category_cmb.Items.Clear();

            string[] perfumeVariant = { "All", "Men Perfume ", "Women Perfume", "Unisex Perfume" };

            foreach (string variant in perfumeVariant)
            {

                category_cmb.Items.Add(variant);
            }

            category_cmb.SelectedItem = "All";

            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand currentCartCount = new MySqlCommand("SELECT * FROM cart WHERE userID = ('" + UserID + "')", conn);

            try
            {

                conn.Open();
                MySqlDataReader fetchCartCount = currentCartCount.ExecuteReader();

                int cartCount = 0;

                while (fetchCartCount.Read())
                {
                    cartCount++;
                }

                cartCnt.Text = cartCount.ToString();

                fetchCartCount.Close();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void category_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRef.Text = category_cmb.Text;
            fetchProductsByCateg();
        }

        private void cart_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Cart(UserID).Show();
        }

        private void about_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductDescriptionPalette_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }
    }
}
