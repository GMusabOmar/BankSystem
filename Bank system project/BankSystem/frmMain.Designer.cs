namespace BankSystem
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BankSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BankerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.UsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ATMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentLoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreditCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMoneyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LockOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BankSystemToolStripMenuItem,
            this.ATMToolStripMenuItem,
            this.LoanToolStripMenuItem,
            this.paymentLoanToolStripMenuItem,
            this.TransactionToolStripMenuItem,
            this.CreditCardToolStripMenuItem,
            this.sendMoneyToolStripMenuItem,
            this.LockOutToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1239, 60);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "msBankSystem";
            this.menuStrip1.MouseLeave += new System.EventHandler(this.menuStrip1_MouseLeave);
            this.menuStrip1.MouseHover += new System.EventHandler(this.menuStrip1_MouseHover);
            // 
            // BankSystemToolStripMenuItem
            // 
            this.BankSystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BankerToolStripMenuItem,
            this.BranchToolStripMenuItem,
            this.toolStripSeparator1,
            this.PersonToolStripMenuItem});
            this.BankSystemToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankSystemToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Settings2;
            this.BankSystemToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BankSystemToolStripMenuItem.Name = "BankSystemToolStripMenuItem";
            this.BankSystemToolStripMenuItem.Size = new System.Drawing.Size(198, 56);
            this.BankSystemToolStripMenuItem.Text = "Bank Manager";
            // 
            // BankerToolStripMenuItem
            // 
            this.BankerToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Banker;
            this.BankerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BankerToolStripMenuItem.Name = "BankerToolStripMenuItem";
            this.BankerToolStripMenuItem.Size = new System.Drawing.Size(185, 58);
            this.BankerToolStripMenuItem.Text = "Banker";
            this.BankerToolStripMenuItem.Click += new System.EventHandler(this.BankerToolStripMenuItem_Click);
            // 
            // BranchToolStripMenuItem
            // 
            this.BranchToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Branch;
            this.BranchToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BranchToolStripMenuItem.Name = "BranchToolStripMenuItem";
            this.BranchToolStripMenuItem.Size = new System.Drawing.Size(185, 58);
            this.BranchToolStripMenuItem.Text = "Branch";
            this.BranchToolStripMenuItem.Click += new System.EventHandler(this.BranchToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // PersonToolStripMenuItem
            // 
            this.PersonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomersToolStripMenuItem,
            this.AccountToolStripMenuItem,
            this.toolStripSeparator2,
            this.UsersToolStripMenuItem,
            this.toolStripSeparator3,
            this.QueryPersonToolStripMenuItem});
            this.PersonToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Person;
            this.PersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PersonToolStripMenuItem.Name = "PersonToolStripMenuItem";
            this.PersonToolStripMenuItem.Size = new System.Drawing.Size(185, 58);
            this.PersonToolStripMenuItem.Text = "Persons";
            // 
            // CustomersToolStripMenuItem
            // 
            this.CustomersToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Customer;
            this.CustomersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CustomersToolStripMenuItem.Name = "CustomersToolStripMenuItem";
            this.CustomersToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.CustomersToolStripMenuItem.Text = "Customers";
            this.CustomersToolStripMenuItem.Click += new System.EventHandler(this.CustomersToolStripMenuItem_Click);
            // 
            // AccountToolStripMenuItem
            // 
            this.AccountToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Manager;
            this.AccountToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AccountToolStripMenuItem.Name = "AccountToolStripMenuItem";
            this.AccountToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.AccountToolStripMenuItem.Text = "Account Customers";
            this.AccountToolStripMenuItem.Click += new System.EventHandler(this.AccountToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(260, 6);
            // 
            // UsersToolStripMenuItem
            // 
            this.UsersToolStripMenuItem.Image = global::BankSystem.Properties.Resources.User;
            this.UsersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem";
            this.UsersToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.UsersToolStripMenuItem.Text = "Users";
            this.UsersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(260, 6);
            // 
            // QueryPersonToolStripMenuItem
            // 
            this.QueryPersonToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Query;
            this.QueryPersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.QueryPersonToolStripMenuItem.Name = "QueryPersonToolStripMenuItem";
            this.QueryPersonToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.QueryPersonToolStripMenuItem.Text = "Query Person";
            this.QueryPersonToolStripMenuItem.Click += new System.EventHandler(this.QueryPersonToolStripMenuItem_Click);
            // 
            // ATMToolStripMenuItem
            // 
            this.ATMToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ATMToolStripMenuItem.Image = global::BankSystem.Properties.Resources.ATM2;
            this.ATMToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ATMToolStripMenuItem.Name = "ATMToolStripMenuItem";
            this.ATMToolStripMenuItem.Size = new System.Drawing.Size(114, 56);
            this.ATMToolStripMenuItem.Text = "ATM";
            this.ATMToolStripMenuItem.Click += new System.EventHandler(this.ATMToolStripMenuItem_Click);
            // 
            // LoanToolStripMenuItem
            // 
            this.LoanToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Loan2;
            this.LoanToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoanToolStripMenuItem.Name = "LoanToolStripMenuItem";
            this.LoanToolStripMenuItem.Size = new System.Drawing.Size(97, 56);
            this.LoanToolStripMenuItem.Text = "Loan";
            this.LoanToolStripMenuItem.Click += new System.EventHandler(this.LoanToolStripMenuItem_Click);
            // 
            // paymentLoanToolStripMenuItem
            // 
            this.paymentLoanToolStripMenuItem.Image = global::BankSystem.Properties.Resources.PaymentLoan;
            this.paymentLoanToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.paymentLoanToolStripMenuItem.Name = "paymentLoanToolStripMenuItem";
            this.paymentLoanToolStripMenuItem.Size = new System.Drawing.Size(145, 56);
            this.paymentLoanToolStripMenuItem.Text = "Payment Loan";
            this.paymentLoanToolStripMenuItem.Click += new System.EventHandler(this.paymentLoanToolStripMenuItem_Click);
            // 
            // TransactionToolStripMenuItem
            // 
            this.TransactionToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Transaction2;
            this.TransactionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem";
            this.TransactionToolStripMenuItem.Size = new System.Drawing.Size(131, 56);
            this.TransactionToolStripMenuItem.Text = "Transaction";
            this.TransactionToolStripMenuItem.Click += new System.EventHandler(this.TransactionToolStripMenuItem_Click);
            // 
            // CreditCardToolStripMenuItem
            // 
            this.CreditCardToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Credit_Card;
            this.CreditCardToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CreditCardToolStripMenuItem.Name = "CreditCardToolStripMenuItem";
            this.CreditCardToolStripMenuItem.Size = new System.Drawing.Size(131, 56);
            this.CreditCardToolStripMenuItem.Text = "Credit Card";
            this.CreditCardToolStripMenuItem.Click += new System.EventHandler(this.CreditCardToolStripMenuItem_Click);
            // 
            // sendMoneyToolStripMenuItem
            // 
            this.sendMoneyToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Send_Money;
            this.sendMoneyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendMoneyToolStripMenuItem.Name = "sendMoneyToolStripMenuItem";
            this.sendMoneyToolStripMenuItem.Size = new System.Drawing.Size(137, 56);
            this.sendMoneyToolStripMenuItem.Text = "Send Money";
            this.sendMoneyToolStripMenuItem.Click += new System.EventHandler(this.sendMoneyToolStripMenuItem_Click);
            // 
            // LockOutToolStripMenuItem
            // 
            this.LockOutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUserInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.changePasswordToolStripMenuItem});
            this.LockOutToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Profile2;
            this.LockOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LockOutToolStripMenuItem.Name = "LockOutToolStripMenuItem";
            this.LockOutToolStripMenuItem.Size = new System.Drawing.Size(105, 56);
            this.LockOutToolStripMenuItem.Text = "Profile";
            // 
            // showUserInfoToolStripMenuItem
            // 
            this.showUserInfoToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Show_User_Info;
            this.showUserInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showUserInfoToolStripMenuItem.Name = "showUserInfoToolStripMenuItem";
            this.showUserInfoToolStripMenuItem.Size = new System.Drawing.Size(199, 42);
            this.showUserInfoToolStripMenuItem.Text = "Show User Info";
            this.showUserInfoToolStripMenuItem.Click += new System.EventHandler(this.showUserInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 6);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Rename_Password;
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(199, 42);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Sign_Out;
            this.signOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(117, 56);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BankSystem.Properties.Resources.Full_Bank;
            this.pictureBox1.Location = new System.Drawing.Point(0, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1239, 390);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1239, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BankSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ATMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TransactionToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem CreditCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LockOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BankerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BranchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem AccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem QueryPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMoneyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentLoanToolStripMenuItem;
    }
}

