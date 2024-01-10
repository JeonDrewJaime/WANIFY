
﻿namespace E_CommerceSystem
{
    partial class AddressControl
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
            this.fullName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.emailAddress = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.street_name = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.region_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.editAddress = new Guna.UI2.WinForms.Guna2Button();
            this.province_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.city_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barangay_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.postal_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.default_label = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chooseAddress = new Guna.UI2.WinForms.Guna2Button();
            this.delete_address = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fullName
            // 
            this.fullName.Location = new System.Drawing.Point(3, 11);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(88, 31);
            this.fullName.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.fullName.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.fullName.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 20.25F, System.Drawing.FontStyle.Bold);
            this.fullName.TabIndex = 5;
            this.fullName.Values.Text = "Name";
            // 
            // emailAddress
            // 
            this.emailAddress.Location = new System.Drawing.Point(3, 45);
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.Size = new System.Drawing.Size(58, 23);
            this.emailAddress.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.emailAddress.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.emailAddress.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailAddress.TabIndex = 6;
            this.emailAddress.Values.Text = "Email";
            // 
            // street_name
            // 
            this.street_name.Location = new System.Drawing.Point(0, 3);
            this.street_name.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.street_name.Name = "street_name";
            this.street_name.Size = new System.Drawing.Size(91, 20);
            this.street_name.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.street_name.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.street_name.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.street_name.TabIndex = 7;
            this.street_name.Values.Text = "Street name";
            // 
            // region_label
            // 
            this.region_label.Location = new System.Drawing.Point(162, 3);
            this.region_label.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.region_label.Name = "region_label";
            this.region_label.Size = new System.Drawing.Size(53, 20);
            this.region_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.region_label.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.region_label.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 9.749999F);
            this.region_label.TabIndex = 8;
            this.region_label.Values.Text = "Region";
            // 
            // editAddress
            // 
            this.editAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editAddress.Animated = true;
            this.editAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editAddress.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.editAddress.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.editAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.editAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.editAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.editAddress.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.editAddress.ForeColor = System.Drawing.Color.White;
            this.editAddress.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.editAddress.HoverState.ForeColor = System.Drawing.Color.White;
            this.editAddress.Location = new System.Drawing.Point(-2, 96);
            this.editAddress.Name = "editAddress";
            this.editAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.editAddress.Size = new System.Drawing.Size(457, 38);
            this.editAddress.TabIndex = 71;
            this.editAddress.Text = "EDIT ADDRESS";
            this.editAddress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            this.editAddress.Tile = true;
            this.editAddress.Click += new System.EventHandler(this.editAddress_Click);
            // 
            // province_label
            // 
            this.province_label.Location = new System.Drawing.Point(265, 3);
            this.province_label.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.province_label.Name = "province_label";
            this.province_label.Size = new System.Drawing.Size(64, 20);
            this.province_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.province_label.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.province_label.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 9.749999F);
            this.province_label.TabIndex = 72;
            this.province_label.Values.Text = "Province";
            // 
            // city_label
            // 
            this.city_label.Location = new System.Drawing.Point(329, 3);
            this.city_label.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.city_label.Name = "city_label";
            this.city_label.Size = new System.Drawing.Size(35, 20);
            this.city_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.city_label.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.city_label.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 9.749999F);
            this.city_label.TabIndex = 73;
            this.city_label.Values.Text = "City";
            // 
            // barangay_label
            // 
            this.barangay_label.Location = new System.Drawing.Point(91, 3);
            this.barangay_label.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.barangay_label.Name = "barangay_label";
            this.barangay_label.Size = new System.Drawing.Size(71, 20);
            this.barangay_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.barangay_label.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.barangay_label.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 9.749999F);
            this.barangay_label.TabIndex = 74;
            this.barangay_label.Values.Text = "Barangay";
            // 
            // postal_label
            // 
            this.postal_label.Location = new System.Drawing.Point(215, 3);
            this.postal_label.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.postal_label.Name = "postal_label";
            this.postal_label.Size = new System.Drawing.Size(50, 20);
            this.postal_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.postal_label.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.postal_label.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 9.749999F);
            this.postal_label.TabIndex = 75;
            this.postal_label.Values.Text = "Postal";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.flowLayoutPanel1.Controls.Add(this.street_name);
            this.flowLayoutPanel1.Controls.Add(this.barangay_label);
            this.flowLayoutPanel1.Controls.Add(this.region_label);
            this.flowLayoutPanel1.Controls.Add(this.postal_label);
            this.flowLayoutPanel1.Controls.Add(this.province_label);
            this.flowLayoutPanel1.Controls.Add(this.city_label);
            this.flowLayoutPanel1.Controls.Add(this.default_label);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(453, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(497, 110);
            this.flowLayoutPanel1.TabIndex = 76;
            // 
            // default_label
            // 
            this.default_label.Location = new System.Drawing.Point(364, 3);
            this.default_label.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.default_label.Name = "default_label";
            this.default_label.Size = new System.Drawing.Size(57, 20);
            this.default_label.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.default_label.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.default_label.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 9.749999F);
            this.default_label.TabIndex = 77;
            this.default_label.Values.Text = "Default";
            // 
            // chooseAddress
            // 
            this.chooseAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseAddress.Animated = true;
            this.chooseAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseAddress.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.chooseAddress.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.chooseAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.chooseAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.chooseAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.chooseAddress.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.chooseAddress.ForeColor = System.Drawing.Color.White;
            this.chooseAddress.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.chooseAddress.HoverState.ForeColor = System.Drawing.Color.White;
            this.chooseAddress.Location = new System.Drawing.Point(953, 259);
            this.chooseAddress.Name = "chooseAddress";
            this.chooseAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chooseAddress.Size = new System.Drawing.Size(807, 38);
            this.chooseAddress.TabIndex = 77;
            this.chooseAddress.Text = "CHOOSE ADDRESS";
            this.chooseAddress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            this.chooseAddress.Tile = true;
            // 
            // delete_address
            // 
            this.delete_address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_address.Animated = true;
            this.delete_address.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_address.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.delete_address.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.delete_address.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.delete_address.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.delete_address.FillColor = System.Drawing.Color.DarkRed;
            this.delete_address.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.delete_address.ForeColor = System.Drawing.Color.White;
            this.delete_address.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.delete_address.HoverState.ForeColor = System.Drawing.Color.White;
            this.delete_address.Location = new System.Drawing.Point(453, 96);
            this.delete_address.Name = "delete_address";
            this.delete_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.delete_address.Size = new System.Drawing.Size(497, 38);
            this.delete_address.TabIndex = 78;
            this.delete_address.Text = "DELETE ADDRESS";
            this.delete_address.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            this.delete_address.Tile = true;
            this.delete_address.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // AddressControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.delete_address);
            this.Controls.Add(this.chooseAddress);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.editAddress);
            this.Controls.Add(this.emailAddress);
            this.Controls.Add(this.fullName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 10);
            this.Name = "AddressControl";
            this.Size = new System.Drawing.Size(950, 134);
            this.Load += new System.EventHandler(this.AddressControl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel fullName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel emailAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel street_name;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel region_label;
        private Guna.UI2.WinForms.Guna2Button editAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel province_label;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel city_label;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel barangay_label;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel postal_label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button chooseAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel default_label;
        private Guna.UI2.WinForms.Guna2Button delete_address;
    }
}