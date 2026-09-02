namespace DVLD
{
    partial class Start_Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDashTitle = new System.Windows.Forms.Label();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.cardApplications = new System.Windows.Forms.Panel();
            this.lblCardAppsSub = new System.Windows.Forms.Label();
            this.lblCardApps = new System.Windows.Forms.Label();
            this.btnApplications = new System.Windows.Forms.Button();
            this.cardDrivers = new System.Windows.Forms.Panel();
            this.lblCardDriversSub = new System.Windows.Forms.Label();
            this.lblCardDrivers = new System.Windows.Forms.Label();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.cardPeople = new System.Windows.Forms.Panel();
            this.lblCardPeopleSub = new System.Windows.Forms.Label();
            this.lblCardPeople = new System.Windows.Forms.Label();
            this.btnPeople = new System.Windows.Forms.Button();
            this.cardUsers = new System.Windows.Forms.Panel();
            this.lblCardUsersSub = new System.Windows.Forms.Label();
            this.lblCardUsers = new System.Windows.Forms.Label();
            this.btnUsers = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.cardApplications.SuspendLayout();
            this.cardDrivers.SuspendLayout();
            this.cardPeople.SuspendLayout();
            this.cardUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(135, 1050);
            this.pnlSidebar.TabIndex = 3;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblDashTitle);
            this.pnlHeader.Controls.Add(this.lblGreeting);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(135, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1665, 135);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblDashTitle
            // 
            this.lblDashTitle.AutoSize = true;
            this.lblDashTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblDashTitle.Location = new System.Drawing.Point(33, 63);
            this.lblDashTitle.Name = "lblDashTitle";
            this.lblDashTitle.Size = new System.Drawing.Size(551, 74);
            this.lblDashTitle.TabIndex = 0;
            this.lblDashTitle.Text = "DVLD Control panel";
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(78)))));
            this.lblGreeting.Location = new System.Drawing.Point(36, 33);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(162, 36);
            this.lblGreeting.TabIndex = 1;
            this.lblGreeting.Text = "Hello, Admin";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.cardApplications);
            this.pnlContent.Controls.Add(this.cardDrivers);
            this.pnlContent.Controls.Add(this.cardPeople);
            this.pnlContent.Controls.Add(this.cardUsers);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(135, 135);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(36);
            this.pnlContent.Size = new System.Drawing.Size(1665, 915);
            this.pnlContent.TabIndex = 1;
            // 
            // cardApplications
            // 
            this.cardApplications.Controls.Add(this.lblCardAppsSub);
            this.cardApplications.Controls.Add(this.lblCardApps);
            this.cardApplications.Controls.Add(this.btnApplications);
            this.cardApplications.Location = new System.Drawing.Point(36, 36);
            this.cardApplications.Name = "cardApplications";
            this.cardApplications.Size = new System.Drawing.Size(480, 300);
            this.cardApplications.TabIndex = 0;
            // 
            // lblCardAppsSub
            // 
            this.lblCardAppsSub.AutoSize = true;
            this.lblCardAppsSub.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCardAppsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(78)))));
            this.lblCardAppsSub.Location = new System.Drawing.Point(33, 100);
            this.lblCardAppsSub.Name = "lblCardAppsSub";
            this.lblCardAppsSub.Size = new System.Drawing.Size(333, 64);
            this.lblCardAppsSub.TabIndex = 0;
            this.lblCardAppsSub.Text = "Manage licence services, tests\r\nand detained records.";
            // 
            // lblCardApps
            // 
            this.lblCardApps.AutoSize = true;
            this.lblCardApps.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardApps.Location = new System.Drawing.Point(33, 36);
            this.lblCardApps.Name = "lblCardApps";
            this.lblCardApps.Size = new System.Drawing.Size(284, 60);
            this.lblCardApps.TabIndex = 1;
            this.lblCardApps.Text = "Applications";
            // 
            // btnApplications
            // 
            this.btnApplications.Location = new System.Drawing.Point(47, 200);
            this.btnApplications.Name = "btnApplications";
            this.btnApplications.Size = new System.Drawing.Size(270, 63);
            this.btnApplications.TabIndex = 2;
            this.btnApplications.Text = "Open";
            this.btnApplications.Click += new System.EventHandler(this.btnApplications_Click);
            this.btnApplications.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnApplications_MouseDown);
            // 
            // cardDrivers
            // 
            this.cardDrivers.Controls.Add(this.lblCardDriversSub);
            this.cardDrivers.Controls.Add(this.lblCardDrivers);
            this.cardDrivers.Controls.Add(this.btnDrivers);
            this.cardDrivers.Location = new System.Drawing.Point(540, 36);
            this.cardDrivers.Name = "cardDrivers";
            this.cardDrivers.Size = new System.Drawing.Size(480, 300);
            this.cardDrivers.TabIndex = 1;
            // 
            // lblCardDriversSub
            // 
            this.lblCardDriversSub.AutoSize = true;
            this.lblCardDriversSub.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCardDriversSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(78)))));
            this.lblCardDriversSub.Location = new System.Drawing.Point(33, 100);
            this.lblCardDriversSub.Name = "lblCardDriversSub";
            this.lblCardDriversSub.Size = new System.Drawing.Size(329, 64);
            this.lblCardDriversSub.TabIndex = 0;
            this.lblCardDriversSub.Text = "Browse driver records, licence\r\nhistory and status.";
            // 
            // lblCardDrivers
            // 
            this.lblCardDrivers.AutoSize = true;
            this.lblCardDrivers.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardDrivers.Location = new System.Drawing.Point(33, 36);
            this.lblCardDrivers.Name = "lblCardDrivers";
            this.lblCardDrivers.Size = new System.Drawing.Size(173, 60);
            this.lblCardDrivers.TabIndex = 1;
            this.lblCardDrivers.Text = "Drivers";
            // 
            // btnDrivers
            // 
            this.btnDrivers.Location = new System.Drawing.Point(33, 200);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(270, 63);
            this.btnDrivers.TabIndex = 2;
            this.btnDrivers.Text = "Open";
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            // 
            // cardPeople
            // 
            this.cardPeople.Controls.Add(this.lblCardPeopleSub);
            this.cardPeople.Controls.Add(this.lblCardPeople);
            this.cardPeople.Controls.Add(this.btnPeople);
            this.cardPeople.Location = new System.Drawing.Point(36, 360);
            this.cardPeople.Name = "cardPeople";
            this.cardPeople.Size = new System.Drawing.Size(480, 300);
            this.cardPeople.TabIndex = 2;
            // 
            // lblCardPeopleSub
            // 
            this.lblCardPeopleSub.AutoSize = true;
            this.lblCardPeopleSub.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCardPeopleSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(78)))));
            this.lblCardPeopleSub.Location = new System.Drawing.Point(33, 100);
            this.lblCardPeopleSub.Name = "lblCardPeopleSub";
            this.lblCardPeopleSub.Size = new System.Drawing.Size(295, 64);
            this.lblCardPeopleSub.TabIndex = 0;
            this.lblCardPeopleSub.Text = "Add, edit or search people\r\nregistered in the system.";
            // 
            // lblCardPeople
            // 
            this.lblCardPeople.AutoSize = true;
            this.lblCardPeople.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardPeople.Location = new System.Drawing.Point(33, 36);
            this.lblCardPeople.Name = "lblCardPeople";
            this.lblCardPeople.Size = new System.Drawing.Size(166, 60);
            this.lblCardPeople.TabIndex = 1;
            this.lblCardPeople.Text = "People";
            // 
            // btnPeople
            // 
            this.btnPeople.Location = new System.Drawing.Point(33, 200);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(270, 63);
            this.btnPeople.TabIndex = 2;
            this.btnPeople.Text = "Open";
            this.btnPeople.Click += new System.EventHandler(this.button1_Click);
            // 
            // cardUsers
            // 
            this.cardUsers.Controls.Add(this.lblCardUsersSub);
            this.cardUsers.Controls.Add(this.lblCardUsers);
            this.cardUsers.Controls.Add(this.btnUsers);
            this.cardUsers.Location = new System.Drawing.Point(540, 360);
            this.cardUsers.Name = "cardUsers";
            this.cardUsers.Size = new System.Drawing.Size(480, 300);
            this.cardUsers.TabIndex = 3;
            // 
            // lblCardUsersSub
            // 
            this.lblCardUsersSub.AutoSize = true;
            this.lblCardUsersSub.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCardUsersSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(78)))));
            this.lblCardUsersSub.Location = new System.Drawing.Point(33, 100);
            this.lblCardUsersSub.Name = "lblCardUsersSub";
            this.lblCardUsersSub.Size = new System.Drawing.Size(304, 64);
            this.lblCardUsersSub.TabIndex = 0;
            this.lblCardUsersSub.Text = "Create and manage system\r\nusers and permissions.";
            // 
            // lblCardUsers
            // 
            this.lblCardUsers.AutoSize = true;
            this.lblCardUsers.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardUsers.Location = new System.Drawing.Point(33, 36);
            this.lblCardUsers.Name = "lblCardUsers";
            this.lblCardUsers.Size = new System.Drawing.Size(137, 60);
            this.lblCardUsers.TabIndex = 1;
            this.lblCardUsers.Text = "Users";
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(33, 200);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(270, 63);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Open";
            this.btnUsers.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 37);
            // 
            // Start_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 1050);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "Start_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DVLD - Control panel";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.cardApplications.ResumeLayout(false);
            this.cardApplications.PerformLayout();
            this.cardDrivers.ResumeLayout(false);
            this.cardDrivers.PerformLayout();
            this.cardPeople.ResumeLayout(false);
            this.cardPeople.PerformLayout();
            this.cardUsers.ResumeLayout(false);
            this.cardUsers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label lblDashTitle;
        private System.Windows.Forms.Panel cardApplications;
        private System.Windows.Forms.Panel cardDrivers;
        private System.Windows.Forms.Panel cardPeople;
        private System.Windows.Forms.Panel cardUsers;
        private System.Windows.Forms.Button btnApplications;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Label lblCardApps;
        private System.Windows.Forms.Label lblCardAppsSub;
        private System.Windows.Forms.Label lblCardDrivers;
        private System.Windows.Forms.Label lblCardDriversSub;
        private System.Windows.Forms.Label lblCardPeople;
        private System.Windows.Forms.Label lblCardPeopleSub;
        private System.Windows.Forms.Label lblCardUsers;
        private System.Windows.Forms.Label lblCardUsersSub;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
