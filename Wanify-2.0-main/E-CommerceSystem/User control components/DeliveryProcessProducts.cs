using AutoCloseMessageBox;
using E_CommerceSystem.Prompts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_CommerceSystem
{
    public partial class DeliveryProcessProducts : UserControl
    {
        Config dbConfig;
        MySqlConnection conn;

        string status;
        public DeliveryProcessProducts()
        {
            InitializeComponent();
        }
        public DeliveryProcessProducts(string user_id, string requestName, string productID)
        {
            InitializeComponent();
            dbConfig = new Config();
            this.UserID = user_id;
            this.ProductID = productID;
            this.RequestName = requestName;

            conn = dbConfig.getConnection();

            try
            {

                conn.Open();
                MySqlCommand getStatus = new MySqlCommand("SELECT orderStatus FROM orders WHERE userID = '"+UserID+"' AND productID = '"+ ProductID + "'", conn);
                MySqlDataReader fetchStatus = getStatus.ExecuteReader();
                fetchStatus.Read();

                status = fetchStatus.GetString("orderStatus");

                fetchStatus.Close();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string UserID { get; set; }
        public string ProductID { get; set; }

        public string RequestName { get; set; }

        private void DeliveryProcessProductsControl_Load(object sender, EventArgs e)
        {

           if(RequestName.Equals("RECEIVE") || RequestName.Equals("ordered"))
           {
                order_receive.Visible = false;

            }
            else
           {
             
                order_receive.Visible = true;
           }

        

        }

        #region Properties

        public string _productName;
        public string _price;
        public string _quantity;
        public string _status;
        public string _prdID;
        public Image _icon;
        public bool _isRated, _isReported;

        [Category("Custom Props")]
        public string ProdName
        {
            get { return _productName; }
            set { _productName = value; product_name.Text = value; }
        }

        [Category("Custom Props")]
        public string Price { get { return _price; } set { _price = value; product_price.Text = value; } }


        [Category("Custom Props")]
        public string Quantity { get { return _quantity; } set { _quantity = value; quantity.Text = value; } }

        [Category("Custom Props")]
        public string Status { get { return _status; } set { _status = value; status_product.Text = value; } }

        [Category("Custom Props")]
        public Image Photo { get { return _icon; } set { _icon = value; productPic.Image = value; } }

        [Category("Custom Props")]
        public bool IsRated { get { return _isRated; } set { _isRated = value; btnRate.Visible = !_isRated && status.Equals("RECEIVED"); } }

        [Category("Custom Props")]
        public bool IsReported { get { return _isReported; } set { _isReported = value; btnDefective.Visible = !_isReported && status.Equals("RECEIVED"); ; } }

        #endregion

        private void btnDefective_Click(object sender, EventArgs e)
        {
            //ProductReturnForm returnProduct = new ProductReturnForm(UserID, ProductID);
            //returnProduct.Show();

        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            RatingForm rateForm = new RatingForm(UserID, ProductID);
            rateForm.Show();

        }

        private void order_receive_Click(object sender, EventArgs e)
        {
            int orderCount = 0;
            orderCount++;

            conn = dbConfig.getConnection();

            MySqlCommand selectProductID = new MySqlCommand("SELECT * FROM orders WHERE productName = ('" + ProdName + "')", conn);

            //get the month
            DateTime monthToday = DateTime.Now;
            string month = monthToday.ToString("MMMM");
            string date = monthToday.ToString("yyyy-MM-dd");


            try
            {
                conn.Open();
                MySqlDataReader fetchProductIDOrders = selectProductID.ExecuteReader();
                fetchProductIDOrders.Read();

                string productIdFromOrders = fetchProductIDOrders.GetString("productID");
                int total = fetchProductIDOrders.GetInt32("total");
                fetchProductIDOrders.Close();

                MySqlCommand updateStatusWhenReceived = new MySqlCommand("UPDATE orders SET orderStatus = 'RECEIVED', date_received = '"+date+"' WHERE userID = ('" + UserID + "') AND productID = ('" + productIdFromOrders + "')", conn);
                updateStatusWhenReceived.ExecuteNonQuery();

                MySqlCommand updateCurrentMonthRevenueAndOrders = new MySqlCommand("UPDATE sales_statistics SET total_revenue = total_revenue + ('" + total + "'), total_orders = total_orders + ('" + orderCount + "') WHERE Month = ('" + month + "') ", conn);
                updateCurrentMonthRevenueAndOrders.ExecuteNonQuery();

                AutoClosingMessageBox.Show("Loading", "Loading", 10);

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
