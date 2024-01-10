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
using ComponentFactory.Krypton.Toolkit;
using E_CommerceSystem.User_control_components;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace E_CommerceSystem
{
    public partial class ProductDescription : KryptonForm
    {
        Config dbConfig;
        MySqlConnection conn;

        UserPrompt refreshForm;

        int cartCount; //global variable for cart count

        public ProductDescription()
        {
            InitializeComponent();
            this.FormClosing += ProductDescriptiom_FormClosing;

        }

        public ProductDescription(string product_id, string user_id, string product_name)
        {
            InitializeComponent();
            dbConfig = new Config();
            this.ProductID = product_id;
            this.UserID = user_id;
            this.PrdName = product_name;
            this.FormClosing += ProductDescriptiom_FormClosing;

        }

        public string ProductID { get; set; }
        public string UserID { get; set; }

        public string PrdName { get; set; }
        private void ProductDescription_Load(object sender, EventArgs e)
        {

            conn = dbConfig.getConnection();

            lbl_ref.Visible = false;
            add_to_cart.Enabled= false;
            commenFlowLayout.Visible = false;

            MySqlCommand getUserPic = new MySqlCommand("SELECT picture_directory FROM users WHERE userID = ('" + UserID + "')", conn);
            MySqlCommand selectProductBasedOnID = new MySqlCommand("SELECT image, description, price, product_name, category, average_rating FROM products WHERE productID = ('" + ProductID + "')", conn);

            try
            {
                conn.Open();

                MySqlDataReader fethcCurrentUserPic = getUserPic.ExecuteReader();
                
                if(fethcCurrentUserPic.HasRows)
                {
                    fethcCurrentUserPic.Read();

                    //display the image based on the fetched id
                    long length = fethcCurrentUserPic.GetBytes(0, 0, null, 0, 0);
                    byte[] arrays = new byte[System.Convert.ToInt32(length + 1)];
                    fethcCurrentUserPic.GetBytes(0, 0, arrays, 0, System.Convert.ToInt32(length));

                    MemoryStream picMemoryStream = new MemoryStream(arrays);
                    Bitmap userPic = new Bitmap(picMemoryStream);

                    fethcCurrentUserPic.Close();


                }
                else
                {
                    fethcCurrentUserPic.Close();

                }

                fethcCurrentUserPic.Close();

                //----------------------------------------------------------------------------
                MySqlDataReader fetchProductByID = selectProductBasedOnID.ExecuteReader();
                fetchProductByID.Read();

                ratingAvg.Value = fetchProductByID.GetFloat("average_rating");

                if (fetchProductByID.GetString("category").Contains("Men Perfume"))
                {
                    string[] scents = {"SEXY MEN", "WILD MEN", "DREAM MEN"};

                    foreach(string scent in scents)
                    {
                        cmb_scent.Items.Add(scent);
                    }

                    cmb_scent.SelectedIndex = 0;


                }
                else if (fetchProductByID.GetString("category").Contains("Women Perfume"))
                {

                    string[] scents = { "MAPLE RED", "STRAW HAT", "RUBY RUSH" };

                    foreach (string scent in scents)
                    {
                        cmb_scent.Items.Add(scent);
                    }

                    cmb_scent.SelectedIndex = 0;

                }
                else
                {
                    string[] scents = { "PARTY", "SMELLY", "DREAMS" };

                    foreach (string scent in scents)
                    {
                        cmb_scent.Items.Add(scent);
                    }
                    cmb_scent.SelectedIndex = 0;

                }

                //display the image based on the fetched id
                long productLength = fetchProductByID.GetBytes(0, 0, null, 0, 0);
                byte[] prodArray = new byte[System.Convert.ToInt32(productLength + 1)];
                fetchProductByID.GetBytes(0, 0, prodArray, 0, System.Convert.ToInt32(productLength));

                MemoryStream productMemoryStream = new MemoryStream(prodArray);
                Bitmap productPictures = new Bitmap(productMemoryStream);
                productPicture.Image = productPictures;

                //changed the desc, price, prdName according to the fetched id using the passed in value during this session
                ProductDesc.Text = fetchProductByID.GetString("description");
                ProductName.Text = fetchProductByID.GetString("product_name");
                ProductPrice.Text = $"₱{fetchProductByID.GetString("price")}";
                fetchProductByID.Close();

                conn.Close();
                fetchComments();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void fetchComments ()
        {
            conn = dbConfig.getConnection();

            try
            {
                conn.Open();

                //get total comments count
                //need to know the current users own comment to prioritize it
                MySqlCommand getCommentCount = new MySqlCommand("SELECT users.picture_directory, comment_center.date_created,comment_center.comment_body, comment_center.user_stars_rating, comment_center.isPriority, comment_center.userID ,users.Name FROM comment_center INNER JOIN users ON comment_center.userID = users.userID WHERE productID = '" + ProductID + "' ORDER BY comment_center.isPriority DESC", conn);
                MySqlDataReader fetchCommentCount = getCommentCount.ExecuteReader();

                CommentControl commentControl;

                int totalCommentCount = 0;
                bool checkCurrentUser;
                while (fetchCommentCount.Read())
                {
                    long len = fetchCommentCount.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                    fetchCommentCount.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                    MemoryStream ms = new MemoryStream(array);
                    Bitmap bitmpap = new Bitmap(ms);

                    totalCommentCount++;
                    commentControl = new CommentControl();

                    //check the current user because you lblYou (You) is depends on who is the current logged in user.
                    checkCurrentUser = UserID == fetchCommentCount.GetString("userID");

                    commentControl.Name = fetchCommentCount.GetString("Name");
                    commentControl.Icon = bitmpap;
                    commentControl.IsPriority = checkCurrentUser;
                    commentControl.Rate = fetchCommentCount.GetFloat("user_stars_rating");
                    commentControl.Date = fetchCommentCount.GetDateTime("date_created").ToString("yyyy-MM-dd");
                    commentControl.Comment = fetchCommentCount.GetString("comment_body");

                    commenFlowLayout.Controls.Add(commentControl);

                }


                lblCommentCount.Text = totalCommentCount.ToString();
                fetchCommentCount.Close();


                conn.Close();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductDescriptiom_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshForm = new UserPrompt(UserID);
            refreshForm.UserPrompt_Load(sender, e);

        }
 
        private void add_to_cart_Click(object sender, EventArgs e)
        {
            cartCount++;

            conn = dbConfig.getConnection();

            string productName, unitPrice;

            MySqlCommand fetchProductInfo = new MySqlCommand("SELECT image, product_name, price FROM products WHERE productID = ('" + ProductID + "') ", conn);

            try
            {
                conn.Open();
                MySqlDataReader fetchResult = fetchProductInfo.ExecuteReader();
                fetchResult.Read();

                productName = fetchResult.GetString("product_name");
                unitPrice = fetchResult.GetString("price");
                fetchResult.Close();

                MemoryStream ms = new MemoryStream();
                productPicture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arrImage = ms.GetBuffer();

                MySqlCommand checkIfProductExists = new MySqlCommand("SELECT * FROM cart WHERE productName = ('" + PrdName + "') AND userID = ('"+UserID+"')", conn);

                try
                {
                    MySqlDataReader fetchProductFromCart = checkIfProductExists.ExecuteReader();

                    fetchProductFromCart.Read();

                    if (fetchProductFromCart.HasRows)
                    {

                        int fetchUnitPrice = fetchProductFromCart.GetInt32("unitPrice");
                        int fetchTotalPrice = fetchProductFromCart.GetInt32("totalPrice");
                        fetchProductFromCart.Close();

                        int updateTotalPriceDupliPrdAdded = fetchTotalPrice + fetchUnitPrice;

                        MySqlCommand updateQuantity = new MySqlCommand("UPDATE cart SET productQuantity = productQuantity + 1, totalPrice = ('" + updateTotalPriceDupliPrdAdded + "'), variant = ('"+cmb_scent.Text+"') WHERE productName = ('" + PrdName + "')", conn);
                        updateQuantity.ExecuteNonQuery();

                        MessageBox.Show("ADDED TO CART");

                        ProductDescription_Load(sender, e);

                        this.Close();

                    }
                    else
                    {
                        fetchProductFromCart.Close();
                        MySqlCommand insertCart = new MySqlCommand("INSERT INTO cart (productName, variant ,unitPrice, productQuantity,totalPrice ,picture_directory,productID ,userID) VALUES (@productName,@variant ,@unitPrice, @productQuantity,@totalPrice ,@picture_directory,@productID, @userID) ", conn);

                        insertCart.Parameters.AddWithValue("@productName", productName);
                        insertCart.Parameters.AddWithValue("@variant", lbl_ref.Text);
                        insertCart.Parameters.AddWithValue("@unitPrice", unitPrice);
                        insertCart.Parameters.AddWithValue("@productQuantity", "1");
                        insertCart.Parameters.AddWithValue("@totalPrice", unitPrice);
                        insertCart.Parameters.AddWithValue("@picture_directory", arrImage);
                        insertCart.Parameters.AddWithValue("@productID", ProductID);
                        insertCart.Parameters.AddWithValue("@userID", UserID);

                        insertCart.ExecuteNonQuery();


                        MessageBox.Show("ADDED TO CART");

                        ProductDescription_Load(sender, e);

                        this.Close();
                    }

                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmb_scent_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_ref.Text = cmb_scent.Text;
            add_to_cart.Enabled= true;
        }

   

        private void lblComment_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void lblComment_Click(object sender, EventArgs e)
        {
            if (commenFlowLayout.Visible == false)
            {
                commenFlowLayout.Visible = true;
            }
            else
            {
                commenFlowLayout.Visible = false;

            }
        }
    }
}
