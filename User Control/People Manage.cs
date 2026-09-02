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
    public partial class People_Manage : UserControl
    {
        private ContextMenuStrip cms;
        public bool Setting = false;
        List<Person> FilteredPeople;
        List<User> FilteredUser;


        public People_Manage()
        {
            InitializeComponent();
        }

        public People_Manage(bool isUserMode = false)
        {
            InitializeComponent();
           
            Setting = isUserMode;  
            Settings();         
     
            
        }
      

        public void Settings()
        {
            
            if(Setting==false)
            {
                InitializeFilterControls();
                InitializeContextMenu();
                LoadData();
            }
            else
            {
                InitializeFilterControls2();
                InitializeContextMenu2();
                LoadData();
            }
            

        }

        private void InitializeContextMenu()
        {
            cms = new ContextMenuStrip();

            ToolStripMenuItem showDetails = new ToolStripMenuItem("🔍 Show Details");
            ToolStripMenuItem addPerson = new ToolStripMenuItem("➕ Add New Person");
            ToolStripMenuItem editPerson = new ToolStripMenuItem("✏️ Edit");
            ToolStripMenuItem deletePerson = new ToolStripMenuItem("🗑️ Delete");
            ToolStripMenuItem sendEmail = new ToolStripMenuItem("📧 Send Email");
            ToolStripMenuItem phoneCall = new ToolStripMenuItem("📞 Phone Call");

            showDetails.Click += Show_Person_Click;
            editPerson.Click += Edit_Person_Click;
            addPerson.Click += button1_Click;
            deletePerson.Click += Delete_Click;

            cms.Items.AddRange(new ToolStripItem[] {
            showDetails, addPerson, editPerson, deletePerson, sendEmail, phoneCall
        });

            dataGridView1.ContextMenuStrip = cms;
        }

        private void InitializeContextMenu2()
        {
            cms = new ContextMenuStrip();

            ToolStripMenuItem showDetails = new ToolStripMenuItem("🔍 Show Details");
            ToolStripMenuItem addUser = new ToolStripMenuItem("➕ Add New user");
            ToolStripMenuItem editUser = new ToolStripMenuItem("✏️ Edit User");
            ToolStripMenuItem deleteUser = new ToolStripMenuItem("🗑️ Delete User");


            showDetails.Click += Show_User_Click;
            addUser.Click += Add_User_Click ;
            editUser.Click += Edit_User_Click;
            //deletePerson.Click += Delete_Click;

            cms.Items.AddRange(new ToolStripItem[] {
            showDetails, addUser, editUser, deleteUser
        });

            dataGridView1.ContextMenuStrip = cms;
        }

        private void InitializeFilterControls()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] {
                "Person ID", "National Number", "First Name", "Last Name", "Email"
            });
            comboBox1.SelectedIndex = 0;
        }

        private void InitializeFilterControls2()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] {
                "Person ID", "UserID", "UserName", "IsActive"
            });
            comboBox1.SelectedIndex = 0 ;
        }

        private void LoadData()
        {
            try
            {
                clsReciveDatabase db = new clsReciveDatabase();

                if (Setting == false)
                {
                    var people = db.GetPeople();
                    dataGridView1.DataSource = people;
                }
                else
                {
                    var users = db.GetUsers();
                    dataGridView1.DataSource = users;
                 
                }
            
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                }
            }
        }

        private void Show_Person_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int personID = Convert.ToInt32(row.Cells["PersonID"].Value);

                clsReciveDatabase Recive = new clsReciveDatabase();
                Person personList = Recive.FilterByID(personID);

                if (personList != null )
                {
                    Person person = personList;

                    Form detailsForm = new Form();
                    detailsForm.Text = "Person Details";
                    detailsForm.Size = new Size(600, 500);
                    detailsForm.StartPosition = FormStartPosition.CenterScreen;

                    ShowDetails detailsControl = new ShowDetails(personList);
                    detailsControl.SetData(person);
                    detailsControl.Dock = DockStyle.Fill;

                    detailsForm.Controls.Add(detailsControl);
                    detailsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No data found for this person.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

        private void Show_User_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int personID = Convert.ToInt32(row.Cells["PersonID"].Value);

                clsReciveDatabase Recive = new clsReciveDatabase();
                Person personList = Recive.FilterByID(personID);

                if (personList != null)
                {
                    Person person = personList;

                    Form  detailsForm = new Form();
                    detailsForm.BackColor = Color.Black;

                    detailsForm.Text = "Person Details";
                    detailsForm.Size = new Size(600, 500);
                    detailsForm.StartPosition = FormStartPosition.CenterScreen;

                    ShowDetails detailsControl = new ShowDetails();
                    User_Details_Control detailsControl2 = new User_Details_Control(personID);
                    detailsControl.SetData(person);
                    detailsControl.Dock = DockStyle.Fill;

                    TableLayoutPanel tableLayout = new TableLayoutPanel();
                    tableLayout.Dock = DockStyle.Fill;
                    tableLayout.ColumnCount = 1;
                    tableLayout.RowCount = 2;
                    tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                    tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

                    detailsControl.Dock = DockStyle.Fill;
                    detailsControl2.Dock = DockStyle.Fill;

                    tableLayout.Controls.Add(detailsControl, 0, 0);
                    tableLayout.Controls.Add(detailsControl2, 0, 1);


                    detailsForm.Controls.Add(tableLayout);
                    detailsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No data found for this person.");
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int personID = Convert.ToInt32(row.Cells["PersonID"].Value);
            string personName = $"{row.Cells["FirstName"].Value} {row.Cells["LastName"].Value}";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {personName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                clsReciveDatabase db = new clsReciveDatabase();
                if (db.DeletePerson(personID))
                {
                    MessageBox.Show("Person deleted successfully.");
                    // Refresh data
                    dataGridView1.DataSource = db.GetPeople();
                }
                else
                {
                    MessageBox.Show("Failed to delete person.");
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string searchText = Serch.Text ;
            clsReciveDatabase db = new clsReciveDatabase();
            if (Setting == false) // for person
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    dataGridView1.DataSource = db.GetPeople();
                    return;
                }

                clsReciveDatabase dbFilter = new clsReciveDatabase();
                List<Person> filteredPeople = new List<Person>();

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (int.TryParse(searchText, out int personId))
                        {
                            Person p = dbFilter.FilterByID(personId);
                            if (p != null)
                                filteredPeople.Add(p);
                        }
                        break;

                    case 1:
                        Person p2 = dbFilter.FilterByNationalNumber(searchText);
                        if (p2 != null)
                            filteredPeople.Add(p2);
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
                {
                    

                    dataGridView1.DataSource = db.GetPeople();
                }
                else
                {
                    dataGridView1.DataSource = filteredPeople;
                }
                FilteredPeople = filteredPeople;
            }

            else // for user
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    dataGridView1.DataSource = db.GetUsers();
                    return;
                }

                List<User> filteredUsers = new List<User>(); 

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (int.TryParse(searchText, out int personId))
                        {
                            List<User> users = db.FindUserByPersonID(personId);
                            if (users != null && users.Count > 0)
                                filteredUsers.AddRange(users);
                        }
                        break;

                    case 1:
                        if (int.TryParse(searchText, out int userId))
                        {
                            List<User> users = db.FindByUserID(userId);
                            if (users != null && users.Count > 0)
                                filteredUsers.AddRange(users);
                        }
                        break;

                    case 2: 
                        List<User> usersByName = db.FindUserByUserName(searchText);
                        if (usersByName != null)
                            filteredUsers.AddRange(usersByName);
                        break;

                    case 3: 
                        if (int.TryParse(searchText, out int activeStatus))
                        {

                            if (activeStatus == 0 || activeStatus == 1)
                            {
                                List<User> usersByActive = db.FindUserByIsActive(activeStatus);
                                if (usersByActive != null)
                                    filteredUsers.AddRange(usersByActive);
                            }
                        }
                        break;

                      
                }

               
                if (filteredUsers == null || filteredUsers.Count == 0)
                {
        
                    dataGridView1.DataSource = db.GetUsers();
                 
                }
                else
                {
                    
                    dataGridView1.DataSource = filteredUsers;
                }

                FilteredUser = filteredUsers; 
            }

        }

        private void btnFilter_Click2()
        {
            string searchText = Serch.Text;
            clsReciveDatabase db = new clsReciveDatabase();

            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView1.DataSource = db.GetUsers(); // استدعاء جميع المستخدمين
                return ;
            }

            List<User> filteredUsers = new List<User>();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (int.TryParse(searchText, out int userId))
                        filteredUsers = db.FindUserByPersonID(userId);
                    break;
                case 1:
                    filteredUsers = db.FindByUserID(Convert.ToInt32(searchText));
                    break;
                case 2:
                    filteredUsers = db.FindUserByUserName(searchText);
                    break;
                case 3:
                    filteredUsers = db.FindUserByIsActive(Convert.ToInt32(searchText));
                    break;
                
            }

            if (filteredUsers == null || filteredUsers.Count == 0)
            {
                MessageBox.Show("⚠️ لا توجد نتائج مطابقة للبحث!");
                dataGridView1.DataSource = db.GetUsers();

            }
            else
            {
                
                MessageBox.Show($"✅ تم العثور على {filteredUsers.Count} نتيجة");
                //return filteredUsers; 
                dataGridView1.DataSource = filteredUsers;
            }
            //return null; 
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFilter_Click(sender, e);
                e.Handled = true;
            }
        }

        private void Edit_Person_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            // Extract data from selected row
            int personID = Convert.ToInt32(row.Cells["PersonID"].Value);
            string nationalNo = row.Cells["NationalNo"].Value.ToString();
            string firstName = row.Cells["FirstName"].Value.ToString();
            string secondName = row.Cells["SecondName"].Value.ToString();
            string thirdName = row.Cells["ThirdName"].Value.ToString();
            string lastName = row.Cells["LastName"].Value.ToString();
            DateTime dob = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);

            // Fix gender conversion
            int gender;
            object genderValue = row.Cells["Gender"].Value;
            if (genderValue is string genderStr)
            {
                gender = genderStr.ToLower() == "male" ? 0 : 1;
            }
            else
            {
                gender = Convert.ToInt32(genderValue);
            }

            string address = row.Cells["Address"].Value.ToString();
            string phone = row.Cells["Phone"].Value.ToString();
            string email = row.Cells["Email"].Value?.ToString() ?? string.Empty;
            int nationalityID = Convert.ToInt32(row.Cells["NationalityCountryID"].Value);
            string imagePath = row.Cells["ImagePath"].Value?.ToString() ?? string.Empty;

            // Create edit control
            Add_Edit editControl = new Add_Edit(personID) // Pass personID for edit mode
            {
                Dock = DockStyle.Fill
            };


            editControl.SetDataForEdit(personID, nationalNo, firstName, secondName, thirdName,
                                     lastName, dob, gender, address, phone, email,
                                     nationalityID, imagePath);

           
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

            if (result == DialogResult.OK)
            {
                // Refresh data
                clsReciveDatabase db = new clsReciveDatabase();
                dataGridView1.DataSource = db.GetPeople();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Setting == false)
            {
                Form addForm = new Form();
                addForm.Text = "Add New Person";
                addForm.Size = new Size(800, 600);
                addForm.StartPosition = FormStartPosition.CenterScreen;

                Add_Edit addControl = new Add_Edit();
                addControl.Dock = DockStyle.Fill;

                addForm.Controls.Add(addControl);
                DialogResult result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    clsReciveDatabase db = new clsReciveDatabase();
                    dataGridView1.DataSource = db.GetPeople();
                }
            }
            else
            {
                Form addForm = new Form();
                addForm.Text = "Add New User";
                addForm.Size = new Size(800, 600);
                addForm.StartPosition = FormStartPosition.CenterScreen;

                ShowDetails_Filter addControl = new ShowDetails_Filter();
                addControl.Dock = DockStyle.Fill;

                addForm.Controls.Add(addControl);
                DialogResult result = addForm.ShowDialog();
               
            }
           
        }

        private void Add_User_Click(object sender, EventArgs e)
        {

            Form addForm = new Form();
            addForm.Text = "Add New User";
            addForm.Size = new Size(800, 600);
            addForm.StartPosition = FormStartPosition.CenterScreen;

            ShowDetails_Filter addControl = new ShowDetails_Filter();
            addControl.Dock = DockStyle.Fill;

            addForm.Controls.Add(addControl);
            DialogResult result = addForm.ShowDialog();


            if (result == DialogResult.OK)
            {
          
                clsReciveDatabase db = new clsReciveDatabase();
                dataGridView1.DataSource = db.GetPeople();
            }
        }

        private void Edit_User_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // استخراج قيمة الـ PersonID من الصف المحدد
                int personID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PersonID"].Value);

                // فتح النموذج وتعديل المستخدم
                Form form = new Form();
                Edit_User_only editForm = new Edit_User_only(personID);
                editForm.Text = "Edit User";
                editForm.Size = new Size(800, 600);
                //editForm.StartPosition = FormStartPosition.CenterScreen;
                form.Controls.Add(editForm);
                form.ShowDialog(); // عرض النموذج كمربع حوار
            }
            else
            {
                MessageBox.Show("يرجى تحديد صف من الجدول أولاً");
            }
        }

        public List<Person> Click()
        {
            if (string.IsNullOrEmpty(Serch.Text))
            {
                clsReciveDatabase db = new clsReciveDatabase();
                var allPeople = db.GetPeople();
                dataGridView1.DataSource = allPeople;
                FilteredPeople = allPeople; // ✅ هذا السطر ضروري
                return null ;
            }

            btnFilter_Click(this,EventArgs.Empty);
            return FilteredPeople;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnFilter_Click2();
        }

        private void Serch_TextChanged(object sender, EventArgs e)
        {
            btnFilter_Click(sender, e);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int rowCount = dataGridView1.Rows.Count;
            NumberOfRows.Text = rowCount.ToString();
        }
    }
}