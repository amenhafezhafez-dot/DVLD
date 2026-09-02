namespace YourNamespace
{
    partial class ShowLDLControl
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Serch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Filter = new System.Windows.Forms.Label();
            this.btnSerch = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1143, 320);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "FullName",
            "Status",
            "PassedRusult",
            "ApplicationDate",
            "ApplicationID"});
            this.comboBox1.Location = new System.Drawing.Point(123, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 27);
            this.comboBox1.TabIndex = 19;
            // 
            // Serch
            // 
            this.Serch.Location = new System.Drawing.Point(293, 24);
            this.Serch.Name = "Serch";
            this.Serch.Size = new System.Drawing.Size(267, 27);
            this.Serch.TabIndex = 18;
            this.Serch.TextChanged += new System.EventHandler(this.Serch_TextChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DVLD.Properties.Resources.add_user_color_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(905, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 36);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Filter
            // 
            this.Filter.AutoSize = true;
            this.Filter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Filter.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Filter.Location = new System.Drawing.Point(11, 24);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(105, 27);
            this.Filter.TabIndex = 16;
            this.Filter.Text = "Filter By";
            // 
            // btnSerch
            // 
            this.btnSerch.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerch.ForeColor = System.Drawing.Color.Black;
            this.btnSerch.Location = new System.Drawing.Point(815, 15);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(83, 64);
            this.btnSerch.TabIndex = 20;
            this.btnSerch.Text = "Serch";
            this.btnSerch.UseVisualStyleBackColor = true;
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // ShowLDLControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.btnSerch);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Serch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ShowLDLControl";
            this.Size = new System.Drawing.Size(1183, 476);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox Serch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Filter;
        private System.Windows.Forms.Button btnSerch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}
