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
using YourNamespace;

namespace DVLD
{
    public partial class Start_Form : Form
    {
        public Start_Form()
        {
            InitializeComponent();
            clsUITheme.Apply(this);
            //clsUITheme.MakeCard(cardApplications, 16);
            //clsUITheme.MakeCard(cardDrivers, 16);
            //clsUITheme.MakeCard(cardPeople, 16);
            //clsUITheme.MakeCard(cardUsers, 16);

            // Build the Applications context menu once and wire both left- and right-click.
            // (btnPeople/btnUsers/btnDrivers Click handlers are already wired in the designer.)
            EnsureApplicationsMenu();
            btnApplications.ContextMenuStrip = contextMenuStrip1;
            btnApplications.Click += ShowApplicationsMenu;

            BuildSidebar();
        }

        private void ShowApplicationsMenu(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnApplications, new Point(0, btnApplications.Height));
        }

        private void BuildSidebar()
        {
            var actions = new EventHandler[]
            {
                ShowApplicationsMenu, // 📋 Applications
                btnDrivers_Click,     // 🚗 Drivers
                button1_Click,        // 👤 People
                button2_Click,        // 🔑 Users
                null                  // ⚙ Settings — placeholder
            };
            string[] icons = { "\U0001F4CB", "\U0001F697", "\U0001F464", "\U0001F511", "⚙" };
            string[] tips  = { "Applications", "Drivers", "People", "Users", "Settings" };
            for (int i = 0; i < icons.Length; i++)
            {
                var b = new Button
                {
                    Text = icons[i],
                    Font = new Font("Segoe UI Emoji", 20f, FontStyle.Regular),
                    Size = new Size(75, 75),
                    Location = new Point(30, 45 + i * 93),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(58, 58, 60),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    TabStop = false,
                };
                b.FlatAppearance.BorderSize = 0;
                //b.Region = clsUITheme.RoundedRegion(75, 75, 37);
                var tip = new ToolTip();
                tip.SetToolTip(b, tips[i]);
                if (actions[i] != null) b.Click += actions[i];
                pnlSidebar.Controls.Add(b);
            }
        }

        private bool _appsMenuBuilt = false;
        private void EnsureApplicationsMenu()
        {
            if (_appsMenuBuilt) return;
            _appsMenuBuilt = true;

            ToolStripMenuItem item1 = new ToolStripMenuItem("Driving Licence Services");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Manage Applications");
            ToolStripMenuItem item22 = new ToolStripMenuItem("Detaine License");
            ToolStripMenuItem item3 = new ToolStripMenuItem("Manage Test Type");
            ToolStripMenuItem item4 = new ToolStripMenuItem("Manage Application Type");

            ToolStripMenuItem subItem1 = new ToolStripMenuItem("🆕 New Driving License");
            ToolStripMenuItem subItem2 = new ToolStripMenuItem("🔄 Renew Driving License");
            ToolStripMenuItem subItem3 = new ToolStripMenuItem("📄 Replacement for Lost");
            ToolStripMenuItem subItem33 = new ToolStripMenuItem("📄 Replacement for Damaged");
            ToolStripMenuItem subItem4 = new ToolStripMenuItem("🔓 Release Detained License");
            ToolStripMenuItem subItem5 = new ToolStripMenuItem("🔁 Retake Test");

            ToolStripMenuItem sub2Item1 = new ToolStripMenuItem("Local Licence");
            ToolStripMenuItem subI2tem2 = new ToolStripMenuItem("international Licence");

            ToolStripMenuItem sub3Item1 = new ToolStripMenuItem("Manage Local Licence");
            ToolStripMenuItem sub3Item2 = new ToolStripMenuItem("Manage international Licence");

            ToolStripMenuItem sub22Item1 = new ToolStripMenuItem("Manage Detainted Licences");
            ToolStripMenuItem sub22Item2 = new ToolStripMenuItem("Detainted Licences");
            ToolStripMenuItem sub22Item3 = new ToolStripMenuItem("Relase Detainted Licences");

            item1.DropDownItems.Add(subItem1);
            item1.DropDownItems.Add(subItem2);
            item1.DropDownItems.Add(subItem3);
            item1.DropDownItems.Add(subItem33);
            item1.DropDownItems.Add(subItem4);
            item1.DropDownItems.Add(subItem5);

            item2.DropDownItems.Add(sub3Item1);
            item2.DropDownItems.Add(sub3Item2);

            item22.DropDownItems.Add(sub22Item1);
            item22.DropDownItems.Add(sub22Item2);
            item22.DropDownItems.Add(sub22Item3);

            subItem1.DropDownItems.Add(sub2Item1);
            subItem1.DropDownItems.Add(subI2tem2);

            sub2Item1.Click += Loacal_License_Click;
            subI2tem2.Click += International_License_Click;

            sub22Item1.Click += Manage_Detainted_License;
            sub22Item2.Click += Detainted_License;

            sub3Item1.Click += Manage_Applications_Click;
            sub3Item2.Click += Manage2_Applications_Click;

            subItem2.Click += Renew_License;
            subItem3.Click += Damage_License;
            subItem33.Click += Lost_License;

            item3.Click += Manage_Test_Type_Click;
            item4.Click += Manage_Application_Type_Click;

            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { item1, item2, item22, item3, item4 });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            People_Manage peopleControl = new People_Manage(false);
            form.Size = new Size(1250, 720); 
            form.StartPosition = FormStartPosition.CenterScreen;

