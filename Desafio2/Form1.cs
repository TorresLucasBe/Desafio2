using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AngouriMath;
using static AngouriMath.MathS;

namespace Desafio2
{
    public partial class Form1 : Form
    {
        private readonly Entity.Variable x = "x";
        private ToolStripStatusLabel lblStatus;

        public Form1()
        {
            InitializeComponent();

            // ===== StatusStrip → lblStatus =====
            lblStatus = statusStrip1.Items.OfType<ToolStripStatusLabel>()
                                          .FirstOrDefault(it => it.Name == "lblStatus");
            if (lblStatus == null)
            {
                lblStatus = new ToolStripStatusLabel
                {
                    Name = "lblStatus",
                    Text = "Listo",
                    Spring = true
                };
                statusStrip1.Items.Add(lblStatus);
            }

            // ===== ListView para oblicuas =====
            if (lvObl.Columns.Count == 0)
            {
                lvObl.View = View.Details;
                lvObl.FullRowSelect = true;
                lvObl.Columns.Add("Sentido", 90);
                lvObl.Columns.Add("Recta", 240);
            }
            lvObl.ShowGroups = false;

            this.AcceptButton = btnAnalizar;
            btnAnalizar.Click += btnAnalizar_Click;
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            lstVert.Items.Clear();
            lstHor.Items.Clear();
            lvObl.Items.Clear();
            rtxDetalle.Clear();
            SetStatus("Analizando...");

            try
            {
                var raw = (txtFuncion.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(raw))
                    throw new Exception("Ingresá una función, por ejemplo: (x^2-1)/(x-1)");

                // normalizo decimales y caracteres “raros”
                raw = raw.Replace(',', '.');
                raw = NormalizeInput(raw);

                // ===== SOLO RACIONALES: bloquear trig/log/exp/sqrt/abs, etc. =====
                var lowered = raw.ToLowerInvariant();
                string[] banned = {
                    "sin(", "cos(", "tan(", "cot(", "sec(", "csc(",
                    "asin(", "acos(", "atan(", "log(", "ln(", "exp(",
                    "sqrt(", "abs("
                };
                if (banned.Any(k => lowered.Contains(k)))
                    throw new Exception("Para este desafío, ingresá SOLO funciones racionales P(x)/Q(x) (sin trigonométricas, log, exp, sqrt, abs).");

                if (!TrySplitTopLevelDivision(raw, out var numStr, out var denStr))
                    throw new Exception("Ingresá P(x)/Q(x) con una única división de nivel superior. Ej: (3x^2-1)/(x-2)");

                Entity P = numStr;
                Entity Q = denStr;
                var f = (P / Q).Simplify();

                var sb = new StringBuilder();
                sb.AppendLine($"• f simplificada: {f}");
                sb.AppendLine("• Análisis de Q(x) = 0:");

                // ===== Verticales, huecos y dominio =====
                bool anyHole = false;
                var domainZeros = new List<double>(); // valores excluidos del dominio (raíces reales de Q)

                var solSet = SolveEquation(Q, x).Simplify();
                if (solSet is Entity.Set.FiniteSet finite)
                {
                    foreach (var sol in finite)
                    {
                        if (!TryEntityToDouble(sol, out var xr))
                            continue;

                        domainZeros.Add(xr); // todas las raíces reales de Q salen del dominio
                        var xs = FormatNum(xr);

                        var P_at = SafeEvalAt(P, xr);
                        var Q_at = SafeEvalAt(Q, xr);

                        bool pZero = NearlyZero(P_at);
                        bool qZero = NearlyZero(Q_at);

                        if (qZero && !pZero)
                        {
                            // Asíntota vertical
                            lstVert.Items.Add($"x = {xs}");
                            sb.AppendLine($"  · x = {xs} ⇒ Q=0 y P≠0 → asíntota vertical.");
                        }
                        else if (qZero && pZero)
                        {
                            // Hueco (también mostrar en la lista)
                            anyHole = true;
                            var L = SafeEvalAt(f, xr);
                            if (double.IsNaN(L)) L = LimitAt(f, xr); // fallback simbólico
                            lstVert.Items.Add($"x = {xs} (hueco; L = {FormatNum(L)})");
                            sb.AppendLine($"  · x = {xs} ⇒ Q=0 y P=0 → HUECO (removible). Límite: {FormatNum(L)}");
                        }
                    }
                }
                else
                {
                    sb.AppendLine("  · No se pudieron enumerar las raíces (conjunto no finito).");
                }

                if (lstVert.Items.Count == 0)
                    lstVert.Items.Add("— (no hay)");
                if (!anyHole)
                    sb.AppendLine("  · No se detectaron huecos.");

                // Dominio (ℝ menos las raíces reales de Q) — ordenado y sin duplicados por tolerancia
                var domValues = domainZeros
                    .GroupBy(v => Math.Round(v, 9))   // dedup por redondeo para evitar 1.999999999 y 2
                    .Select(g => g.First())
                    .OrderBy(v => v)
                    .Select(FormatNum)
                    .ToList();

                if (domValues.Count > 0)
                    sb.AppendLine("• Dominio: ℝ \\ { " + string.Join(", ", domValues) + " }");
                else
                    sb.AppendLine("• Dominio: ℝ");

                // ===== Horizontales (límite analítico + fallback) =====
                var hPlus = EstimateHorizontal(f, +1);
                var hMinus = EstimateHorizontal(f, -1);

                if (hPlus.ok) lstHor.Items.Add($"x → +∞ : y = {FormatNum(hPlus.L)}");
                if (hMinus.ok) lstHor.Items.Add($"x → -∞ : y = {FormatNum(hMinus.L)}");
                if (lstHor.Items.Count == 0) lstHor.Items.Add("— (no hay)");

                // ===== Oblicuas (estimación numérica robusta) =====
                var oblPlus = EstimateOblique(f, +1);
                var oblMinus = EstimateOblique(f, -1);

                bool printedObl = false;
                if (oblPlus.ok && oblMinus.ok &&
                    AreClose(oblPlus.m, oblMinus.m, 1e-3) &&
                    AreClose(oblPlus.b, oblMinus.b, 1e-3))
                {
                    var m = (oblPlus.m + oblMinus.m) / 2.0;
                    var b = (oblPlus.b + oblMinus.b) / 2.0;
                    lvObl.Items.Add(new ListViewItem(new[] { "x → ±∞", FormatLine(m, b) }));
                    printedObl = true;
                }
                else
                {
                    if (oblPlus.ok)
                    {
                        lvObl.Items.Add(new ListViewItem(new[] { "x → +∞", FormatLine(oblPlus.m, oblPlus.b) }));
                        printedObl = true;
                    }
                    if (oblMinus.ok)
                    {
                        lvObl.Items.Add(new ListViewItem(new[] { "x → -∞", FormatLine(oblMinus.m, oblMinus.b) }));
                        printedObl = true;
                    }
                }
                if (!printedObl)
                    lvObl.Items.Add(new ListViewItem(new[] { "—", "(no hay)" }));

                rtxDetalle.Text = sb.ToString();
                SetStatus("Análisis OK");
            }
            catch (Exception ex)
            {
                SetStatus("Error");
                rtxDetalle.Text = "⛔ " + ex.Message;
                if (lstVert.Items.Count == 0) lstVert.Items.Add("—");
                if (lstHor.Items.Count == 0) lstHor.Items.Add("—");
                if (lvObl.Items.Count == 0) lvObl.Items.Add(new ListViewItem(new[] { "—", "—" }));
            }
        }

