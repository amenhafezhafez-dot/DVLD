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
    public partial class Filter_License : UserControl
    {
        public Filter_License()
        {
            InitializeComponent();
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            int ID = Convert.ToInt32(tbSerch.Text) ;
            Licenses L = clsReciveDatabase.FindLicenseByLicenseID(ID);
            int DriverID = L.DriverID;
            MessageBox.Show($"{DriverID}");
            Person P = clsReciveDatabase.FindPersonFromDriverID(DriverID);

            if (P == null)
            {
                MessageBox.Show("NULL");
            }

            String FullName = P.FirstName + P.ThirdName + P.SecondName + P.LastName;
            DateTime dateTime = P.DateOfBirth;
            String Gendor = P.Gender;
            string N = P.NationalNo;

            MessageBox.Show($"{FullName}", $"{N}");

            laclassType.Text = L.LicenseClass.ToString();
            laName.Text = FullName;
            laID.Text = L.LicenseID.ToString();
            laNationalNumber.Text = N;
            laGendor.Text = Gendor;
            laIssueReason.Text = L.IssueReason.ToString();
            laIssueDate.Text = L.IssueDate.ToString();
            if (L.Notes == null)
            {
                laNot.Text = "No Notes";
            }
            else
            {
                laNot.Text = L.Notes.ToString();
            }
            laIsActive.Text = L.IsActive.ToString();
            laDOB.Text = dateTime.ToString();
            laDriverID.Text = L.DriverID.ToString();
            laExpirationDate.Text = L.ExpirationDate.ToString();
            laIsDetained.Text = "YES";
        }
    }
}
