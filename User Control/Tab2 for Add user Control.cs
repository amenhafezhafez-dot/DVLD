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
    public partial class Tab2_for_Add_user_Control : UserControl
    {
        private int personID;
        public Tab2_for_Add_user_Control()
        {
            InitializeComponent();
        }

        public Tab2_for_Add_user_Control(int p)
        {
            InitializeComponent();
            personID = p;
        }

        private void tbUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {



        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsReciveDatabase db = new clsReciveDatabase();
            int isActiveValue = chkActive.Checked ? 1 : 0;

            // التحقق من كلمة المرور
            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("كلمة المرور غير متطابقة!");
                errorProvider1.SetError(tbConfirmPassword, "كلمة المرور غير متطابقة");
                tbConfirmPassword.Focus();
                return;
            }

            List<User> existingByName = db.FindUserByUserName(tbUserName.Text);
            if (existingByName != null && existingByName.Count > 0)
            {
                MessageBox.Show("اسم المستخدم موجود مسبقًا!");
                errorProvider1.SetError(tbUserName, "اسم المستخدم مستخدم مسبقًا");
                tbUserName.Focus();
                return;
            }

    
            int id = db.InsertUser(
                personID: personID,
                userName: tbUserName.Text,
                password: tbPassword.Text,
                isActive: isActiveValue
            );

            label5.Text = id.ToString();

            MessageBox.Show("تم إضافة المستخدم بنجاح ✅");
        }
    }
}
