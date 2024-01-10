
using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;

namespace E_CommerceSystem
{
    public partial class Verification : KryptonForm
    {
        int seconds = 30;
        //global obj
        Config dbConfig;
        MySqlConnection conn;
        SendEmailVerification emailVerify;

        public Verification()
        {
            InitializeComponent();
            this.FormClosing += Verification_FormClosing;
        }
        public Verification(string gmail, string userName, string fullName, string region, string province, string city, string barangay, string postalCode, string streetName)
        {
            InitializeComponent();
            this.UserGmail = gmail;
            this.UserName = userName;
            this.FormClosing += Verification_FormClosing;
            this.FullName = fullName;
            this.Regions = region;
            this.Province = province;
            this.City = city;
            this.Barangay = barangay;
            this.PostalCode = postalCode;
            this.StreetName = streetName;
        }

        public Verification(string recovery_email)
        {
            InitializeComponent();
            this.RecoveryEmail = recovery_email;
            this.FormClosing += Verification_FormClosing;

        }

        public string UserGmail { get; set; }
        public string UserName { get; set; }
        public string RecoveryEmail { get; set; }
        public string FullName { get; set; }
        public string Regions { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }

        private void Verification_Load(object sender, EventArgs e)
        {
            user_code.Text = "";
            user_gmail.Text = RecoveryEmail == null ? UserGmail : RecoveryEmail;
            lbl_countdown.Text = seconds.ToString("");
            resend_code.Enabled = false;
            hiddenPicBoxRef.Hide();
            verification_countdown.Start();
        }

        private void verify_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand sendVerificationCode = new MySqlCommand("SELECT * FROM users WHERE Email = ('" + RecoveryEmail + "')", conn);

