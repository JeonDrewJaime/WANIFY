using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System.IO;
using System.Xml.Serialization;
using System.Security.Policy;

namespace E_CommerceSystem
{
    public partial class Cart : KryptonForm
    {
        Config dbConfig;
        MySqlConnection conn;

        public Cart()
        {
            InitializeComponent();

        }

        public Cart(string userid)
        {
            InitializeComponent();
            dbConfig = new Config();
            this.UserID = userid;
            this.FormClosing += Cart_FormClosing;
        }
        public string UserID { get; set; }
        private void Cart_Load(object sender, EventArgs e)
        {

        }

        private void Cart_FormClosed(object sender, FormClosedEventArgs e)
        {
            new UserPrompt(UserID).Show();
        }

        private void to_ship_Click(object sender, EventArgs e)
        {
            toship_flowLayoutPanel.Controls.Clear();
            #region Button
            toShip_Button.Enabled = false;
            toReceive_Button.Enabled = true;
            checkout.Enabled = true;
            received_Button.Enabled = true;
            #endregion
            #region DynamicPanel
            checkout_panel.Visible = false;
            toShip_panel.Visible = true;
            received_panel.Visible = false;
            toReceive_panel.Visible = false;
            to_pay_Panel.Visible = false;
            to_pay.Enabled = true;

            #endregion
            cart_header.Text = "TO SHIP";
            fetchByStatus("SHIP");


        }

        private void checkout_Click(object sender, EventArgs e)
        {
            #region Button
            toShip_Button.Enabled = true;
            toReceive_Button.Enabled = true;
            checkout.Enabled = false;
            received_Button.Enabled = true;
            #endregion
            #region DynamicPanel
            checkout_panel.Visible = true;
            toShip_panel.Visible = false;
            received_panel.Visible = false;
            toReceive_panel.Visible = false;
            to_pay_Panel.Visible = false;
            to_pay.Enabled = true;

            #endregion
            cart_header.Text = "CHECKOUT";

            Cart_Activated(sender, e);

        }

