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
    public partial class User_Details_Control : UserControl
    {
        private int ID = -1;
        public User_Details_Control()
        {
            InitializeComponent();
        }
        public User_Details_Control(int iD)
        {
            InitializeComponent();
            ID = iD;
            Load(iD);
        }

      
        private void Load(int id)
        {
            clsReciveDatabase crd = new clsReciveDatabase();
            List<User> user = new List<User>();
            user = crd.FindUserByPersonID(id);
            label1.Text = user[0].UserName.ToString();
            label2.Text = user[0].UserID.ToString();
            //label3.Text = user[0].Active.ToString();
            if (user[0].Active == 0)
            {
                label3.Text = "NO";
            }
            else
            {
                label3.Text = "Yes";
            }
        }
    }
}
