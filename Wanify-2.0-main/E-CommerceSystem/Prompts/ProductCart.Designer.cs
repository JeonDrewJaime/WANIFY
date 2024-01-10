namespace E_CommerceSystem
{
    partial class ProductCart
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
            this.delete_item = new Guna.UI2.WinForms.Guna2Button();
            this.product_quantity = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.minusQuantity_button = new Guna.UI2.WinForms.Guna2Button();
            this.addQuantity_button = new Guna.UI2.WinForms.Guna2Button();
            this.referenceID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.add_list = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productPic = new System.Windows.Forms.PictureBox();
            this.order_received = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // product_name
            // 
            this.product_name.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.product_name.Location = new System.Drawing.Point(3, 3);
            this.product_name.Name = "product_name";
            this.product_name.Size = new System.Drawing.Size(189, 53);
            this.product_name.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.product_name.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.product_name.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_name.TabIndex = 5;
            this.product_name.Values.Text = "Product";
            // 
            // product_price
            // 
            this.product_price.Location = new System.Drawing.Point(304, 62);
            this.product_price.Name = "product_price";
            this.product_price.Size = new System.Drawing.Size(71, 31);
            this.product_price.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.product_price.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.product_price.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_price.TabIndex = 6;
            this.product_price.Values.Text = "Price";
            // 
            // delete_item
            // 
            this.delete_item.Animated = true;
            this.delete_item.BorderRadius = 5;
            this.delete_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_item.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.delete_item.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.delete_item.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.delete_item.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.delete_item.FillColor = System.Drawing.Color.Maroon;
            this.delete_item.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.delete_item.ForeColor = System.Drawing.Color.White;
            this.delete_item.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.delete_item.HoverState.ForeColor = System.Drawing.Color.White;
            this.delete_item.Location = new System.Drawing.Point(890, 88);
            this.delete_item.Name = "delete_item";
            this.delete_item.PressedColor = System.Drawing.Color.Empty;
            this.delete_item.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.delete_item.Size = new System.Drawing.Size(273, 45);
            this.delete_item.TabIndex = 49;
            this.delete_item.Text = "REMOVE FROM CART";
            this.delete_item.Tile = true;
            this.delete_item.Click += new System.EventHandler(this.delete_item_Click);
            // 
            // product_quantity
            // 
            this.product_quantity.AutoSize = false;
            this.product_quantity.Location = new System.Drawing.Point(937, 35);
            this.product_quantity.Name = "product_quantity";
            this.product_quantity.Size = new System.Drawing.Size(180, 43);
            this.product_quantity.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 20.25F);
            this.product_quantity.StateCommon.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.product_quantity.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.product_quantity.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.product_quantity.TabIndex = 54;
            this.product_quantity.Values.Text = "0";
            this.product_quantity.Paint += new System.Windows.Forms.PaintEventHandler(this.product_quantity_Paint);
            // 
            // minusQuantity_button
            // 
            this.minusQuantity_button.Animated = true;
            this.minusQuantity_button.BorderRadius = 5;
            this.minusQuantity_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minusQuantity_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.minusQuantity_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.minusQuantity_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.minusQuantity_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.minusQuantity_button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.minusQuantity_button.Font = new System.Drawing.Font("Manrope", 25F, System.Drawing.FontStyle.Bold);
            this.minusQuantity_button.ForeColor = System.Drawing.Color.White;
            this.minusQuantity_button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.minusQuantity_button.HoverState.ForeColor = System.Drawing.Color.White;
            this.minusQuantity_button.Location = new System.Drawing.Point(890, 31);
            this.minusQuantity_button.Name = "minusQuantity_button";
            this.minusQuantity_button.PressedColor = System.Drawing.Color.Empty;
            this.minusQuantity_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.minusQuantity_button.Size = new System.Drawing.Size(48, 43);
            this.minusQuantity_button.TabIndex = 53;
            this.minusQuantity_button.Text = "-";
            this.minusQuantity_button.TextOffset = new System.Drawing.Point(2, -4);
            this.minusQuantity_button.Tile = true;
            this.minusQuantity_button.Click += new System.EventHandler(this.minusQuantity_button_Click);
            // 
            // addQuantity_button
            // 
            this.addQuantity_button.Animated = true;
            this.addQuantity_button.BorderRadius = 5;
            this.addQuantity_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addQuantity_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addQuantity_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addQuantity_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addQuantity_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addQuantity_button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.addQuantity_button.Font = new System.Drawing.Font("Manrope", 25F, System.Drawing.FontStyle.Bold);
            this.addQuantity_button.ForeColor = System.Drawing.Color.White;
            this.addQuantity_button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.addQuantity_button.HoverState.ForeColor = System.Drawing.Color.White;
            this.addQuantity_button.Location = new System.Drawing.Point(1115, 31);
            this.addQuantity_button.Name = "addQuantity_button";
            this.addQuantity_button.PressedColor = System.Drawing.Color.Empty;
            this.addQuantity_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addQuantity_button.Size = new System.Drawing.Size(48, 43);
            this.addQuantity_button.TabIndex = 52;
            this.addQuantity_button.Text = "+";
            this.addQuantity_button.TextOffset = new System.Drawing.Point(2, -4);
            this.addQuantity_button.Tile = true;
            this.addQuantity_button.Click += new System.EventHandler(this.addQuantity_button_Click);
            // 
            // referenceID
            // 
            this.referenceID.Location = new System.Drawing.Point(304, 88);
            this.referenceID.Name = "referenceID";
            this.referenceID.Size = new System.Drawing.Size(116, 31);
            this.referenceID.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.referenceID.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 20.25F);
            this.referenceID.TabIndex = 55;
            this.referenceID.Values.Text = "Quantity";
            // 
            // add_list
            // 
            this.add_list.Animated = true;
            this.add_list.BackColor = System.Drawing.Color.Transparent;
            this.add_list.CausesValidation = false;
            this.add_list.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.add_list.CheckedState.BorderRadius = 1;
            this.add_list.CheckedState.BorderThickness = 10;
            this.add_list.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.add_list.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.add_list.Location = new System.Drawing.Point(34, 61);
            this.add_list.Name = "add_list";
            this.add_list.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.add_list.Size = new System.Drawing.Size(57, 42);
            this.add_list.TabIndex = 56;
            this.add_list.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.add_list.UncheckedState.BorderRadius = 2;
            this.add_list.UncheckedState.BorderThickness = 2;
            this.add_list.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(202)))), ((int)(((byte)(234)))));
            this.add_list.UseTransparentBackground = true;
            this.add_list.Click += new System.EventHandler(this.add_list_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.panel1.Controls.Add(this.add_list);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 167);
            this.panel1.TabIndex = 57;
            // 
            // productPic
            // 
            this.productPic.Location = new System.Drawing.Point(131, 0);
            this.productPic.Name = "productPic";
            this.productPic.Size = new System.Drawing.Size(167, 168);
            this.productPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productPic.TabIndex = 7;
            this.productPic.TabStop = false;
            this.productPic.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // order_received
            // 
            this.order_received.Animated = true;
            this.order_received.Cursor = System.Windows.Forms.Cursors.Hand;
            this.order_received.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.order_received.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.order_received.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.order_received.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.order_received.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.order_received.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.order_received.ForeColor = System.Drawing.Color.White;
            this.order_received.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.order_received.HoverState.ForeColor = System.Drawing.Color.White;
            this.order_received.Location = new System.Drawing.Point(297, 124);
            this.order_received.Name = "order_received";
            this.order_received.PressedColor = System.Drawing.Color.Empty;
            this.order_received.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.order_received.Size = new System.Drawing.Size(889, 45);
            this.order_received.TabIndex = 58;
            this.order_received.Text = "ORDER RECEIVED";
            this.order_received.Tile = true;
            this.order_received.Click += new System.EventHandler(this.order_received_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.product_name);
            this.panel2.Location = new System.Drawing.Point(304, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 57);
            this.panel2.TabIndex = 59;
            // 
            // ProductCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.referenceID);
            this.Controls.Add(this.product_price);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.order_received);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.minusQuantity_button);
            this.Controls.Add(this.addQuantity_button);
            this.Controls.Add(this.delete_item);
            this.Controls.Add(this.productPic);
            this.Controls.Add(this.product_quantity);
            this.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.Name = "ProductCart";
            this.Size = new System.Drawing.Size(1186, 169);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel product_name;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel product_price;
        private System.Windows.Forms.PictureBox productPic;
        private Guna.UI2.WinForms.Guna2Button delete_item;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel product_quantity;
        private Guna.UI2.WinForms.Guna2Button minusQuantity_button;
        private Guna.UI2.WinForms.Guna2Button addQuantity_button;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel referenceID;
        private Guna.UI2.WinForms.Guna2CustomCheckBox add_list;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button order_received;
        private System.Windows.Forms.Panel panel2;
    }
}
