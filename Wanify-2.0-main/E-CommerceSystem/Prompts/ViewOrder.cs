
﻿using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_CommerceSystem
{
    public partial class ViewOrder : KryptonForm
    {
        Config dbConfig;
        MySqlConnection conn;

        public ViewOrder()
        {
            InitializeComponent();
        }

        public ViewOrder(string user_id)
        {
            InitializeComponent();
            this.UserID = user_id;
        }

        public string UserID { get; set; }

        private void UserAddress_Load(object sender, EventArgs e)
        {
            update_status.Enabled= false;
            current_status.Visible=true;
            ref_delivered.Visible = false;


          
        }

        private void profile_description_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void fetchOrdersByStatus()
        {

            default_deliveryAddressFlowLayout.Controls.Clear();

            dbConfig = new Config();
            conn = dbConfig.getConnection();

            cmb_status.Items.Clear();

            MySqlCommand checkIfThereIsCourier = new MySqlCommand("SELECT courier_name, orderStatus FROM orders WHERE userID = ('" + UserID + "') AND orderStatus = 'PREPARING' OR  orderStatus = 'SHIP' OR orderStatus = 'RECEIVE'", conn);
            MySqlCommand selectFullName = new MySqlCommand("SELECT user_address.FullName FROM user_address INNER JOIN orders ON user_address.userID = orders.userID", conn);

            try
            {
                conn.Open();

                MySqlDataReader fetchBuyerFullName = selectFullName.ExecuteReader();
                fetchBuyerFullName.Read();
                if (fetchBuyerFullName.HasRows)
                {
                    string fullName = fetchBuyerFullName.GetString("FullName");
                    name_lbl.Text = fullName;

                }
                fetchBuyerFullName.Close();

                //-----------------------------------------------------------------------

                MySqlDataReader fetchCourierName = checkIfThereIsCourier.ExecuteReader();
                fetchCourierName.Read();

                if (fetchCourierName.HasRows)
                {
                    if (fetchCourierName.GetString("courier_name").Length > 0)
                    {
                        cmb_courier.Enabled = false;
                        cmb_courier.Items.Add(fetchCourierName.GetString("courier_name"));
                        cmb_courier.SelectedItem = fetchCourierName.GetString("courier_name");

                    }

                }

                fetchCourierName.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (current_status.Text.Equals("PREPARING"))
            {
                string[] status = { "SHIP" };
                foreach (string statuses in status)
                {
                    cmb_status.Items.Add(statuses);
                }

                cmb_status.SelectedItem = "SHIP";
                cmb_courier.Items.Clear();

                cmb_courier.Enabled = true;

                string[] couriers = { "Wanify Express", "Concised Delivery", "Humble Delivery" };

                foreach (string couriersis in couriers)
                {
                    cmb_courier.Items.Add(couriersis);
                }

                if (cmb_courier.SelectedIndex == -1)
                {
                    update_status.Enabled = false;
                }

            }
            else if (current_status.Text.Equals("SHIP"))
            {

                string[] status = { "RECEIVE" };
                foreach (string statuses in status)
                {
                    cmb_status.Items.Add(statuses);
                }

                cmb_status.SelectedItem = "RECEIVE";

            }
            else if (current_status.Text.Equals("RECEIVE"))
            {

                string[] status = { "DELIVER" };
                foreach (string statuses in status)
                {
                    cmb_status.Items.Add(statuses);
                }

                cmb_status.SelectedItem = "DELIVER";

            }

            MySqlCommand selectOrderByStatus = new MySqlCommand("SELECT picture_directory, productName, total FROM orders WHERE userID = ('" + UserID + "') AND orderStatus = ('" + current_status.Text + "')", conn);

            try
            {
                MySqlDataReader fetchOrder = selectOrderByStatus.ExecuteReader();

                if (!fetchOrder.Read())
                {
                    fetchOrder.Close();
                    cmb_status.Enabled = false;
                    update_status.Enabled = false;
                    cmb_status.SelectedIndex = -1;
                    cmb_courier.SelectedIndex = -1;


                }
                else
                {
                    fetchOrder.Close();
                    MySqlCommand selectOrdersByStatus = new MySqlCommand("SELECT picture_directory, productName, total, productQuantity FROM orders WHERE userID = ('" + UserID + "') AND orderStatus = ('" + current_status.Text + "')", conn);
                    MySqlDataReader fetchByStatusResult = selectOrdersByStatus.ExecuteReader();
                    while (fetchByStatusResult.Read())
                    {
                        long len = fetchByStatusResult.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchByStatusResult.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        ProductOrderCheckOut orderList = new ProductOrderCheckOut();

                        orderList.Photo = bitmpap;

                        //calculate the unitprice based on the total price
                        const int defaultShippingFee = 25;
                        int unitPrice = fetchByStatusResult.GetInt32("total") - defaultShippingFee;
                        unitPrice /= fetchByStatusResult.GetInt32("productQuantity");

                        orderList.UnitPrice = $"P{unitPrice}";
                        orderList.ProductNames = fetchByStatusResult.GetString("productName");
                        orderList.Amount = fetchByStatusResult.GetString("productQuantity");
                        orderList.Subtotal = fetchByStatusResult.GetString("total");

                        default_deliveryAddressFlowLayout.Controls.Add(orderList);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UserAddress_Activated(object sender, EventArgs e)
        {
            cmb_sort_order.Items.Clear();

            string[] sortOrders = { "PREPARING", "TO SHIP", "TO RECEIVE"};
            foreach (string sort in sortOrders)
            {
                cmb_sort_order.Items.Add(sort);
            }

            cmb_sort_order.SelectedItem = "PREPARING";

            default_deliveryAddressFlowLayout.Controls.Clear();
            fetchOrdersByStatus();
        }

        private void cmb_courier_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (cmb_courier.SelectedIndex == -1)
            {
                update_status.Enabled = false;

            }
            else
            {
                if (cmb_status.SelectedIndex >= 0)
                {
                    update_status.Enabled = true;
                }
            }
        }

        private void cmb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_status.Enabled = true;       
        }

        private void update_status_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();
            conn.Open();
            try
            {
                MySqlCommand updateOrder = new MySqlCommand("UPDATE orders SET orderStatus = ('" + cmb_status.Text + "'), courier_name = ('" + cmb_courier.Text + "') WHERE userID = ('" + UserID + "') AND orderStatus = ('" + current_status.Text + "')", conn);
                updateOrder.ExecuteNonQuery();

                MessageBox.Show("Order Updated!");

                if (ref_delivered.Text.Equals("DELIVER"))
                {
                    int total = 0;
                    string courierName = "", riderName = "";
                    //Randomize a rider name

                    string[] riders_name = { "John Doe", "Jane Doe", "Robert Amazon", "Jeon Jaime", "Charles Nilick", "Danny GGerman" };
                    Random getRandomRider = new Random();

                    riderName = riders_name[getRandomRider.Next(riders_name.Length)];

                    //update the rider field
                    MySqlCommand updateRiderField = new MySqlCommand("UPDATE orders SET rider_name = '"+riderName+"' WHERE userID = '"+UserID+"'", conn);
                    updateRiderField.ExecuteNonQuery();

                    MySqlCommand selectOrderInfo = new MySqlCommand("SELECT * FROM orders WHERE userID = ('" + UserID + "') AND orderStatus = 'DELIVER'", conn);
                    MySqlDataReader fetchOrderInfo = selectOrderInfo.ExecuteReader();

                    while (fetchOrderInfo.Read())
                    {
                        total += fetchOrderInfo.GetInt32("total");
                        courierName = fetchOrderInfo.GetString("courier_name");
                    }

                    fetchOrderInfo.Close();

                    MySqlCommand selectFullName = new MySqlCommand("SELECT user_address.FullName, user_address.Email FROM user_address INNER JOIN orders ON user_address.userID = orders.userID", conn);
                    MySqlDataReader fetchUserInfo = selectFullName.ExecuteReader();

                    fetchUserInfo.Read();

                    string name = fetchUserInfo.GetString("FullName");
                    string email = fetchUserInfo.GetString("Email");
                    fetchUserInfo.Close();

                    DeliveryNotification delNotif = new DeliveryNotification();
                    delNotif.DeliveryNotif(email, name, courierName, total, riderName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmb_sort_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_sort_order.Text.Equals("PREPARING"))
            {
                current_status.Text = "PREPARING";

            }
            else if (cmb_sort_order.Text.Equals("TO SHIP"))
            {
                current_status.Text = "SHIP";

            }
            else if (cmb_sort_order.Text.Equals("TO RECEIVE"))
            {
                current_status.Text = "RECEIVE";
                ref_delivered.Text = "DELIVER";

            }

            fetchOrdersByStatus();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminPrompt().Show();
        }
    }
}