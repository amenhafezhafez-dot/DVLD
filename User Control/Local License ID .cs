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
    public partial class Local_License_ID : UserControl
    {
        public Local_License_ID()
        {
            InitializeComponent();
        }

        public Local_License_ID(InternationalLicense L , Person P )
        {
            InitializeComponent();
            Load(L , P);
        }

        private void Load(InternationalLicense L , Person P)
        {
            laName.Text = $"{P.FirstName} {P.SecondName} {P.ThirdName} {P.LastName}"; laIntLicenseId.Text = L.InternationalLicenseID.ToString();
            laID.Text = L.IssuedUsingLocalLicenseID.ToString() ;
            laNationalNumber.Text = P.NationalNo;
            laGendor.Text  =  P.Gender;
            laIssueDate.Text = L.IssueDate.ToString() ;
            A.Text = L.ApplicationID.ToString();
            laIsActive.Text = L.IsActive.ToString()  ;
            laDOB.Text = P.DateOfBirth.ToString() ;
            laDriverID.Text = L.DriverID.ToString() ;
            laExpirationDate.Text = L.ExpirationDate.ToString() ;

            
            
        }

    }
}
