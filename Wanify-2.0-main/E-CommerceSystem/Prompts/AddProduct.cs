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
using System.IO;

namespace E_CommerceSystem
{
    public partial class AddProduct : KryptonForm
    {
        Config dbConfig;
        MySqlConnection conn;
        string productID;
        string function;
        public AddProduct()
        {
            InitializeComponent();
            function = "Create";
        }
        public AddProduct(string productID)
        {
            InitializeComponent();
            this.productID = productID;
            function = "edit";
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            dbConfig = new Config();
            conn = dbConfig.getConnection();

            add_product.Enabled = false;

            string[] perfumeVariant = { "Men Perfume ", "Women Perfume", "Unisex Perfume" };

            foreach (string variant in perfumeVariant)
            {

                category_cmb.Items.Add(variant);
            }

            if (function.Equals("edit"))
            {
                MySqlCommand fetchProduct = new MySqlCommand("SELECT image, product_name, price, category, description, product_stock FROM products WHERE productID = ('" + productID + "')", conn);
                add_product.Text = "UPDATE PRODUCT";
                try
                {
                    conn.Open();

                    MySqlDataReader fetchproductByID = fetchProduct.ExecuteReader();

                    fetchproductByID.Read();
                    if (fetchproductByID.HasRows)
                    {
                        long len = fetchproductByID.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len + 1)];
                        fetchproductByID.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmpap = new Bitmap(ms);

                        productPicture.Image = bitmpap;

                        product_name.Text = fetchproductByID.GetString("product_name");
                        product_price.Text = fetchproductByID.GetString("price");
                        category_cmb.SelectedItem = fetchproductByID.GetString("category");
                        product_description.Text = fetchproductByID.GetString("description");
                        stock.Text = fetchproductByID.GetString("product_stock");
                        if (stock.Text.ToString().Equals("0"))
                        {
                            required_stock.Text = "Restocking Required";
                            required_stock.Visible = true;

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void upload_photo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.png) | *.png|(*.jpg)|*.jpg|(*.gif)|*.gif|(*.jpeg)| *.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                productPicture.Image = new Bitmap(openFileDialog1.FileName);
            }
            else
            {
                // do nothing
            }
        }

