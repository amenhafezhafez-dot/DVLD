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
    public partial class IDDriver : UserControl
    {
        public IDDriver()
        {
            InitializeComponent();
        }
        int personID;
        int classType;

        public IDDriver(LocalDriving l , int classtype, int personID)
        {
            InitializeComponent();
            this.classType = classtype;
            this.personID = personID;
            Load(l);
            //InitializeComponent(); 
        }

        private void Load(LocalDriving L)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            int AppID = clsReciveDatabase.GetApplicationID(L.L_D_L_AppID);
            Applications A = clsReciveDatabase.FindApplicationByID(AppID);
            int Fees = Convert.ToInt32(A.PaidFees);

            laLDLAppID.Text = L.L_D_L_AppID.ToString();
            laCreateBy.Text = "User4";
            laClassType.Text = L.DrivingClass;
            laDate.Text = L.ApplicationDate.ToString();
            laPassesTest.Text = L.PassedRusult.ToString();
            laStatus.Text = L.Status.ToString();
            laType.Text = L.DrivingClass.ToString();
            LaID.Text = AppID.ToString();
            laFees.Text = A.PaidFees.ToString();
            laStatusDate.Text = A.LastStatusDate.ToString();
            laApplicant.Text = clsReciveDatabase.FilterByID(A.ApplicantPersonID).LastName.ToString();





        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsReciveDatabase db = new clsReciveDatabase();

            int ApplicationID = Convert.ToInt32(LaID.Text);
            int DriverId = db.FindDriverID(personID);
            int classTypeId = classType;
            DateTime issueDate = Convert.ToDateTime(laDate.Text);
            DateTime expirationDate = issueDate.AddYears(10);  // أو حسب المدة المطلوبة
            string Notes = laNotes.Text;
            decimal Fees = Convert.ToDecimal(laFees.Text);
            bool IsActive = true;
            byte IssueReason = 1;   // حسب جدولك
            int UserID = 15;


            if(DriverId ==-1)
            {
                bool added = db.AddDriver(personID, 15, DateTime.Now);
               
                 DriverId = db.FindDriverID(personID);
            }
            //-------------------------------
            bool insertLicense = db.InsertLicense(ApplicationID, DriverId, classTypeId, issueDate, expirationDate,
                                                  Notes, Fees, IsActive, IssueReason, UserID);



            if (insertLicense)
            {
                bool stutus = db.UpdateStatus(Convert.ToInt32(LaID.Text));
                MessageBox.Show("License Inserted Successfully!");
            }
            else
            {
                MessageBox.Show("Failed to Insert License!");
            }





        }
    }
}
