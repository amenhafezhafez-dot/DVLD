namespace DVLD
{
    partial class Check_User
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
            this.cardPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkremmber = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cardPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // cardPanel
            //
            this.cardPanel.Location = new System.Drawing.Point(430, 130);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(540, 630);
            this.cardPanel.Controls.Add(this.lblTitle);
            this.cardPanel.Controls.Add(this.lblSubtitle);
            this.cardPanel.Controls.Add(this.lblUser);
            this.cardPanel.Controls.Add(this.textBox1);
            this.cardPanel.Controls.Add(this.lblPass);
            this.cardPanel.Controls.Add(this.textBox2);
            this.cardPanel.Controls.Add(this.chkremmber);
            this.cardPanel.Controls.Add(this.button1);
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(45, 48);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Welcome back";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(74, 74, 78);
            this.lblSubtitle.Location = new System.Drawing.Point(47, 112);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Sign in to DVLD to continue";
            //
            // lblUser
            //
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(74, 74, 78);
            this.lblUser.Location = new System.Drawing.Point(45, 178);
            this.lblUser.Name = "lblUser";
            this.lblUser.Text = "USERNAME";
            //
            // textBox1
            //
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox1.Location = new System.Drawing.Point(45, 210);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(450, 40);
            this.textBox1.TabIndex = 1;
            //
            // lblPass
            //
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(74, 74, 78);
            this.lblPass.Location = new System.Drawing.Point(45, 285);
            this.lblPass.Name = "lblPass";
            this.lblPass.Text = "PASSWORD";
            //
            // textBox2
            //
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox2.Location = new System.Drawing.Point(45, 318);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(450, 40);
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.TabIndex = 2;
            //
            // chkremmber
            //
            this.chkremmber.AutoSize = true;
            this.chkremmber.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkremmber.Location = new System.Drawing.Point(45, 387);
            this.chkremmber.Name = "chkremmber";
            this.chkremmber.Text = "Remember me";
            this.chkremmber.TabIndex = 3;
            this.chkremmber.CheckedChanged += new System.EventHandler(this.chkremmber_CheckedChanged);
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(45, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(450, 66);
            this.button1.Text = "Sign in";
            this.button1.TabIndex = 4;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // backgroundWorker1
            //
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            //
            // Check_User
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.cardPanel);
            this.Name = "Check_User";
            this.Text = "DVLD - Sign in";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Check_User_Load);
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkremmber;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
