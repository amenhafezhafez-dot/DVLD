namespace DVLD
{
    partial class People_Manage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Filter = new System.Windows.Forms.Label();
            this.Serch = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Add_Person = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Person = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_Person = new System.Windows.Forms.ToolStripMenuItem();
            this.Show_Details = new System.Windows.Forms.ToolStripMenuItem();
            this.Sent_Email = new System.Windows.Forms.ToolStripMenuItem();
            this.Make_call = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfRows = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(3, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 301);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            // 
            // Filter
            // 
            this.Filter.AutoSize = true;
            this.Filter.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Filter.Location = new System.Drawing.Point(6, 0);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(105, 27);
            this.Filter.TabIndex = 8;
            this.Filter.Text = "Filter By";
            // 
            // Serch
            // 
            this.Serch.Location = new System.Drawing.Point(287, 3);
            this.Serch.Name = "Serch";
            this.Serch.Size = new System.Drawing.Size(267, 27);
            this.Serch.TabIndex = 14;
            this.Serch.TextChanged += new System.EventHandler(this.Serch_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ID",
            "NationalNumber",
            "FirstName",
            "LastName",
            "Email",
            "all"});
            this.comboBox1.Location = new System.Drawing.Point(117, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 27);
            this.comboBox1.TabIndex = 15;
            // 
            // Add_Person
            // 
            this.Add_Person.Name = "Add_Person";
            this.Add_Person.Size = new System.Drawing.Size(240, 32);
            this.Add_Person.Text = "Add Person";
            // 
            // Edit_Person
            // 
            this.Edit_Person.Name = "Edit_Person";
            this.Edit_Person.Size = new System.Drawing.Size(240, 32);
            this.Edit_Person.Text = "Edit_Person";
            this.Edit_Person.Click += new System.EventHandler(this.Edit_Person_Click);
            // 
            // Delete_Person
            // 
            this.Delete_Person.Name = "Delete_Person";
            this.Delete_Person.Size = new System.Drawing.Size(240, 32);
            this.Delete_Person.Text = "Delete Person";
            // 
            // Show_Details
            // 
            this.Show_Details.Name = "Show_Details";
            this.Show_Details.Size = new System.Drawing.Size(240, 32);
            this.Show_Details.Text = "Show Details";
            // 
            // Sent_Email
            // 
            this.Sent_Email.Name = "Sent_Email";
            this.Sent_Email.Size = new System.Drawing.Size(240, 32);
            this.Sent_Email.Text = "Sent_Email";
            // 
            // Make_call
            // 
            this.Make_call.Name = "Make_call";
            this.Make_call.Size = new System.Drawing.Size(240, 32);
            this.Make_call.Text = "Make_call";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DVLD.Properties.Resources.add_user_color_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(560, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 47);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(722, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 39);
            this.label1.TabIndex = 16;
            this.label1.Text = "Record #";
            // 
            // NumberOfRows
            // 
            this.NumberOfRows.AutoSize = true;
            this.NumberOfRows.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfRows.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NumberOfRows.Location = new System.Drawing.Point(877, 3);
            this.NumberOfRows.Name = "NumberOfRows";
            this.NumberOfRows.Size = new System.Drawing.Size(77, 39);
            this.NumberOfRows.TabIndex = 17;
            this.NumberOfRows.Text = "????";
            // 
            // People_Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.NumberOfRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Serch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Filter);
            this.Name = "People_Manage";
            this.Size = new System.Drawing.Size(1180, 493);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Filter;
        private System.Windows.Forms.TextBox Serch;
        private System.Windows.Forms.ComboBox comboBox1;
        //private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem Add_Person;
        private System.Windows.Forms.ToolStripMenuItem Edit_Person;
        private System.Windows.Forms.ToolStripMenuItem Delete_Person;
        private System.Windows.Forms.ToolStripMenuItem Show_Details;
        private System.Windows.Forms.ToolStripMenuItem Sent_Email;
        private System.Windows.Forms.ToolStripMenuItem Make_call;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NumberOfRows;
    }
}
