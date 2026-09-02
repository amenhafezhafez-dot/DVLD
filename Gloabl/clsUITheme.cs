using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace DVLD
{
    /// <summary>
    /// Central light-theme engine for the whole DVLD app.
    /// Call clsUITheme.InstallGlobalHook() once in Program.Main (already done),
    /// and every form that opens is styled automatically:
    ///  - Labels get readable colors based on the background behind them
    ///  - Buttons, TextBoxes, ComboBoxes and DataGridViews get a clean modern look
    ///  - Over-sized forms are clamped to the screen and made scrollable
    /// </summary>
    public static class clsUITheme
    {
        // ---------- Palette (matches the reference image) ----------
        public static readonly Color RoyalBlue = ColorTranslator.FromHtml("#2F5BEA"); // sidebar / primary
        public static readonly Color BlueHover = ColorTranslator.FromHtml("#1E46C8");
        public static readonly Color BlueSoft = ColorTranslator.FromHtml("#E8EEFF"); // selection / soft fill
        public static readonly Color AppBackground = ColorTranslator.FromHtml("#EEF2FB"); // window background
        public static readonly Color CardWhite = Color.White;
        public static readonly Color TextDark = ColorTranslator.FromHtml("#1F2937"); // main text
        public static readonly Color TextMuted = ColorTranslator.FromHtml("#6B7280"); // secondary text
        public static readonly Color InputBg = ColorTranslator.FromHtml("#F3F4F6");
        public static readonly Color BorderColor = ColorTranslator.FromHtml("#E5E7EB");
        public static readonly Color Success = ColorTranslator.FromHtml("#16A34A");
        public static readonly Color Danger = ColorTranslator.FromHtml("#DC2626");
        public static readonly Color Warning = ColorTranslator.FromHtml("#F59E0B");

        public const string FontName = "Segoe UI";

        // ---------- Global hook ----------
        private static readonly HashSet<Form> _hooked = new HashSet<Form>();
        private static readonly HashSet<Form> _themed = new HashSet<Form>();
        private static Timer _watch;

        /// <summary>Starts watching for any form that opens and themes it automatically.</summary>
        public static void InstallGlobalHook()
        {
            if (_watch != null) return;
            _watch = new Timer { Interval = 40 };
            _watch.Tick += (s, e) =>
            {
                foreach (Form f in Application.OpenForms.Cast<Form>().ToArray())
                {
                    if (_hooked.Contains(f)) continue;
                    _hooked.Add(f);

                    f.Shown += (s2, e2) => Apply(f);
                    f.FormClosed += (s2, e2) => { _hooked.Remove(f); _themed.Remove(f); };

                    if (f.Visible && f.IsHandleCreated) Apply(f);
                }
            };
            _watch.Start();
        }

        /// <summary>Applies the full theme to a single form. Safe to call more than once.</summary>
        public static void Apply(Form form)
        {
            if (form == null || form.IsDisposed) return;
            if ((form.Tag as string) == "custom") { FixSizing(form); return; } // opt-out for fully hand-designed forms
            if (_themed.Contains(form)) return;
            _themed.Add(form);

            try
            {
                form.SuspendLayout();
                form.BackColor = AppBackground;
                if (form.Font.Name != FontName) form.Font = new Font(FontName, 9.75f);
                FixSizing(form);
                StyleTree(form.Controls);
                form.ResumeLayout();
                form.Invalidate(true);
            }
            catch { /* never let theming crash the app */ }
        }

        /// <summary>Clamps forms bigger than the screen and turns on scrolling so you can always see everything.</summary>
        public static void FixSizing(Form form)
        {
            try
            {
                Rectangle wa;
                try { wa = Screen.FromControl(form).WorkingArea; }
                catch { wa = Screen.PrimaryScreen.WorkingArea; }

                form.MaximumSize = wa.Size;
                if (form.Width > wa.Width || form.Height > wa.Height)
                    form.Size = new Size(Math.Min(form.Width, wa.Width), Math.Min(form.Height, wa.Height));

                form.AutoScroll = true; // content taller/wider than the window can be scrolled

                if (form.StartPosition == FormStartPosition.WindowsDefaultLocation ||
                    form.StartPosition == FormStartPosition.WindowsDefaultBounds)
                    form.StartPosition = FormStartPosition.CenterScreen;
            }
            catch { }
        }

        // ---------- Recursive styling ----------
        internal static void StyleTree(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                switch (c)
                {
                    case Label lbl: StyleLabel(lbl); break;
                    //case LinkLabel link: link.LinkColor = RoyalBlue; link.ActiveLinkColor = BlueHover; link.Font = new Font(FontName, 9.75f); break;
                    case Button btn: StyleButton(btn); break;
                    case TextBox tb: StyleTextBox(tb); break;
                    case ComboBox cb: StyleCombo(cb); break;
                    case DateTimePicker dt: dt.Font = new Font(FontName, 9.75f); dt.CalendarForeColor = TextDark; break;
                    case DataGridView dgv: StyleGrid(dgv); break;
                    case CheckBox chk: chk.ForeColor = IsDark(EffectiveBg(chk)) ? Color.White : TextDark; chk.Font = new Font(FontName, 9.75f); break;
                    case RadioButton rb: rb.ForeColor = IsDark(EffectiveBg(rb)) ? Color.White : TextDark; rb.Font = new Font(FontName, 9.75f); break;
                    case GroupBox gb: gb.ForeColor = TextDark; gb.Font = new Font(FontName, 10f, FontStyle.Bold); break;
                    case Panel _: break; // keep panels as-is
                }
                if (c.HasChildren) StyleTree(c.Controls);
            }
        }

        /// <summary>يفرض خلفية بيضاء ونصوصًا مقروءة على أي UserControl يُعرض داخل الداشبورد.</summary>
        public static void ApplyToControl(Control root)
        {
            if (root == null) return;
            try
            {
                PaintContainers(root);      // خلفية بيضاء لكل الحاويات في كل المستويات
                StyleTree(root.Controls);   // تنسيق الأزرار/النصوص/الحقول/الجداول
            }
            catch { }
        }

        private static void PaintContainers(Control c)
        {
            bool isContainer = c is Panel || c is UserControl || c is TabPage
                            || c is GroupBox || c is TableLayoutPanel || c is FlowLayoutPanel;

            // أي حاوية، أو أي عنصر خلفيته داكنة → أبيض
            if (isContainer || IsDark(c.BackColor))
            {
                if (!(c is Button) && !(c is TextBox) && !(c is ComboBox) && !(c is DataGridView))
                    c.BackColor = CardWhite;
            }

            foreach (Control child in c.Controls)
                PaintContainers(child);
        }
        private static void StyleLabel(Label lbl)
        {
            // The core fix for "labels don't show because of color":
            // choose white or dark text based on the actual background behind the label.
            Color bg = EffectiveBg(lbl);
            lbl.ForeColor = IsDark(bg) ? Color.White : TextDark;
            if (lbl.Font.Name != FontName)
                lbl.Font = new Font(FontName, lbl.Font.Size, lbl.Font.Style);
        }

        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font(FontName, 9.75f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // Give default/unstyled buttons the primary blue; keep intentional red/green.
            if (btn.BackColor == SystemColors.Control || btn.BackColor == Color.Empty || btn.BackColor == Color.Transparent)
                btn.BackColor = RoyalBlue;

            btn.ForeColor = IsDark(btn.BackColor) ? Color.White : TextDark;

            Color baseColor = btn.BackColor;
            Color hover = Darken(baseColor, 0.10f);
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = baseColor;
        }

        public static void StyleTextBox(TextBox tb)
        {
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.BackColor = InputBg;
            tb.ForeColor = TextDark;
            tb.Font = new Font(FontName, 9.75f);
        }

        public static void StyleCombo(ComboBox cb)
        {
            cb.FlatStyle = FlatStyle.Flat;
            cb.BackColor = InputBg;
            cb.ForeColor = TextDark;
            cb.Font = new Font(FontName, 9.75f);
        }

        public static void StyleGrid(DataGridView g)
        {
            g.EnableHeadersVisualStyles = false;
            g.BackgroundColor = CardWhite;
            g.BorderStyle = BorderStyle.None;
            g.GridColor = BorderColor;
            g.Font = new Font(FontName, 9.5f);
            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToResizeRows = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 42;
            g.RowTemplate.Height = 40;

            g.ColumnHeadersDefaultCellStyle.BackColor = CardWhite;
            g.ColumnHeadersDefaultCellStyle.ForeColor = TextMuted;
            g.ColumnHeadersDefaultCellStyle.Font = new Font(FontName, 9.5f, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);

            g.DefaultCellStyle.BackColor = CardWhite;
            g.DefaultCellStyle.ForeColor = TextDark;
            g.DefaultCellStyle.SelectionBackColor = BlueSoft;
            g.DefaultCellStyle.SelectionForeColor = TextDark;
            g.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            g.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAFBFF");
        }

        // ---------- Public factories (used by DashboardForm) ----------
        public static Button CreateNavButton(string text)
        {
            Button b = new Button
            {
                Text = "   " + text,
                Size = new Size(210, 46),
                BackColor = RoyalBlue,
                ForeColor = Color.FromArgb(225, 232, 255),
                Font = new Font(FontName, 10.5f),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                ImageAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand,
                Padding = new Padding(14, 0, 0, 0)
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = BlueHover;
            b.MouseEnter += (s, e) => b.ForeColor = Color.White;
            b.MouseLeave += (s, e) => { if ((b.Tag as string) != "active") b.ForeColor = Color.FromArgb(225, 232, 255); };
            return b;
        }

        public static Button CreatePrimaryButton(string text)
        {
            Button b = new Button
            {
                Text = text,
                Height = 42,
                BackColor = RoyalBlue,
                ForeColor = Color.White,
                Font = new Font(FontName, 10f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            b.MouseEnter += (s, e) => b.BackColor = BlueHover;
            b.MouseLeave += (s, e) => b.BackColor = RoyalBlue;
            return b;
        }

        public static Panel CreateStatCard(string title, string value, Color accent, bool highlighted)
        {
            Panel card = new Panel
            {
                Size = new Size(210, 118),
                BackColor = highlighted ? RoyalBlue : CardWhite
            };
            Round(card, 16);

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font(FontName, 9.5f, FontStyle.Bold),
                ForeColor = highlighted ? Color.FromArgb(220, 228, 255) : TextMuted,
                AutoSize = true,
                Location = new Point(18, 18),
                BackColor = Color.Transparent
            };
            Label lblValue = new Label
            {
                Text = value,
                Font = new Font(FontName, 26f, FontStyle.Bold),
                ForeColor = highlighted ? Color.White : TextDark,
                AutoSize = true,
                Location = new Point(15, 46),
                BackColor = Color.Transparent
            };
            Panel dot = new Panel
            {
                Size = new Size(10, 10),
                Location = new Point(182, 22),
                BackColor = highlighted ? Color.White : accent
            };
            Round(dot, 5);

            card.Controls.AddRange(new Control[] { lblTitle, lblValue, dot });
            return card;
        }

        // ---------- Helpers ----------
        /// <summary>Rounds a control's corners.</summary>
        public static void Round(Control c, int radius)
        {
            void Build()
            {
                var path = new GraphicsPath();
                int d = radius * 2;
                Rectangle r = c.ClientRectangle;
                if (r.Width <= 0 || r.Height <= 0) return;
                path.AddArc(r.X, r.Y, d, d, 180, 90);
                path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                c.Region = new Region(path);
            }
            Build();
            c.Resize += (s, e) => Build();
        }

        public static Color EffectiveBg(Control c)
        {
            Control p = c.Parent;
            while (p != null)
            {
                if (p.BackColor.A != 0 && p.BackColor != Color.Transparent)
                    return p.BackColor;
                p = p.Parent;
            }
            return AppBackground;
        }

        public static bool IsDark(Color c)
        {
            double lum = 0.299 * c.R + 0.587 * c.G + 0.114 * c.B;
            return lum < 140;
        }

        public static Color Darken(Color c, float amount)
        {
            return Color.FromArgb(c.A,
                (int)(c.R * (1 - amount)),
                (int)(c.G * (1 - amount)),
                (int)(c.B * (1 - amount)));
        }
    }
}