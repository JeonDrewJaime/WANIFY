using ComponentFactory.Krypton.Toolkit;
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

namespace E_CommerceSystem.Prompts
{
    public partial class RatingForm : KryptonForm
    {
        Config dbConfig;
        MySqlConnection conn;

        //global command for checking the values
        MySqlCommand checkIfNotZero;

        double previousCount = 0, newCount = 0;


        public RatingForm()
        {
            InitializeComponent();
        }

        public RatingForm(string userID, string productiD)
        {
            InitializeComponent();
            this.UserID = userID;
            this.ProductID = productiD;

            dbConfig = new Config();
        }

        public string UserID { get; set; }
        public string ProductID { get; set; }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            conn = dbConfig.getConnection();

            try
            {
                if (gunaRatingStar.Value < 0.5 || gunaRatingStar.Value == 0)
                {
                    MessageBox.Show("Rate cannot be less than 0.5");
                }
                else
                {
                    conn.Open();

                    //get the image profile of the user 
                    MySqlCommand getUserIcon = new MySqlCommand("SELECT picture_directory, userName, Name, Gender, Email, Phone, Birth FROM users WHERE userID = ('" + UserID + "')", conn);
                    MySqlDataReader fetchIcon = getUserIcon.ExecuteReader();
                    fetchIcon.Read();

                    long len = fetchIcon.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                    fetchIcon.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                    MemoryStream ms = new MemoryStream(array);
                    Bitmap bitmpap = new Bitmap(ms);

                    pictureBox1.Image = bitmpap;

                    fetchIcon.Close();

                    MemoryStream mss = new MemoryStream();
                    pictureBox1.Image.Save(mss, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imagesArr = mss.GetBuffer();

                    MySqlCommand insertComment = new MySqlCommand("INSERT INTO comment_center (user_stars_rating, image ,comment_body, date_created, time_created, userID, productID, isPriority) VALUES (@user_stars_rating, @image, @comment_body, @date_created, @time_created, @userID, @productID, @isPriority) ", conn);
                    insertComment.Parameters.AddWithValue("@image", imagesArr);
                    insertComment.Parameters.AddWithValue("@user_stars_rating", gunaRatingStar.Value);
                    insertComment.Parameters.AddWithValue("@comment_body", txtComment.Text);

                    DateTime currentDateTime = DateTime.Now;
                    string formatDate = currentDateTime.ToString("yyyy-MM-dd");
                    string formatTime = currentDateTime.ToString("HH:mm:ss");

                    insertComment.Parameters.AddWithValue("@date_created", formatDate);
                    insertComment.Parameters.AddWithValue("@time_created", formatTime);
                    insertComment.Parameters.AddWithValue("@userID", UserID);
                    insertComment.Parameters.AddWithValue("@productID", ProductID);
                    insertComment.Parameters.AddWithValue("@isPriority", "true");


                    insertComment.ExecuteNonQuery();

                    //insert rating in products
                    if (gunaRatingStar.Value == 5)
                    {
                        insertFiveStarRating();
                    }
                    else if (gunaRatingStar.Value >= 4 && gunaRatingStar.Value <= 4.5)
                    {
                        insertFourStarRating();
                    }
                    else if (gunaRatingStar.Value >= 3 && gunaRatingStar.Value <= 3.5)
                    {
                        insertThreeStarRating();
                    }
                    else if (gunaRatingStar.Value >= 2 && gunaRatingStar.Value <= 2.5)
                    {
                        insertTwoStarRating();
                    }
                    else
                    {
                        insertOneStarRating();
                    }

                    MessageBox.Show("Thank you for your comment!");

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RatingForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            conn = dbConfig.getConnection();
            try
            {
                conn.Open();

                MySqlCommand getProductInfo = new MySqlCommand("SELECT * FROM products WHERE productID = '" + ProductID + "'", conn);
                MySqlDataReader fetchProductInfo = getProductInfo.ExecuteReader();

                if (fetchProductInfo.HasRows)
                {
                    fetchProductInfo.Read();
                    lblProductName.Text = fetchProductInfo.GetString("product_name");

                    fetchProductInfo.Close();
                }
                else
                {
                    lblProductName.Text = "NULL";
                    fetchProductInfo.Close();
                }

                fetchProductInfo.Close();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void UpdateTotalAverage()
        {
            conn = dbConfig.getConnection();

            try
            {
                conn.Open();

                MySqlCommand getPreviousTotal = new MySqlCommand("SELECT five_star_count, four_star_count, three_star_count, two_star_count, one_star_count,total_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                MySqlDataReader fetchPrevTotalCount = getPreviousTotal.ExecuteReader();
                fetchPrevTotalCount.Read();

                double fiveStarCount = fetchPrevTotalCount.GetDouble("five_star_count"), fourStarCount = fetchPrevTotalCount.GetDouble("four_star_count"),
                    threeStarCount = fetchPrevTotalCount.GetDouble("three_star_count"), twoStarCount = fetchPrevTotalCount.GetDouble("two_star_count"),
                    oneStarCount = fetchPrevTotalCount.GetDouble("one_star_count");

                newCount = fiveStarCount + fourStarCount + threeStarCount + twoStarCount + oneStarCount;
                fetchPrevTotalCount.Close();

                MySqlCommand updateTotalCount = new MySqlCommand("UPDATE products SET total_star_count = '" + newCount + "' WHERE productID = '" + ProductID + "'", conn);
                updateTotalCount.ExecuteNonQuery();

                double fiveStarProduct = 5 * fiveStarCount,
                    fourStarProduct = 4 * fourStarCount,
                    threeStarProduct = 3 * threeStarCount,
                    twoStarProduct = 2 * twoStarCount,
                    oneStarProduct = 1 * oneStarCount;

                double newAverage = fiveStarProduct + fourStarProduct + threeStarProduct + twoStarProduct + oneStarProduct;
                newAverage /= newCount;

                //update the average
                MySqlCommand updateRatingAverage = new MySqlCommand("UPDATE products SET average_rating = '" + newAverage + "' WHERE productID = '" + ProductID + "'", conn);
                updateRatingAverage.ExecuteNonQuery();

                //update the orderRating
                MySqlCommand updateRated = new MySqlCommand("UPDATE orders SET isRated = 'true' WHERE userID = '" + UserID + "' AND productID = '" + ProductID + "'", conn);
                updateRated.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        public void insertFiveStarRating()
        {
            conn = dbConfig.getConnection();

            try
            {
                conn.Open();

                checkIfNotZero = new MySqlCommand("SELECT five_star_count, four_star_count, three_star_count, two_star_count, one_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                MySqlDataReader fetchValue = checkIfNotZero.ExecuteReader();
                fetchValue.Read();

                if (fetchValue.GetDouble("five_star_count") == 0)
                {
                    fetchValue.Close();

                    MySqlCommand updateFiveStar = new MySqlCommand("UPDATE products SET five_star_count = five_star_count + 1 WHERE productID = '" + ProductID + "'", conn);
                    updateFiveStar.ExecuteNonQuery();

                    //call the update method per rating
                    UpdateTotalAverage();

                }
                else
                {
                    fetchValue.Close();
                    //get the prev value
                    MySqlCommand getPreviousFiveStarCount = new MySqlCommand("SELECT five_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                    MySqlDataReader fetchPrevCount = getPreviousFiveStarCount.ExecuteReader();
                    fetchPrevCount.Read();

                    previousCount = fetchPrevCount.GetDouble("five_star_count");
                    previousCount += gunaRatingStar.Value;

                    fetchPrevCount.Close();

                    MySqlCommand updateCount = new MySqlCommand("UPDATE products SET five_star_count = '" + previousCount + "' WHERE productID = '" + ProductID + "' ", conn);
                    updateCount.ExecuteNonQuery();

                    UpdateTotalAverage();
                }
                fetchValue.Close();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void insertFourStarRating()
        {
            conn = dbConfig.getConnection();

            try
            {
                conn.Open();

                checkIfNotZero = new MySqlCommand("SELECT five_star_count, four_star_count, three_star_count, two_star_count, one_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                MySqlDataReader fetchValue = checkIfNotZero.ExecuteReader();
                fetchValue.Read();

                if (fetchValue.GetDouble("four_star_count") == 0)
                {
                    fetchValue.Close();

                    MySqlCommand updateFiveStar = new MySqlCommand("UPDATE products SET four_star_count = four_star_count + 1 WHERE productID = '" + ProductID + "'", conn);
                    updateFiveStar.ExecuteNonQuery();

                    //call the update method per rating
                    UpdateTotalAverage();


                }
                else
                {
                    fetchValue.Close();
                    //get the prev value
                    MySqlCommand getPreviousFourStarCount = new MySqlCommand("SELECT four_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                    MySqlDataReader fetchPrevCount = getPreviousFourStarCount.ExecuteReader();
                    fetchPrevCount.Read();

                    previousCount = fetchPrevCount.GetDouble("four_star_count");
                    previousCount += gunaRatingStar.Value;

                    fetchPrevCount.Close();

                    MySqlCommand updateCount = new MySqlCommand("UPDATE products SET four_star_count = '" + previousCount + "' WHERE productID = '" + ProductID + "'", conn);
                    updateCount.ExecuteNonQuery();

                    UpdateTotalAverage();


                }
                fetchValue.Close();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void insertThreeStarRating()
        {
            conn = dbConfig.getConnection();

            try
            {
                conn.Open();

                checkIfNotZero = new MySqlCommand("SELECT five_star_count, four_star_count, three_star_count, two_star_count, one_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                MySqlDataReader fetchValue = checkIfNotZero.ExecuteReader();
                fetchValue.Read();

                if (fetchValue.GetDouble("three_star_count") == 0)
                {
                    fetchValue.Close();

                    MySqlCommand updateFiveStar = new MySqlCommand("UPDATE products SET three_star_count = three_star_count + 1 WHERE productID = '" + ProductID + "'", conn);
                    updateFiveStar.ExecuteNonQuery();
                    //call the update method per rating
                    UpdateTotalAverage();


                }
                else
                {
                    fetchValue.Close();
                    //get the prev value 
                    MySqlCommand getPreviousThreeStarCount = new MySqlCommand("SELECT three_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                    MySqlDataReader fetchPrevCount = getPreviousThreeStarCount.ExecuteReader();
                    fetchPrevCount.Read();

                    previousCount = fetchPrevCount.GetDouble("three_star_count");
                    previousCount += gunaRatingStar.Value;

                    fetchPrevCount.Close();

                    MySqlCommand updateCount = new MySqlCommand("UPDATE products SET three_star_count = '" + previousCount + "' WHERE productID = '" + ProductID + "'", conn);
                    updateCount.ExecuteNonQuery();

                    UpdateTotalAverage();

                }
                fetchValue.Close();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void insertTwoStarRating()
        {
            conn = dbConfig.getConnection();

            try
            {
                conn.Open();

                checkIfNotZero = new MySqlCommand("SELECT five_star_count, four_star_count, three_star_count, two_star_count, one_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                MySqlDataReader fetchValue = checkIfNotZero.ExecuteReader();
                fetchValue.Read();

                if (fetchValue.GetDouble("two_star_count") == 0)
                {
                    fetchValue.Close();

                    MySqlCommand updateFiveStar = new MySqlCommand("UPDATE products SET two_star_count = two_star_count + 1 WHERE productID = '" + ProductID + "'", conn);
                    updateFiveStar.ExecuteNonQuery();

                    //call the update method per rating
                    UpdateTotalAverage();


                }
                else
                {
                    fetchValue.Close();
                    //get the prev value
                    MySqlCommand getPreviousTwoStarCount = new MySqlCommand("SELECT two_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                    MySqlDataReader fetchPrevCount = getPreviousTwoStarCount.ExecuteReader();
                    fetchPrevCount.Read();

                    previousCount = fetchPrevCount.GetDouble("two_star_count");
                    previousCount += gunaRatingStar.Value;

                    fetchPrevCount.Close();

                    MySqlCommand updateCount = new MySqlCommand("UPDATE products SET three_star_count = '" + previousCount + "' WHERE productID = '" + ProductID + "'", conn);
                    updateCount.ExecuteNonQuery();

                    UpdateTotalAverage();


                }
                fetchValue.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void insertOneStarRating()
        {
            conn = dbConfig.getConnection();
            try
            {
                conn.Open();

                checkIfNotZero = new MySqlCommand("SELECT five_star_count, four_star_count, three_star_count, two_star_count, one_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                MySqlDataReader fetchValue = checkIfNotZero.ExecuteReader();
                fetchValue.Read();

                if (fetchValue.GetDouble("one_star_count") == 0)
                {
                    fetchValue.Close();

                    MySqlCommand updateFiveStar = new MySqlCommand("UPDATE products SET one_star_count = one_star_count + 1 WHERE productID = '" + ProductID + "'", conn);
                    updateFiveStar.ExecuteNonQuery();

                    //call the update method per rating
                    UpdateTotalAverage();


                }
                else
                {
                    fetchValue.Close();
                    //get the prev value
                    MySqlCommand getPreviousOneStarCount = new MySqlCommand("SELECT one_star_count FROM products WHERE productID = '" + ProductID + "'", conn);
                    MySqlDataReader fetchPrevCount = getPreviousOneStarCount.ExecuteReader();
                    fetchPrevCount.Read();

                    previousCount = fetchPrevCount.GetDouble("one_star_count");
                    previousCount += gunaRatingStar.Value;

                    fetchPrevCount.Close();

                    MySqlCommand updateCount = new MySqlCommand("UPDATE products SET one_star_count = '" + previousCount + "' WHERE productID = '" + ProductID + "'", conn);
                    updateCount.ExecuteNonQuery();

                    UpdateTotalAverage();


                }
                fetchValue.Close();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
