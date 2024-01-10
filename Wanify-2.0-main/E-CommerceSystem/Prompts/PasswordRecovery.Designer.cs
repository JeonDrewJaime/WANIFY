namespace E_CommerceSystem
{
    partial class PassRecovery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassRecovery));
            this.label1 = new System.Windows.Forms.Label();
            this.user_recoveryEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.continue_btn = new Guna.UI2.WinForms.Guna2Button();
            this.required_FieldRecEmail = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.UserPallette = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.back_btn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("League Spartan Thin", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(56)))), ((int)(((byte)(142)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.label1.Location = new System.Drawing.Point(47, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 50);
            this.label1.TabIndex = 22;
            this.label1.Text = "ENTER YOUR GMAIL FOR RECOVERY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // user_recoveryEmail
            // 
            this.user_recoveryEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.user_recoveryEmail.Location = new System.Drawing.Point(147, 64);
            this.user_recoveryEmail.MaxLength = 255;
            this.user_recoveryEmail.Name = "user_recoveryEmail";
            this.user_recoveryEmail.Size = new System.Drawing.Size(342, 34);
            this.user_recoveryEmail.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.user_recoveryEmail.StateCommon.Border.Rounding = 5;
            this.user_recoveryEmail.StateCommon.Border.Width = 1;
            this.user_recoveryEmail.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.user_recoveryEmail.StateCommon.Content.Font = new System.Drawing.Font("Manrope Light", 9.75F);
            this.user_recoveryEmail.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.user_recoveryEmail.TabIndex = 23;
            this.user_recoveryEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.user_recoveryEmail.TextChanged += new System.EventHandler(this.user_recoveryEmail_TextChanged);
            // 
            // continue_btn
            // 
            this.continue_btn.Animated = true;
            this.continue_btn.BorderRadius = 5;
            this.continue_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continue_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.continue_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.continue_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.continue_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.continue_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.continue_btn.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.continue_btn.ForeColor = System.Drawing.Color.White;
            this.continue_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.continue_btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.continue_btn.Location = new System.Drawing.Point(193, 131);
            this.continue_btn.Name = "continue_btn";
            this.continue_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.continue_btn.Size = new System.Drawing.Size(256, 45);
            this.continue_btn.TabIndex = 24;
            this.continue_btn.Text = "CONTINUE";
            this.continue_btn.Tile = true;
            this.continue_btn.Click += new System.EventHandler(this.continue_btn_Click);
            // 
            // required_FieldRecEmail
            // 
            this.required_FieldRecEmail.Location = new System.Drawing.Point(278, 104);
            this.required_FieldRecEmail.Name = "required_FieldRecEmail";
            this.required_FieldRecEmail.Size = new System.Drawing.Size(83, 18);
            this.required_FieldRecEmail.StateCommon.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.required_FieldRecEmail.StateCommon.ShortText.Font = new System.Drawing.Font("Nexa Light", 8.249999F);
            this.required_FieldRecEmail.TabIndex = 53;
            this.required_FieldRecEmail.Values.Text = "Required field";
            // 
            // UserPallette
            // 
            this.UserPallette.ButtonSpecs.FormClose.Image = ((System.Drawing.Image)(resources.GetObject("UserPallette.ButtonSpecs.FormClose.Image")));
            this.UserPallette.ButtonSpecs.FormMax.Image = ((System.Drawing.Image)(resources.GetObject("UserPallette.ButtonSpecs.FormMax.Image")));
            this.UserPallette.ButtonSpecs.FormMin.Image = ((System.Drawing.Image)(resources.GetObject("UserPallette.ButtonSpecs.FormMin.Image")));
            this.UserPallette.FormStyles.FormCommon.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.UserPallette.FormStyles.FormCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserPallette.FormStyles.FormCommon.StateCommon.Border.Width = 0;
            this.UserPallette.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(191)))));
            this.UserPallette.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(191)))));
            this.UserPallette.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserPallette.FormStyles.FormMain.StateCommon.Border.Width = 0;
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(191)))));
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(191)))));
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Border.Width = 0;
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.ButtonPadding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Content.LongText.Color1 = System.Drawing.Color.White;
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Content.LongText.Font = new System.Drawing.Font("League Spartan Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.UserPallette.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // back_btn
            // 
            this.back_btn.Animated = true;
            this.back_btn.BorderRadius = 5;
            this.back_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.back_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.back_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.back_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.back_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(122)))), ((int)(((byte)(202)))));
            this.back_btn.Font = new System.Drawing.Font("League Spartan Thin", 15.75F, System.Drawing.FontStyle.Bold);
            this.back_btn.ForeColor = System.Drawing.Color.White;
            this.back_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(95)))), ((int)(((byte)(192)))));
            this.back_btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.back_btn.Location = new System.Drawing.Point(15, 131);
            this.back_btn.Name = "back_btn";
            this.back_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.back_btn.Size = new System.Drawing.Size(46, 45);
            this.back_btn.TabIndex = 55;
            this.back_btn.Text = "<";
            this.back_btn.Tile = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click_1);
            // 
            // PassRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(202)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(638, 201);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.required_FieldRecEmail);
            this.Controls.Add(this.continue_btn);
            this.Controls.Add(this.user_recoveryEmail);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PassRecovery";
            this.Palette = this.UserPallette;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.Text = "WANIFY";
            this.TextExtra = "Forgot Password";
            this.Load += new System.EventHandler(this.PassRecovery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox user_recoveryEmail;
        private Guna.UI2.WinForms.Guna2Button continue_btn;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel required_FieldRecEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette UserPallette;
        private Guna.UI2.WinForms.Guna2Button back_btn;
    }
}