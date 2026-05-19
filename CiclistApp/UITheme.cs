using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CiclistApp
{
    public static class UITheme
    {
        // ── Paletă verde ──────────────────────────────────────
        public static readonly Color Green1       = Color.FromArgb(34,  139,  86);   // accent principal
        public static readonly Color Green2       = Color.FromArgb(22,  101,  60);   // accent hover / dark
        public static readonly Color GreenLight   = Color.FromArgb(220, 245, 230);   // fundal subtil
        public static readonly Color GreenMid     = Color.FromArgb(180, 225, 200);   // borduri
        public static readonly Color Danger       = Color.FromArgb(211,  47,  47);
        public static readonly Color DangerHover  = Color.FromArgb(160,  20,  20);
        public static readonly Color BgForm       = Color.FromArgb(240, 248, 243);
        public static readonly Color BgCard       = Color.White;
        public static readonly Color TextPrimary  = Color.FromArgb(20,  50,  30);
        public static readonly Color TextMuted    = Color.FromArgb(100, 130, 110);

        // ── Fonturi ───────────────────────────────────────────
        public static readonly Font FontBase  = new Font("Segoe UI",  9.5f, FontStyle.Regular);
        public static readonly Font FontBold  = new Font("Segoe UI", 10f,   FontStyle.Bold);
        public static readonly Font FontTitle = new Font("Segoe UI", 12f,   FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI",  8.5f, FontStyle.Regular);

        // ─────────────────────────────────────────────────────
        public static void Apply(Form form)
        {
            form.BackColor = BgForm;
            form.Font      = FontBase;
            form.ForeColor = TextPrimary;
            PaintFormGradient(form);
            ApplyControls(form.Controls);
        }

        // ── Gradient pe fundal formei ─────────────────────────
        private static void PaintFormGradient(Form form)
        {
            form.Paint += (s, e) =>
            {
                using (var brush = new LinearGradientBrush(
                    form.ClientRectangle,
                    Color.FromArgb(235, 250, 240),
                    Color.FromArgb(210, 240, 225),
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, form.ClientRectangle);
                }
            };
        }

        // ─────────────────────────────────────────────────────
        private static void ApplyControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                switch (c)
                {
                    case GroupBox gb:   StyleGroupBox(gb);       break;
                    case Button btn:    StyleButton(btn);        break;
                    case TextBox tb:    StyleTextBox(tb);        break;
                    case ComboBox cb:   StyleComboBox(cb);       break;
                    case ListBox lb:    StyleListBox(lb);        break;
                    case DataGridView dgv: StyleDataGridView(dgv); break;
                    case PropertyGrid pg:  StylePropertyGrid(pg);  break;
                    case Label lbl:
                        lbl.ForeColor = TextPrimary;
                        lbl.Font      = FontBase;
                        lbl.BackColor = Color.Transparent;
                        break;
                }

                if (c.HasChildren)
                    ApplyControls(c.Controls);
            }
        }

        // ── GroupBox cu colțuri rotunjite + shadow simulat ────
        private static void StyleGroupBox(GroupBox gb)
        {
            gb.ForeColor  = Green1;
            gb.Font       = FontBold;
            gb.BackColor  = Color.Transparent;
            gb.FlatStyle  = FlatStyle.Flat;
            gb.Padding    = new Padding(10, 14, 10, 10);

            gb.Paint += (s, e) =>
            {
                var g   = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var rc = new Rectangle(2, 12, gb.Width - 5, gb.Height - 15);

                // shadow
                using (var shadow = new SolidBrush(Color.FromArgb(18, 0, 0, 0)))
                {
                    var sr = new Rectangle(rc.X + 3, rc.Y + 3, rc.Width, rc.Height);
                    FillRoundRect(g, shadow, sr, 12);
                }

                // card bianco
                using (var fill = new SolidBrush(BgCard))
                    FillRoundRect(g, fill, rc, 12);

                // bordură verde subtilă
                using (var pen = new Pen(GreenMid, 1.2f))
                    DrawRoundRect(g, pen, rc, 12);

                // titlu
                var titleSize = g.MeasureString(gb.Text, FontBold);
                float tx = rc.X + 14;
                float ty = rc.Y - titleSize.Height / 2f;

                using (var bgBrush = new SolidBrush(Color.FromArgb(240, 248, 243)))
                    g.FillRectangle(bgBrush, tx - 4, ty, titleSize.Width + 8, titleSize.Height);

                using (var textBrush = new SolidBrush(Green1))
                    g.DrawString(gb.Text, FontBold, textBrush, tx, ty);
            };
        }

        // ── Button cu gradient + colțuri rotunjite ────────────
        private static void StyleButton(Button btn)
        {
            bool isDanger = btn.Name.ToLower().Contains("sterge") ||
                            btn.BackColor == Color.MistyRose;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.White;
            btn.Font      = FontBold;
            btn.Cursor    = Cursors.Hand;
            btn.BackColor = isDanger ? Danger : Green1;
            btn.FlatAppearance.MouseOverBackColor = isDanger ? DangerHover : Green2;

            btn.Paint += (s, e) =>
            {
                var b   = (Button)s;
                var g   = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                bool hover = b.ClientRectangle.Contains(b.PointToClient(Cursor.Position));
                Color top    = isDanger
                    ? (hover ? Color.FromArgb(230, 60, 60)  : Color.FromArgb(220, 70, 70))
                    : (hover ? Color.FromArgb(45, 160, 100) : Color.FromArgb(52, 175, 110));
                Color bottom = isDanger
                    ? (hover ? DangerHover : Danger)
                    : (hover ? Green2      : Green1);

                var rc = new Rectangle(0, 0, b.Width - 1, b.Height - 1);

                using (var brush = new LinearGradientBrush(rc, top, bottom, LinearGradientMode.Vertical))
                    FillRoundRect(g, brush, rc, 10);

                // text centrat
                var sf = new StringFormat
                {
                    Alignment     = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                using (var tb = new SolidBrush(Color.White))
                    g.DrawString(b.Text, FontBold, tb, b.ClientRectangle, sf);
            };

            btn.MouseEnter += (s, e) => ((Button)s).Invalidate();
            btn.MouseLeave += (s, e) => ((Button)s).Invalidate();
        }

        // ── TextBox cu bordură verde + colțuri ───────────────
        private static void StyleTextBox(TextBox tb)
        {
            tb.BackColor   = Color.White;
            tb.ForeColor   = TextPrimary;
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Font        = FontBase;

            // bordură colorată la focus
            tb.Enter += (s, e) =>
            {
                var t = (TextBox)s;
                t.BackColor = Color.FromArgb(245, 255, 250);
            };
            tb.Leave += (s, e) =>
            {
                var t = (TextBox)s;
                t.BackColor = Color.White;
            };
        }

        // ── ComboBox ──────────────────────────────────────────
        private static void StyleComboBox(ComboBox cb)
        {
            cb.BackColor = Color.White;
            cb.ForeColor = TextPrimary;
            cb.FlatStyle = FlatStyle.Flat;
            cb.Font      = FontBase;
        }

        // ── ListBox ───────────────────────────────────────────
        private static void StyleListBox(ListBox lb)
        {
            lb.BackColor     = Color.White;
            lb.ForeColor     = TextPrimary;
            lb.BorderStyle   = BorderStyle.FixedSingle;
            lb.Font          = FontBase;
            lb.ItemHeight    = 24;
            lb.DrawMode      = DrawMode.OwnerDrawFixed;

            lb.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;
                var list = (ListBox)s;
                var g    = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                bool selected = (e.State & DrawItemState.Selected) != 0;
                var rc = new Rectangle(e.Bounds.X + 4, e.Bounds.Y + 2,
                                       e.Bounds.Width - 8, e.Bounds.Height - 4);

                if (selected)
                {
                    using (var brush = new LinearGradientBrush(rc,
                        Color.FromArgb(200, 240, 215),
                        Color.FromArgb(160, 220, 190),
                        LinearGradientMode.Vertical))
                        FillRoundRect(g, brush, rc, 8);

                    using (var pen = new Pen(GreenMid, 1f))
                        DrawRoundRect(g, pen, rc, 8);
                }
                else
                {
                    using (var brush = new SolidBrush(e.Index % 2 == 0
                        ? Color.White
                        : Color.FromArgb(245, 252, 248)))
                        g.FillRectangle(brush, e.Bounds);
                }

                string text = list.Items[e.Index].ToString();
                using (var tb = new SolidBrush(selected ? Green2 : TextPrimary))
                    g.DrawString(text, FontBase, tb,
                        new RectangleF(rc.X + 8, rc.Y + 3, rc.Width - 10, rc.Height));
            };
        }

        // ── DataGridView ──────────────────────────────────────
        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor           = Color.White;
            dgv.BorderStyle               = BorderStyle.None;
            dgv.GridColor                 = GreenMid;
            dgv.Font                      = FontBase;
            dgv.RowHeadersVisible         = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.ColumnHeadersDefaultCellStyle.BackColor  = Green1;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor  = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font       = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding    = new Padding(8, 5, 8, 5);
            dgv.ColumnHeadersHeight                      = 34;
            dgv.ColumnHeadersBorderStyle                 = DataGridViewHeaderBorderStyle.None;

            dgv.DefaultCellStyle.BackColor          = Color.White;
            dgv.DefaultCellStyle.ForeColor          = TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = GreenLight;
            dgv.DefaultCellStyle.SelectionForeColor = Green2;
            dgv.DefaultCellStyle.Padding            = new Padding(6, 4, 6, 4);
            dgv.RowTemplate.Height                  = 28;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 252, 246);
        }

        // ── PropertyGrid ──────────────────────────────────────
        private static void StylePropertyGrid(PropertyGrid pg)
        {
            pg.BackColor             = Color.White;
            pg.LineColor             = GreenMid;
            pg.CategoryForeColor     = Green1;
            pg.CategorySplitterColor = GreenMid;
            pg.ViewBackColor         = Color.White;
            pg.ViewForeColor         = TextPrimary;
            pg.HelpBackColor         = GreenLight;
            pg.HelpForeColor         = TextMuted;
        }

        // ── Helpers pentru rounded rectangles ─────────────────
        private static void FillRoundRect(Graphics g, Brush brush, Rectangle rc, int radius)
        {
            using (var path = RoundedPath(rc, radius))
                g.FillPath(brush, path);
        }

        private static void DrawRoundRect(Graphics g, Pen pen, Rectangle rc, int radius)
        {
            using (var path = RoundedPath(rc, radius))
                g.DrawPath(pen, path);
        }

        private static GraphicsPath RoundedPath(Rectangle rc, int r)
        {
            var path = new GraphicsPath();
            path.AddArc(rc.X,              rc.Y,              r * 2, r * 2, 180, 90);
            path.AddArc(rc.Right - r * 2,  rc.Y,              r * 2, r * 2, 270, 90);
            path.AddArc(rc.Right - r * 2,  rc.Bottom - r * 2, r * 2, r * 2,   0, 90);
            path.AddArc(rc.X,              rc.Bottom - r * 2, r * 2, r * 2,  90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
