using System;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Persons
{
    public partial class frmAddUpdatePerson : Form
    {
        public enum enTypeMode { Add = 0, Update = 1 }
        private enTypeMode _Mode;
        private clsPeron _Person;
        private int _PersonId;
        public Action<int> OnPersonSelected;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enTypeMode.Add;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enTypeMode.Update;
            _PersonId = PersonID;
        }
        private void _RestDevaultValues()
        {
            _Person = new clsPeron();
            lblTitle.Text = "Add New Person";
            this.Text = "Add New Person";
            lblPersonID.Text = "N/A";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }
        private void _LoadPersonData()
        {
            lblTitle.Text = "Update Person Info";
            this.Text = "Update Person Info";
            _Person = clsPeron.FindPerson(_PersonId);
            if(_Person == null)
            {
                MessageBox.Show("Error", $"This person not found with id = {_PersonId}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblPersonID.Text = _PersonId.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _RestDevaultValues();
            if (_Mode == enTypeMode.Update)
                _LoadPersonData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Put the mouse on red flag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            if(_Person.Save())
            {
                lblTitle.Text = "Update Person Info";
                this.Text = "Update Person Info";
                _PersonId = _Person.PersonID;
                lblPersonID.Text = _PersonId.ToString();
                btnSave.Enabled = false;
                MessageBox.Show("Done successfuly :-)", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(OnPersonSelected != null)
                    OnPersonSelected?.Invoke(_PersonId);
                return;
            }
            else
                MessageBox.Show("Error not save :-(", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void CheckValidatingTextBox(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if(string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required");
            }
            else
                errorProvider1.SetError(Temp, null);
        }
        private void CheckValidatingPhoneNumber(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Phone should be only numbers");
            }
            else
                errorProvider1.SetError(txtPhone, null);
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
