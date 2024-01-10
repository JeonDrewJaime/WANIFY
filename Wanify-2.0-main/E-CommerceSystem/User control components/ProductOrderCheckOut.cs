using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_CommerceSystem
{
    public partial class ProductOrderCheckOut : UserControl
    {
        public ProductOrderCheckOut()
        {
            InitializeComponent();
        }

        public ProductOrderCheckOut(string user_id)
        {
            InitializeComponent();
            this.UserID = user_id;
        }

        public string UserID { get; set; }

        private void ProductOrderCheckOut_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public string _productName;
        public string _unitPrice;
        public string _amount;
        public string _subtotal;
        public Image _photo;

        [Category("Custom Props")]
        public string ProductNames
        {
            get { return _productName; }
            set { _productName = value; product_name.Text = value; }
        }

        public string UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; unit_price.Text = value; }
        }

        public string Amount
        {
            get { return _amount; }
            set { _amount = value; amount.Text = value; }
        }

        public string Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; item_subtotal.Text = value; }
        }

        public Image Photo { get { return _photo; } set { _photo = value; product_pic.Image = value; } }

        #endregion

        private void ProductOrderCheckOut_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}