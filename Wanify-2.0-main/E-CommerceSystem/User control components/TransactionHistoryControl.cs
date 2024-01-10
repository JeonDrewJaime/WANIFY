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
    public partial class TransactionHistoryControl : UserControl
    {
        public TransactionHistoryControl()
        {
            InitializeComponent();
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TransactionHistoryControl_Load(object sender, EventArgs e)
        {

        }

        #region

        public int _Amount;
        public bool _isGain;
        public string _Date, _ProductID;

        [Category("Custom Props")]
        public int Amount { get { return _Amount; } set { _Amount = value; lblPositiveAmount.Text = value.ToString(); lblAmountNegative.Text = value.ToString(); } }


        [Category("Custom Props")]
        public bool Gain
        {
            get { return _isGain; }
            set
            {
                _isGain = value; lblPositiveSign.Visible = _isGain;
                lblPositiveAmount.Visible = _isGain; lblNegativeSign.Visible = !_isGain; lblAmountNegative.Visible = !_isGain;
            }
        }

        [Category("Custom Props")]
        public string ID { get { return _ProductID; } set { _ProductID = value; lblProductID.Text = value; } }

        [Category("Custom Props")]
        public string Date { get { return _Date; } set { _Date = value; lblDate.Text = value; } }
        #endregion

    }
}
