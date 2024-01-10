using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace E_CommerceSystem
{
    public partial class PassRecovery : KryptonForm
    {
        Config dbConfig;
        MySqlConnection conn;
        SendEmailVerification sendCode;
        public PassRecovery()
        {
            InitializeComponent();
        }

        private void PassRecovery_Load(object sender, EventArgs e)
        {

            required_FieldRecEmail.Visible = false;
            continue_btn.Enabled = false;

        }

        private void user_recoveryEmail_TextChanged(object sender, EventArgs e)
        {
            if (user_recoveryEmail.Text == string.Empty)
            {

                required_FieldRecEmail.Visible = true;
                continue_btn.Enabled = false;


            }
            else
            {
                required_FieldRecEmail.Text = "";
                continue_btn.Enabled = true;
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void continue_btn_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            sendCode = new SendEmailVerification();
            conn = dbConfig.getConnection();

            MySqlCommand checkDBIfUserExists = new MySqlCommand("SELECT * FROM users WHERE Email = ('" + user_recoveryEmail.Text + "')", conn);

            try
            {
                conn.Open();
                MySqlDataReader fetchRecoveryEmail = checkDBIfUserExists.ExecuteReader();
                fetchRecoveryEmail.Read();

                if (fetchRecoveryEmail.HasRows)
                {

                    string gmail = fetchRecoveryEmail.GetString("Email");
                    string username = fetchRecoveryEmail.GetString("userName");

                    fetchRecoveryEmail.Close();

                    string generatedRecoveryCode = sendCode.EmailVerificationCode(gmail, username);

                    MySqlCommand insertRecoveryCode = new MySqlCommand("UPDATE users SET recovery_code = ('" + generatedRecoveryCode + "') WHERE Email = ('" + gmail + "')", conn);
                    MySqlDataReader insertCode = insertRecoveryCode.ExecuteReader();
                    insertCode.Close();

                    this.Close();
                    new Verification(gmail).Show();

                }
                else
                {
                
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void back_btn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
