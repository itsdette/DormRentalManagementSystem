namespace DormRentalManagementSystem.Forms
{
    partial class frmAdminWindows
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.panelPaymentlSubmenu = new System.Windows.Forms.Panel();
            this.btnPaymenthistory = new System.Windows.Forms.Button();
            this.btnAcceptPayment = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnTenants = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelPaymentlSubmenu.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1734, 45);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::DormRentalManagementSystem.Properties.Resources.delete;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1675, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 42);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnPayment);
            this.panel2.Controls.Add(this.btnEmail);
            this.panel2.Controls.Add(this.panelPaymentlSubmenu);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnEmployee);
            this.panel2.Controls.Add(this.btnTenants);
            this.panel2.Controls.Add(this.btnRooms);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 1055);
            this.panel2.TabIndex = 2;
            // 
            // btnPayment
            // 
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayment.FlatAppearance.BorderSize = 0;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_payments_50;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayment.Location = new System.Drawing.Point(3, 599);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(434, 84);
            this.btnPayment.TabIndex = 6;
            this.btnPayment.Text = "Payments";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmail.FlatAppearance.BorderSize = 0;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmail.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_email_50;
            this.btnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmail.Location = new System.Drawing.Point(3, 508);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(434, 84);
            this.btnEmail.TabIndex = 8;
            this.btnEmail.Text = "Send Mails";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // panelPaymentlSubmenu
            // 
            this.panelPaymentlSubmenu.Controls.Add(this.btnPaymenthistory);
            this.panelPaymentlSubmenu.Controls.Add(this.btnAcceptPayment);
            this.panelPaymentlSubmenu.Location = new System.Drawing.Point(3, 695);
            this.panelPaymentlSubmenu.Name = "panelPaymentlSubmenu";
            this.panelPaymentlSubmenu.Size = new System.Drawing.Size(511, 196);
            this.panelPaymentlSubmenu.TabIndex = 7;
            // 
            // btnPaymenthistory
            // 
            this.btnPaymenthistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaymenthistory.FlatAppearance.BorderSize = 0;
            this.btnPaymenthistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymenthistory.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymenthistory.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_payment_history_50;
            this.btnPaymenthistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymenthistory.Location = new System.Drawing.Point(-1, 91);
            this.btnPaymenthistory.Name = "btnPaymenthistory";
            this.btnPaymenthistory.Size = new System.Drawing.Size(438, 84);
            this.btnPaymenthistory.TabIndex = 6;
            this.btnPaymenthistory.Text = "Payment History";
            this.btnPaymenthistory.UseVisualStyleBackColor = true;
            this.btnPaymenthistory.Click += new System.EventHandler(this.btnPaymenthistory_Click);
            // 
            // btnAcceptPayment
            // 
            this.btnAcceptPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceptPayment.FlatAppearance.BorderSize = 0;
            this.btnAcceptPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptPayment.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptPayment.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_accept_payment_50;
            this.btnAcceptPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcceptPayment.Location = new System.Drawing.Point(0, 1);
            this.btnAcceptPayment.Name = "btnAcceptPayment";
            this.btnAcceptPayment.Size = new System.Drawing.Size(437, 84);
            this.btnAcceptPayment.TabIndex = 5;
            this.btnAcceptPayment.Text = "Accept Payment";
            this.btnAcceptPayment.UseVisualStyleBackColor = true;
            this.btnAcceptPayment.Click += new System.EventHandler(this.btnAcceptPayment_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_logout_rounded_50;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 948);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(509, 84);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_name_tag_50;
            this.btnEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployee.Location = new System.Drawing.Point(3, 423);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(437, 84);
            this.btnEmployee.TabIndex = 4;
            this.btnEmployee.Text = "Employees";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnTenants
            // 
            this.btnTenants.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTenants.FlatAppearance.BorderSize = 0;
            this.btnTenants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTenants.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenants.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_person_at_home_50;
            this.btnTenants.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTenants.Location = new System.Drawing.Point(3, 339);
            this.btnTenants.Name = "btnTenants";
            this.btnTenants.Size = new System.Drawing.Size(437, 84);
            this.btnTenants.TabIndex = 3;
            this.btnTenants.Text = "Tenants";
            this.btnTenants.UseVisualStyleBackColor = true;
            this.btnTenants.Click += new System.EventHandler(this.btnTenants_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRooms.FlatAppearance.BorderSize = 0;
            this.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRooms.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRooms.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_room_50;
            this.btnRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRooms.Location = new System.Drawing.Point(3, 255);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(437, 84);
            this.btnRooms.TabIndex = 2;
            this.btnRooms.Text = "Rooms";
            this.btnRooms.UseVisualStyleBackColor = true;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Image = global::DormRentalManagementSystem.Properties.Resources.icons8_dashboard_50;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(3, 172);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(437, 84);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelUsername);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 153);
            this.panel3.TabIndex = 0;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Lucida Bright", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(139, 58);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(156, 32);
            this.labelUsername.TabIndex = 4;
            this.labelUsername.Text = "Username:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DormRentalManagementSystem.Properties.Resources.user__1_;
            this.pictureBox1.Location = new System.Drawing.Point(10, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(447, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1287, 1055);
            this.panel4.TabIndex = 3;
            // 
            // frmAdminWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1734, 1100);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAdminWindows";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAdminWindows_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelPaymentlSubmenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnTenants;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelPaymentlSubmenu;
        private System.Windows.Forms.Button btnPaymenthistory;
        private System.Windows.Forms.Button btnAcceptPayment;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnClose;
    }
}