            form.Controls.Add(peopleControl);
            peopleControl.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            People_Manage usersControl = new People_Manage(true);
            form.Size = new Size(1250, 720);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Controls.Add(usersControl);
            usersControl.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

       

        private void btnApplications_MouseDown(object sender, MouseEventArgs e)
        {
            // Menu is now built once in the constructor via EnsureApplicationsMenu().
            // Right-click auto-shows through ContextMenuStrip; left-click is handled by ShowApplicationsMenu.
        }

       
        private void Manage_Detainted_License(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            Manage_Detainted control = new Manage_Detainted();
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void Detainted_License(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            Add_Inter_License control = new Add_Inter_License(5);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void Lost_License(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            Add_Inter_License control = new Add_Inter_License(3);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void Damage_License(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            Add_Inter_License control = new Add_Inter_License(4);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }


        private void Renew_License(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            Add_Inter_License control = new Add_Inter_License(2);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void International_License_Click(object sender, EventArgs e )
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            Add_Inter_License control = new Add_Inter_License();
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }


        private void Loacal_License_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Person want to Local License";
            ShowDetails_Filter control = new ShowDetails_Filter(true);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }


        private void Manage_Applications_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Local Applications Manage";
            ShowLDLControl control = new ShowLDLControl();
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }


        private void Manage2_Applications_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Local Applications Manage";
            ShowLDLControl control = new ShowLDLControl(2);
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void Manage_Test_Type_Click(object sennder, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(900, 500);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Manage Test Type";
            Manage_Tests application_Manages = new Manage_Tests();
            form.Controls.Add(application_Manages);
            application_Manages.Dock = DockStyle.Fill;
            form.ShowDialog();

        }


        private void Manage_Application_Type_Click(object sender , EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Application Manages";
            Application_Manages application_Manages = new Application_Manages();
            form.Controls.Add(application_Manages);
            application_Manages.Dock = DockStyle.Fill;
            form.ShowDialog();

        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new Size(1250, 850);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Driving Manage";
            DriversControl d = new DriversControl();
            form.Controls.Add(d);
            d.Dock = DockStyle.Fill;
            form.ShowDialog();

        }

        private void lblCardAppsSub_Click(object sender, EventArgs e)
        {

        }

        private void btnApplications_Click(object sender, EventArgs e)
        {

        }
    }
}
