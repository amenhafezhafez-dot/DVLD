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
    public partial class Take_Test : UserControl
    {
        int ID;
        int TestID;
        int type;

        public Take_Test()
        {
            InitializeComponent();
        }

        
        public Take_Test(int TestAppointmerts)
        {
            InitializeComponent();
            ID = TestAppointmerts;
            LoadDataFromDB(); // new 
        }

        int personId;
        public Take_Test(int testAppointmentID, string classType, string applicant , int personid , int type)
        {
            InitializeComponent();
            this.ID = testAppointmentID;
            this.type = type;
            this.personId = personid;
            Load(testAppointmentID, classType, applicant, type);
            
        }

        public Take_Test(int TestID , int type)
        {
            InitializeComponent();
            this.TestID = TestID;
            this.type = type;
            

        }
        

        private void Load(int testAppointmentID, string classType, string applicant, int type)
        {
            clsReciveDatabase db = new clsReciveDatabase();
            TestAppointments t = db.FindTestAppointmentByID(testAppointmentID);

            if (t == null)
            {
                MessageBox.Show("❌ لم يتم العثور على بيانات الموعد في قاعدة البيانات");
                return;
            }

           
            laAppID.Text = t.LocalDrivingLicenseApplicationID.ToString();
            laclass.Text = classType;
            laName.Text = applicant;
            laTiral.Text = t.AppointmentDate.ToString("yyyy/MM/dd");

            // حفظ النوع
            this.type = type;
        }

      
        private void LoadDataFromDB()
        {
            clsReciveDatabase db = new clsReciveDatabase();
            TestAppointments t = db.FindTestAppointmentByID(ID);

            if (t != null)
            {
                laAppID.Text = t.LocalDrivingLicenseApplicationID.ToString();
                laclass.Text = t.TestTypeID.ToString();
                laName.Text = "غير محدد";
                laTiral.Text = t.AppointmentDate.ToString("yyyy/MM/dd");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();

            // ✅ منع إعادة اختبار مجتاز مسبقًا (بالفئة الصحيحة)
            int classId = clsReciveDatabase.GetClassTypeID(laclass.Text);
            if (clsReciveDatabase.HasPassedThisTestType(personId, classId, type))
            {
                MessageBox.Show("هذا الشخص اجتاز هذا الاختبار مسبقًا، لا يمكن إعادته.");
                return;
            }

            Tests T = new Tests
            {
                TestAppointmentID = ID,
                TestResult = radioButton1.Checked,   // true = ناجح ، false = راسب
                Notes = notes.Text,
                CreatedByUserID = 15
            };

            int TestID = clsReciveDatabase.InsertTest(T);
            if (TestID <= 0)
            {
                MessageBox.Show("تعذّر حفظ نتيجة الاختبار.");
                return;
            }

            // تحديث نتيجة النجاح للطلب
            clsReciveDatabase.RecalculatePassedResultByTestAppointment(ID);

            bool Pass = clsReciveDatabase.ISpassOrNot(TestID);
            MessageBox.Show(Pass ? "تم الحفظ: ناجح ✅" : "تم الحفظ: راسب ❌");
        }
    }
}
