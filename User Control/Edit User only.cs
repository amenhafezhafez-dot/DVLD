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
using System.Xml.Linq;

namespace DVLD
{
    public partial class Edit_User_only : UserControl
    {
        private int ID = -1;
        public Edit_User_only()
        {
            InitializeComponent();
        }

        public Edit_User_only(int PersonID)
        {
            InitializeComponent();

            ID = PersonID;
            Data(PersonID);
        }

        private void Data(int PersonID)
        {
            clsReciveDatabase sd = new clsReciveDatabase();
            Person personList = sd.FilterByID(ID);
            List<User> UserList = sd.FindUserByPersonID(ID);

            if (personList != null)
            {
                Person person = personList;
                User user = UserList[0];

                tbFirstName.Text = person.FirstName;
                tbSecondName.Text = person.SecondName;
                tbThirdName.Text = person.ThirdName;
                tbLastName.Text = person.LastName;
                tbAddress.Text = person.Address;
                tbEmail.Text = person.Email;
                tbPhone.Text = person.Phone;
                textBox1.Text = user.UserName;
                textBox2.Text = user.UserID.ToString();
                textBox3.Text = user.Active.ToString();



                
                if (person.Gender == "ذكر")
                    rbMale.Checked = true;
                else if (person.Gender == "أنثى")
                    rbFemale.Checked = true;

                dtpDateOfBirth.Value = person.DateOfBirth;
                tbNationalNo.Text = person.NationalNo;

                // تحميل البلدان وتعيين البلد الافتراضي
                LoadCountries();
                if (person.NationalityCountryID > 0)
                {
                    cbCountry.SelectedValue = person.NationalityCountryID;
                }
            }
            else
            {
                MessageBox.Show("❌ لم يتم العثور على بيانات الشخص");
            }
        }

        private void LoadCountries()
        {
            try
            {
                clsReciveDatabase db = new clsReciveDatabase();
                List<Countries> countries = db.GetAllCountries(); // يجب إنشاء هذه الدالة في clsReciveDatabase

                cbCountry.DisplayMember = "CountryName";
                cbCountry.ValueMember = "CountryID";
                cbCountry.DataSource = countries;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ خطأ في تحميل قائمة البلدان: " + ex.Message);
            }
        }

        private void showDetails1_Load(object sender, EventArgs e)
        {
            // يمكن تحميل البلدان هنا أيضاً إذا لزم الأمر
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // التحقق من الحقول المطلوبة
            if (string.IsNullOrWhiteSpace(tbNationalNo.Text) ||
                string.IsNullOrWhiteSpace(tbFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                MessageBox.Show("❌ الرجاء ملء الحقول الإلزامية (الرقم الوطني، الاسم الأول، الاسم الأخير)");
                return;
            }

            // التحقق من تاريخ الميلاد
            if (dtpDateOfBirth.Value > DateTime.Now)
            {
                MessageBox.Show("❌ تاريخ الميلاد لا يمكن أن يكون في المستقبل");
                return;
            }

            // التحقق من الجنس
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("❌ الرجاء اختيار الجنس");
                return;
            }

            // التحقق من البلد
            if (cbCountry.SelectedValue == null || cbCountry.SelectedIndex == -1)
            {
                MessageBox.Show("❌ الرجاء اختيار البلد");
                return;
            }

            try
            {
                int genderValue = rbMale.Checked ? 0 : 1;
                string imagePath = pictureBox1.ImageLocation ?? "";

                clsReciveDatabase db = new clsReciveDatabase();

                // تحرير بيانات الشخص
                bool isUpdated = db.EditPerson(
                    ID,
                    tbNationalNo.Text,
                    tbFirstName.Text,
                    tbSecondName.Text,
                    tbThirdName.Text,
                    tbLastName.Text,
                    dtpDateOfBirth.Value,
                    genderValue,
                    tbAddress.Text,
                    tbPhone.Text,
                    tbEmail.Text,
                    Convert.ToInt32(cbCountry.SelectedValue),
                    imagePath
                );

                bool isUpdate2 = db.EditUser(Convert.ToInt32(textBox2.Text), textBox1.Text, Convert.ToInt32(textBox3.Text) , ID);
                if (!isUpdated)
                    Console.WriteLine("فشل تعديل الشخص");

                if (!isUpdate2)
                    Console.WriteLine("فشل تعديل المستخدم");

                if (isUpdated && isUpdate2)
                {
                    MessageBox.Show("✅ تم تحديث بيانات الشخص والمستخدم بنجاح");
               
                // إغلاق النموذج الأب
                if (this.ParentForm != null)
                    {
                        this.ParentForm.DialogResult = DialogResult.OK;
                        this.ParentForm.Close();
                    }
                }
                else
                {
                    MessageBox.Show("❌ فشل في تحديث البيانات");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("❌ قيم غير صالحة في الحقول الرقمية");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ خطأ: " + ex.Message);
            }
        }
    }
}