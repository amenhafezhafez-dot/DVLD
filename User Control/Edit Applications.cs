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
    public partial class Edit_Applications : UserControl
    {
        private int ID;
        public Edit_Applications()
        {
            InitializeComponent();
        }

        public Edit_Applications(int id)
        {
            InitializeComponent();
            ID = id;
            SetData();
            
        }

        private void SetData()
        {
            ApplicationsType applications = new ApplicationsType();
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            applications = clsReciveDatabase.Select(ID);
           
            laID.Text = applications.ApplicationTypeID.ToString();
            tbTitle.Text = applications.ApplicationTypeTitle.ToString();
            tbFees.Text = applications.ApplicationFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
      
            if (string.IsNullOrWhiteSpace(tbTitle.Text) || string.IsNullOrWhiteSpace(tbFees.Text))
            {
                MessageBox.Show("⚠️ Fill the all boxes ");
                return;
            }

            ApplicationsType updatedType = new ApplicationsType
            {
                ApplicationTypeID = ID,
                ApplicationTypeTitle = tbTitle.Text.Trim(),
                ApplicationFees = tbFees.Text.Trim()
            };

            clsReciveDatabase db = new clsReciveDatabase();
            bool success = db.UpdateApplicationType(updatedType);

            if (success)
            {
                MessageBox.Show("✅ تم حفظ التعديلات بنجاح.");
               
            }
            else
            {
                MessageBox.Show("❌ حدث خطأ أثناء حفظ التعديلات.");
            }
        }
        

        private void btnClose_Click(object sender, EventArgs e)
        { 
        }
    }
}