            try
            {
                conn.Open();
                MySqlDataReader fetchRecoveryCode = sendVerificationCode.ExecuteReader();
                fetchRecoveryCode.Read();
                if (fetchRecoveryCode.HasRows)
                {
                    string recoveryCode = fetchRecoveryCode.GetString("recovery_code");
                    string userID = fetchRecoveryCode.GetString("userID");
                    fetchRecoveryCode.Close();
                    if (user_code.Text.Equals(recoveryCode))
                    {
                        this.Close();
                        new ChangePassword(userID).Show();
                        removeRecoveryCodeWhenClosed();
                    }
                    else
                    {
                        new CustomMessageBox().Show();
                    }
                }
                else
                {
                    fetchRecoveryCode.Close();
                    string verificationCode, tblSUp_usernName, tblSUp_userPass, tblSUp_userEmail, tblSUp_userPhoneNumber;
                    string tblSUp_userRole = "user";

                    MySqlCommand getCode = new MySqlCommand("SELECT * FROM temporary_signups WHERE Email = ('" + UserGmail + "')", conn);

                    try
                    {
                        MySqlDataReader checkCode = getCode.ExecuteReader();
                        checkCode.Read();
                        verificationCode = checkCode.GetString("verificationCode");
                        tblSUp_usernName = checkCode.GetString("userName");
                        tblSUp_userPass = checkCode.GetString("password");
                        tblSUp_userEmail = checkCode.GetString("Email");
                        tblSUp_userPhoneNumber = checkCode.GetString("phoneNumber");
                        checkCode.Close();

                        if (user_code.Text.Equals(verificationCode))
                        {

                            MySqlCommand checkIfExists = new MySqlCommand("SELECT * FROM users WHERE Phone = ('" + tblSUp_userPhoneNumber + "') OR Email = ('" + tblSUp_userEmail + "')", conn);
                            MySqlDataReader fetchResult = checkIfExists.ExecuteReader();
                            fetchResult.Read();
                            if (fetchResult.HasRows) //user already exists in the users table
                            {
                                fetchResult.Close();

                                //user already exists message box
                                MessageBox.Show("USER ALREADY EXISTS");
                                this.Hide();
                                new Login().Show();
                                this.Close();

                                deleteQueue();
                            }
                            else
                            {
                                fetchResult.Close();
                                hiddenPicBoxRef.BackgroundImage = new Bitmap("C:\\Users\\jaime\\Desktop\\defaultProfile.png");
                                MemoryStream ms = new MemoryStream();
                                hiddenPicBoxRef.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                byte[] imagesArr = ms.GetBuffer();

                                MySqlCommand insertNewUser = new MySqlCommand("INSERT INTO users (userName, userPass, picture_directory, Email, Phone, role) VALUES (@userName, @userPass, @picture_directory, @Email, @Phone, @role)", conn);
                                insertNewUser.Parameters.AddWithValue("@userName", tblSUp_usernName);
                                insertNewUser.Parameters.AddWithValue("@userPass", tblSUp_userPass);
                                insertNewUser.Parameters.AddWithValue("@picture_directory", imagesArr);
                                insertNewUser.Parameters.AddWithValue("@Email", tblSUp_userEmail);
                                insertNewUser.Parameters.AddWithValue("@Phone", tblSUp_userPhoneNumber);
                                insertNewUser.Parameters.AddWithValue("@role", tblSUp_userRole);
                                insertNewUser.ExecuteNonQuery();

                                MySqlCommand getnewUserID = new MySqlCommand("SELECT * FROM users WHERE Email = ('" + UserGmail + "')", conn);
                                MySqlDataReader ferchUserID = getnewUserID.ExecuteReader();
                                ferchUserID.Read();
                                int userID = ferchUserID.GetInt32("userID");
                                ferchUserID.Close();

                                MySqlCommand insertAddress = new MySqlCommand("INSERT INTO user_address (FullName, Email, Region, Province, City, Barangay, PostalCode, StreetName, isDefault, userID) VALUES (@FullName, @Email, @Region, @Province, @City, @Barangay, @PostalCode, @StreetName, @isDefault, @userID)", conn);
                                insertAddress.Parameters.AddWithValue("@FullName", FullName);
                                insertAddress.Parameters.AddWithValue("@Email", UserGmail);
                                insertAddress.Parameters.AddWithValue("@Region", Regions);
                                insertAddress.Parameters.AddWithValue("@Province", Province);
                                insertAddress.Parameters.AddWithValue("@City", City);
                                insertAddress.Parameters.AddWithValue("@Barangay", Barangay);
                                insertAddress.Parameters.AddWithValue("@PostalCode", PostalCode);
                                insertAddress.Parameters.AddWithValue("@StreetName", StreetName);
                                insertAddress.Parameters.AddWithValue("@isDefault", "true");
                                insertAddress.Parameters.AddWithValue("@userID", userID);

                                insertAddress.ExecuteNonQuery();

                                //sign up successful message box
                                MessageBox.Show("USER CREATED!");
                                this.Hide();
                                new Login().Show();
                                this.Close();
                            }

                        }
                        else
                        {
                            //incorrect verification code message box
                            new CustomMessageBox().Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Verification_FormClosed(object sender, FormClosedEventArgs e)
        {
            deleteQueue();
            removeRecoveryCodeWhenClosed();
        }

        private void Verification_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteQueue();
            removeRecoveryCodeWhenClosed();
        }

        private void verification_countdown_Tick(object sender, EventArgs e)
        {

            lbl_countdown.Text = seconds--.ToString();
            if (seconds < 0)
            {
                verification_countdown.Stop();
                verify_btn.Enabled = false;
                resend_code.Enabled = true;
                user_code.Enabled = false;
            }
        }

        private void resend_code_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            emailVerify = new SendEmailVerification();
            conn = dbConfig.getConnection();

            seconds = 30;
            lbl_countdown.Text = seconds.ToString();
            resend_code.Enabled = false;
            verify_btn.Enabled = true;
            user_code.Enabled = true;

            verification_countdown.Start();

            if (UserGmail == null)
            {
                MySqlCommand delelePrevCode = new MySqlCommand("UPDATE users SET recovery_code = '' WHERE Email = ('" + RecoveryEmail + "')", conn);
                try
                {
                    conn.Open();
                    MySqlDataReader removePrevCode = delelePrevCode.ExecuteReader();
                    removePrevCode.Close();

                    string code = emailVerify.EmailVerificationCode(RecoveryEmail, UserName);
                    MySqlCommand newCode = new MySqlCommand("UPDATE users SET recovery_code = ('" + code + "') WHERE Email = ('" + RecoveryEmail + "')", conn);
                    newCode.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MySqlCommand delelePrevCode = new MySqlCommand("UPDATE temporary_signups SET verificationCode = '' WHERE Email = ('" + UserGmail + "')", conn);
                try
                {
                    conn.Open();
                    MySqlDataReader removePrevCode = delelePrevCode.ExecuteReader();
                    removePrevCode.Close();

                    string code = emailVerify.EmailVerificationCode(UserGmail, UserName);
                    MySqlCommand newCode = new MySqlCommand("UPDATE temporary_signups SET verificationCode = ('" + code + "') WHERE Email = ('" + UserGmail + "')", conn);
                    newCode.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void deleteQueue()
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand deleteUserQueue = new MySqlCommand("DELETE FROM temporary_signups WHERE Email = ('" + UserGmail + "')", conn);
            try
            {
                conn.Open();
                MySqlDataReader deleteExecute = deleteUserQueue.ExecuteReader();
                deleteExecute.Close();
            }
            catch (Exception) { }
        }

        private void removeRecoveryCodeWhenClosed()
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand deleteRecoveryCode = new MySqlCommand("UPDATE users SET recovery_code = '' WHERE Email = ('" + RecoveryEmail + "')", conn);
            try
            {
                conn.Open();
                MySqlDataReader deleteExecute = deleteRecoveryCode.ExecuteReader();
                deleteExecute.Close();
            }
            catch (Exception) { }
        }

        private void verification_proceedtogmail_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://gmail.com");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}