        private void toReceive_panel_Click(object sender, EventArgs e)
        {

            conn = dbConfig.getConnection();
            toReceive_flowLayoutPanel.Controls.Clear();

            #region Button
            toShip_Button.Enabled = true;
            toReceive_Button.Enabled = false;
            checkout.Enabled = true;
            received_Button.Enabled = true;
            to_pay_Panel.Visible = false;
            to_pay.Enabled = true;

            #endregion
            #region DynamicPanel
            checkout_panel.Visible = false;
            toShip_panel.Visible = false;
            received_panel.Visible = false;
            toReceive_panel.Visible = true;
            #endregion
            cart_header.Text = "TO RECEIVE";

            MySqlCommand selectStatus = new MySqlCommand("SELECT picture_directory, productName, productQuantity, total, orderStatus, isRated, isReported, productID FROM orders WHERE userID = ('" + UserID + "') AND orderStatus = 'RECEIVE' OR orderStatus = 'DELIVER'", conn);
            checkout_FlowLayout.Controls.Clear();

            try
            {
                conn.Open();
                MySqlDataReader fetchStatus = selectStatus.ExecuteReader();
                DeliveryProcessProducts cartItems;
                while (fetchStatus.Read())
                {
                    if (fetchStatus.GetString("orderStatus").Contains("RECEIVE"))
                    {
                        long len = fetchStatus.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchStatus.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        cartItems = new DeliveryProcessProducts(UserID, "RECEIVE", fetchStatus.GetString("productID"));

                        cartItems.ProdName = fetchStatus.GetString("productName");
                        cartItems.Quantity = $"x{fetchStatus.GetString("productQuantity")}";
                        cartItems.IsRated = bool.Parse(fetchStatus.GetString("isRated"));
                        cartItems.IsReported = bool.Parse(fetchStatus.GetString("isReported"));
                        cartItems.Price = $"P{fetchStatus.GetString("total")}";
                        cartItems.Status = "Parcel is on the way to Delivery Hub";
                        cartItems.Photo = bitmpap;

                    }
                    else
                    {
                        long len = fetchStatus.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchStatus.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        cartItems = new DeliveryProcessProducts(UserID, "DELIVER", fetchStatus.GetString("productID"));

                        cartItems.ProdName = fetchStatus.GetString("productName");
                        cartItems.Quantity = $"x{fetchStatus.GetString("productQuantity")}";
                        cartItems.IsRated = bool.Parse(fetchStatus.GetString("isRated"));
                        cartItems.IsReported = bool.Parse(fetchStatus.GetString("isReported"));
                        cartItems.Price = $"P{fetchStatus.GetString("total")}";
                        cartItems.Status = "Parcel is out for delivery";
                        cartItems.Photo = bitmpap;
                    }

                    toReceive_flowLayoutPanel.Controls.Add(cartItems);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void receive_panel_Click(object sender, EventArgs e)
        {
            received_flowLayoutPanel.Controls.Clear();

            #region Button
            toShip_Button.Enabled = true;
            toReceive_Button.Enabled = true;
            checkout.Enabled = true;
            received_Button.Enabled = false;
            #endregion
            #region DynamicPanel
            checkout_panel.Visible = false;
            toShip_panel.Visible = false;
            received_panel.Visible = true;
            toReceive_panel.Visible = false;
            to_pay_Panel.Visible = false;
            to_pay.Enabled = true;
            #endregion
            cart_header.Text = "RECEIVED";
            fetchByStatus("RECEIVED");

        }

        private void fetchByStatus(string status)
        {
            conn = dbConfig.getConnection();

            MySqlCommand selectByStatus = new MySqlCommand("SELECT picture_directory, productName, productQuantity, total, isRated, isReported, productID  FROM orders WHERE userID = ('" + UserID + "') AND orderStatus = ('" + status + "')", conn);

            try
            {
                conn.Open();
                checkout_FlowLayout.Controls.Clear();
                MySqlDataReader fetchResults = selectByStatus.ExecuteReader();

                while (fetchResults.Read())
                {

                    if (status.Equals("PREPARING"))
                    {
                        long len = fetchResults.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchResults.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        DeliveryProcessProducts cartItems = new DeliveryProcessProducts(UserID, "ordered", fetchResults.GetString("productID"));

                        cartItems.ProdName = fetchResults.GetString("productName");
                        cartItems.Quantity = $"x{fetchResults.GetString("productQuantity")}";
                        cartItems.IsRated = bool.Parse(fetchResults.GetString("isRated"));
                        cartItems.IsReported = bool.Parse(fetchResults.GetString("isReported"));
                        cartItems.Price = $"P{fetchResults.GetString("total")}";
                        cartItems.Status = "Seller is preparing to ship your parcel";
                        cartItems.Photo = bitmpap;
                        to_pay_flowPanel.Controls.Add(cartItems);

                    }
                    else if (status.Equals("SHIP"))
                    {
                        long len = fetchResults.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchResults.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        DeliveryProcessProducts cartItems = new DeliveryProcessProducts(UserID, "ordered", fetchResults.GetString("productID"));

                        cartItems.ProdName = fetchResults.GetString("productName");
                        cartItems.Quantity = $"x{fetchResults.GetString("productQuantity")}";
                        cartItems.IsRated = bool.Parse(fetchResults.GetString("isRated"));
                        cartItems.IsReported = bool.Parse(fetchResults.GetString("isReported"));
                        cartItems.Price = $"P{fetchResults.GetString("total")}";
                        cartItems.Status = "Parcel is shipped out";
                        cartItems.Photo = bitmpap;

                        toship_flowLayoutPanel.Controls.Add(cartItems);

                    }
                    else if (status.Equals("RECEIVED"))
                    {
                        long len = fetchResults.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchResults.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        DeliveryProcessProducts cartItems = new DeliveryProcessProducts(UserID, "ordered", fetchResults.GetString("productID"));

                        cartItems.ProdName = fetchResults.GetString("productName");
                        cartItems.Quantity = $"x{fetchResults.GetString("productQuantity")}";
                        cartItems.IsRated = bool.Parse(fetchResults.GetString("isRated"));
                        cartItems.IsReported = bool.Parse(fetchResults.GetString("isReported"));
                        cartItems.Price = $"P{fetchResults.GetString("total")}";
                        cartItems.Status = "Parcel has been delivered";
                        cartItems.Photo = bitmpap;

                        received_flowLayoutPanel.Controls.Add(cartItems);
                    }

                }
                fetchResults.Close();
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cart_Activated(object sender, EventArgs e)
        {
            conn = dbConfig.getConnection();


            MySqlCommand fetchCartPrd = new MySqlCommand("SELECT * FROM cart WHERE userID = ('" + UserID + "') ", conn);

            try
            {
                conn.Open();
                MySqlDataReader fetchResult = fetchCartPrd.ExecuteReader();

                int total = 0;


                while (fetchResult.Read())
                {

                    total += fetchResult.GetInt32("totalSummary");
                }

                fetchResult.Close();
                MySqlCommand fetchCartPrds = new MySqlCommand("SELECT picture_directory, productName, unitPrice, productQuantity, productID, totalSummary FROM cart WHERE userID = ('" + UserID + "') ", conn);

                try
                {
                    checkout_FlowLayout.Controls.Clear();

                    MySqlDataReader fetchResults = fetchCartPrds.ExecuteReader();

                    while (fetchResults.Read())
                    {

                        long len = fetchResults.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchResults.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        ProductCart cartItems = new ProductCart(UserID, "checkout");

                        cartItems.ProdName = fetchResults.GetString("productName");
                        cartItems.Price = $"₱{fetchResults.GetString("unitPrice")}";
                        cartItems.Quantity = fetchResults.GetString("productQuantity");
                        cartItems.ProductID = fetchResults.GetString("productID");
                        cartItems.Photo = bitmpap;

                        checkout_FlowLayout.Controls.Add(cartItems);
                    }

                    fetchResults.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                summary_price.Text = $"P{total}";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            MySqlCommand selectCheckedProducts = new MySqlCommand("SELECT * FROM checked_products WHERE userID = ('" + UserID + "')", conn);

            try
            {
                MySqlDataReader fetchIfThereIsProduct = selectCheckedProducts.ExecuteReader();
                fetchIfThereIsProduct.Read();

                if (fetchIfThereIsProduct.HasRows)
                {
                    checkout_btn.Enabled = true;
                }
                else
                {
                    checkout_btn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conn.Close();

        }
        private void Cart_FormClosing(object sender, FormClosingEventArgs e)
        {

            conn = dbConfig.getConnection();

            MySqlCommand resetTotalSummary = new MySqlCommand("UPDATE cart SET totalSummary = 0, isChecked = 'false'", conn);
            conn.Open();
            resetTotalSummary.ExecuteNonQuery();

            conn.Close() ;


        }

        private void checkout_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CheckOut(UserID).Show();
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkout_btn_Click_1(object sender, EventArgs e)
        {
            conn = dbConfig.getConnection();

            MySqlCommand checkIfUserHasAddress = new MySqlCommand("SELECT * FROM user_address WHERE userID = ('" + UserID + "') AND isDefault = 'true'", conn);

            try
            {
                conn.Open();
                MySqlDataReader fetchResultCheckAddress = checkIfUserHasAddress.ExecuteReader();
                fetchResultCheckAddress.Read();

                if (fetchResultCheckAddress.HasRows) //merong default address na nakaset
                {
                    fetchResultCheckAddress.Close();
                    this.Hide();
                    new CheckOut(UserID).Show();

                }
                else//walang default address
                {
                    fetchResultCheckAddress.Close();
                    string errorMessage = "SET UP YOUR ADDRESS FIRST!";
                    MBPopup(errorMessage);
                    new AddressEdit(UserID).Show();
                }

                conn.Close();
            }
            catch (Exception ex)
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

        private void to_pay_Click(object sender, EventArgs e)
        {
            to_pay_flowPanel.Controls.Clear();
            #region Button
            to_pay.Enabled = false;
            toShip_Button.Enabled = true;
            toReceive_Button.Enabled = true;
            checkout.Enabled = true;
            received_Button.Enabled = true;
            #endregion
            #region DynamicPanel
            checkout_panel.Visible = false;
            toShip_panel.Visible = false;
            received_panel.Visible = false;
            toReceive_panel.Visible = false;
            to_pay_Panel.Visible = true;
            #endregion
            cart_header.Text = "TO PAY";
            fetchByStatus("PREPARING");

        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            conn = dbConfig.getConnection();

            MySqlCommand resetTotalSummary = new MySqlCommand("UPDATE cart SET totalSummary = 0, isChecked = 'false'", conn);
            conn.Open();
            resetTotalSummary.ExecuteNonQuery();

            this.Hide();
            new UserPrompt(UserID).Show();

            conn.Close();
        }
    }
}
