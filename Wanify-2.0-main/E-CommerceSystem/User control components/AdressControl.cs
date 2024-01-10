
﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace E_CommerceSystem
{
    public partial class AddressControl : UserControl
    {
        Config dbConfig = new Config();
        MySqlConnection conn;
        public AddressControl()
        {
            InitializeComponent();
        }
        public AddressControl(string user_id, string requestFrom)
        {
            InitializeComponent();
            this.UserID = user_id;
            this.RequestFrom = requestFrom;
        }
        public string UserID { get; set; }

        public string RequestFrom { get; set; }
        private void AddressControl_Load(object sender, EventArgs e)
        {

            if(RequestFrom.Equals("Edit"))
            {
                editAddress.Visible = true;
                chooseAddress.Visible = false;
            }else
            {
                editAddress.Visible = false;
                delete_address.Visible = false;
                chooseAddress.Visible = true;
            }
        }

        #region Properties

        public string _fullNAme;
        public string _email;
        public string _region;
        public string _province;
        public string _city;
        public string _barangay;
        public string _postal;
        public string _street;
        public string _default;
        public int _addressID;


        [Category("Custom Props")]
        public string FullName
        {
            get { return _fullNAme; }
            set { _fullNAme = value; fullName.Text = value; }
        }

        [Category("Custom Props")]
        public string Email { get { return _email; } set { _email = value; emailAddress.Text = value; } }

        [Category("Custom Props")]
        public string Regions { get { return _region; } set { _region = value; region_label.Text = value; } }

        [Category("Custom Props")]
        public string Province { get { return _province; } set { _province = value; province_label.Text = value; } }

        [Category("Custom Props")]
        public string City { get { return _city; } set { _city = value; city_label.Text = value; } }

        [Category("Custom Props")]
        public string Barangay { get { return _barangay; } set { _barangay = value; barangay_label.Text = value; } }

        [Category("Custom Props")]
        public string Postal { get { return _postal; } set { _postal = value; postal_label.Text = value; } }

        [Category("Custom Props")]
        public string Street { get { return _street; } set { _street = value; street_name.Text = value; } }

        [Category("Custom Props")]
        public string Default { get { return _default; } set { _default = value; default_label.Visible = (_default.Equals("true")) ? true : false; } }

        [Category("Custom Props")]
        public int addressID { get { return _addressID; } set { _addressID = value; } }

        #endregion

        private void editAddress_Click(object sender, EventArgs e)
        {
            new AddressEdit(this.UserID, this.addressID).Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();
            try
            {
                MySqlCommand deleteAddress = new MySqlCommand("DELETE FROM user_address WHERE AddressID = '" + this.addressID + "'", conn);
                conn.Open();
                deleteAddress.ExecuteNonQuery();
                MessageBox.Show("Address Deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}