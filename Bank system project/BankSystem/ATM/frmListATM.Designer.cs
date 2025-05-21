namespace BankSystem.ATM
{
    partial class frmListATM
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
            this.dgvListATM = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.cmsListATM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.makeDepositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.makeWithDrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWithDraw = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnAddNewATM = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListATM)).BeginInit();
            this.cmsListATM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListATM
            // 
            this.dgvListATM.AllowUserToAddRows = false;
            this.dgvListATM.AllowUserToDeleteRows = false;
            this.dgvListATM.BackgroundColor = System.Drawing.Color.White;
            this.dgvListATM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListATM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvListATM.Location = new System.Drawing.Point(12, 411);
            this.dgvListATM.Name = "dgvListATM";
            this.dgvListATM.ReadOnly = true;
            this.dgvListATM.Size = new System.Drawing.Size(503, 181);
            this.dgvListATM.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "List ATM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 608);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "#Records :";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(143, 608);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(36, 20);
            this.lblRecords.TabIndex = 3;
            this.lblRecords.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filter By :";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "ATM ID",
            "Transaction ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(107, 360);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(133, 28);
            this.cbFilterBy.TabIndex = 7;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(246, 361);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(151, 26);
            this.txtFilterBy.TabIndex = 8;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // cmsListATM
            // 
            this.cmsListATM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeDepositToolStripMenuItem,
            this.toolStripSeparator1,
            this.makeWithDrawToolStripMenuItem});
            this.cmsListATM.Name = "cmsListATM";
            this.cmsListATM.Size = new System.Drawing.Size(175, 86);
            // 
            // makeDepositToolStripMenuItem
            // 
            this.makeDepositToolStripMenuItem.Image = global::BankSystem.Properties.Resources.Make_Deposit;
            this.makeDepositToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.makeDepositToolStripMenuItem.Name = "makeDepositToolStripMenuItem";
            this.makeDepositToolStripMenuItem.Size = new System.Drawing.Size(174, 38);
            this.makeDepositToolStripMenuItem.Text = "Make Deposit";
            this.makeDepositToolStripMenuItem.Click += new System.EventHandler(this.makeDepositToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // makeWithDrawToolStripMenuItem
            // 
            this.makeWithDrawToolStripMenuItem.Image = global::BankSystem.Properties.Resources.WithDraw;
            this.makeWithDrawToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.makeWithDrawToolStripMenuItem.Name = "makeWithDrawToolStripMenuItem";
            this.makeWithDrawToolStripMenuItem.Size = new System.Drawing.Size(174, 38);
            this.makeWithDrawToolStripMenuItem.Text = "Make WithDraw";
            this.makeWithDrawToolStripMenuItem.Click += new System.EventHandler(this.makeWithDrawToolStripMenuItem_Click);
            // 
            // btnWithDraw
            // 
            this.btnWithDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnWithDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWithDraw.FlatAppearance.BorderSize = 0;
            this.btnWithDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithDraw.Image = global::BankSystem.Properties.Resources.Eject_Green;
            this.btnWithDraw.Location = new System.Drawing.Point(432, 95);
            this.btnWithDraw.Name = "btnWithDraw";
            this.btnWithDraw.Size = new System.Drawing.Size(60, 61);
            this.btnWithDraw.TabIndex = 10;
            this.btnWithDraw.UseVisualStyleBackColor = false;
            this.btnWithDraw.Click += new System.EventHandler(this.btnWithDraw_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeposit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeposit.FlatAppearance.BorderSize = 0;
            this.btnDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeposit.Image = global::BankSystem.Properties.Resources.Menu_Green;
            this.btnDeposit.Location = new System.Drawing.Point(432, 156);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(60, 61);
            this.btnDeposit.TabIndex = 10;
            this.btnDeposit.UseVisualStyleBackColor = false;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnAddNewATM
            // 
            this.btnAddNewATM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddNewATM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewATM.FlatAppearance.BorderSize = 0;
            this.btnAddNewATM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewATM.Image = global::BankSystem.Properties.Resources.Add_ATM;
            this.btnAddNewATM.Location = new System.Drawing.Point(432, 34);
            this.btnAddNewATM.Name = "btnAddNewATM";
            this.btnAddNewATM.Size = new System.Drawing.Size(60, 61);
            this.btnAddNewATM.TabIndex = 9;
            this.btnAddNewATM.UseVisualStyleBackColor = false;
            this.btnAddNewATM.Click += new System.EventHandler(this.btnAddNewATM_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::BankSystem.Properties.Resources.Close32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(408, 608);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 38);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "      Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankSystem.Properties.Resources.Records_Number2;
            this.pictureBox2.Location = new System.Drawing.Point(12, 599);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankSystem.Properties.Resources.List_ATM;
            this.pictureBox1.Location = new System.Drawing.Point(100, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 257);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmListATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(525, 657);
            this.ContextMenuStrip = this.cmsListATM;
            this.Controls.Add(this.btnWithDraw);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnAddNewATM);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvListATM);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListATM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List ATM";
            this.Load += new System.EventHandler(this.frmListATM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListATM)).EndInit();
            this.cmsListATM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListATM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.Button btnAddNewATM;
        private System.Windows.Forms.ContextMenuStrip cmsListATM;
        private System.Windows.Forms.ToolStripMenuItem makeDepositToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeWithDrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnWithDraw;
        private System.Windows.Forms.Button btnDeposit;
    }
}