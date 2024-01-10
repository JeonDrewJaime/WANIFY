﻿using System;
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

namespace E_CommerceSystem
{
    public partial class ChangePassword : KryptonForm
    {
        Config dbConfig;
        MySqlConnection conn;

        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(string userID)
        {
            InitializeComponent();
            this.UserID = userID;
        }

        public string UserID { get; set; }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            error_newpass.Visible = true;
            error_newpassconfirm.Visible = true;
            new_password.UseSystemPasswordChar = true;
            new_password_confirm.UseSystemPasswordChar = true;

        }

        private void new_password_TextChanged(object sender, EventArgs e)
        {
            if (new_password.Text == string.Empty && error_newpassconfirm.Text == string.Empty)
            {
                error_newpass.Visible = true;
                change_password.Enabled = false;

            }
            else if (new_password.Text == string.Empty)
            {

                error_newpass.Visible = true;
                change_password.Enabled = false;

            }
            else if (new_passShow.Text.Length > 0 && error_newpassconfirm.Text == string.Empty)
            {
                error_newpass.Visible = true;
                change_password.Enabled = false;
            }
            else
            {
                error_newpass.Visible = false;

            }
        }

        private void new_password_confirm_TextChanged(object sender, EventArgs e)
        {
            if (new_password_confirm.Text == string.Empty && new_password.Text == string.Empty)
            {

                error_newpassconfirm.Visible = true;
                change_password.Enabled = false;

            }
            else if (new_password_confirm.Text == string.Empty)
            {

                error_newpassconfirm.Visible = true;
                change_password.Enabled = false;

            }
            else if ((new_password_confirm.Text.Length > 0 && new_password.Text == string.Empty))
            {

                error_newpassconfirm.Visible = true;
                change_password.Enabled = false;
            }
            else
            {
                error_newpassconfirm.Text = "";
                change_password.Enabled = true;
            }
        }

        private void new_passShow_CheckedChanged(object sender, EventArgs e)
        {
            new_password.UseSystemPasswordChar = new_passShow.Checked == true ? false : true;
        }

        private void confirmpass_show_CheckedChanged(object sender, EventArgs e)
        {
            new_password_confirm.UseSystemPasswordChar = confirmpass_show.Checked == true ? false : true;

        }

        private void change_password_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            if (new_password.Text.Equals(new_password_confirm.Text))
            {
                MySqlCommand updatePass = new MySqlCommand("UPDATE users SET userPass = ('" + new_password_confirm.Text + "') WHERE userID = ('" + UserID + "')", conn);

                try
                {
                    conn.Open();
                    updatePass.ExecuteNonQuery();
                    this.Close();
                    new Login().Show();

                }
                catch (Exception )
                {

                }

            }
            else
            {
              
            }

        }
    }
}