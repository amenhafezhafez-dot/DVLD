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
    public partial class Add_Inter_License : UserControl
    {

        bool Renew = false , Damage=false , Lost= false , Detainted=false , Relased = false;
        Person P1 = new Person();
        InternationalLicense L1 = new InternationalLicense();


        public Add_Inter_License(int i=1)
        {
            InitializeComponent();
            LinkedLocalID.Enabled = false;
            if (i == 2)
            {
                label9.Text = "Old Local License ID : ";
                label2.Text = "R.L.Application ID : ";
                label10.Text = "Renew Local License ID: ";
                Renew = true;
            }
            else if (i == 3)
            {
                label9.Text = "Old Local License ID : ";
                label2.Text = "R.L.Application ID : ";
                label10.Text = "Replace Local License ID: ";
                Damage = true;
            }
            else if (i == 4)
            {
                label9.Text = "Old Local License ID : ";
                label2.Text = "R.L.Application ID : ";
                label10.Text = "Replace Local License ID: ";
                Lost = true;
            }
            else if (i == 5)
            {
                label10.Text  = "License ID : ";
                label2.Text  = "Detaint ID : ";
                label6.Text = "Detainted Date : ";

                label5.Visible = false;
                laDateIssue.Visible = false;

                label8.Visible = false;
                laDateExp.Visible = false;

                label9.Visible = false;
                laLocalLicense.Visible = false;

                tbFees.Visible = true;
                groupBox1.Text = "Detained Info ";

                Detainted = true;

            }
            else if (i==6)
            {
                label10.Text = "License ID : ";
                label2.Text = "Detaint ID : ";
                label6.Text = "Detainted Date : ";
                label4.Text = "Application Fees";
                label9.Text = "Fees";
                label5.Text = "Total Fees ";
                label8.Text = "Application ID";
                Relased = true;
            }
        }

        private void tbFees_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();

            if (!int.TryParse(tbSerch.Text, out _))
            {
                MessageBox.Show("خطأ في صيغة البحث :(\nيجب إدخال أرقام فقط!");
                return;
            }

            int ID = Convert.ToInt32(tbSerch.Text);

            Licenses L = clsReciveDatabase.FindLicenseByLicenseID(ID);
            if (L == null)                                   // ← حماية
            {
                MessageBox.Show("لا توجد رخصة بهذا الرقم.");
                return;
            }

            int DriverID = L.DriverID;
            Person P = clsReciveDatabase.FindPersonFromDriverID(DriverID);
            if (P == null)                                   // ← حماية
            {
                MessageBox.Show("لا يوجد سائق مرتبط بهذه الرخصة.");
                return;
            }

            String FullName = P.FirstName + " " + P.ThirdName + " " + P.SecondName + " " + P.LastName;
            DateTime dateTime = P.DateOfBirth;
            String Gendor = P.Gender;
            string N = P.NationalNo;
            double Fees = 0.00;
            double F = Convert.ToDouble(tbSerch.Text);

            if (Lost == true) { Fees = clsReciveDatabase.GetFees(3); }
            else if (Damage == true) { Fees = clsReciveDatabase.GetFees(4); }
            else if (Renew == true) { Fees = clsReciveDatabase.GetFees(2); }
            else if (Detainted == true) { Fees = F; }
            else if (Relased == true) { Fees = clsReciveDatabase.GetFees(5); }
            else { Fees = clsReciveDatabase.GetFees(6); }

            laclassType.Text = L.LicenseClass.ToString();
            laName.Text = FullName;
            laID.Text = L.LicenseID.ToString();
            laNationalNumber.Text = N;
            laGendor.Text = Gendor;
            laIssueReason.Text = L.IssueReason.ToString();
            laIssueDate.Text = L.IssueDate.ToString();
            laNot.Text = (L.Notes == null) ? "No Notes" : L.Notes.ToString();
            laIsActive.Text = L.IsActive.ToString();
            laDOB.Text = dateTime.ToString();
            laDriverID.Text = L.DriverID.ToString();
            laExpirationDate.Text = L.ExpirationDate.ToString();

            DetainedLicense Detainedornot = clsReciveDatabase.FindDetainedLicenseByID(ID);

            // ✅ الإصلاح الأساسي: افحص null وحده أولاً
            if (Detainedornot == null)
            {
                laIsDetained.Text = "False";

                // في وضع الإفراج لا يوجد ما يُفرَج عنه
                if (Relased == true)
                {
                    MessageBox.Show("هذه الرخصة غير محتجزة، لا يوجد ما يمكن الإفراج عنه.");
                    return;
                }
            }
            else
            {
                laIsDetained.Text = (!Detainedornot.IsReleased).ToString();
            }

            laUserId.Text = "15";
            laFees.Text = Fees.ToString();
            laLocalLicense.Text = laID.Text.ToString();

            if (Detainted == false && Relased == false)
            {
                laDateIssue.Text = laIssueDate.Text;
                laDateExp.Text = laExpirationDate.Text;
            }

            // في هذه النقطة، إن كنّا في وضع الإفراج فإن Detainedornot ليست null (وإلا رجعنا مبكرًا)
            if (Relased == true && Detainedornot != null)
            {
                laFees.Text = clsReciveDatabase.GetFees(5).ToString();
                laLocalLicense.Text = Detainedornot.FineFees.ToString();
                laDateIssue.Text = (Convert.ToInt32(clsReciveDatabase.GetFees(5)) + Convert.ToInt32(Detainedornot.FineFees)).ToString();
            }

            P1 = P;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            Person P = clsReciveDatabase.FilterByNationalNumber(laNationalNumber.Text.ToString());
            int PersonID = P.PersonID;

            DateTime applicationDate = DateTime.Now;
            int applicationTypeID = 6;
            int applicationStatus = 1;
            DateTime lastStatusDate = DateTime.Now;
            double feesPaid = clsReciveDatabase.GetFees(6);
            double F = Convert.ToDouble(tbSerch.Text);
            int userID = 15; // should Edit


            if (Renew == true) { applicationTypeID = 2; feesPaid = clsReciveDatabase.GetFees(2); }
            else if (Lost == true) { applicationTypeID = 3; feesPaid = clsReciveDatabase.GetFees(3); }
            else if (Damage == true) { applicationTypeID = 4; feesPaid = clsReciveDatabase.GetFees(4); }
            else if (Relased == true) { applicationTypeID = 5; feesPaid = clsReciveDatabase.GetFees(5); }
            else if (Detainted == true) { applicationTypeID = 5; feesPaid = F; }

            int classID = Convert.ToInt32(laclassType.Text);





            Licenses licenses = clsReciveDatabase.FindLicenseByLicenseID(Convert.ToInt32(tbSerch.Text));
            if (Renew == true)
            {

                if (licenses.IsActive == true)
                {
                    MessageBox.Show("The driver Already Renew the  License ");
                    return;
                }

            }
            else if (Lost == true || Damage == true)
            {

                if (licenses.IsActive == false)
                {
                    MessageBox.Show("This License Is Not Active You can't replace it");
                    return;
                }

            }
            else if (Detainted == true)
            {
                DetainedLicense Detainedornot = clsReciveDatabase.FindDetainedLicenseByID(licenses.LicenseID);

                if (Detainedornot != null)
                {
                    bool answerd = Detainedornot.IsReleased;
                    if (answerd == false)
                    {
                        MessageBox.Show("This License Detainted  , You can't Detaine it");
                        return;
                    }
                }
            }
            else if (Relased == true)
            {
                DetainedLicense Detainedornot = clsReciveDatabase.FindDetainedLicenseByID(licenses.LicenseID);

                if (Detainedornot != null)
                {
                    bool answerd = Detainedornot.IsReleased;
                    if (answerd == true)
                    {
                        MessageBox.Show("This License not Detainted  , You can't Relased it");
                        return;
                    }
                }
            }
            else
            {
                bool Find = clsReciveDatabase.IsHaveInterNationalLicense(Convert.ToInt32(laDriverID.Text));

                if (classID != 3)
                {
                    MessageBox.Show("The driver do not have Class3 , so the condition is false ");
                    return;
                }

                if (Find == true)
                {
                    MessageBox.Show("The driver Has Already InterNational License ");
                    return;

                }

            }


            int applicationID = -1;
            if (Detainted == false)
            {
                applicationID = clsReciveDatabase.InsertApplication(PersonID, applicationDate, applicationTypeID,
                                                                    applicationStatus, lastStatusDate, feesPaid, userID);


                Applications A = clsReciveDatabase.FindApplicationByID(applicationID);

                if (Relased == false)
                {
                    laApplicationDate.Text = A.ApplicationDate.ToString();

                    laILAppID.Text = applicationID.ToString();
                }
                else
                {
                    laDateExp.Text = applicationID.ToString();
                }

            }

            List<Licenses> localLicenses = clsReciveDatabase.FindLicensesByDriverID(Convert.ToInt32(laDriverID.Text));
            bool Updated = false;
            if (Renew == true) 
            {

                laIssueReason.Text = "Renew License";
                for (int i = 0; i < localLicenses.Count ; i++)
                {
                    if (localLicenses[i].LicenseClass.ToString() == laclassType.Text)
                    {
                        localLicenses[i].IsActive = false;
                        Updated = clsReciveDatabase.UpdateLicense(localLicenses[i]);
                        
                    }
                    Console.WriteLine($"LicenseID: {localLicenses[i].LicenseID}, DriverID: {localLicenses[i].DriverID}, Class: {localLicenses[i].LicenseClass}");
                }


                int ID = clsReciveDatabase.InsertLicenseandGetID(applicationID, Convert.ToInt32(laDriverID.Text), Convert.ToInt32(laclassType.Text)
                    , Convert.ToDateTime(laIssueDate.Text), Convert.ToDateTime(laExpirationDate.Text), laNot.Text.ToString(), Convert.ToDecimal(laFees.Text),
                    true, (byte)2
                    , Convert.ToInt32(laUserId.Text));

                laInterNationalLID.Text = ID.ToString();
            }

            else if (Lost == true)
            {
                    
                laIssueReason.Text = "Lost License";
                for (int i = 0; i < localLicenses.Count; i++)
                {
                    if (localLicenses[i].LicenseClass.ToString() == laclassType.Text)
                    {
                        localLicenses[i].IsActive = false;
                        Updated = clsReciveDatabase.UpdateLicense(localLicenses[i]);
                    }
                }

                int ID = clsReciveDatabase.InsertLicenseandGetID(applicationID, Convert.ToInt32(laDriverID.Text), Convert.ToInt32(laclassType.Text)
                    , Convert.ToDateTime(laIssueDate.Text), Convert.ToDateTime(laExpirationDate.Text), laNot.Text.ToString(), Convert.ToDecimal(laFees.Text),
                    true, (byte)3 , Convert.ToInt32(laUserId.Text));

                laInterNationalLID.Text = ID.ToString();

            }

            else if (Damage == true)
            {

                laIssueReason.Text = "Damage License";
                for (int i = 0; i < localLicenses.Count; i++)
                {
                    if (localLicenses[i].LicenseClass.ToString() == laclassType.Text)
                    {
                        localLicenses[i].IsActive = false;
                        Updated = clsReciveDatabase.UpdateLicense(localLicenses[i]);
                    }
                }

                int ID = clsReciveDatabase.InsertLicenseandGetID(applicationID, Convert.ToInt32(laDriverID.Text), Convert.ToInt32(laclassType.Text)
                    , Convert.ToDateTime(laIssueDate.Text), Convert.ToDateTime(laExpirationDate.Text), laNot.Text.ToString(), Convert.ToDecimal(laFees.Text),
                    true, (byte)4
                    , Convert.ToInt32(laUserId.Text));

                laInterNationalLID.Text = ID.ToString();

            }
            else if(Detainted==true)
            {
                DetainedLicense D = new DetainedLicense();

               
                D.LicenseID = Convert.ToInt32(laID.Text);
                D.DetainDate = DateTime.Now;
                D.CreatedByUserID = 15; // Edite 
                D.FineFees = F; // Convert.ToInt64(tbFees.Text);
                D.IsReleased = false;
                D.ReleaseDate = null;
                D.ReleasedByUserID = null;
                D.ReleaseApplicationID = null;
                
               int IDDetainted = clsReciveDatabase.InsertDetainedLicense(D);

             

                laILAppID.Text = IDDetainted.ToString();

                laInterNationalLID.Text = laID.Text;


            }
            else if (Relased == true)
            {
                DetainedLicense DetaintedID = clsReciveDatabase.FindDetainedLicenseByID(Convert.ToInt32(tbSerch.Text));
                if (DetaintedID == null)
                {
                    MessageBox.Show("Fuck you stupid");
                    return;
                }
                //MessageBox.Show($"{DetaintedID.DetainID}, { DetaintedID.LicenseID }" ,tbSerch.Text );
                laILAppID.Text = DetaintedID.DetainID.ToString();
                laInterNationalLID.Text = laID.Text;
                laApplicationDate.Text = DateTime.Now.ToString() ;
                bool o = clsReciveDatabase.ReleaseDetainedLicense(DetaintedID.DetainID);
                laIsDetained.Text = o.ToString();

            }
            else
            {

                int LocalID = clsReciveDatabase.InsertInternationalLicense(applicationID, Convert.ToInt32(laDriverID.Text),
                    Convert.ToInt32(laID.Text), Convert.ToDateTime(laIssueDate.Text), Convert.ToDateTime(laExpirationDate.Text),
                    true, 15);

                laInterNationalLID.Text = LocalID.ToString();


                InternationalLicense L = clsReciveDatabase.GetInternationalLicenseByID(LocalID);

                L1 = L;

            }
      

            LinkedLocalID.Enabled = true;
           
          




        }

        private void LinkedLocalID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form form = new Form();
            form.Size = new Size(800, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            Show_Driving_License control = new Show_Driving_License(laNationalNumber.Text ,  Convert.ToInt32(laInterNationalLID.Text));
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();

        }

        private void linkedHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(800, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            Panel topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = form.Height / 2;



            form.Text = "Person want to Local License";
            ShowDetails control = new ShowDetails(P1);





            control.Dock = DockStyle.Fill;
            topPanel.Controls.Add(control);

            
            Panel bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Fill; 
            History_Liceses H = new History_Liceses(Convert.ToInt32(laDriverID.Text));
            H.Dock = DockStyle.Fill;
            bottomPanel.Controls.Add(H);

            form.Controls.Add(bottomPanel);
            form.Controls.Add(topPanel);

            form.ShowDialog();


        }
    }
}
