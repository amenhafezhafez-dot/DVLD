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
    public partial class ShowDetails : UserControl
    {
        public ShowDetails()
        {
            InitializeComponent();
        }

        Person person = new Person(); 
        public ShowDetails(Person person)
        {
            InitializeComponent();
            this.person = person;
            SetData(person);

        }

        public void SetData(Person person)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            string nameofthecountry = clsReciveDatabase.GetCountryNameByID(person.NationalityCountryID);
            try
            {
                lbID.Text = person.PersonID.ToString();
                lbName.Text = $"{person.FirstName} {" "} {person.SecondName} {" "} {person.ThirdName}{" "} {person.LastName}";
                lbAddress.Text = person.Address;
                lbEmail.Text = person.Email;
                lbPhone.Text = person.Phone;
             
                if(person.Gender=="0")
                {
                    lbGendor.Text = "Male";
                }
                else
                {
                    lbGendor.Text = "Female";
                }

                lbDateofBirth.Text = person.DateOfBirth.ToString("dd/MM/yyyy");
                lbNationalNo.Text = person.NationalNo;
                lbCountry.Text = nameofthecountry;

                
                if (!string.IsNullOrEmpty(person.ImagePath) && System.IO.File.Exists(person.ImagePath))
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(person.ImagePath);
                    }
                    catch
                    {
                        if (person.Gender == "0")
                        {
                            pictureBox1.Image = imageList1.Images[0];
                        }
                        else
                        {
                            pictureBox1.Image = imageList1.Images[1];
                        }

                       
                    }
                }
                else
                {
                    if (person.Gender == "0")
                    {
                        pictureBox1.Image = imageList1.Images[0];
                    }
                    else
                    {
                        pictureBox1.Image = imageList1.Images[1];
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading person details: " + ex.Message);
            }
        }

        private string GetCountryName(int countryID)
        {
            
            return countryID.ToString();
        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
      
            if (person == null)
            {
                MessageBox.Show("Person object is null. Cannot edit.");
                return;
            }

            Add_Edit editControl = new Add_Edit(person.PersonID) 
            {
                Dock = DockStyle.Fill
            };
            MessageBox.Show($"{person.FirstName} {person.Gender} {person.NationalityCountryID}");

            
            editControl.SetDataForEdit(
                person.PersonID,
                person.NationalNo,
                person.FirstName,
                person.SecondName,
                person.ThirdName,
                person.LastName,
                person.DateOfBirth,
                person.Gender == "0" ? 0 : 1 ,
                person.Address,
                person.Phone,
                person.Email ?? string.Empty,
                person.NationalityCountryID,
                person.ImagePath ?? string.Empty
            );

            
            Form popupForm = new Form
            {
                Text = "Edit person Informations",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            popupForm.Controls.Add(editControl);
            DialogResult result = popupForm.ShowDialog();

            if (result == DialogResult.OK)
            {
             

                MessageBox.Show("✅ Updated Successfuly");
            }
        }
    }
    
}