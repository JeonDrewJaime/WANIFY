using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_CommerceSystem.User_control_components
{
    public partial class CommentControl : UserControl
    {
        public CommentControl()
        {
            InitializeComponent();
        }

        private void CommentControl_Load(object sender, EventArgs e)
        {

        }

        #region
        public string _Name;
        public Image _Photo;
        public string _Date;
        public string _Comment;
        public float _Rate;
        public bool _isPriority;

        [Category("Custom Props")]
        public string Name { get { return _Name; } set { _Name = value; lblName.Text = value; } }

        [Category("Custom Props")]
        public string Date { get { return _Date; } set { _Date = value; lblDate.Text = value; } }

        [Category("Custom Props")]
        public string Comment { get { return _Comment; } set { _Comment = value; lblComment.Text = value; } }

        [Category("Custom Props")]
        public float Rate { get { return _Rate; } set { _Rate = value; rateStar.Value = value; } }

        [Category("Custom Props")]
        public Image Icon { get { return _Photo; } set { _Photo = value; userImage.Image = value; } }

        [Category("Custom Props")]
        public bool IsPriority { get { return _isPriority; } set { _isPriority = value; lblYou.Visible = _isPriority; } }

        #endregion

        private void userImage_Click(object sender, EventArgs e)
        {

        }
    }
}
