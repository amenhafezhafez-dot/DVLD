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

    /*
     GetLicenseByApplicationID
    */
    public partial class Show_Driving_License : UserControl
    {
        //int ID2 = -1;
        public Show_Driving_License(int AppID , string NationlNo )
        {
            InitializeComponent();
            //b= B;
            Load(AppID , NationlNo);
        }

        public Show_Driving_License(string N , int LicenseID)
        {
            InitializeComponent();
            //ID2 = LicenseID;
            Load2(LicenseID , N );
        }





        private void Load2(int ID , string N)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();

            Person P = clsReciveDatabase.FilterByNationalNumber(N);

            String FullName = P.FirstName + P.ThirdName + P.SecondName + P.LastName;
            DateTime dateTime = P.DateOfBirth;
            String Gendor = P.Gender;

            Licenses L = clsReciveDatabase.FindLicenseByLicenseID(ID);
            //MessageBox.Show($"{AppID}");

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

            //DetainedLicense Detainedornot = clsReciveDatabase.FindDetainedLicenseByID(ID);
            //bool answerd = !Detainedornot.IsReleased;

            DetainedLicense Detainedornot = clsReciveDatabase.FindDetainedLicenseByID(ID);
            if (Detainedornot == null)
                laIsDetained.Text = "False";
            else
                laIsDetained.Text = (!Detainedornot.IsReleased).ToString();

            //laIsDetained.Text = answerd.ToString();

        }

        private void Load(int App, string N)
        { 
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            
            Person P  = clsReciveDatabase.FilterByNationalNumber(N);

            String FullName = P.FirstName  + P.ThirdName  + P.SecondName + P.LastName;
            DateTime dateTime = P.DateOfBirth;
            String Gendor = P.Gender;


            int AppID = clsReciveDatabase.GetApplicationIdfromLDLID(App);
            Licenses L = clsReciveDatabase.GetLicenseByApplicationID(AppID);
      

            laclassType.Text = L.LicenseClass.ToString();
            laName.Text = FullName ;
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
            laDOB.Text = dateTime.ToString() ;
            laDriverID.Text = L.DriverID.ToString();
            laExpirationDate.Text = L.ExpirationDate.ToString();
            //DetainedLicense Detainedornot = clsReciveDatabase.FindDetainedLicenseByID(L.LicenseID);
            //bool answerd = !Detainedornot.IsReleased;

            DetainedLicense Detainedornot = clsReciveDatabase.FindDetainedLicenseByID(L.LicenseID);
            if (Detainedornot == null)
                laIsDetained.Text = "False";
            else
                laIsDetained.Text = (!Detainedornot.IsReleased).ToString();
            //laIsDetained.Text = answerd.ToString();

        }
    }
}