        private void add_product_Click(object sender, EventArgs e)
        {
            dbConfig = new Config();
            conn = dbConfig.getConnection();

            MySqlCommand checkIfProductExists = new MySqlCommand("SELECT * FROM products WHERE product_name = ('" + product_name.Text + "')", conn);
            MySqlCommand insertProduct = new MySqlCommand("INSERT INTO products (product_name, price, image, category, description, product_stock, one_star_count, two_star_count, three_star_count, four_star_count, five_star_count) VALUES (@product_name, @price, @image, @category, @description, @product_stock, @one_star_count, @two_star_count, @three_star_count, @four_star_count, @five_star_count)", conn);

            try
            {
                if (function.Equals("edit"))
                {
                    try
                    {
                        conn.Open();
                        MemoryStream ms = new MemoryStream();
                        productPicture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] arrImage = ms.GetBuffer();

                        MySqlCommand updateProduct = new MySqlCommand("UPDATE products SET product_name = @productname, price = @price,image = @image ,category = @category, description = @description, product_stock = @production_stock WHERE productID = @productID", conn);
                        updateProduct.Parameters.AddWithValue("@productname", product_name.Text);
                        updateProduct.Parameters.AddWithValue("@price", product_price.Text);
                        updateProduct.Parameters.AddWithValue("@image", arrImage);
                        updateProduct.Parameters.AddWithValue("@category", category_cmb.SelectedItem);
                        updateProduct.Parameters.AddWithValue("@description", product_description.Text);
                        updateProduct.Parameters.AddWithValue("@production_stock", stock.Text);
                        updateProduct.Parameters.AddWithValue("@productID", productID);
                       
                        updateProduct.ExecuteNonQuery();
                        MessageBox.Show("Edit Successfully");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (function.Equals("Create"))
                {
                    conn.Open();
                    MySqlDataReader checkResult = checkIfProductExists.ExecuteReader();
                    checkResult.Read();

                    if (checkResult.HasRows) //check if product already exists to avoid product dupplication
                    {
                        checkResult.Close();
                        MBPopup("Product Already Exists!");

                        productPicture.Image = null;
                        product_name.Text = "";
                        category_cmb.SelectedIndex = -1;
                        product_description.Text = "";
                        product_price.Text = "";
                        stock.Text = "";

                    }
                    else
                    {
                        checkResult.Close();

                        MemoryStream ms = new MemoryStream();
                        productPicture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] arrImage = ms.GetBuffer();

                        insertProduct.Parameters.AddWithValue("@product_name", product_name.Text);
                        insertProduct.Parameters.AddWithValue("@price", product_price.Text);
                        insertProduct.Parameters.AddWithValue("@image", arrImage);
                        insertProduct.Parameters.AddWithValue("@category", category_cmb.Text);
                        insertProduct.Parameters.AddWithValue("@description", product_description.Text);
                        insertProduct.Parameters.AddWithValue("@product_stock", stock.Text);
                        insertProduct.Parameters.AddWithValue("@one_star_count", "0");
                        insertProduct.Parameters.AddWithValue("@two_star_count", "0");
                        insertProduct.Parameters.AddWithValue("@three_star_count", "0");
                        insertProduct.Parameters.AddWithValue("@four_star_count", "0");
                        insertProduct.Parameters.AddWithValue("@five_star_count", "0");

                        insertProduct.ExecuteNonQuery();

                        MySqlCommand selectProductID = new MySqlCommand("SELECT productID FROM products WHERE product_name = ('" + product_name.Text + "')", conn);

                        MySqlDataReader fetchPrdID = selectProductID.ExecuteReader();
                        fetchPrdID.Read();
                        string productID = fetchPrdID.GetString("productID");
                        fetchPrdID.Close();

                        MySqlCommand insertForProductStatistics = new MySqlCommand("INSERT INTO product_sales_statistics (productName, productCategory, productID) VALUES (@productName, @productCategory, @productID)", conn);

                        insertForProductStatistics.Parameters.AddWithValue("@productName", product_name.Text);
                        insertForProductStatistics.Parameters.AddWithValue("@productCategory", category_cmb.Text);
                        insertForProductStatistics.Parameters.AddWithValue("@productID", productID);

                        insertForProductStatistics.ExecuteNonQuery();

                        MessageBox.Show("Product Added!");

                        productPicture.Image = null;
                        product_name.Text = "";
                        category_cmb.SelectedIndex = -1;
                        product_description.Text = "";
                        product_price.Text = "";
                        stock.Text = "";

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void product_name_TextChanged(object sender, EventArgs e)
        {
            if (product_name.Text == string.Empty)
            {
                required_FieldName.Visible = true;
            }
            else
            {
                required_FieldName.Visible = false;

                if (product_price.Text.Any(char.IsDigit) == true && stock.Text.Any(char.IsDigit) == true && productPicture.Image != null)
                {
                    add_product.Enabled = true;
                }

            }
        }

        private void product_price_TextChanged(object sender, EventArgs e)
        {
            if (product_price.Text == string.Empty || product_price.Text.Any(char.IsDigit) == false)
            {
                required_price.Visible = true;
            }
            else
            {
                required_price.Visible = false;

                if (product_price.Text.Any(char.IsDigit) == true && stock.Text.Any(char.IsDigit) == true && productPicture.Image != null)
                {
                    add_product.Enabled = true;
                }

            }
        }

        private void category_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (category_cmb.SelectedIndex == -1)
            {
                required_category.Visible = true;
            }
            else
            {
                required_category.Visible = false;

                if (product_price.Text.Any(char.IsDigit) == true && stock.Text.Any(char.IsDigit) == true && productPicture.Image != null)
                {
                    add_product.Enabled = true;
                }

            }
        }

        private void stock_TextChanged(object sender, EventArgs e)
        {
            if (stock.Text == string.Empty || stock.Text.Any(char.IsDigit) == false || stock.Text.ToString().Equals("0"))
            {
                if (stock.Text.ToString().Equals("0"))
                {
                    required_stock.Text = "Required Restocking";
                }
                else
                {
                    required_stock.Text = "Required ";
                }

                required_stock.Visible = true;
            }
            else
            {
                required_stock.Visible = false;


                if (product_price.Text.Any(char.IsDigit) == true && stock.Text.Any(char.IsDigit) == true && productPicture.Image != null)
                {
                    add_product.Enabled = true;
                }

            }
        }

        private void product_description_TextChanged(object sender, EventArgs e)
        {
            if (product_description.Text == string.Empty)
            {
                required_desc.Visible = true;
            }
            else
            {
                required_desc.Visible = false;

                if (product_price.Text.Any(char.IsDigit) == true && stock.Text.Any(char.IsDigit) == true && productPicture.Image != null)
                {
                    add_product.Enabled = true;
                }

            }
        }

        private void productPicture_Click(object sender, EventArgs e)
        {

        }

        private void product_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                required_price.Text = "Not Accepting letters!";
                required_price.Visible = true;
            }
            else
            {
                required_price.Text = "Required Field";

            }
        }

        private void stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                required_stock.Text = "Not Accepting letters!";
                required_stock.Visible = true;
            }
            else
            {
                required_stock.Text = "Required Field";

            }
        }
    }
}