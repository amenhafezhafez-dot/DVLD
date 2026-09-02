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
    public partial class Application_Manages : UserControl
    {
        public Application_Manages()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            List<ApplicationsType> applicationsTypes = new List<ApplicationsType>();
            applicationsTypes = clsReciveDatabase.ShowApplicationTypes();
            dataGridView1.DataSource = applicationsTypes;

            contextMenuStrip1 = new ContextMenuStrip();

            ToolStripMenuItem editPerson = new ToolStripMenuItem("✏️ Edit");


            editPerson.Click += Edit_Person_Click;



            contextMenuStrip1.Items.Add(editPerson);

            dataGridView1.ContextMenuStrip = contextMenuStrip1;

        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void Edit_Person_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int ID = Convert.ToInt32(row.Cells["ApplicationTypeID"].Value);
                Form form = new Form();
                Edit_Applications edit = new Edit_Applications(ID);

                form.Controls.Add(edit);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Row");

            }



        }
    }
}
