using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD
{
    public partial class Add_Edit : UserControl
    {
        private int _personID = -1;
        private bool _isEditMode = false;

        public Add_Edit() : this(-1) { }

        public Add_Edit(int personID)
        {
            InitializeComponent();
            _personID = personID;
            _isEditMode = (_personID != -1);

            LoadCountries();
        }

        public void SetDataForEdit(int personID, string nationalNo, string firstName, string secondName,
                                 string thirdName, string lastName, DateTime dob, int gender,
                                 string address, string phone, string email, int nationalityID,
                                 string imagePath)
        {
            _personID = personID;
            _isEditMode = true;

            lbPersonID.Text = personID.ToString();
            tbNationalNo.Text = nationalNo;
            tbFirstName.Text = firstName;
            tbSecondName.Text = secondName;
            tbThirdName.Text = thirdName;
            tbLastName.Text = lastName;
            //dtpDateOfBirth.Value = dob;
            rbMale.Checked = (gender == 0);
            rbFemale.Checked = (gender == 1);
            tbAddress.Text = address;
            tbPhone.Text = phone;
            tbEmail.Text = email;

            
            if (cbCountry.Items.Count > 0)
            {
                cbCountry.SelectedValue = nationalityID;
            }

            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                pictureBox1.ImageLocation = imagePath;
            }

            //lbTitle.Text = "Edit Person";
            //btnSave.Text = "Update";
        }

     

        private void LoadCountries()
        {
            var countries = new List<KeyValuePair<int, string>>()
{
    new KeyValuePair<int, string>(1, "Afghanistan"),
    new KeyValuePair<int, string>(2, "Albania"),
    new KeyValuePair<int, string>(3, "Algeria"),
    new KeyValuePair<int, string>(4, "Andorra"),
    new KeyValuePair<int, string>(5, "Angola"),
    new KeyValuePair<int, string>(6, "Antigua and Barbuda"),
    new KeyValuePair<int, string>(7, "Argentina"),
    new KeyValuePair<int, string>(8, "Armenia"),
    new KeyValuePair<int, string>(9, "Australia"),
    new KeyValuePair<int, string>(10, "Austria"),
    new KeyValuePair<int, string>(11, "Azerbaijan"),
    new KeyValuePair<int, string>(12, "Bahamas"),
    new KeyValuePair<int, string>(13, "Bahrain"),
    new KeyValuePair<int, string>(14, "Bangladesh"),
    new KeyValuePair<int, string>(15, "Barbados"),
    new KeyValuePair<int, string>(16, "Belarus"),
    new KeyValuePair<int, string>(17, "Belgium"),
    new KeyValuePair<int, string>(18, "Belize"),
    new KeyValuePair<int, string>(19, "Benin"),
    new KeyValuePair<int, string>(20, "Bhutan"),
    new KeyValuePair<int, string>(21, "Bolivia"),
    new KeyValuePair<int, string>(22, "Bosnia and Herzegovina"),
    new KeyValuePair<int, string>(23, "Botswana"),
    new KeyValuePair<int, string>(24, "Brazil"),
    new KeyValuePair<int, string>(25, "Brunei"),
    new KeyValuePair<int, string>(26, "Bulgaria"),
    new KeyValuePair<int, string>(27, "Burkina Faso"),
    new KeyValuePair<int, string>(28, "Burundi"),
    new KeyValuePair<int, string>(29, "Cabo Verde"),
    new KeyValuePair<int, string>(30, "Cambodia"),
    new KeyValuePair<int, string>(31, "Cameroon"),
    new KeyValuePair<int, string>(32, "Canada"),
    new KeyValuePair<int, string>(33, "Central African Republic"),
    new KeyValuePair<int, string>(34, "Chad"),
    new KeyValuePair<int, string>(35, "Chile"),
    new KeyValuePair<int, string>(36, "China"),
    new KeyValuePair<int, string>(37, "Colombia"),
    new KeyValuePair<int, string>(38, "Comoros"),
    new KeyValuePair<int, string>(39, "Congo, Democratic Republic"),
    new KeyValuePair<int, string>(40, "Congo, Republic"),
    new KeyValuePair<int, string>(41, "Costa Rica"),
    new KeyValuePair<int, string>(42, "Croatia"),
    new KeyValuePair<int, string>(43, "Cuba"),
    new KeyValuePair<int, string>(44, "Cyprus"),
    new KeyValuePair<int, string>(45, "Czech Republic"),
    new KeyValuePair<int, string>(46, "Denmark"),
    new KeyValuePair<int, string>(47, "Djibouti"),
    new KeyValuePair<int, string>(48, "Dominica"),
    new KeyValuePair<int, string>(49, "Dominican Republic"),
    new KeyValuePair<int, string>(50, "Ecuador"),
    new KeyValuePair<int, string>(51, "Egypt"),
    new KeyValuePair<int, string>(52, "El Salvador"),
    new KeyValuePair<int, string>(53, "Equatorial Guinea"),
    new KeyValuePair<int, string>(54, "Eritrea"),
    new KeyValuePair<int, string>(55, "Estonia"),
    new KeyValuePair<int, string>(56, "Eswatini"),
    new KeyValuePair<int, string>(57, "Ethiopia"),
    new KeyValuePair<int, string>(58, "Fiji"),
    new KeyValuePair<int, string>(59, "Finland"),
    new KeyValuePair<int, string>(60, "France"),
    new KeyValuePair<int, string>(61, "Gabon"),
    new KeyValuePair<int, string>(62, "Gambia"),
    new KeyValuePair<int, string>(63, "Georgia"),
    new KeyValuePair<int, string>(64, "Germany"),
    new KeyValuePair<int, string>(65, "Ghana"),
    new KeyValuePair<int, string>(66, "Greece"),
    new KeyValuePair<int, string>(67, "Grenada"),
    new KeyValuePair<int, string>(68, "Guatemala"),
    new KeyValuePair<int, string>(69, "Guinea"),
    new KeyValuePair<int, string>(70, "Guinea-Bissau"),
    new KeyValuePair<int, string>(71, "Guyana"),
    new KeyValuePair<int, string>(72, "Haiti"),
    new KeyValuePair<int, string>(73, "Honduras"),
    new KeyValuePair<int, string>(74, "Hungary"),
    new KeyValuePair<int, string>(75, "Iceland"),
    new KeyValuePair<int, string>(76, "India"),
    new KeyValuePair<int, string>(77, "Indonesia"),
    new KeyValuePair<int, string>(78, "Iran"),
    new KeyValuePair<int, string>(79, "Iraq"),
    new KeyValuePair<int, string>(80, "Ireland"),
    new KeyValuePair<int, string>(81, "Israel"),
    new KeyValuePair<int, string>(82, "Italy"),
    new KeyValuePair<int, string>(83, "Jamaica"),
    new KeyValuePair<int, string>(84, "Japan"),
    new KeyValuePair<int, string>(85, "Jordan"),
    new KeyValuePair<int, string>(86, "Kazakhstan"),
    new KeyValuePair<int, string>(87, "Kenya"),
    new KeyValuePair<int, string>(88, "Kiribati"),
    new KeyValuePair<int, string>(89, "Kuwait"),
    new KeyValuePair<int, string>(90, "Kyrgyzstan"),
    new KeyValuePair<int, string>(91, "Laos"),
    new KeyValuePair<int, string>(92, "Latvia"),
    new KeyValuePair<int, string>(93, "Lebanon"),
    new KeyValuePair<int, string>(94, "Lesotho"),
    new KeyValuePair<int, string>(95, "Liberia"),
    new KeyValuePair<int, string>(96, "Libya"),
    new KeyValuePair<int, string>(97, "Liechtenstein"),
    new KeyValuePair<int, string>(98, "Lithuania"),
    new KeyValuePair<int, string>(99, "Luxembourg"),
    new KeyValuePair<int, string>(100, "Madagascar"),
    new KeyValuePair<int, string>(100, "Madagascar"),
    new KeyValuePair<int, string>(101, "Malawi"),
    new KeyValuePair<int, string>(102, "Malaysia"),
    new KeyValuePair<int, string>(103, "Maldives"),
    new KeyValuePair<int, string>(104, "Mali"),
    new KeyValuePair<int, string>(105, "Malta"),
    new KeyValuePair<int, string>(106, "Marshall Islands"),
    new KeyValuePair<int, string>(107, "Mauritania"),
    new KeyValuePair<int, string>(108, "Mauritius"),
    new KeyValuePair<int, string>(109, "Mexico"),
    new KeyValuePair<int, string>(110, "Micronesia"),
    new KeyValuePair<int, string>(111, "Moldova"),
    new KeyValuePair<int, string>(112, "Monaco"),
    new KeyValuePair<int, string>(113, "Mongolia"),
    new KeyValuePair<int, string>(114, "Montenegro"),
    new KeyValuePair<int, string>(115, "Morocco"),
    new KeyValuePair<int, string>(116, "Mozambique"),
    new KeyValuePair<int, string>(117, "Myanmar"),
    new KeyValuePair<int, string>(118, "Namibia"),
    new KeyValuePair<int, string>(119, "Nauru"),
    new KeyValuePair<int, string>(120, "Nepal"),
    new KeyValuePair<int, string>(121, "Netherlands"),
    new KeyValuePair<int, string>(122, "New Zealand"),
    new KeyValuePair<int, string>(123, "Nicaragua"),
    new KeyValuePair<int, string>(124, "Niger"),
    new KeyValuePair<int, string>(125, "Nigeria"),
    new KeyValuePair<int, string>(126, "North Korea"),
    new KeyValuePair<int, string>(127, "North Macedonia"),
    new KeyValuePair<int, string>(128, "Norway"),
    new KeyValuePair<int, string>(129, "Oman"),
    new KeyValuePair<int, string>(130, "Pakistan"),
    new KeyValuePair<int, string>(131, "Palau"),
    new KeyValuePair<int, string>(132, "Palestine"),
    new KeyValuePair<int, string>(133, "Panama"),
    new KeyValuePair<int, string>(134, "Papua New Guinea"),
    new KeyValuePair<int, string>(135, "Paraguay"),
    new KeyValuePair<int, string>(136, "Peru"),
    new KeyValuePair<int, string>(137, "Philippines"),
    new KeyValuePair<int, string>(138, "Poland"),
    new KeyValuePair<int, string>(139, "Portugal"),
    new KeyValuePair<int, string>(140, "Qatar"),
    new KeyValuePair<int, string>(141, "Romania"),
    new KeyValuePair<int, string>(142, "Russia"),
    new KeyValuePair<int, string>(143, "Rwanda"),
    new KeyValuePair<int, string>(144, "Saint Kitts and Nevis"),
    new KeyValuePair<int, string>(145, "Saint Lucia"),
    new KeyValuePair<int, string>(146, "Saint Vincent and the Grenadines"),
    new KeyValuePair<int, string>(147, "Samoa"),
    new KeyValuePair<int, string>(148, "San Marino"),
    new KeyValuePair<int, string>(149, "Sao Tome and Principe"),
    new KeyValuePair<int, string>(150, "Saudi Arabia"),
    new KeyValuePair<int, string>(151, "Senegal"),
    new KeyValuePair<int, string>(152, "Serbia"),
    new KeyValuePair<int, string>(153, "Seychelles"),
    new KeyValuePair<int, string>(154, "Sierra Leone"),
    new KeyValuePair<int, string>(155, "Singapore"),
    new KeyValuePair<int, string>(156, "Slovakia"),
    new KeyValuePair<int, string>(157, "Slovenia"),
    new KeyValuePair<int, string>(158, "Solomon Islands"),
    new KeyValuePair<int, string>(159, "Somalia"),
    new KeyValuePair<int, string>(160, "South Africa"),
    new KeyValuePair<int, string>(161, "South Korea"),
    new KeyValuePair<int, string>(162, "South Sudan"),
    new KeyValuePair<int, string>(163, "Spain"),
    new KeyValuePair<int, string>(164, "Sri Lanka"),
    new KeyValuePair<int, string>(165, "Sudan"),
    new KeyValuePair<int, string>(166, "Suriname"),
    new KeyValuePair<int, string>(167, "Sweden"),
    new KeyValuePair<int, string>(168, "Switzerland"),
    new KeyValuePair<int, string>(169, "Syria"),
    new KeyValuePair<int, string>(170, "Taiwan"),
    new KeyValuePair<int, string>(171, "Tajikistan"),
    new KeyValuePair<int, string>(172, "Tanzania"),
    new KeyValuePair<int, string>(173, "Thailand"),
    new KeyValuePair<int, string>(174, "Timor-Leste"),
    new KeyValuePair<int, string>(175, "Togo"),
    new KeyValuePair<int, string>(176, "Tonga"),
    new KeyValuePair<int, string>(177, "Trinidad and Tobago"),
    new KeyValuePair<int, string>(178, "Tunisia"),
    new KeyValuePair<int, string>(179, "Turkey"),
    new KeyValuePair<int, string>(180, "Turkmenistan"),
    new KeyValuePair<int, string>(181, "Tuvalu"),
    new KeyValuePair<int, string>(182, "Uganda"),
    new KeyValuePair<int, string>(183, "Ukraine"),
    new KeyValuePair<int, string>(184, "United Arab Emirates"),
    new KeyValuePair<int, string>(185, "United Kingdom"),
    new KeyValuePair<int, string>(186, "United States"),
    new KeyValuePair<int, string>(187, "Uruguay"),
    new KeyValuePair<int, string>(188, "Uzbekistan"),
    new KeyValuePair<int, string>(189, "Vanuatu"),
    new KeyValuePair<int, string>(190, "Vatican City"),
    new KeyValuePair<int, string>(191, "Venezuela"),
    new KeyValuePair<int, string>(192, "Vietnam"),
    new KeyValuePair<int, string>(193, "Yemen"),
    new KeyValuePair<int, string>(194, "Zambia"),
    new KeyValuePair<int, string>(195, "Zimbabwe")
};


            cbCountry.DataSource = countries;
            cbCountry.DisplayMember = "Value";
            cbCountry.ValueMember = "Key";
            cbCountry.SelectedValue = 169;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                int genderValue = rbMale.Checked ? 0 : 1;
                string imagePath = pictureBox1.ImageLocation ?? "";

                clsReciveDatabase db = new clsReciveDatabase();

                if (_isEditMode)
                {
                    // Edit existing person
                    db.EditPerson(
                        _personID,
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

                    MessageBox.Show("Person updated successfully! 🎉");
                }
                else
                {
                    // Add new person
                    int personID = db.InsertPerson(
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

                    if (personID > 0)
                    {
                        MessageBox.Show($"Person added successfully! 🎉 PersonID: {personID}");
                        lbPersonID.Text = personID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add person.");
                        return;
                    }
                }

                // Close the parent form
                if (this.ParentForm != null)
                {
                    this.ParentForm.DialogResult = DialogResult.OK;
                    this.ParentForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            // Clear previous errors
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(tbNationalNo.Text))
            {
                errorProvider1.SetError(tbNationalNo, "National Number is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                errorProvider1.SetError(tbFirstName, "First Name is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbSecondName.Text))
            {
                errorProvider1.SetError(tbLastName, "second Name is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                errorProvider1.SetError(tbLastName, "Last Name is required");
                return false;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                errorProvider1.SetError(rbMale, "Please select gender");
                return false;
            }

            if (cbCountry.SelectedValue == null)
            {
                errorProvider1.SetError(cbCountry, "Please select a country");
                return false;
            }

            // Check if national number is unique (only for add mode)
            if (!_isEditMode)
            {
                clsReciveDatabase db = new clsReciveDatabase();
                if (!db.FindNationalNumber(tbNationalNo.Text))
                {
                    errorProvider1.SetError(tbNationalNo, "National Number already exists");
                    return false;
                }
            }

            // Email validation
            if (!string.IsNullOrWhiteSpace(tbEmail.Text) && !tbEmail.Text.EndsWith("@gmail.com"))
            {
                errorProvider1.SetError(tbEmail, "Email should end with @gmail.com");
                return false;
            }

            return true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.DialogResult = DialogResult.Cancel;
                this.ParentForm.Close();
            }
        }

        private void tbNationalNo_TextChanged(object sender, EventArgs e)
        {
            if (!_isEditMode) // Only validate for new entries
            {
                tbNationalNumber_TextChanged(sender, e);
            }
        }

        private bool tbNationalNumber_TextChanged(object sender, EventArgs e)
        {
            bool answer = false;
            clsReciveDatabase rd = new clsReciveDatabase();
            string nationalNo = tbNationalNo.Text;

            if (!string.IsNullOrWhiteSpace(nationalNo))
            {
                if (!rd.FindNationalNumber(nationalNo))
                {
                    errorProvider1.SetError(tbNationalNo, "The National Number already exists");
                }
                else
                {
                    errorProvider1.SetError(tbNationalNo, "");
                    answer = true;
                }
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, "National Number cannot be empty");
            }
            return answer;
        }


        public Person SaveRusult()
        {
            Person p = new Person();

            p.FirstName = tbFirstName.Text;
            p.SecondName = tbSecondName.Text;
            p.ThirdName = tbThirdName.Text;
            p.LastName = tbLastName.Text;
            p.NationalNo = tbNationalNo.Text;
            p.Email = tbEmail.Text;
            p.Phone = tbPhone.Text;
            p.Address = tbAddress.Text;
            p.Gender = rbMale.Checked ? "male" : "female";

            if (DateTime.TryParse(dtpDateOfBirth.Text, out DateTime dob))
                p.DateOfBirth = dob;

            if (int.TryParse(cbCountry.SelectedValue?.ToString(), out int countryId))
                p.NationalityCountryID = countryId;


            return p;
        }



        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)   
            {
                pictureBox1.Image = imageList1.Images[0];
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)   
            {
                pictureBox1.Image = imageList1.Images[1];
            }
        }

    }
}