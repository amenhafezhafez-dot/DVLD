using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using YourNamespace;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD
{
    public partial class ShowDetails_Filter : UserControl
    {
        private int allPersonID = 0 ;
        private string National = "";
        public ShowDetails_Filter()
        {
            InitializeComponent();
            InitFilterCombo();
        }


        private bool _localLicenseMode = false;

        public ShowDetails_Filter(bool localLicenseMode)
        {
            InitializeComponent();
            _localLicenseMode = localLicenseMode;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DoSearch();
        }



        private void InitFilterCombo()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] {
            "Person ID", "National Number", "First Name", "Last Name", "Email"
                 });
            comboBox1.SelectedIndex = 0;
        }



        public void SetData(Person person)
        {
            try
            {
                //MessageBox.Show("set");
                lbID.Text = person.PersonID.ToString();
                lbName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
                lbAddress.Text = person.Address;
                lbEmail.Text = person.Email;
                lbPhone.Text = person.Phone;
                if(person.Gender=="0")
                {
                    //MessageBox.Show("MMMM");
                    lbGendor.Text = "Male";
                }
                else
                {
                    //MessageBox.Show("ffff");
                    lbGendor.Text = "Female";
                }
                lbDateofBirth.Text = person.DateOfBirth.ToString("dd/MM/yyyy");
                lbNationalNo.Text = person.NationalNo;
                lbCountry.Text = GetCountryName(person.NationalityCountryID);
                allPersonID = person.PersonID;

                if (!string.IsNullOrEmpty(person.ImagePath) && System.IO.File.Exists(person.ImagePath))
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(person.ImagePath);
                    }
                    catch
                    {
                      
                        pictureBox1.Image = (person.Gender == "0")
                            ? imageList1.Images[0]
                            : imageList1.Images[1];
                    }
                }
                else
                {
                 
                    pictureBox1.Image = (person.Gender == "0")
                        ? imageList1.Images[0]
                        : imageList1.Images[1];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading person details: " + ex.Message);
            }

         
        }


        public void Refreash()
        {
            lbID.Text ="[?????]";
            lbName.Text = "[?????]";
            lbAddress.Text = "[?????]";
            lbEmail.Text = "[?????]";
            lbPhone.Text = "[?????]";
            lbGendor.Text = "[?????]";
            lbDateofBirth.Text = "[?????]";
            lbNationalNo.Text = "[?????]";
            lbCountry.Text = "[?????]";
            pictureBox1.Image = imageList1.Images[2]; 
        }

        private string GetCountryName(int countryID)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            return clsReciveDatabase.GetCountryNameByID(countryID);
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form form = new Form();
            Add_Edit ae = new Add_Edit();

         
            ae.Dock = DockStyle.Fill;

            form.ClientSize = ae.Size;

            form.StartPosition = FormStartPosition.CenterScreen;

            form.Controls.Add(ae);

            form.ShowDialog();



            SetData(ae.SaveRusult());
           
        }

        private int id(object sender)
        {
            return Convert.ToInt32(lbID.Text);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (allPersonID <= 0)
            {
                MessageBox.Show("يرجى اختيار شخص أولاً قبل المتابعة.");
                return;
            }

            Form form = new Form();

            if (_localLicenseMode)
            {
                // ✅ تدفّق الرخصة المحلية
                Add_Local_part2 licenseControl = new Add_Local_part2(lbNationalNo.Text);
                form.Text = "Add Local License";
                form.Controls.Add(licenseControl);
                form.ClientSize = licenseControl.Size;
            }
            else
            {
                // تدفّق إضافة مستخدم (كما كان)
                Tab2_for_Add_user_Control userControl = new Tab2_for_Add_user_Control(allPersonID);
                form.Text = "Add User";
                form.Controls.Add(userControl);
                form.ClientSize = userControl.Size;
            }

            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }



        private void DoSearch()
        {
            string searchText = Serch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                Refreash();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
                comboBox1.SelectedIndex = 0;

            clsReciveDatabase dbFilter = new clsReciveDatabase();
            List<Person> filteredPeople = new List<Person>();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (int.TryParse(searchText, out int personId))
                    {
                        Person p = dbFilter.FilterByID(personId);
                        if (p != null) filteredPeople.Add(p);
                    }
                    break;
                case 1:
                    Person p2 = dbFilter.FilterByNationalNumber(searchText);
                    if (p2 != null) filteredPeople.Add(p2);
                    break;
                case 2:
                    filteredPeople = dbFilter.FilterByFirstName(searchText);
                    break;
                case 3:
                    filteredPeople = dbFilter.FilterByLastName(searchText);
                    break;
                case 4:
                    filteredPeople = dbFilter.FilterByEmail(searchText);
                    break;
            }

            if (filteredPeople == null || filteredPeople.Count == 0)
                Refreash();                    // بدون رسائل مزعجة
            else
                SetData(filteredPeople[0]);
        }

        private void Serch_TextChanged(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            clsReciveDatabase db = new clsReciveDatabase();
            Person p = db.FilterByID(allPersonID);

            if (p == null)
            {
                MessageBox.Show("❌ Person not found!");
                return;
            }

       
            int gender;
            if (p.Gender == "0" || p.Gender.Equals("male", StringComparison.OrdinalIgnoreCase))
                gender = 0;
            else
                gender = 1;

            Add_Edit editControl = new Add_Edit(p.PersonID)
            {
                Dock = DockStyle.Fill
            };

         
            editControl.SetDataForEdit(
                p.PersonID,
                p.NationalNo,
                p.FirstName,
                p.SecondName,
                p.ThirdName,
                p.LastName,
                p.DateOfBirth,
                gender,
                p.Address,
                p.Phone,
                p.Email ?? string.Empty,
                p.NationalityCountryID,
                p.ImagePath ?? string.Empty
            );

            
            Form popupForm = new Form
            {
                Text = "Edit Person Details",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            popupForm.Controls.Add(editControl);
            DialogResult result = popupForm.ShowDialog();


        }


    }
}

