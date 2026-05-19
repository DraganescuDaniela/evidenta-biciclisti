using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CiclistApp
{
    /// <summary>
    /// Tema vizuală verde pentru CiclistApp.
    /// Apelează UITheme.Apply(this) în constructor, după InitializeComponent().
    /// Nu conține Paint events sau owner-draw — compatibil cu VS Designer.
    /// </summary>
    public static class UITheme
    {
        // ── Culori ────────────────────────────────────────────
        public static readonly Color BgForm      = Color.FromArgb(240, 247, 240);  // #F0F7F0
        public static readonly Color BgWhite     = Color.White;
        public static readonly Color GreenAccent = Color.FromArgb(76,  175,  80);  // #4CAF50
        public static readonly Color GreenDark   = Color.FromArgb(46,  125,  50);  // #2E7D32
        public static readonly Color TextDark    = Color.FromArgb(33,   33,  33);  // #212121
        public static readonly Color TextMid     = Color.FromArgb(66,   66,  66);  // #424242
        public static readonly Color TextMuted   = Color.FromArgb(158, 158, 158);  // #9E9E9E
        public static readonly Color BorderGreen = Color.FromArgb(200, 230, 201);  // #C8E6C9

        // ── Fonturi ───────────────────────────────────────────
        public static readonly Font FontBase  = new Font("Segoe UI", 10f, FontStyle.Regular);
        public static readonly Font FontBold  = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI",  9f, FontStyle.Regular);

        // ─────────────────────────────────────────────────────
        public static void Apply(Form form)
        {
            // Nu executa nimic în VS Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            form.BackColor = BgForm;
            form.Font      = FontBase;
            form.ForeColor = TextDark;

            StyleAllControls(form.Controls);
        }

        private static void StyleAllControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                switch (c)
                {
                    case GroupBox gb:
                        gb.BackColor = BgWhite;
                        gb.ForeColor = GreenDark;
                        gb.Font      = FontBold;
                        break;

                    case Button btn:
                        // butoane lăsate default
                        btn.Font = FontBase;
                        break;

                    case TextBox tb:
                        tb.BackColor   = BgWhite;
                        tb.ForeColor   = TextDark;
                        tb.BorderStyle = BorderStyle.FixedSingle;
                        tb.Font        = FontBase;
                        tb.Height      = 30;
                        // highlight la focus
                        tb.Enter += (s, e) => ((TextBox)s).BackColor = Color.FromArgb(232, 245, 233);
                        tb.Leave += (s, e) => ((TextBox)s).BackColor = BgWhite;
                        break;

                    case ComboBox cb:
                        cb.BackColor = BgWhite;
                        cb.ForeColor = TextDark;
                        cb.FlatStyle = FlatStyle.Flat;
                        cb.Font      = FontBase;
                        break;

                    case ListBox lb:
                        lb.BackColor   = BgWhite;
                        lb.ForeColor   = TextDark;
                        lb.BorderStyle = BorderStyle.FixedSingle;
                        lb.Font        = FontBase;
                        lb.ItemHeight  = 26;
                        lb.DrawMode    = DrawMode.OwnerDrawFixed;
                        lb.DrawItem   += ListBox_DrawItem;
                        break;

                    case DataGridView dgv:
                        StyleDataGridView(dgv);
                        break;

                    case PropertyGrid pg:
                        pg.BackColor             = BgWhite;
                        pg.LineColor             = BorderGreen;
                        pg.CategoryForeColor     = GreenDark;
                        pg.CategorySplitterColor = BorderGreen;
                        pg.ViewBackColor         = BgWhite;
                        pg.ViewForeColor         = TextDark;
                        pg.HelpBackColor         = BgForm;
                        pg.HelpForeColor         = TextMuted;
                        break;

                    case Label lbl:
                        lbl.ForeColor  = TextMid;
                        lbl.Font       = FontBase;
                        lbl.BackColor  = Color.Transparent;
                        // label-uri statistici — bold verde
                        if (lbl.Name.StartsWith("lblStart"))
                        {
                            lbl.ForeColor = GreenDark;
                            lbl.Font      = FontBold;
                        }
                        break;
                }

                if (c.HasChildren)
                    StyleAllControls(c.Controls);
            }
        }

        // ── ListBox owner-draw cu padding ─────────────────────
        private static void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var lb       = (ListBox)sender;
            bool selected = (e.State & DrawItemState.Selected) != 0;

            // fundal
            Color bg = selected
                ? Color.FromArgb(232, 245, 233)   // #E8F5E9
                : (e.Index % 2 == 0 ? Color.White : Color.FromArgb(245, 251, 245));
            e.Graphics.FillRectangle(new SolidBrush(bg), e.Bounds);

            // bordură stânga colorată la selecție
            if (selected)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(76, 175, 80)),
                    new Rectangle(e.Bounds.X, e.Bounds.Y, 4, e.Bounds.Height));

            // text cu padding
            Color fg = selected ? Color.FromArgb(27, 94, 32) : Color.FromArgb(33, 33, 33);
            string text = lb.Items[e.Index].ToString();
            e.Graphics.DrawString(text, lb.Font, new SolidBrush(fg),
                new RectangleF(e.Bounds.X + 10, e.Bounds.Y + 4, e.Bounds.Width - 12, e.Bounds.Height));
        }

        // ── DataGridView ──────────────────────────────────────
        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor           = Color.White;
            dgv.BorderStyle               = BorderStyle.None;
            dgv.GridColor                 = Color.FromArgb(200, 230, 201);
            dgv.Font                      = FontBase;
            dgv.RowHeadersVisible         = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(56, 142, 60);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor  = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font       = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding    = new Padding(8, 6, 8, 6);
            dgv.ColumnHeadersHeight                      = 36;
            dgv.ColumnHeadersBorderStyle                 = DataGridViewHeaderBorderStyle.None;

            dgv.DefaultCellStyle.BackColor          = Color.White;
            dgv.DefaultCellStyle.ForeColor          = TextDark;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 245, 233);
            dgv.DefaultCellStyle.SelectionForeColor = GreenDark;
            dgv.DefaultCellStyle.Padding            = new Padding(6, 4, 6, 4);
            dgv.RowTemplate.Height                  = 30;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 250, 242);
        }
    }
}
