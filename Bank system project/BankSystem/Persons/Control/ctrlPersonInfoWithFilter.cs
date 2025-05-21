using System;
using System.Windows.Forms;
using EventViewr;

namespace BankSystem.Persons.Control
{
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        private int _PersonID = -1;
        public event Action<int> OnPersonSelectedFromFilter2;
        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get
            {
                return _FilterEnable;
            }
            set
            {
                gbFilter.Enabled = value;
                _FilterEnable = gbFilter.Enabled;
            }
        }
        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }
        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }
        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            ctrlPersonInfo1.ResetDefaultValues();
            txtFilterBy.Focus();
        }
        public void FilterFocus()
        {
            txtFilterBy.Focus();
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtFilterBy_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterBy.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterBy, "This field must be not null");
            }
            else
                errorProvider1.SetError(txtFilterBy, null);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            _PersonID = int.Parse(txtFilterBy.Text.Trim());
            if (_PersonID < 0)
            {
                MessageBox.Show("Error not found person!");
                clsEventLog error = clsEventLog.SetEvent("ctrlPersonInfoWithFilter", "Person id must be bigger then zero!");
                return;
            }
            LoadData(_PersonID);
        }
        public void LoadData(int PersonID)
        {
            txtFilterBy.Clear();
            txtFilterBy.Text = PersonID.ToString();
            ctrlPersonInfo1.LoadPersonInfo(PersonID);
            if (OnPersonSelectedFromFilter2 != null)
                OnPersonSelectedFromFilter2(PersonID);
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnPersonSelected = LoadData;
            frm.ShowDialog();
        }
    }
}
