using DataBase;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Vision_Test_Appoinment : UserControl
    {
        int type  = -1 ;
        int count = 1 ;
        public int ID { get; set; }   

        public int IDTestApp {  get; set; }

        public Vision_Test_Appoinment(int TestID)
        {
            InitializeComponent();
            this.IDTestApp = TestID;

            SetupContextMenu();
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            bool b = clsReciveDatabase.UpdateIsLockToOne(TestID);
            //MessageBox.Show("{Pass function}");
            //MessageBox.Show($"{TestID}");
            //MessageBox.Show($"{b}");
        }

        static bool Pas=false;
        private bool pass(int TestID)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            bool A = clsReciveDatabase.ISpassOrNot(TestID);
            Pas = A;
            if(count==3)
            {
                count += 0;
            }
            else
            {
                count++;
            }
           


            return A;
        }

        public Vision_Test_Appoinment(bool pasedornot , int TestID)
        {
            InitializeComponent();
            this.ID = TestID;
            
            pass(TestID);

         
        }

        public Vision_Test_Appoinment(LocalDriving l , int classtype , int personID, int type)
        {
            InitializeComponent();
            this.type = type;
            Load(l);
            Load2(classtype,personID, type);
            SetupContextMenu();
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

        private void Load2(int classtype , int personID , int type)
        {
            clsReciveDatabase db = new clsReciveDatabase();

            
            
            List<TestAppointments> testAppointments = db.FindAllTestAppointmentsforPerson(personID, classtype , type);

            if (testAppointments == null || testAppointments.Count == 0)
            {
                MessageBox.Show("لا توجد مواعيد لهذا الشخص وهذا النوع من الرخصة.");
                dataGridView1.DataSource = null;
            }
            else
            {
                dataGridView1.DataSource = testAppointments;
            }
        }


        private void Filldgv(int personID, int classType, int type)
        {
            clsReciveDatabase db = new clsReciveDatabase();

            List<TestAppointments> testAppointments = db.FindAllTestAppointmentsforPerson(personID, classType, type);

            if (testAppointments != null && testAppointments.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = testAppointments;

                // نعمل تعديل على عمود IsLocked إذا موجود
                if (dataGridView1.Columns.Contains("IsLocked"))
                {
                    int colIndex = dataGridView1.Columns["IsLocked"].Index;
                    dataGridView1.Columns.Remove("IsLocked");

                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.Name = "IsLocked";
                    chk.HeaderText = "Is Locked";
                    chk.DataPropertyName = "IsLocked";
                    chk.TrueValue = 1;
                    chk.FalseValue = 0;

                    dataGridView1.Columns.Insert(colIndex, chk);
                }

                //MessageBox.Show($"عدد المواعيد: {testAppointments.Count}", "تم جلب البيانات");
            }
            else
            {
                MessageBox.Show("لا يوجد مواعيد لهذا الشخص.", "تنبيه");
                dataGridView1.DataSource = null;
            }
        }



        private void SetupContextMenu()
        {
            ToolStripMenuItem item1 = new ToolStripMenuItem("Edit");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Take Test");


            item1.Click += Edit;
            item2.Click += Take_Test;

            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { item1, item2 });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }


        private void Take_Test(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }
         
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int testAppointmentID = Convert.ToInt32(selectedRow.Cells[0].Value);
            string classType = laClassType.Text;
            string applicant = laApplicant.Text;
            DateTime appDate = Convert.ToDateTime(selectedRow.Cells[3].Value);

            Form form = new Form();
            form.Size = new System.Drawing.Size(600, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Take Test";

            int personId = clsReciveDatabase.GetPersonIDFromLDL(Convert.ToInt32(laLDLAppID.Text));

            Take_Test TT = new Take_Test(
                testAppointmentID,
                classType,
                applicant,
                personId ,
                type
                
            );

            TT.Dock = DockStyle.Fill;
            form.Controls.Add(TT);
            form.ShowDialog();
        }


        private void Edit(object sender, EventArgs e)
        {
            clsReciveDatabase db = new clsReciveDatabase();
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }
            if(Pas==true)
            {
                MessageBox.Show("Passed :)");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            int testAppointmentID = Convert.ToInt32(selectedRow.Cells[0].Value);
            string classType = laClassType.Text;
            string applicant = laApplicant.Text;
            DateTime appDate = Convert.ToDateTime(selectedRow.Cells[3].Value);

            Form form = new Form();
            form.Size = new System.Drawing.Size(600, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Editing Schedule Test Appointments";

            Suchdule_Test control = new Suchdule_Test(
                testAppointmentID,
                classType,
                applicant,
                type,
                appDate
            );

            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);

            form.FormClosed += (s, args) =>
            {
                int personId = db.GetPersonIDFromLDL(Convert.ToInt32(laLDLAppID.Text));
                int c = db.GetClassTypeID(laClassType.Text);

                Filldgv(personId, c, type);

            };

            form.ShowDialog();
        }
        /*bool added = db.AddDriver(personId, 15, DateTime.Now);
      if (passedVision && passedWritten && passedPractical)
            {
            MessageBox.Show("This Person Have Passed three Tests , You can Add him To Drivers List:)");
            }
            else
            {
            MessageBox.Show("This Person already Passed Test , You can not  Add TestAppointment :)");
            } */

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(":)");
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            clsReciveDatabase db = new clsReciveDatabase();

            
            int personId = db.GetPersonIDFromLDL(Convert.ToInt32(laLDLAppID.Text)); 
            int classType = db.GetClassTypeID(laClassType.Text); 

           
                bool passedVision = db.HasPassedThisTestType(personId, classType, type);
                //bool passedWritten = db.HasPassedThisTestType(personId, classType, 2);
                //bool passedPractical = db.HasPassedThisTestType(personId, classType, 3);

            if (passedVision)
            {
                MessageBox.Show("This Person Have Passed  Test , You can not  Add Appointments");
                //bool added = db.AddDriver(personId, 15, DateTime.Now);
                //bool stutus = db.UpdateStatus(Convert.ToInt32(LaID.Text));
                return;
            }


          



            Form form = new Form();
            form.Size = new System.Drawing.Size(600, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Schedule Test Appointments";
            bool c = true;

            if(dataGridView1.Rows.Count==0)
            {
                c=false;
            }
            


            Suchdule_Test control = new Suchdule_Test(
                Convert.ToInt32(laLDLAppID.Text),
                laClassType.Text,
                laApplicant.Text,
                type , c
            );

            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);

            form.FormClosed += (s, args) =>
            {
                if (control.TestId > 0) // إذا في ID جديد
                {
                    this.ID = control.TestId;   // حدّث الـ ID
                    int p = db.GetPersonIDFromLDL(Convert.ToInt32(laLDLAppID.Text));
                    int cc = db.GetClassTypeID(laClassType.Text);

                    Filldgv(p, cc, type);
                   
                    //MessageBox.Show($"{this.ID}", "Updated ID After Insert");
                }
            };

            form.ShowDialog();
        }


    }
}
