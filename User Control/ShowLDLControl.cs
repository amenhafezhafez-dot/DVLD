using DataBase;
using DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace YourNamespace
{
    public partial class ShowLDLControl : UserControl
    {
        public ShowLDLControl(int i=1)
        {
            InitializeComponent();
            if (i == 1)
            {
                FillComboBox();
                SetupDataGridView();
                LoadData();
                SetupContextMenu();
            }
            else
            {
                SetupDataGridView_International();
                LoadData_International();
                SetupContextMenu_International();
            }
        }

        private string National = "";
        private List<LocalDriving> _allLDL = new List<LocalDriving>();

        public ShowLDLControl(string national)
        {
            National = national;
            InitializeComponent();
            FillComboBox();
            SetupDataGridView();
            LoadData();
            SetupContextMenu();
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(LocalDriving.L_D_L_AppID),
                DataPropertyName = nameof(LocalDriving.L_D_L_AppID)
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(LocalDriving.DrivingClass),
                DataPropertyName = nameof(LocalDriving.DrivingClass)
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(LocalDriving.NationalNo),
                DataPropertyName = nameof(LocalDriving.NationalNo)
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(LocalDriving.FullName),
                DataPropertyName = nameof(LocalDriving.FullName)
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(LocalDriving.ApplicationDate),
                DataPropertyName = nameof(LocalDriving.ApplicationDate)
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(LocalDriving.PassedRusult),
                DataPropertyName = nameof(LocalDriving.PassedRusult)
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(LocalDriving.Status),
                DataPropertyName = nameof(LocalDriving.Status)
            });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.MouseDown += DataGridView1_MouseDown;
        }

        private void SetupDataGridView_International()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(InternationalLicense.InternationalLicenseID),
                DataPropertyName = nameof(InternationalLicense.InternationalLicenseID),
                HeaderText = "International License ID"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(InternationalLicense.ApplicationID),
                DataPropertyName = nameof(InternationalLicense.ApplicationID),
                HeaderText = "Application ID"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(InternationalLicense.DriverID),
                DataPropertyName = nameof(InternationalLicense.DriverID),
                HeaderText = "Driver ID"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(InternationalLicense.IssuedUsingLocalLicenseID),
                DataPropertyName = nameof(InternationalLicense.IssuedUsingLocalLicenseID),
                HeaderText = "Local License ID"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(InternationalLicense.IssueDate),
                DataPropertyName = nameof(InternationalLicense.IssueDate),
                HeaderText = "Issue Date"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(InternationalLicense.ExpirationDate),
                DataPropertyName = nameof(InternationalLicense.ExpirationDate),
                HeaderText = "Expiration Date"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(InternationalLicense.IsActive),
                DataPropertyName = nameof(InternationalLicense.IsActive),
                HeaderText = "Active"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(InternationalLicense.CreatedByUserID),
                DataPropertyName = nameof(InternationalLicense.CreatedByUserID),
                HeaderText = "Created By User"
            });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.MouseDown += DataGridView1_MouseDown;
        }

        private void FillComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(nameof(LocalDriving.L_D_L_AppID));
            comboBox1.Items.Add(nameof(LocalDriving.NationalNo));
            comboBox1.Items.Add(nameof(LocalDriving.DrivingClass));
            comboBox1.Items.Add(nameof(LocalDriving.FullName));
            comboBox1.Items.Add(nameof(LocalDriving.ApplicationDate));
            comboBox1.Items.Add(nameof(LocalDriving.PassedRusult));
            comboBox1.Items.Add(nameof(LocalDriving.Status));
        }


        private void LoadData()
        {
            try
            {
                clsReciveDatabase db = new clsReciveDatabase();
                _allLDL = db.GetAllLDL() ?? new List<LocalDriving>();
                RenderLDL(_allLDL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }
        }

        private void RenderLDL(List<LocalDriving> list)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(
                    item.L_D_L_AppID,
                    item.DrivingClass,
                    item.NationalNo,
                    item.FullName,
                    item.ApplicationDate.ToString("yyyy-MM-dd"),
                    item.PassedRusult,
                    item.Status
                );
            }
        }


        private void LoadData_International()
        {
            try
            {
                clsReciveDatabase db = new clsReciveDatabase();
                List<InternationalLicense> data = db.GetAllInternationalLicenses();

                dataGridView1.Rows.Clear();

                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(
                        item.InternationalLicenseID,
                        item.ApplicationID,
                        item.DriverID,
                        item.IssuedUsingLocalLicenseID,
                        item.IssueDate.ToString("yyyy-MM-dd"),
                        item.ExpirationDate.ToString("yyyy-MM-dd"),
                        item.IsActive ? "Yes" : "No",
                        item.CreatedByUserID
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل بيانات الرخص الدولية: " + ex.Message);
            }
        }



        private void ReloadGrid()
        {
            try
            {
                clsReciveDatabase db = new clsReciveDatabase();
                List<LocalDriving> data = db.GetAllLDL() ?? new List<LocalDriving>();

                dataGridView1.DataSource = null;   // في حال كان الجدول مربوطًا من بحث سابق
                dataGridView1.Rows.Clear();

                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(
                        item.L_D_L_AppID,
                        item.DrivingClass,
                        item.NationalNo,
                        item.FullName,
                        item.ApplicationDate.ToString("yyyy-MM-dd"),
                        item.PassedRusult,
                        item.Status
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }
        }


        private void btnSerch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Serch.Text))
            {
                RenderLDL(_allLDL);
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار عمود البحث أولاً.");
                return;
            }

            string searchText = Serch.Text.Trim();
            string column = comboBox1.SelectedItem.ToString();
            List<LocalDriving> filtered;

            switch (column)
            {
                case nameof(LocalDriving.L_D_L_AppID):
                    filtered = _allLDL.Where(x =>
                        x.L_D_L_AppID.ToString().Contains(searchText)).ToList();
                    break;

                case nameof(LocalDriving.NationalNo):
                    filtered = _allLDL.Where(x =>
                        (x.NationalNo ?? "").IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;

                case nameof(LocalDriving.DrivingClass):
                    filtered = _allLDL.Where(x =>
                        (x.DrivingClass ?? "").IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;

                case nameof(LocalDriving.FullName):
                    filtered = _allLDL.Where(x =>
                        (x.FullName ?? "").IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;

                case nameof(LocalDriving.Status):
                    filtered = _allLDL.Where(x =>
                        (x.Status ?? "").IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;

                case nameof(LocalDriving.PassedRusult):
                    filtered = _allLDL.Where(x =>
                        x.PassedRusult.ToString() == searchText).ToList();
                    break;

                case nameof(LocalDriving.ApplicationDate):
                    if (!DateTime.TryParse(searchText, out DateTime appDate))
                    {
                        MessageBox.Show("صيغة التاريخ غير صحيحة. استخدم صيغة مثل 2025-08-31.");
                        return;
                    }
                    filtered = _allLDL.Where(x => x.ApplicationDate.Date == appDate.Date).ToList();
                    break;

                default:
                    MessageBox.Show("عمود البحث غير معروف.");
                    return;
            }

            RenderLDL(filtered);

            if (filtered.Count == 0)
                MessageBox.Show("لا توجد نتائج مطابقة للبحث.");
        }

        private void SetupContextMenu()
        {
            

            ToolStripMenuItem item1 = new ToolStripMenuItem("Cancelled");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Sechdule Tests");

            ToolStripMenuItem SubItem1 = new ToolStripMenuItem("Sechdule Vision Test");
            ToolStripMenuItem Subitem2 = new ToolStripMenuItem("Sechdule Written Test");
            ToolStripMenuItem Subitem3 = new ToolStripMenuItem("Sechdule Street Test");

            ToolStripMenuItem item3 = new ToolStripMenuItem("Show Person License History");
            ToolStripMenuItem item4 = new ToolStripMenuItem("Issue Driving License (First Time)");

            ToolStripMenuItem item5 = new ToolStripMenuItem("Person ID");
            ToolStripMenuItem item6 = new ToolStripMenuItem("Delete Licence");
            ToolStripMenuItem item7 = new ToolStripMenuItem("Edite Licence");



            item1.Click += Cancelled;

            item2.DropDownItems.Add(SubItem1);
            item2.DropDownItems.Add(Subitem2);
            item2.DropDownItems.Add(Subitem3);

          

            SubItem1.Click += (s, e) => Sechdule_Vision(s, e, 1);
            Subitem2.Click += (s, e) => Sechdule_Vision(s, e, 2);
            Subitem3.Click += (s, e) => Sechdule_Vision(s, e, 3);

            item3.Click += Issue_Driving_License2;
            item4.Click += Issue_Driving_License;

            item5.Click += Issue_PersonID;

            item6.Click += Issue_PersonID;
            item7.Click += Issue_PersonID;


            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { item1, item2 , item3 , item4 , item5 , item6 , item7});
            contextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void SetupContextMenu_International()
        {


            ToolStripMenuItem item1 = new ToolStripMenuItem("Show Person Details");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Show License Details");
            ToolStripMenuItem item3 = new ToolStripMenuItem("Show Person License History");


             item1.Click += Show_Person;
             item2.Click += Show_License ;
             item3.Click += Show_History;


            contextMenuStrip2.Items.Clear();
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { item1, item2, item3 });
         //   contextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            dataGridView1.ContextMenuStrip = contextMenuStrip2;
        }

        private void Show_Person(object sender, EventArgs e)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
      
            int DriverID = Convert.ToInt32(selectedRow.Cells["DriverID"].Value);
            Person P = clsReciveDatabase.FindPersonFromDriverID(DriverID);
            //
            //Person P = clsReciveDatabase.Fil
            // ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen

            Form form = new Form();
            form.Size = new Size(600, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person Details";
       //     string National = selectedRow.Cells["NationalNo"].Value.ToString();
            ShowDetails control = new ShowDetails(P); //, classtype, personID, type);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
            ReloadGrid();


        }

        private void Show_License(object sender, EventArgs e)
        {
            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int InternationalLicenseID = Convert.ToInt32(selectedRow.Cells["InternationalLicenseID"].Value);

            int DriverID = Convert.ToInt32(selectedRow.Cells["DriverID"].Value);

            Person p = clsReciveDatabase.FindPersonFromDriverID(DriverID);
            InternationalLicense l = clsReciveDatabase.GetInternationalLicenseByID(InternationalLicenseID);

            Form form = new Form();
            form.Size = new Size(600, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Suchdule Test Appoinments";
           
            Local_License_ID control = new Local_License_ID(l , p); 
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
            ReloadGrid();


        }

        private void Show_History(object sender, EventArgs e)
        {

            clsReciveDatabase clsReciveDatabase = new clsReciveDatabase();

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int DriverID = Convert.ToInt32(selectedRow.Cells["DriverID"].Value);
            Person p = clsReciveDatabase.FindPersonFromDriverID(DriverID);

            Form form = new Form();
            form.Size = new Size(800, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";

            Panel topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = form.Height / 2;

            ShowDetails control = new ShowDetails(p);
            control.Dock = DockStyle.Fill;
            topPanel.Controls.Add(control);

            // 🔹 البانل التحتاني (فيه History_Liceses)
            Panel bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Fill; // ياخد الباقي من الفورم

            History_Liceses H = new History_Liceses(DriverID);
            H.Dock = DockStyle.Fill;
            bottomPanel.Controls.Add(H);

            // 🔹 نضيف البانلين للفورم
            form.Controls.Add(bottomPanel);
            form.Controls.Add(topPanel);

            form.ShowDialog();
            ReloadGrid();




        }


        private void Issue_Driving_License2(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int AppID = Convert.ToInt32(selectedRow.Cells["L_D_L_AppID"].Value);

            // ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen ameen

            Form form = new Form();
            form.Size = new Size(600, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Suchdule Test Appoinments";
            string National = selectedRow.Cells["NationalNo"].Value.ToString() ;
            Show_Driving_License control = new Show_Driving_License(AppID , National); //, classtype, personID, type);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
            ReloadGrid();


        }

        private void Issue_Driving_License(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            string nationalNo = dataGridView1.SelectedRows[0].Cells["NationalNo"].Value.ToString();
            clsReciveDatabase db = new clsReciveDatabase();
            Person p = db.FilterByNationalNumber(nationalNo);



            int personId = p.PersonID;

          


            string drivingClass = dataGridView1.SelectedRows[0].Cells["DrivingClass"].Value.ToString();

            int classTypeId = -1;
            switch (drivingClass)
            {
                case "Class 1 - Small Motorcycle":
                    classTypeId = 1;
                    break;
                case "Class 2 - Heavy Motorcycle License":
                    classTypeId = 2;
                    break;
                case "Class 3 - Ordinary driving license":
                    classTypeId = 3;
                    break;
                case "Class 4 - Commercial":
                    classTypeId = 4;
                    break;
                case "Class 5 - Agricultural":
                    classTypeId = 5;
                    break;
                case "Class 6 - Small and medium bus":
                    classTypeId = 6;
                    break;
                case "Class 7 - Truck and heavy vehicle":
                    classTypeId = 7;
                    break;
                default:
                    MessageBox.Show("⚠ نوع الكلاس غير معروف!");
                    return;
            }
            

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int AppID = Convert.ToInt32(selectedRow.Cells["L_D_L_AppID"].Value); //.ToString();


                LocalDriving L = db.FindLDLByAppID(AppID);

                if (L != null)
                {
                    Show_Licence_History(L, classTypeId, personId);
                    ReloadGrid();

                }
            }
        }


        private void Issue_PersonID(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            String personID = row.Cells[2].Value.ToString();

            clsReciveDatabase Recive = new clsReciveDatabase();
            Person personList = Recive.FilterByNationalNumber(personID);

            if (personList != null)// && personList.Count > 0)
            {
                //Person person = personList[0];

                // Create a form to show details
                Form detailsForm = new Form();
                
                detailsForm.Text = "Person Details";
                detailsForm.Size = new Size(600, 500);
                detailsForm.StartPosition = FormStartPosition.CenterScreen;

                ShowDetails detailsControl = new ShowDetails();
                detailsControl.SetData(personList);
                detailsControl.Dock = DockStyle.Fill;

                detailsForm.Controls.Add(detailsControl);
                detailsForm.ShowDialog();
                ReloadGrid();

            }
        }

        private void Show_Licence_History(LocalDriving L, int classtype, int personID)
        {
            Form form = new Form();
            form.Size = new Size(600, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Suchdule Test Appoinments";
            IDDriver control = new IDDriver(L , classtype , personID); //, classtype, personID, type);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();

        }

        private void Show(LocalDriving L , int classtype , int personID  , int type)
        {
            Form form = new Form();
            form.Size = new Size(600, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Suchdule Test Appoinments";
            Vision_Test_Appoinment control = new Vision_Test_Appoinment(L , classtype,personID , type);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();

        }

        private void Sechdule_Vision(object sender, EventArgs e , int type)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            string nationalNo = dataGridView1.SelectedRows[0].Cells["NationalNo"].Value.ToString();
            clsReciveDatabase db = new clsReciveDatabase();
            Person p = db.FilterByNationalNumber(nationalNo);

          

            int personId = p.PersonID;  


            string drivingClass = dataGridView1.SelectedRows[0].Cells["DrivingClass"].Value.ToString();

            int classTypeId = 0;
            switch (drivingClass)
            {
                case "Class 1 - Small Motorcycle":
                    classTypeId = 1;
                    break;
                case "Class 2 - Heavy Motorcycle License":
                    classTypeId = 2;
                    break;
                case "Class 3 - Ordinary driving license":
                    classTypeId = 3;
                    break;
                case "Class 4 - Commercial":
                    classTypeId = 4;
                    break;
                case "Class 5 - Agricultural":
                    classTypeId = 5;
                    break;
                case "Class 6 - Small and medium bus":
                    classTypeId = 6;
                    break;
                case "Class 7 - Truck and heavy vehicle":
                    classTypeId = 7;
                    break;
                default:
                    MessageBox.Show("⚠ نوع الكلاس غير معروف!");
                    return;
            }


            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int AppID = Convert.ToInt32(selectedRow.Cells["L_D_L_AppID"].Value); //.ToString();

                
                LocalDriving L = db.FindLDLByAppID(AppID);

                if (L != null)
                {
                    Show(L , classTypeId , personId  ,type);
                }
            }

        }

       

        private void Subitem2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dataGridView1.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;
                }
            }
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            string status = selectedRow.Cells["Status"].Value?.ToString();
            int Passed = Convert.ToInt32(selectedRow.Cells["PassedRusult"].Value ?? 0);
            string nationalNo = selectedRow.Cells["NationalNo"].Value?.ToString();

            clsReciveDatabase db = new clsReciveDatabase();
            Person p = db.FilterByNationalNumber(nationalNo);
            if (p == null)
            {
                e.Cancel = true;
                return;
            }
            int personId = p.PersonID;
            bool h = clsReciveDatabase.HasDataInDriversDataBase(personId);

            var cancelledItem = contextMenuStrip1.Items[0];      // Cancelled
            var scheduleTestsItem = contextMenuStrip1.Items[1];  // Schedule Tests
            var Issue = contextMenuStrip1.Items[3];              // Issue License (First Time)

            // الشرط الصحيح: ليس سائقًا بعد + نجح في 3 اختبارات + الحالة New
            Issue.Enabled = (!h && Passed == 3 && status == "New");

            bool finished = (status == "Cancelled" || status == "Completed");
            cancelledItem.Enabled = !finished;
            scheduleTestsItem.Enabled = !finished;
        }
        private void Cancelled(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0) return;
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string status = selectedRow.Cells["Status"].Value?.ToString();

            if (status == "Cancelled")
            {
               
            }


            if (dataGridView1.SelectedRows.Count > 0)
            {
               
                int AppID = Convert.ToInt32(selectedRow.Cells["L_D_L_AppID"].Value); //.ToString();

                clsReciveDatabase db = new clsReciveDatabase();
                LocalDriving L = db.FindLDLByAppID(AppID);

                if (L != null)
                {
                    L.Status = "Cancelled";
                    bool updated = db.UpdateLocalDriving(
                        L.L_D_L_AppID,
                        L.FullName,
                        L.NationalNo,
                        L.DrivingClass,
                        L.ApplicationDate,
                        L.PassedRusult,
                        L.Status
                    );


                    if (updated)
                    {
                        MessageBox.Show("✅ تم تغيير الحالة إلى Cancelled");
                        ReloadGrid(); 
                    }
                    else
                    {
                        MessageBox.Show("❌ ما تم تحديث الحالة");
                    }
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            else
            {
                MessageBox.Show("⚠️ لازم تختار صف أولاً!");
            }

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(800, 600);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            ShowDetails_Filter control = new ShowDetails_Filter(true);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void Serch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
