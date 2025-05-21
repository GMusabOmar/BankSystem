using System;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Persons.Customers.Controls
{
    public partial class ctrlCustomersInfoWithFilter : UserControl
    {
        public event Action<int> OnCustomerSelected;
        private int _CustomerID = -1;
        private clsCustomer _CustomerInfo;
        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get
            {
                return _FilterEnable;
            }
            set
            {
                _FilterEnable = value;
                gbFilter.Enabled = _FilterEnable;
            }
        }
        public ctrlCustomersInfoWithFilter()
        {
            InitializeComponent();
        }
        public void RestDefaultValues()
        {
            lblCustomerID.Text = "???";
            _CustomerID = -1;
            ctrlPersonInfo1.ResetDefaultValues();
        }
        public void LoadData(int CustomerID)
        {
            _CustomerInfo = clsCustomer.FindCustomerByID(CustomerID);
            if(_CustomerInfo == null)
            {
                MessageBox.Show($"Not found customer with id = {CustomerID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                RestDefaultValues();
                return;
            }
            txtFilterby.Text = CustomerID.ToString();
            _CustomerID = CustomerID;
            lblCustomerID.Text = _CustomerID.ToString();
            ctrlPersonInfo1.LoadPersonInfo(_CustomerInfo.PersonID);
            if (OnCustomerSelected != null)
                OnCustomerSelected?.Invoke(_CustomerID);
        }
        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterby.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterby, "This filed must be not null");
            }
            else
                errorProvider1.SetError(txtFilterby, null);
        }
        public void FilterFocus()
        {
            txtFilterby.Focus();
        }
        private void txtFilterby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            int CustomerID = int.Parse(txtFilterby.Text.Trim());
            LoadData(CustomerID);
        }
    }
}
