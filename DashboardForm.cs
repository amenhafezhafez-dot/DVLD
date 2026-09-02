using System;
using System.Drawing;
using System.Windows.Forms;
using YourNamespace;

namespace DVLD
{
    /// <summary>
    /// Modern DVLD dashboard: blue sidebar + header + content host.
    /// Merges every navigation action from the old Start_Form:
    ///  - List/Manage screens open INSIDE the white content area.
    ///  - Multi-step service wizards (New/Renew/Replace/Detained) open as popups,
    ///    exactly like the old dashboard did.
    /// </summary>
    public class DashboardForm : Form
    {
        private Panel sidebar;
        private Panel mainArea;
        private Panel content;
        private Label pageTitle;
        private Button activeNav;
        private ContextMenuStrip applicationsMenu;

        public DashboardForm()
        {
            this.Tag = "custom";
            this.DoubleBuffered = true;
            this.Text = "DVLD — Driver & Vehicle License Department";
            this.Size = new Size(1220, 760);
            this.MinimumSize = new Size(1000, 640);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = clsUITheme.AppBackground;
            this.Font = new Font(clsUITheme.FontName, 9.75f);

            BuildApplicationsMenu();   // the full Applications dropdown from Start_Form
            BuildMainArea();           // Fill first
            BuildSidebar();            // Left after

            ShowHome();
        }

        // ---------------- Sidebar ----------------
        private void BuildSidebar()
        {
            sidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 236,
                BackColor = clsUITheme.RoyalBlue
            };

            Label logo = new Label
            {
                Text = "🚗  DVLD",
                Font = new Font(clsUITheme.FontName, 17f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(22, 26),
                BackColor = Color.Transparent
            };
            sidebar.Controls.Add(logo);

            // (label, action). null action = handled specially (Dashboard / Applications menu)
            var items = new (string text, Action act)[]
            {
                ("Dashboard",           () => ShowHome()),
                ("People",              () => Host("People", new People_Manage(false))),
                ("Users",               () => Host("Users", new People_Manage(true))),
                ("Drivers",             () => Host("Drivers", new DriversControl())),
                ("Applications",        null),   // opens the dropdown menu instead
                ("Manage Local Lic.",   () => Host("Manage Local License", new ShowLDLControl())),
                ("Manage Intl. Lic.",   () => Host("Manage International License", new ShowLDLControl(2))),
                ("Manage Detained",     () => Host("Manage Detained", new Manage_Detainted())),
                ("Manage Tests",        () => Host("Manage Tests", new Manage_Tests())),
                ("Application Types",   () => Host("Application Types", new Application_Manages())),
            };

            int y = 84;
            Button appsButton = null;
            foreach (var it in items)
            {
                Button nav = clsUITheme.CreateNavButton(it.text);
                nav.Location = new Point(13, y);
                nav.Height = 44;

                if (it.text == "Applications")
                {
                    appsButton = nav;
                    nav.Click += (s, e) =>
                    {
                        SetActive(nav);
                        applicationsMenu.Show(nav, new Point(nav.Width, 0)); // fly out to the right
                    };
                }
                else
                {
                    Action a = it.act;
                    nav.Click += (s, e) => { SetActive(nav); a(); };
                }

                sidebar.Controls.Add(nav);
                y += 46;

                if (it.text == "Dashboard") SetActive(nav);
            }

            this.Controls.Add(sidebar);
        }

        // ---------------- Applications dropdown (from Start_Form) ----------------
        private void BuildApplicationsMenu()
        {
            applicationsMenu = new ContextMenuStrip();

            var item1 = new ToolStripMenuItem("Driving Licence Services");
            var item2 = new ToolStripMenuItem("Manage Applications");
            var item22 = new ToolStripMenuItem("Detain License");
            var item3 = new ToolStripMenuItem("Manage Test Type");
            var item4 = new ToolStripMenuItem("Manage Application Type");

            var subNew = new ToolStripMenuItem("🆕 New Driving License");
            var subRenew = new ToolStripMenuItem("🔄 Renew Driving License");
            var subLost = new ToolStripMenuItem("📄 Replacement for Lost");
            var subDamaged = new ToolStripMenuItem("📄 Replacement for Damaged");

            var subLocal = new ToolStripMenuItem("Local Licence");
            var subIntl = new ToolStripMenuItem("International Licence");
            subNew.DropDownItems.Add(subLocal);
            subNew.DropDownItems.Add(subIntl);

            item1.DropDownItems.Add(subNew);
            item1.DropDownItems.Add(subRenew);
            item1.DropDownItems.Add(subLost);
            item1.DropDownItems.Add(subDamaged);

            var manageLocal = new ToolStripMenuItem("Manage Local Licence");
            var manageIntl = new ToolStripMenuItem("Manage International Licence");
            item2.DropDownItems.Add(manageLocal);
            item2.DropDownItems.Add(manageIntl);

            var manageDetained = new ToolStripMenuItem("Manage Detained Licences");
            var detainLicence = new ToolStripMenuItem("Detain Licence");
            item22.DropDownItems.Add(manageDetained);
            item22.DropDownItems.Add(detainLicence);

            // --- wire actions (same targets as Start_Form) ---
            subLocal.Click += (s, e) => Popup("New Local License", new ShowDetails_Filter(true), 1250, 850);
            subIntl.Click += (s, e) => Popup("New International License", new Add_Inter_License(), 1250, 850);
            subRenew.Click += (s, e) => Popup("Renew License", new Add_Inter_License(2), 1250, 850);
            subLost.Click += (s, e) => Popup("Replacement for Lost", new Add_Inter_License(3), 1250, 850);
            subDamaged.Click += (s, e) => Popup("Replacement for Damaged", new Add_Inter_License(4), 1250, 850);

            manageLocal.Click += (s, e) => Host("Manage Local License", new ShowLDLControl());
            manageIntl.Click += (s, e) => Host("Manage International License", new ShowLDLControl(2));

            manageDetained.Click += (s, e) => Host("Manage Detained", new Manage_Detainted());
            detainLicence.Click += (s, e) => Popup("Detain License", new Add_Inter_License(5), 1250, 850);

            item3.Click += (s, e) => Host("Manage Tests", new Manage_Tests());
            item4.Click += (s, e) => Host("Application Types", new Application_Manages());

            applicationsMenu.Items.AddRange(new ToolStripItem[] { item1, item2, item22, item3, item4 });
        }

