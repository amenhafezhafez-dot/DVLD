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
    public partial class History_Liceses : UserControl
    {
        public History_Liceses()
        {
            InitializeComponent();
        }

        public History_Liceses(int DriverID)
        {
            InitializeComponent();
            ShowInternationalLicenseInTab(DriverID);
        }

        public void ShowInternationalLicenseInTab(int ID)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            List<Licenses> localLicenses = clsReciveDatabase.FindLicensesByDriverID(ID);
            List<InternationalLicense> internationalLicenses = clsReciveDatabase.GetInternationalLicenseByDriverID(ID);

            // إنشاء DataGridView للرخص المحلية
            DataGridView dgvLocal = new DataGridView();
            dgvLocal.Dock = DockStyle.Fill;
            dgvLocal.ReadOnly = true;
            dgvLocal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocal.DataSource = localLicenses; // تعبئة البيانات

            // إنشاء DataGridView للرخص الدولية
            DataGridView dgvInternational = new DataGridView();
            dgvInternational.Dock = DockStyle.Fill;
            dgvInternational.ReadOnly = true;
            dgvInternational.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInternational.DataSource = internationalLicenses; // تعبئة البيانات

            // مسح أي عناصر سابقة (حتى ما تتكرر)
            Local.Controls.Clear();
            laInter.Controls.Clear();

            Local.Controls.Add(dgvLocal);
            laInter.Controls.Add(dgvInternational);
        }

    }
}