        // =================== Helpers ===================

        // Normaliza caracteres "raros" a ASCII para el parser
        private static string NormalizeInput(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            var sb = new StringBuilder(s.Length);
            foreach (var ch in s)
            {
                switch (ch)
                {
                    case '\u2013': case '\u2014': case '\u2212': sb.Append('-'); break;   // guiones / menos
                    case '\u00D7': case '\u22C5': case '\u2219': sb.Append('*'); break;   // × · ∙
                    case '\u2044': sb.Append('/'); break;                                 // ⁄
                    case '\u00A0':
                    case '\u2009':
                    case '\u200A':
                    case '\u200B':
                    case '\u202F':
                        sb.Append(' '); break;                                           // espacios raros
                    case '_': break;                                                     // ignoramos subíndice
                    default: sb.Append(ch == 'X' ? 'x' : ch); break;                      // X → x
                }
            }
            return sb.ToString();
        }

        // Límite en un punto finito (simbólico) con NaN si no se puede
        private static double LimitAt(Entity f, double a)
        {
            try
            {
                var lim = f.Limit("x", a).Simplify();
                if (TryEntityToDouble(lim, out var d) && !double.IsNaN(d) && !double.IsInfinity(d))
                    return d;
            }
            catch { }
            return double.NaN;
        }

        // "Ajusta" números a enteros o décimas si están muy cerca (para imprimir lindo)
        private static double Snap(double v)
        {
            if (double.IsNaN(v) || double.IsInfinity(v)) return v;
            var r0 = Math.Round(v);
            if (Math.Abs(v - r0) < 1e-3) return r0;
            var r1 = Math.Round(v * 10.0) / 10.0;
            if (Math.Abs(v - r1) < 5e-4) return r1;
            return v;
        }

        // Devuelve "y = x + 1", "y = -x - 2", "y = 2·x - 0.5", etc.
        private static string FormatLine(double m, double b)
        {
            m = Snap(m);
            b = Snap(b);

            string slope;
            if (Math.Abs(m - 1.0) < 1e-9) slope = "x";
            else if (Math.Abs(m + 1.0) < 1e-9) slope = "-x";
            else slope = $"{FormatNum(m)}·x";

            string intercept = "";
            if (!NearlyZero(b))
                intercept = (b > 0 ? " + " : " - ") + FormatNum(Math.Abs(b));

            return $"y = {slope}{intercept}";
        }

        private void SetStatus(string text)
        {
            if (lblStatus != null) lblStatus.Text = text;
        }

