namespace E_CommerceSystem
{
    partial class Orders
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
            this.emailAddress = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.fullName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.street_name = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.region_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barangay_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.postal_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.province_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.city_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.open_order = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailAddress
            // 
            this.emailAddress.Location = new System.Drawing.Point(2, 44);
            this.emailAddress.Margin = new System.Windows.Forms.Padding(2);
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.Size = new System.Drawing.Size(65, 28);
            this.emailAddress.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(48)))));
            this.emailAddress.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.emailAddress.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailAddress.TabIndex = 79;
            this.emailAddress.Values.Text = "Email";
            // 
            // fullName
            // 
            this.fullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.fullName.Location = new System.Drawing.Point(2, 9);
            this.fullName.Margin = new System.Windows.Forms.Padding(2);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(92, 36);
            this.fullName.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(48)))));
            this.fullName.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.fullName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.fullName.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.fullName.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.fullName.TabIndex = 78;
            this.fullName.Values.Text = "Name";
            // 
            // street_name
            // 
            this.street_name.Location = new System.Drawing.Point(0, 2);
            this.street_name.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.street_name.Name = "street_name";
            this.street_name.Size = new System.Drawing.Size(81, 20);
            this.street_name.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.street_name.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.street_name.StateCommon.ShortText.Font = new System.Drawing.Font("Manrope", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.street_name.TabIndex = 7;
            this.street_name.Values.Text = "Street name";
            // 
            // region_label
            // 
            this.region_label.Location = new System.Drawing.Point(145, 2);
            this.region_label.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.region_label.Name = "region_label";
            this.region_label.Size = new System.Drawing.Size(50, 20);
            this.region_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.region_label.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.region_label.StateCommon.ShortText.Font = new System.Drawing.Font("Manrope", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.region_label.TabIndex = 8;
            this.region_label.Values.Text = "Region";
            // 
            // barangay_label
            // 
            this.barangay_label.Location = new System.Drawing.Point(81, 2);
            this.barangay_label.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.barangay_label.Name = "barangay_label";
            this.barangay_label.Size = new System.Drawing.Size(64, 20);
            this.barangay_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.barangay_label.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.barangay_label.StateCommon.ShortText.Font = new System.Drawing.Font("Manrope", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barangay_label.TabIndex = 74;
            this.barangay_label.Values.Text = "Barangay";
            // 
            // postal_label
            // 
            this.postal_label.Location = new System.Drawing.Point(195, 2);
            this.postal_label.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.postal_label.Name = "postal_label";
            this.postal_label.Size = new System.Drawing.Size(46, 20);
            this.postal_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.postal_label.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.postal_label.StateCommon.ShortText.Font = new System.Drawing.Font("Manrope", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postal_label.TabIndex = 75;
            this.postal_label.Values.Text = "Postal";
            // 
            // province_label
            // 
            this.province_label.Location = new System.Drawing.Point(241, 2);
            this.province_label.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.province_label.Name = "province_label";
            this.province_label.Size = new System.Drawing.Size(60, 20);
            this.province_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.province_label.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.province_label.StateCommon.ShortText.Font = new System.Drawing.Font("Manrope", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.province_label.TabIndex = 72;
            this.province_label.Values.Text = "Province";
            // 
            // city_label
            // 
            this.city_label.Location = new System.Drawing.Point(0, 26);
            this.city_label.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.city_label.Name = "city_label";
            this.city_label.Size = new System.Drawing.Size(34, 20);
            this.city_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.city_label.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.city_label.StateCommon.ShortText.Font = new System.Drawing.Font("Manrope", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city_label.TabIndex = 73;
            this.city_label.Values.Text = "City";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.flowLayoutPanel1.Controls.Add(this.street_name);
            this.flowLayoutPanel1.Controls.Add(this.barangay_label);
            this.flowLayoutPanel1.Controls.Add(this.region_label);
            this.flowLayoutPanel1.Controls.Add(this.postal_label);
            this.flowLayoutPanel1.Controls.Add(this.province_label);
            this.flowLayoutPanel1.Controls.Add(this.city_label);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 71);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 68);
            this.flowLayoutPanel1.TabIndex = 81;
            // 
            // open_order
            // 
            this.open_order.Animated = true;
            this.open_order.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_order.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.open_order.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.open_order.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.open_order.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.open_order.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(48)))));
            this.open_order.Font = new System.Drawing.Font("Manrope ExtraBold", 15F, System.Drawing.FontStyle.Bold);
            this.open_order.ForeColor = System.Drawing.Color.White;
            this.open_order.HoverState.FillColor = System.Drawing.Color.Cyan;
            this.open_order.HoverState.ForeColor = System.Drawing.Color.Black;
            this.open_order.Location = new System.Drawing.Point(0, 132);
            this.open_order.Margin = new System.Windows.Forms.Padding(2);
            this.open_order.Name = "open_order";
            this.open_order.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.open_order.Size = new System.Drawing.Size(328, 39);
            this.open_order.TabIndex = 84;
            this.open_order.Text = "VIEW ORDER";
            this.open_order.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            this.open_order.Tile = true;
            this.open_order.Click += new System.EventHandler(this.open_order_Click);
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.open_order);
            this.Controls.Add(this.emailAddress);
            this.Controls.Add(this.fullName);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 60, 20);
            this.Name = "Orders";
            this.Size = new System.Drawing.Size(328, 171);
            this.Load += new System.EventHandler(this.OrdersControlcs_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel emailAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel fullName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel street_name;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel region_label;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel barangay_label;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel postal_label;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel province_label;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel city_label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button open_order;
    }
}
