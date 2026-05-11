using System.Drawing;
using System.Windows.Forms;

namespace AOOP_HABI.Services
{
    public static class ThemeManager
    {
        // ── Core Palette ──
        public static readonly Color NavBg         = Color.FromArgb(15, 23, 42);
        public static readonly Color NavActive      = Color.FromArgb(30, 41, 59);
        public static readonly Color NavHover       = Color.FromArgb(30, 41, 59);
        public static readonly Color NavText        = Color.FromArgb(148, 163, 184);
        public static readonly Color NavTextActive  = Color.FromArgb(248, 250, 252);

        public static readonly Color PageBg         = Color.FromArgb(15, 23, 42);
        public static readonly Color CardBg         = Color.FromArgb(30, 41, 59);
        public static readonly Color CardBgHover    = Color.FromArgb(51, 65, 85);
        public static readonly Color SurfaceBg      = Color.FromArgb(51, 65, 85);

        public static readonly Color TextPrimary    = Color.FromArgb(248, 250, 252);
        public static readonly Color TextSecondary  = Color.FromArgb(148, 163, 184);
        public static readonly Color TextMuted      = Color.FromArgb(71, 85, 105);

        public static readonly Color AccentGreen    = Color.FromArgb(34, 197, 94);
        public static readonly Color AccentGreenDark = Color.FromArgb(22, 163, 74);
        public static readonly Color AccentGreenBg  = Color.FromArgb(20, 83, 45);

        public static readonly Color AccentRed      = Color.FromArgb(239, 68, 68);
        public static readonly Color AccentRedBg    = Color.FromArgb(127, 29, 29);

        public static readonly Color AccentAmber    = Color.FromArgb(245, 158, 11);
        public static readonly Color AccentBlue     = Color.FromArgb(59, 130, 246);
        public static readonly Color AccentBlueBg   = Color.FromArgb(30, 58, 138);

        public static readonly Color BorderColor    = Color.FromArgb(51, 65, 85);

        // ── Fonts ──
        public static readonly Font FontTitle    = new Font("Segoe UI", 16f, FontStyle.Bold);
        public static readonly Font FontSubtitle = new Font("Segoe UI", 10f, FontStyle.Regular);
        public static readonly Font FontBold     = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FontBody     = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font FontSmall    = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        public static readonly Font FontBadge    = new Font("Segoe UI", 7.5f, FontStyle.Bold);
        public static readonly Font FontNav      = new Font("Segoe UI", 10f, FontStyle.Regular);
        public static readonly Font FontNavBold  = new Font("Segoe UI", 10f, FontStyle.Bold);

        // ── Helpers ──
        public static void StyleForm(Form form)
        {
            form.BackColor = PageBg;
            form.ForeColor = TextPrimary;
        }

        public static void StyleLabel(Label lbl, bool secondary = false)
        {
            lbl.ForeColor = secondary ? TextSecondary : TextPrimary;
            lbl.BackColor = Color.Transparent;
            lbl.Font      = secondary ? FontBody : FontBody;
        }

        public static void StyleCard(Panel card)
        {
            card.BackColor   = CardBg;
            card.ForeColor   = TextPrimary;
        }

        public static void StyleButton(Button btn, string type = "primary")
        {
            btn.FlatStyle   = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor      = Cursors.Hand;
            btn.Font        = FontBold;

            switch (type)
            {
                case "primary":
                    btn.BackColor = AccentGreen;
                    btn.ForeColor = Color.FromArgb(15, 23, 42);
                    break;
                case "danger":
                    btn.BackColor = AccentRed;
                    btn.ForeColor = TextPrimary;
                    break;
                case "secondary":
                    btn.BackColor = SurfaceBg;
                    btn.ForeColor = TextPrimary;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = BorderColor;
                    break;
                case "blue":
                    btn.BackColor = AccentBlue;
                    btn.ForeColor = TextPrimary;
                    break;
                case "nav":
                    btn.BackColor = AccentGreen;
                    btn.ForeColor = Color.FromArgb(15, 23, 42);
                    break;
            }
        }

        public static void StyleTextBox(TextBox txt)
        {
            txt.BackColor   = SurfaceBg;
            txt.ForeColor   = TextPrimary;
            txt.BorderStyle = BorderStyle.None;
            txt.Font        = FontBody;
        }

        public static void StyleNumericUpDown(NumericUpDown nud)
        {
            nud.BackColor = SurfaceBg;
            nud.ForeColor = TextPrimary;
            nud.BorderStyle = BorderStyle.None;
        }

        public static void StyleComboBox(ComboBox cmb)
        {
            cmb.BackColor   = SurfaceBg;
            cmb.ForeColor   = TextPrimary;
            cmb.FlatStyle   = FlatStyle.Flat;
            cmb.Font        = FontBody;
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor              = CardBg;
            dgv.GridColor                    = BorderColor;
            dgv.DefaultCellStyle.BackColor   = CardBg;
            dgv.DefaultCellStyle.ForeColor   = TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = SurfaceBg;
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font        = FontBody;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(22, 33, 50);
            dgv.ColumnHeadersDefaultCellStyle.BackColor   = NavBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor   = TextSecondary;
            dgv.ColumnHeadersDefaultCellStyle.Font        = FontSmall;
            dgv.EnableHeadersVisualStyles    = false;
            dgv.BorderStyle                  = BorderStyle.None;
            dgv.RowHeadersVisible            = false;
            dgv.CellBorderStyle              = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        // Add this inside AOOP_HABI.Services.ThemeManager
        public static void MakeRounded(Control ctrl, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(ctrl.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(ctrl.Width - radius * 2, ctrl.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, ctrl.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);
        }

        // ── Badge Colors ──
        public static Color BadgeBuildBg   = Color.FromArgb(20, 83, 45);
        public static Color BadgeBuildFg   = Color.FromArgb(34, 197, 94);
        public static Color BadgeBreakBg   = Color.FromArgb(127, 29, 29);
        public static Color BadgeBreakFg   = Color.FromArgb(252, 165, 165);

        // ── Heatmap Colors ──
        public static Color HeatNone       = Color.FromArgb(30, 41, 59);
        public static Color HeatLow        = Color.FromArgb(20, 83, 45);
        public static Color HeatMid        = Color.FromArgb(22, 163, 74);
        public static Color HeatHigh       = Color.FromArgb(34, 197, 94);
        public static Color HeatMissed     = Color.FromArgb(127, 29, 29);
    }
}
