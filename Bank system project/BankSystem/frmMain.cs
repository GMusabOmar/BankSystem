using System;
using System.Windows.Forms;
using BankSystem.ATM;
using BankSystem.Bank;
using BankSystem.Bank.Branch;
using BankSystem.CreditCard;
using BankSystem.Global_Class;
using BankSystem.Loan;
using BankSystem.Loan.PaymentLoan;
using BankSystem.Login;
using BankSystem.Persons.Customers;
using BankSystem.Persons.Customers.Accounts;
using BankSystem.Persons.Users;
using BankSystem.SendMoneies;
using BankSystem.Transactions;

namespace BankSystem
{
    public partial class frmMain : Form
    {
        private frmLogin _Login;
        public frmMain(frmLogin Login)
        {
            InitializeComponent();
            _Login = Login;
        }

        private void QueryPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPerson frm = new frmListPerson();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _Login.Show();
            this.Close();
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCustomers frm = new frmListCustomers();
            frm.ShowDialog();
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUser frm = new frmListUser();
            frm.ShowDialog();
        }

        private void AccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAccount frm = new frmListAccount();
            frm.ShowDialog();
        }

        private void BranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListBranch frm = new frmListBranch();
            frm.ShowDialog();
        }

        private void BankerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListBanker frm = new frmListBanker();
            frm.ShowDialog();
        }

        private void ATMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListATM frm = new frmListATM();
            frm.ShowDialog();
        }

        private void TransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTransaction frm = new frmListTransaction();
            frm.ShowDialog();
        }

        private void CreditCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCreditCard frm = new frmListCreditCard();
            frm.ShowDialog();
        }

        private void LoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLoan frm = new frmListLoan();
            frm.ShowDialog();
        }

        private void paymentLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPaymentLoan frm = new frmListPaymentLoan();
            frm.ShowDialog();
        }

        private void sendMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListSendMoneies frm = new frmListSendMoneies();
            frm.ShowDialog();
        }

        private void showUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }
    }
}