        // ---------------- Main area ----------------
        private void BuildMainArea()
        {
            mainArea = new Panel { Dock = DockStyle.Fill, BackColor = clsUITheme.AppBackground };

            Panel wrapper = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(24, 6, 24, 24),
                BackColor = clsUITheme.AppBackground
            };
            content = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, AutoScroll = true };
            wrapper.Controls.Add(content);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 74, BackColor = clsUITheme.AppBackground };
            pageTitle = new Label
            {
                Text = "Dashboard",
                Font = new Font(clsUITheme.FontName, 18f, FontStyle.Bold),
                ForeColor = clsUITheme.TextDark,
                AutoSize = true,
                Location = new Point(28, 22),
                BackColor = Color.Transparent
            };
            header.Controls.Add(pageTitle);

            mainArea.Controls.Add(wrapper);
            mainArea.Controls.Add(header);
            this.Controls.Add(mainArea);
        }

        // ---------------- Hosting helpers ----------------
        // Opens a screen INSIDE the white content area.
        private void Host(string title, UserControl uc)
        {
            pageTitle.Text = title;
            content.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            content.Controls.Add(uc);

            ArrangeScreen(uc);

            // افرض الثيم الآن وبعد اكتمال التخطيط
            clsUITheme.ApplyToControl(uc);
            uc.HandleCreated += (s, e) => clsUITheme.ApplyToControl(uc);
            this.BeginInvoke(new Action(() => clsUITheme.ApplyToControl(uc)));

            uc.BringToFront();
        }

        private void Popup(string title, UserControl uc, int w, int h)
        {
            Form form = new Form
            {
                Text = title,
                Size = new Size(w, h),
                StartPosition = FormStartPosition.CenterScreen
            };
            uc.Dock = DockStyle.Fill;
            form.Controls.Add(uc);

            // افرض الثيم بعد أن تظهر النافذة فعليًا
            form.Shown += (s, e) => clsUITheme.ApplyToControl(uc);

            form.ShowDialog();
        }

        // Puts the filter row on top and lets the grid fill the rest (no floating controls).
        private void ArrangeScreen(Control host)
        {
            DataGridView grid = FindGrid(host);
            if (grid == null) return;

            Control parent = grid.Parent;

            var toMove = new System.Collections.Generic.List<Control>();
            foreach (Control c in parent.Controls)
                if (!(c is DataGridView)) toMove.Add(c);

            Panel topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(12, 12, 12, 8)
            };

            int x = 12;
            foreach (Control c in toMove)
            {
                parent.Controls.Remove(c);
                c.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                c.Location = new Point(x, 14);
                topBar.Controls.Add(c);
                x += c.Width + 12;
            }

            grid.Dock = DockStyle.Fill;
            parent.Controls.Add(topBar);
            topBar.Dock = DockStyle.Top;
            grid.BringToFront();
        }

        private DataGridView FindGrid(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is DataGridView g) return g;
                if (c.HasChildren)
                {
                    var found = FindGrid(c);
                    if (found != null) return found;
                }
            }
            return null;
        }

        private void SetActive(Button nav)
        {
            if (activeNav != null)
            {
                activeNav.Tag = null;
                activeNav.BackColor = clsUITheme.RoyalBlue;
                activeNav.ForeColor = Color.FromArgb(225, 232, 255);
            }
            activeNav = nav;
            activeNav.Tag = "active";
            activeNav.BackColor = clsUITheme.BlueHover;
            activeNav.ForeColor = Color.White;
        }

        // ---------------- Home ----------------
        private void ShowHome()
        {
            pageTitle.Text = "Dashboard";
            content.Controls.Clear();

            Label quick = new Label
            {
                Text = "QUICK ACCESS",
                Font = new Font(clsUITheme.FontName, 10f, FontStyle.Bold),
                ForeColor = clsUITheme.TextMuted,
                AutoSize = true,
                Location = new Point(28, 24),
                BackColor = Color.Transparent
            };
            content.Controls.Add(quick);

            var cards = new[]
            {
                new { t = "Total People",   v = "—", c = clsUITheme.RoyalBlue, hi = true  },
                new { t = "Local Licenses", v = "—", c = clsUITheme.Success,   hi = false },
                new { t = "Drivers",        v = "—", c = clsUITheme.Warning,   hi = false },
                new { t = "Applications",   v = "—", c = clsUITheme.Danger,    hi = false },
            };

            int x = 28;
            foreach (var card in cards)
            {
                Panel p = clsUITheme.CreateStatCard(card.t, card.v, card.c, card.hi);
                p.Location = new Point(x, 58);
                content.Controls.Add(p);
                x += 230;
            }
        }
    }
}