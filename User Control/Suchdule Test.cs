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
    public partial class Suchdule_Test : UserControl
    {
        public static int Trial { get; private set; } = 0 ;
        public int TestId { get; private set; } = -1;
        public Suchdule_Test()
        {
            InitializeComponent();
        }

        public Suchdule_Test(int D_L_AppID ,String ClassType , String Name , int type ,bool c = true )
        {
            InitializeComponent();
            Load(D_L_AppID, ClassType, Name , type);
            if(c==false)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled=true;
            }
        }

        public Suchdule_Test(int testAppointmentId, string ClassType, string Name, int type, DateTime date)
        {
            InitializeComponent();

            // اجلب البيانات من DB
            clsReciveDatabase db = new clsReciveDatabase();
            TestAppointments t = db.GetAllTestAppointmentsByAppID(testAppointmentId).FirstOrDefault();

            if (t == null)
            {
                MessageBox.Show("❌ Appointment not found!");
                return;
            }

            Test = t; // ✅ نخزن البيانات في الكائن الأصلي

            // تحديث الواجهة
            laAppID.Text = t.LocalDrivingLicenseApplicationID.ToString();
            laclass.Text = ClassType;
            laName.Text = Name;
            laTiral.Text = Trial.ToString();

            dateTimePicker1.Value = t.AppointmentDate;
            laFees.Text = t.PaidFees.ToString();
            laRAppFees.Text = "5"; // إذا عندك قيمة ثابتة
            laTotalFees.Text = (t.PaidFees + 5).ToString();
        }


        TestAppointments Test = new TestAppointments();
        
        private void Load(int D_L_AppID, String ClassType, String Name , int type )
        {
            laAppID.Text = D_L_AppID.ToString();
            laclass.Text = ClassType.ToString();
            laName.Text = Name.ToString();
            laTiral.Text = Trial.ToString(); 
            groupBox1.Enabled = true;
            laFees.Text = 10.ToString() ;
            laRAppFees.Text = 5.ToString() ;
            int i = (Convert.ToInt32(Convert.ToInt32(laRAppFees.Text) + Convert.ToInt32(laFees.Text)));
            laTotalFees.Text = i.ToString();
            Test.LocalDrivingLicenseApplicationID = D_L_AppID;
            Test.TestTypeID = type;
            Test.AppointmentDate =  dateTimePicker1.Value ;
            if (type == 1)
            {
                Test.PaidFees = 10;
            }
            else if (type == 2)
            {
                Test.PaidFees = 20;
            }
            else if (type == 3)
            {
                Test.PaidFees= 30;
            }
            Test.CreatedByUserID = 15;
            Test.IsLocked = 0;
            



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Test.AppointmentDate = dateTimePicker1.Value;

            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            TestId = clsReciveDatabase.InsertTestAppointment(Test);
            laTestAppID.Text = TestId.ToString();
            //MessageBox.Show($"{TestId}" + "This is from Suchdule Test");
         
            //Vision_Test_Appoinment a = new Vision_Test_Appoinment(TestId);

        }

        private void btn_save_Editing_Click(object sender, EventArgs e)
        {
            clsReciveDatabase db = new clsReciveDatabase();

            if (Test.TestAppointmentID <= 0)
            {
                MessageBox.Show("⚠ لا يوجد TestAppointmentID صالح للتعديل");
                return;
            }

            // ✅ حدّث القيم من الواجهة
            Test.AppointmentDate = dateTimePicker1.Value;
            Test.PaidFees = Convert.ToDouble(laFees.Text);
            Test.IsLocked = 0;  // أو حسب قيمة CheckBox إذا عندك
            Test.CreatedByUserID = 15;

            bool result = db.UpdateTestAppointment(Test);

            if (result)
                MessageBox.Show("✅ Updated Successfully!");
            else
                MessageBox.Show("❌ Update Failed!");
        }

    }
}
