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
    public partial class Add_Local_part2 : UserControl
    {
        String National = "";

        public Add_Local_part2()
        {
            InitializeComponent();
            FillComboBox();
            LoadData();
        }

        public Add_Local_part2(String national)
        {
            InitializeComponent();
            this.National = national;
            FillComboBox();
            LoadData();
        }

        private void FillComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Class 1 - Small Motorcycle");
            comboBox1.Items.Add("Class 2 - Heavy Motorcycle License");
            comboBox1.Items.Add("Class 3 - Ordinary driving license");
            comboBox1.Items.Add("Class 4 - Commercial");
            comboBox1.Items.Add("Class 5 - Agricultural");          // أُزيلت المسافة الزائدة
            comboBox1.Items.Add("Class 6 - Small and medium bus");
            comboBox1.Items.Add("Class 7 - Truck and heavy vehicle");
        }

        private void LoadData()
        {
            textBox1.Text = "";                 // يُملأ برقم الطلب بعد النجاح
            textBox2.Text = National ?? "";
            textBox4.Text = "15";               // الرسوم (يفضّل جلبها من الإعدادات)
            textBox5.Text = "user4";            // المستخدم (يفضّل جلبه من الجلسة)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1) تحقق من المدخلات
            if (string.IsNullOrWhiteSpace(National))
            {
                MessageBox.Show("لا يوجد رقم وطني محدد لهذا الشخص.");
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى اختيار نوع الرخصة أولاً.");
                return;
            }

            string drivingClass = comboBox1.SelectedItem.ToString().Trim();

            try
            {
                clsReciveDatabase db = new clsReciveDatabase();

                // 2) تأكد من وجود الشخص
                Person person = db.FilterByNationalNumber(National);
                if (person == null)
                {
                    MessageBox.Show("لم يتم العثور على شخص بهذا الرقم الوطني.");
                    return;
                }

                // 3) منع تكرار طلب بنفس الفئة قيد المعالجة
                if (db.HasNewLocalDriving(National, drivingClass))
                {
                    MessageBox.Show("هذا الشخص لديه طلب رخصة بنفس الفئة قيد المعالجة.");
                    return;
                }

                // 4) قيم يُفضّل جلبها لاحقًا من الإعدادات ومن المستخدم المسجّل
                const double feesPaid = 15.0;
                const int currentUserID = 15;      // TODO: استبدلها بمعرّف المستخدم المسجّل فعليًا
                int classId = comboBox1.SelectedIndex + 1;

                // 5) إدراج الطلب ثم الرخصة
                int applicationID = db.InsertApplication(
                    person.PersonID,
                    DateTime.Now,
                    1,               // applicationTypeID
                    1,               // applicationStatus
                    DateTime.Now,    // lastStatusDate
                    feesPaid,
                    currentUserID);

                if (applicationID <= 0)
                {
                    MessageBox.Show("فشل إنشاء الطلب. لم تتم الإضافة.");
                    return;
                }

                int appID = db.InsertLD(applicationID, classId);

                if (appID <= 0)
                {
          
                    MessageBox.Show("تم إنشاء الطلب لكن فشل إنشاء الرخصة. يرجى المراجعة.");
                    return;
                }

                textBox1.Text = appID.ToString();
                MessageBox.Show("تمت إضافة الرخصة المحلية بنجاح.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الإضافة: " + ex.Message);
            }
        }
    }
}