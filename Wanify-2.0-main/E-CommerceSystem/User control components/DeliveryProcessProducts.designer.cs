namespace E_CommerceSystem
{
    partial class DeliveryProcessProducts
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.product_name = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.product_price = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.quantity = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.status_product = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.order_receive = new Guna.UI2.WinForms.Guna2Button();
            this.productPic = new System.Windows.Forms.PictureBox();
            this.lblCommentCount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnDefective = new Guna.UI2.WinForms.Guna2Button();
            this.btnRate = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.productPic)).BeginInit();
            this.SuspendLayout();
            // 
            // product_name
            // 
            this.product_name.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.product_name.Location = new System.Drawing.Point(264, 8);
            this.product_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.product_name.Name = "product_name";
            this.product_name.Size = new System.Drawing.Size(280, 78);
            this.product_name.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.product_name.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.product_name.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_name.TabIndex = 6;
            this.product_name.Values.Text = "Product";
            // 
            // product_price
            // 
            this.product_price.Location = new System.Drawing.Point(508, 84);
            this.product_price.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.product_price.Name = "product_price";
            this.product_price.Size = new System.Drawing.Size(103, 45);
            this.product_price.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.product_price.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.product_price.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_price.TabIndex = 7;
            this.product_price.Values.Text = "Price";
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(508, 137);
            this.quantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(98, 45);
            this.quantity.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.quantity.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.quantity.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.TabIndex = 8;
            this.quantity.Values.Text = "QNT";
            // 
            // status_product
            // 
            this.status_product.Location = new System.Drawing.Point(508, 195);
            this.status_product.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.status_product.Name = "status_product";
            this.status_product.Size = new System.Drawing.Size(156, 45);
            this.status_product.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.status_product.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.status_product.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_product.TabIndex = 9;
            this.status_product.Values.Text = "STATUS";
            // 
            // order_receive
            // 
            this.order_receive.Animated = true;
            this.order_receive.BorderRadius = 5;
            this.order_receive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.order_receive.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.order_receive.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.order_receive.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.order_receive.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.order_receive.FillColor = System.Drawing.Color.Maroon;
            this.order_receive.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.order_receive.ForeColor = System.Drawing.Color.White;
            this.order_receive.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.order_receive.HoverState.ForeColor = System.Drawing.Color.White;
            this.order_receive.Location = new System.Drawing.Point(1272, 170);
            this.order_receive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.order_receive.Name = "order_receive";
            this.order_receive.PressedColor = System.Drawing.Color.Empty;
            this.order_receive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.order_receive.Size = new System.Drawing.Size(410, 69);
            this.order_receive.TabIndex = 50;
            this.order_receive.Text = "ORDER RECEIVED";
            this.order_receive.Tile = true;
            this.order_receive.Click += new System.EventHandler(this.order_receive_Click);
            // 
            // productPic
            // 
            this.productPic.Location = new System.Drawing.Point(0, 0);
            this.productPic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.productPic.Name = "productPic";
            this.productPic.Size = new System.Drawing.Size(250, 258);
            this.productPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productPic.TabIndex = 10;
            this.productPic.TabStop = false;
            // 
            // lblCommentCount
            // 
            this.lblCommentCount.Location = new System.Drawing.Point(276, 84);
            this.lblCommentCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCommentCount.Name = "lblCommentCount";
            this.lblCommentCount.Size = new System.Drawing.Size(128, 46);
            this.lblCommentCount.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblCommentCount.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblCommentCount.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentCount.TabIndex = 56;
            this.lblCommentCount.Values.Text = "Total:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(273, 138);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(201, 46);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 57;
            this.kryptonLabel1.Values.Text = "Quantity:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(277, 194);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(155, 46);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.kryptonLabel2.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 58;
            this.kryptonLabel2.Values.Text = "Status:";
            // 
            // btnDefective
            // 
            this.btnDefective.Animated = true;
            this.btnDefective.BorderRadius = 5;
            this.btnDefective.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefective.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDefective.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDefective.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDefective.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDefective.FillColor = System.Drawing.Color.Firebrick;
            this.btnDefective.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnDefective.ForeColor = System.Drawing.Color.White;
            this.btnDefective.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.btnDefective.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDefective.Location = new System.Drawing.Point(1272, 84);
            this.btnDefective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDefective.Name = "btnDefective";
            this.btnDefective.PressedColor = System.Drawing.Color.Empty;
            this.btnDefective.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDefective.Size = new System.Drawing.Size(410, 69);
            this.btnDefective.TabIndex = 59;
            this.btnDefective.Text = "DEFECTIVE PRODUCT";
            this.btnDefective.Tile = true;
            this.btnDefective.Click += new System.EventHandler(this.btnDefective_Click);
            // 
            // btnRate
            // 
            this.btnRate.Animated = true;
            this.btnRate.BorderRadius = 5;
            this.btnRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.btnRate.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnRate.ForeColor = System.Drawing.Color.White;
            this.btnRate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.btnRate.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnRate.Location = new System.Drawing.Point(1272, 171);
            this.btnRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRate.Name = "btnRate";
            this.btnRate.PressedColor = System.Drawing.Color.Empty;
            this.btnRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRate.Size = new System.Drawing.Size(410, 69);
            this.btnRate.TabIndex = 60;
            this.btnRate.Text = "RATE PRODUCT";
            this.btnRate.Tile = true;
            this.btnRate.Click += new System.EventHandler(this.btnRate_Click);
            // 
            // DeliveryProcessProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.btnRate);
            this.Controls.Add(this.btnDefective);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.lblCommentCount);
            this.Controls.Add(this.order_receive);
            this.Controls.Add(this.productPic);
            this.Controls.Add(this.status_product);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.product_price);
            this.Controls.Add(this.product_name);
            this.Name = "DeliveryProcessProducts";
            this.Size = new System.Drawing.Size(1718, 255);
            this.Load += new System.EventHandler(this.DeliveryProcessProductsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel product_name;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel product_price;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel quantity;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel status_product;
        private System.Windows.Forms.PictureBox productPic;
        private Guna.UI2.WinForms.Guna2Button order_receive;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCommentCount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Guna.UI2.WinForms.Guna2Button btnDefective;
        private Guna.UI2.WinForms.Guna2Button btnRate;
    }
}
