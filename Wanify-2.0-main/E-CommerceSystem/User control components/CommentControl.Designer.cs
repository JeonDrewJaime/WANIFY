namespace E_CommerceSystem.User_control_components
{
    partial class CommentControl
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
            this.userImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.rateStar = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lblName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblYou = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblComment = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            this.SuspendLayout();
            // 
            // userImage
            // 
            this.userImage.BorderRadius = 45;
            this.userImage.ImageRotate = 0F;
            this.userImage.Location = new System.Drawing.Point(21, 31);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(120, 112);
            this.userImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userImage.TabIndex = 0;
            this.userImage.TabStop = false;
            this.userImage.Click += new System.EventHandler(this.userImage_Click);
            // 
            // rateStar
            // 
            this.rateStar.Location = new System.Drawing.Point(158, 4);
            this.rateStar.Name = "rateStar";
            this.rateStar.RatingColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rateStar.ReadOnly = true;
            this.rateStar.Size = new System.Drawing.Size(201, 45);
            this.rateStar.TabIndex = 9;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(158, 78);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(145, 46);
            this.lblName.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblName.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblName.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.TabIndex = 56;
            this.lblName.Values.Text = "Name:";
            // 
            // lblYou
            // 
            this.lblYou.Location = new System.Drawing.Point(158, 51);
            this.lblYou.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblYou.Name = "lblYou";
            this.lblYou.Size = new System.Drawing.Size(78, 32);
            this.lblYou.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblYou.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblYou.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYou.TabIndex = 57;
            this.lblYou.Values.Text = "(You)";
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(158, 119);
            this.lblComment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(156, 36);
            this.lblComment.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblComment.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblComment.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.TabIndex = 58;
            this.lblComment.Values.Text = "P3500.00";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(794, 139);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(152, 32);
            this.lblDate.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblDate.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(55)))), ((int)(((byte)(176)))));
            this.lblDate.StateCommon.ShortText.Font = new System.Drawing.Font("League Spartan Thin Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.TabIndex = 59;
            this.lblDate.Values.Text = "2024-01-01";
            // 
            // CommentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblYou);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.rateStar);
            this.Controls.Add(this.userImage);
            this.Name = "CommentControl";
            this.Size = new System.Drawing.Size(968, 176);
            this.Load += new System.EventHandler(this.CommentControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox userImage;
        private Guna.UI2.WinForms.Guna2RatingStar rateStar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblYou;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblComment;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDate;
    }
}
