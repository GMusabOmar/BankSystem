namespace BankSystem.Loan.PaymentLoan
{
    partial class frmListPaymentLoan
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
            this.dgvPaymentLoan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsPaymentLoan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updatePaymentLoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnAddNewPayment = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentLoan)).BeginInit();
            this.cmsPaymentLoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPaymentLoan
            // 
            this.dgvPaymentLoan.AllowUserToAddRows = false;
            this.dgvPaymentLoan.AllowUserToDeleteRows = false;
            this.dgvPaymentLoan.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaymentLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentLoan.Location = new System.Drawing.Point(12, 408);
            this.dgvPaymentLoan.Name = "dgvPaymentLoan";
            this.dgvPaymentLoan.ReadOnly = true;
            this.dgvPaymentLoan.Size = new System.Drawing.Size(426, 150);
            this.dgvPaymentLoan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 572);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "#Records :";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(144, 572);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(36, 20);
            this.lblRecords.TabIndex = 1;
            this.lblRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Payment Loan List";
            // 
            // cmsPaymentLoan
            // 
            this.cmsPaymentLoan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatePaymentLoanToolStripMenuItem});
            this.cmsPaymentLoan.Name = "cmsPaymentLoan";
            this.cmsPaymentLoan.Size = new System.Drawing.Size(209, 44);
            // 
            // updatePaymentLoanToolStripMenuItem
            // 
            this.updatePaymentLoanToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Update_PaymentLoan;
            this.updatePaymentLoanToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updatePaymentLoanToolStripMenuItem.Name = "updatePaymentLoanToolStripMenuItem";
            this.updatePaymentLoanToolStripMenuItem.Size = new System.Drawing.Size(208, 40);
            this.updatePaymentLoanToolStripMenuItem.Text = "Update Payment Loan";
            this.updatePaymentLoanToolStripMenuItem.Click += new System.EventHandler(this.updatePaymentLoanToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::BankSystem.Properties.Resources.Close3;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(348, 565);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Image = global::BankSystem.Properties.Resources.History;
            this.btnHistory.Location = new System.Drawing.Point(278, 336);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(77, 58);
            this.btnHistory.TabIndex = 7;
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnAddNewPayment
            // 
            this.btnAddNewPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewPayment.FlatAppearance.BorderSize = 0;
            this.btnAddNewPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPayment.Image = global::BankSystem.Properties.Resources.Add_New_Pay_Loan;
            this.btnAddNewPayment.Location = new System.Drawing.Point(361, 336);
            this.btnAddNewPayment.Name = "btnAddNewPayment";
            this.btnAddNewPayment.Size = new System.Drawing.Size(77, 58);
            this.btnAddNewPayment.TabIndex = 6;
            this.btnAddNewPayment.UseVisualStyleBackColor = true;
            this.btnAddNewPayment.Click += new System.EventHandler(this.btnAddNewPayment_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankSystem.Properties.Resources.Payment_List3;
            this.pictureBox2.Location = new System.Drawing.Point(83, -15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(284, 282);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankSystem.Properties.Resources.Records_Number2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 563);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmListPaymentLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(447, 613);
            this.ContextMenuStrip = this.cmsPaymentLoan;
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnAddNewPayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPaymentLoan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListPaymentLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmListPaymentLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentLoan)).EndInit();
            this.cmsPaymentLoan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPaymentLoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewPayment;
        private System.Windows.Forms.ContextMenuStrip cmsPaymentLoan;
        private System.Windows.Forms.ToolStripMenuItem updatePaymentLoanToolStripMenuItem;
        private System.Windows.Forms.Button btnHistory;
    }
}