namespace E_CommerceSystem
{
    partial class ChangePassword
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.new_password_confirm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.confirmpass_show = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.error_newpassconfirm = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.new_password = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.new_passShow = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.error_newpass = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.change_password = new Guna.UI2.WinForms.Guna2Button();
            this.ChangePasswordPallette = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("League Spartan Thin", 35F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.label1.Location = new System.Drawing.Point(40, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 70);
            this.label1.TabIndex = 12;
            this.label1.Text = "CHANGE PASSWORD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // new_password_confirm
            // 
            this.new_password_confirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.new_password_confirm.Location = new System.Drawing.Point(101, 182);
            this.new_password_confirm.Name = "new_password_confirm";
            this.new_password_confirm.Size = new System.Drawing.Size(338, 31);
            this.new_password_confirm.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.new_password_confirm.StateCommon.Border.Rounding = 5;
            this.new_password_confirm.StateCommon.Border.Width = 1;
            this.new_password_confirm.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.new_password_confirm.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.new_password_confirm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.new_password_confirm.TabIndex = 44;
            this.new_password_confirm.TextChanged += new System.EventHandler(this.new_password_confirm_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(99, 164);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(135, 19);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.kryptonLabel5.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin Light", 12F);
            this.kryptonLabel5.TabIndex = 48;
            this.kryptonLabel5.Values.Text = "Confirm password:";
            // 
            // confirmpass_show
            // 
            this.confirmpass_show.Animated = true;
            this.confirmpass_show.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.confirmpass_show.CheckedState.BorderRadius = 2;
            this.confirmpass_show.CheckedState.BorderThickness = 0;
            this.confirmpass_show.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.confirmpass_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmpass_show.Location = new System.Drawing.Point(334, 218);
            this.confirmpass_show.Name = "confirmpass_show";
            this.confirmpass_show.Size = new System.Drawing.Size(13, 13);
            this.confirmpass_show.TabIndex = 46;
            this.confirmpass_show.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.confirmpass_show.UncheckedState.BorderRadius = 2;
            this.confirmpass_show.UncheckedState.BorderThickness = 2;
            this.confirmpass_show.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(202)))), ((int)(((byte)(234)))));
            this.confirmpass_show.CheckedChanged += new System.EventHandler(this.confirmpass_show_CheckedChanged);
            // 
            // error_newpassconfirm
            // 
            this.error_newpassconfirm.Location = new System.Drawing.Point(100, 218);
            this.error_newpassconfirm.Name = "error_newpassconfirm";
            this.error_newpassconfirm.Size = new System.Drawing.Size(83, 18);
            this.error_newpassconfirm.StateCommon.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.error_newpassconfirm.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 8.249999F);
            this.error_newpassconfirm.TabIndex = 45;
            this.error_newpassconfirm.Values.Text = "Required field";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(344, 218);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(94, 18);
            this.kryptonLabel7.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 8.249999F);
            this.kryptonLabel7.TabIndex = 47;
            this.kryptonLabel7.Values.Text = "Show password";
            // 
            // new_password
            // 
            this.new_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.new_password.Location = new System.Drawing.Point(101, 100);
            this.new_password.Name = "new_password";
            this.new_password.Size = new System.Drawing.Size(338, 31);
            this.new_password.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.new_password.StateCommon.Border.Rounding = 5;
            this.new_password.StateCommon.Border.Width = 1;
            this.new_password.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.new_password.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.new_password.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.new_password.TabIndex = 49;
            this.new_password.TextChanged += new System.EventHandler(this.new_password_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(99, 82);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(111, 19);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin Light", 12F);
            this.kryptonLabel1.TabIndex = 53;
            this.kryptonLabel1.Values.Text = "New password:";
            // 
            // new_passShow
            // 
            this.new_passShow.Animated = true;
            this.new_passShow.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.new_passShow.CheckedState.BorderRadius = 2;
            this.new_passShow.CheckedState.BorderThickness = 0;
            this.new_passShow.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.new_passShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.new_passShow.Location = new System.Drawing.Point(334, 136);
            this.new_passShow.Name = "new_passShow";
            this.new_passShow.Size = new System.Drawing.Size(13, 13);
            this.new_passShow.TabIndex = 51;
            this.new_passShow.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.new_passShow.UncheckedState.BorderRadius = 2;
            this.new_passShow.UncheckedState.BorderThickness = 2;
            this.new_passShow.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(202)))), ((int)(((byte)(234)))));
            this.new_passShow.CheckedChanged += new System.EventHandler(this.new_passShow_CheckedChanged);
            // 
            // error_newpass
            // 
            this.error_newpass.Location = new System.Drawing.Point(101, 136);
            this.error_newpass.Name = "error_newpass";
            this.error_newpass.Size = new System.Drawing.Size(83, 18);
            this.error_newpass.StateCommon.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.error_newpass.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 8.249999F);
            this.error_newpass.TabIndex = 50;
            this.error_newpass.Values.Text = "Required field";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(345, 136);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(94, 18);
            this.kryptonLabel8.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 8.249999F);
            this.kryptonLabel8.TabIndex = 52;
            this.kryptonLabel8.Values.Text = "Show password";
            // 
            // change_password
            // 
            this.change_password.Animated = true;
            this.change_password.BorderRadius = 5;
            this.change_password.Cursor = System.Windows.Forms.Cursors.Hand;
            this.change_password.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.change_password.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.change_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.change_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.change_password.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.change_password.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.change_password.ForeColor = System.Drawing.Color.White;
            this.change_password.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.change_password.HoverState.ForeColor = System.Drawing.Color.White;
            this.change_password.Location = new System.Drawing.Point(129, 259);
            this.change_password.Name = "change_password";
            this.change_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.change_password.Size = new System.Drawing.Size(270, 45);
            this.change_password.TabIndex = 54;
            this.change_password.Text = "CHANGE PASSWORD";
            this.change_password.Tile = true;
            this.change_password.Click += new System.EventHandler(this.change_password_Click);
            // 
            // ChangePasswordPallette
            // 
            this.ChangePasswordPallette.ButtonSpecs.FormClose.Image = ((System.Drawing.Image)(resources.GetObject("ProfilePallette.ButtonSpecs.FormClose.Image")));
            this.ChangePasswordPallette.ButtonSpecs.FormMax.Image = ((System.Drawing.Image)(resources.GetObject("ProfilePallette.ButtonSpecs.FormMax.Image")));
            this.ChangePasswordPallette.ButtonSpecs.FormMin.Image = ((System.Drawing.Image)(resources.GetObject("ProfilePallette.ButtonSpecs.FormMin.Image")));
            this.ChangePasswordPallette.ButtonSpecs.FormRestore.Image = ((System.Drawing.Image)(resources.GetObject("ProfilePallette.ButtonSpecs.FormRestore.Image")));
            this.ChangePasswordPallette.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.ChangePasswordPallette.FormStyles.FormMain.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ChangePasswordPallette.FormStyles.FormMain.StateCommon.Border.ColorAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.ChangePasswordPallette.FormStyles.FormMain.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ChangePasswordPallette.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.ChangePasswordPallette.FormStyles.FormMain.StateCommon.Border.Rounding = 10;
            this.ChangePasswordPallette.FormStyles.FormMain.StateCommon.Border.Width = 0;
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(191)))));
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(191)))));
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Border.Width = 0;
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.ButtonPadding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Content.LongText.Color1 = System.Drawing.Color.White;
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Content.LongText.Font = new System.Drawing.Font("League Spartan Thin Light", 11.25F);
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Content.LongText.Prefix = ComponentFactory.Krypton.Toolkit.PaletteTextHotkeyPrefix.Hide;
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.ChangePasswordPallette.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 11.25F, System.Drawing.FontStyle.Bold);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(202)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(549, 313);
            this.Controls.Add(this.change_password);
            this.Controls.Add(this.new_password);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.new_passShow);
            this.Controls.Add(this.error_newpass);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.new_password_confirm);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.confirmpass_show);
            this.Controls.Add(this.error_newpassconfirm);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePassword";
            this.Palette = this.ChangePasswordPallette;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WANIFY";
            this.TextExtra = "Change Password";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox new_password_confirm;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Guna.UI2.WinForms.Guna2CustomCheckBox confirmpass_show;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel error_newpassconfirm;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox new_password;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Guna.UI2.WinForms.Guna2CustomCheckBox new_passShow;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel error_newpass;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Guna.UI2.WinForms.Guna2Button change_password;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette ChangePasswordPallette;
    }
}