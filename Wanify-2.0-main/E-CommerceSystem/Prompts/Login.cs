using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;

namespace E_CommerceSystem
{
    public partial class Login : KryptonForm

    {
        #region Variables & Objects
        Config dbConfig;
        MySqlConnection conn;
        string errorMessages = "CONNECTION LOST";
        string userName, userPass;
        string userID = "";
        #endregion 
        #region Encapsulation
        public string UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public string UserPass
        {
            get { return this.userPass; }
            set { this.userPass = value; }
        }
        #endregion
        #region Main Form
        public Login()
        {;
            this.userID= "";
            InitializeComponent();
        }
        public Login(string userID, string userName, string userPass)
        {
            this.userID = userID;
            this.userName = userName;
            this.userPass = userPass;
        } 
        private void Login_Load(object sender, EventArgs e)
        {
            log_in.Enabled = false;
            password.UseSystemPasswordChar = true;
        }
        private void password_TextChanged(object sender, EventArgs e)
        {
            if (password.Text == string.Empty && user_name.Text == string.Empty)
            {
                error_password.Visible = true;
                error_password.Text = "Required field";
                log_in.Enabled = false;
            }
            else if (password.Text.Length > 0 && user_name.Text == string.Empty)
            {
                error_password.Visible = false;
                error_password.Text = "Required field";
                log_in.Enabled = false;
            }
            else if (password.Text == string.Empty)
            {
                error_password.Visible = true;
                error_password.Text = "Required field";
                log_in.Enabled = false;
            }

            else
            {
                error_password.Text = "";
                log_in.Enabled = true;
            }
        }
        private void user_name_TextChanged(object sender, EventArgs e)
        {
            if (user_name.Text == string.Empty && password.Text == string.Empty)
            {
                error_username.Visible = true;
                error_username.Text = "Required field";
                log_in.Enabled = false;
            }
            else if (user_name.Text.Length > 0 && password.Text == string.Empty)
            {
                error_username.Visible = false;
                error_username.Text = "Required field";
                log_in.Enabled = false;
            }
            else if (user_name.Text == string.Empty)
            {
                error_username.Visible = true;
                error_username.Text = "Required field";
                log_in.Enabled = false;
            }
            else
            {
                error_username.Text = "";
                log_in.Enabled = true;
            }
        }

        private void sign_up_Click(object sender, EventArgs e)
        {

            this.Hide();
            new SignUp().Show();

        }
        private void show_password_CheckedChanged(object sender, EventArgs e)
        {
           password.UseSystemPasswordChar = show_password.Checked == true ? false: true;
        }

        private void forgot_password_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PassRecovery().Show();
        }

        private void log_in_Click(object sender, EventArgs e)
        {
            UserName = user_name.Text;
            UserPass = password.Text;
            dbConfig = new Config();
            conn = dbConfig.getConnection();
            MySqlCommand checkUser = new MySqlCommand("SELECT * FROM users WHERE userName = ('" + UserName + "') AND userPass = ('" + UserPass + "')",conn); //query
            try
            {
                conn.Open(); //open the connection after command
                MySqlDataReader fetchUser = checkUser.ExecuteReader(); //execute the query/command
                fetchUser.Read(); //fetch

                if (fetchUser.HasRows) //check if data exists in the database
                {
                    //if data does exist check the role
                    if (fetchUser.GetString("role").Equals("admin"))
                    {
                        UserID = fetchUser.GetString("userID");
                        new AdminPrompt(UserID).Show();
                        this.Hide();

                        fetchUser.Close();

                    }
                    else
                    {
                        UserID = fetchUser.GetString("userID");
                        new UserPrompt(UserID).Show();
                        this.Hide();

                        fetchUser.Close();

                    }

                    fetchUser.Close();

                    MySqlCommand updatePriorityStatus = new MySqlCommand("UPDATE comment_center SET isPriority = 'true' WHERE userID = '" + UserID + "'", conn);
                    updatePriorityStatus.ExecuteNonQuery();

                }
                else//User not found
                {
                        MBPopup("USER NOT FOUND");
                }

                conn.Close();
            }
            catch (Exception ) {
                MBPopup(errorMessages);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
        #endregion
    }
}