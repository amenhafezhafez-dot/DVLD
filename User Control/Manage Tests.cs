using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Manage_Tests : UserControl
    {
        public Manage_Tests()
        {
            InitializeComponent();
            Load();
            contextMenuStrip1 = new ContextMenuStrip();



        }

        private void Load()
        {
         

            clsReciveDatabase db = new clsReciveDatabase();
                List<TestsTypes> testsTypes = db.GetAllTests();

                if (testsTypes != null && testsTypes.Count > 0)
                {
                    dataGridView1.DataSource = testsTypes;
                }
                else
                {
                    MessageBox.Show("⚠️ No Data !");
                    dataGridView1.DataSource = null;
                }
         
                ToolStripMenuItem EditTest = new ToolStripMenuItem("Edit");

                EditTest.Click += Test_Edit_Click;
                
                contextMenuStrip1.Items.Add(EditTest);
                
                dataGridView1.ContextMenuStrip = contextMenuStrip1;






        }

        private void Test_Edit_Click(object sender , EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int ID = Convert.ToInt32(row.Cells["TestTypeID"].Value);
            Manage_Test_Type manage_Test_Type = new Manage_Test_Type(ID); 
            Form form = new Form();
            form.Size = new Size(600, 300);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Manage Test Type";
            manage_Test_Type.Dock = DockStyle.Fill;
            form.Controls.Add(manage_Test_Type);
            form.ShowDialog();


        }





    }
}
