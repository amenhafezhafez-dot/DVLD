using DataBase;
using DVLD.Classes;
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
    public partial class Check_User : Form
    {

        static bool remmber = false; 
     
        public Check_User()
        {
            InitializeComponent();
            clsUITheme.Apply(this);
            //clsUITheme.MakeCard(cardPanel, 16);
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            clsReciveDatabase r = new clsReciveDatabase();


         

            if (r.CheckUser(textBox1.Text, textBox2.Text))
            {
                // بعد نجاح تسجيل الدخول:
                this.Hide();                                   // إخفاء نافذة الدخول
                DashboardForm dash = new DashboardForm();
                //dash.FormClosed += (s, e) => Application.Exit(); // إغلاق البرنامج عند إغلاق الداشبورد
                dash.Show();

            }
            else if(!r.CheckUser(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("It is not Active");
            }
            else 
            {
                MessageBox.Show("The password or user name is false");
            }


        }

        private void chkremmber_CheckedChanged(object sender, EventArgs e)
        {
        
            if (chkremmber.Checked)
            {
                
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    string u = textBox1.Text;
                    string p = textBox2.Text;
                    bool b = clsGlobal.RememberUsernameAndPassword(u, p);
                }
                else
                {
                    
                    MessageBox.Show("⚠️Enter User name and password");
                    chkremmber.Checked = false; 
                }
            }
            else
            {
                bool b = clsGlobal.RememberUsernameAndPassword("", "");
            }
        }


        private void Check_User_Load(object sender, EventArgs e)
        {
            string u = "";
            string p = "";
            bool b = clsGlobal.GetStoredCredential(ref u, ref p);

            if (b) 
            {

                if (!string.IsNullOrWhiteSpace(u) && !string.IsNullOrWhiteSpace(p))
                {
                    textBox1.Text = u;
                    textBox2.Text = p;
                    chkremmber.Checked = true;
                }
                else
                {
                   
                    chkremmber.Checked = false;
                }
            }
            else
            {
                
                chkremmber.Checked = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
