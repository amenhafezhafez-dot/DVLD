namespace DVLD
{
    partial class History_Liceses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Local = new System.Windows.Forms.TabPage();
            this.laInter = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Local);
            this.tabControl1.Controls.Add(this.laInter);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1227, 179);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // Local
            // 
            this.Local.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Local.Location = new System.Drawing.Point(4, 31);
            this.Local.Name = "Local";
            this.Local.Padding = new System.Windows.Forms.Padding(3);
            this.Local.Size = new System.Drawing.Size(1219, 144);
            this.Local.TabIndex = 0;
            this.Local.Text = "Local License";
            this.Local.UseVisualStyleBackColor = true;
            //this.Local.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // laInter
            // 
            this.laInter.Location = new System.Drawing.Point(4, 31);
            this.laInter.Name = "laInter";
            this.laInter.Padding = new System.Windows.Forms.Padding(3);
            this.laInter.Size = new System.Drawing.Size(1219, 144);
            this.laInter.TabIndex = 1;
            this.laInter.Text = "InterNational License";
            this.laInter.UseVisualStyleBackColor = true;
            // 
            // History_Liceses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.tabControl1);
            this.Name = "History_Liceses";
            this.Size = new System.Drawing.Size(1254, 193);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Local;
        private System.Windows.Forms.TabPage laInter;
    }
}
