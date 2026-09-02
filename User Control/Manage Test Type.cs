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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class Manage_Test_Type : UserControl
    {
        private int ID;
        public Manage_Test_Type(int id)
        {
            InitializeComponent();
            ID = id;
            SetData();
        }

        private void SetData()
        {

            TestsTypes test = null ;
            clsReciveDatabase data = new clsReciveDatabase();
            test = data.FindTestByID(ID);

            if (test != null)
            {
                btnID.Text = test.TestTypeID.ToString();                 
                tbDiscription.Text = test.TestTypeDescription.ToString();
                tbTitle.Text = test.TestTypeTitle.ToString();
                tbFees.Text = test.TestTypeFees.ToString();
              
            }
            else
            {
                MessageBox.Show("Null");
            }


        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // تحقق من صحة الإدخال
            if (string.IsNullOrWhiteSpace(tbTitle.Text) || string.IsNullOrWhiteSpace(tbDiscription.Text) || string.IsNullOrWhiteSpace(tbFees.Text))
            {
                MessageBox.Show("⚠️ الرجاء ملء جميع الحقول قبل الحفظ.");
                return;
            }

            // تحويل الرسوم إلى رقم
            if (!double.TryParse(tbFees.Text, out double fees))
            {
                MessageBox.Show("⚠️ الرجاء إدخال رقم صحيح في خانة الرسوم.");
                return;
            }

            // إنشاء كائن جديد يحتوي على البيانات المعدلة
            TestsTypes test = new TestsTypes
            {
                TestTypeID = ID,
                TestTypeTitle = tbTitle.Text.Trim(),
                TestTypeDescription = tbDiscription.Text.Trim(),
                TestTypeFees = fees
            };

            clsReciveDatabase data = new clsReciveDatabase();
            if (data.UpdateTests(test))
            {
                MessageBox.Show("✅ تم حفظ التعديلات بنجاح.");
            }
            else
            {
                MessageBox.Show("❌ لم يتم حفظ أي تعديل.");
            }
        }
    }
}