        // Partir s en P y Q considerando paréntesis — RECHAZA más de una “/” al nivel superior
        private static bool TrySplitTopLevelDivision(string s, out string left, out string right)
        {
            left = right = null;
            int depth = 0;
            int pos = -1;
            bool foundTopSlash = false;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(') depth++;
                else if (c == ')') depth = Math.Max(0, depth - 1);
                else if (c == '/' && depth == 0)
                {
                    if (foundTopSlash)  // segunda división de nivel superior => inválido
                        return false;
                    foundTopSlash = true;
                    pos = i;
                }
            }

            if (!foundTopSlash) return false;

            left = s.Substring(0, pos).Trim();
            right = s.Substring(pos + 1).Trim();
            return !(string.IsNullOrEmpty(left) || string.IsNullOrEmpty(right));
        }

        // Eval numérica segura: f(xr) -> double (NaN si no evaluable)
        private static double SafeEvalAt(Entity expr, double xr)
        {
            try
            {
                var e = expr.Substitute("x", xr).Simplify();
                if (!e.EvaluableNumerical) return double.NaN;
                var n = e.EvalNumerical();
                if (n is Entity.Number.Real r)
                {
                    double d = r.AsDouble();
                    return double.IsInfinity(d) ? double.NaN : d;
                }
                return double.NaN;
            }
            catch { return double.NaN; }
        }

        private static bool TryEntityToDouble(Entity e, out double val)
        {
            try
            {
                var n = e.EvalNumerical();
                if (n is Entity.Number.Real r)
                {
                    val = r.AsDouble();
                    if (double.IsNaN(val) || double.IsInfinity(val))
                    { val = double.NaN; return false; }
                    return true;
                }
            }
            catch { }
            val = double.NaN;
            return false;
        }

        private static bool NearlyZero(double d, double tol = 1e-8) =>
            !double.IsNaN(d) && Math.Abs(d) < tol;

        private static bool AreClose(double a, double b, double tol = 1e-6) =>
            Math.Abs(a - b) <= tol * Math.Max(1.0, Math.Max(Math.Abs(a), Math.Abs(b)));

        private static string FormatNum(double d)
        {
            if (double.IsNaN(d)) return "indef.";
            if (Math.Abs(d) < 1e-9) return "0";

            var r0 = Math.Round(d);
            if (Math.Abs(d - r0) < 1e-3) return r0.ToString(CultureInfo.InvariantCulture);

            var r1 = Math.Round(d * 10.0) / 10.0;
            if (Math.Abs(d - r1) < 5e-4) return r1.ToString("0.0", CultureInfo.InvariantCulture);

            return d.ToString("G6", CultureInfo.InvariantCulture);
        }

        private static string FormatNum(Entity e)
        {
            if (TryEntityToDouble(e, out var d)) return FormatNum(d);
            return e.Simplify().ToString();
        }

        // ===== Horizontales: límite simbólico (±∞ reales) con fallback numérico =====
        private static (bool ok, double L) EstimateHorizontal(Entity f, int sign)
        {
            try
            {
                Entity to = sign > 0
                    ? (Entity)Entity.Number.Real.PositiveInfinity
                    : (Entity)Entity.Number.Real.NegativeInfinity;

                var limEnt = f.Limit("x", to).Simplify();

                if (TryEntityToDouble(limEnt, out var d) && !double.IsNaN(d) && !double.IsInfinity(d))
                    return (true, d);
            }
            catch { }

            double X1 = 1e5 * sign;
            double X2 = 1e6 * sign;

            double y1 = SafeEvalAt(f, X1);
            double y2 = SafeEvalAt(f, X2);
            if (double.IsNaN(y1) || double.IsNaN(y2)) return (false, double.NaN);

            double tolAbs = Math.Max(1e-6 * Math.Max(Math.Abs(y1), Math.Abs(y2)), 1e-4);
            if (Math.Abs(y1 - y2) <= tolAbs)
                return (true, (y1 + y2) / 2.0);

            return (false, double.NaN);
        }

        // Oblicua por secante entre dos puntos grandes + verificación con un tercero
        // Devuelve ok=false si la pendiente es ~0 (entonces consideramos horizontal)
        private static (bool ok, double m, double b) EstimateOblique(Entity f, int sign)
        {
            double X1 = 1e4 * sign;
            double X2 = 1e5 * sign;
            double X3 = 5e4 * sign;

            double y1 = SafeEvalAt(f, X1);
            double y2 = SafeEvalAt(f, X2);
            double y3 = SafeEvalAt(f, X3);
            if (double.IsNaN(y1) || double.IsNaN(y2) || double.IsNaN(y3))
                return (false, double.NaN, double.NaN);

            double m = (y2 - y1) / (X2 - X1);
            if (Math.Abs(m) < 1e-3)
                return (false, double.NaN, double.NaN);

            double b1 = y1 - m * X1;
            double b2 = y2 - m * X2;
            double b3 = y3 - m * X3;

            if (!AreClose(b1, b2, 1e-3) || !AreClose(b2, b3, 1e-3))
                return (false, double.NaN, double.NaN);

            double b = (b1 + b2 + b3) / 3.0;
            return (true, m, b);
        }

        // Stubs por si el diseñador dejó enganchados estos eventos
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void lvObl_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnAnalizar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
