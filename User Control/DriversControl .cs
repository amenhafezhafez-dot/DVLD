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
    public partial class DriversControl : UserControl
    {
        public DriversControl()
        {
            InitializeComponent();
        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            List<Drivers> drivers = new List<Drivers>();
            drivers = clsReciveDatabase.GetAllDrivers();
            dataGridView1.DataSource = drivers;

        }
    }
}
