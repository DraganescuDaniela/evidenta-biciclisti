using System;
using System.Drawing;
using System.Windows.Forms;

namespace CiclistApp
{
    public partial class Form1 : Form
    {
        private readonly DatabaseHelper _db = new DatabaseHelper("ciclism.db");

        public Form1()
        {
            InitializeComponent();
            this.Text = "Evidență Trasee Ciclism";

            // Populăm combo dificultate
            cmbDificultate.Items.AddRange(new object[] { "ușor", "mediu", "dificil" });
            cmbDificultate.SelectedIndex = 0;

            // Conectăm evenimentele
            btnAdaugaBiciclist.Click += BtnAdaugaBiciclist_Click;
            btnCautaDupaCnp.Click += BtnCautaDupaCnp_Click;
            button1.Click += BtnAdaugaTraseu_Click;
            btnStergeTraseu.Click += BtnStergeTraseu_Click;
            lstBiciclist.SelectedIndexChanged += LstBiciclisti_SelectedIndexChanged;
            dvgTrasee.SelectionChanged += DgvTrasee_SelectionChanged;

            // Configurăm DataGridView
            dvgTrasee.AllowUserToAddRows = false;
            dvgTrasee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgTrasee.MultiSelect = false;
            dvgTrasee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurăm PropertyGrid
            pgDetalisTraseu.HelpVisible = false;
            pgDetalisTraseu.ToolbarVisible = false;

            _db.InitDB();
            LoadBiciclisti();
            UpdateStatisticiGenerale();
            UITheme.Apply(this);
        }

        // ══════════════════════════════════════════════════════
        //  LOAD / REFRESH
        // ══════════════════════════════════════════════════════
        private void LoadBiciclisti()
        {
            int selectedId = GetSelectedBiciclistId();
            lstBiciclist.Items.Clear();

            foreach (var b in _db.GetBiciclisti())
                lstBiciclist.Items.Add(b);

            for (int i = 0; i < lstBiciclist.Items.Count; i++)
                if (((Biciclist)lstBiciclist.Items[i]).Id == selectedId)
                { lstBiciclist.SelectedIndex = i; break; }
        }

        private void LoadTrasee(int idBiciclist)
        {
            dvgTrasee.Rows.Clear();
            dvgTrasee.Columns.Clear();
            dvgTrasee.Columns.Add("IdTraseu", "ID");
            dvgTrasee.Columns.Add("Denumire", "Denumire");
            dvgTrasee.Columns.Add("Distanta", "Distanță (km)");
            dvgTrasee.Columns.Add("Dificultate", "Dificultate");
            dvgTrasee.Columns.Add("Durata", "Durată (min)");
            dvgTrasee.Columns["IdTraseu"].Visible = false;

            foreach (var t in _db.GetTrasee(idBiciclist))
                dvgTrasee.Rows.Add(t.IdTraseu, t.Denumire, t.DistantaKm, t.Dificultate, t.DurataMinute);

            UpdateStatisticiBiciclist(idBiciclist);
        }

        // ══════════════════════════════════════════════════════
        //  EVENTS
        // ══════════════════════════════════════════════════════
        private void LstBiciclisti_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = GetSelectedBiciclistId();
            if (id > 0) LoadTrasee(id);
            else { dvgTrasee.Rows.Clear(); dvgTrasee.Columns.Clear(); }
        }

        private void DgvTrasee_SelectionChanged(object sender, EventArgs e)
        {
            if (dvgTrasee.SelectedRows.Count == 0) { pgDetalisTraseu.SelectedObject = null; return; }
            var row = dvgTrasee.SelectedRows[0];
            if (row.Cells["IdTraseu"].Value == null) return;

            pgDetalisTraseu.SelectedObject = new TraseuDetalii
            {
                IdTraseu = Convert.ToInt32(row.Cells["IdTraseu"].Value),
                Denumire = row.Cells["Denumire"].Value?.ToString(),
                DistantaKm = Convert.ToDouble(row.Cells["Distanta"].Value),
                Dificultate = row.Cells["Dificultate"].Value?.ToString(),
                DurataMinute = Convert.ToInt32(row.Cells["Durata"].Value)
            };
        }

        private void BtnAdaugaBiciclist_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text.Trim();
            string cnp = txtCnp.Text.Trim();

            if (!Validators.ValidateNume(nume)) return;
            if (!Validators.ValidateCnp(cnp)) return;

            _db.AddBiciclist(nume, cnp);
            txtNume.Clear(); txtCnp.Clear();
            LoadBiciclisti();
            UpdateStatisticiGenerale();
            MessageBox.Show("Biciclist adăugat cu succes!");
        }

        private void BtnAdaugaTraseu_Click(object sender, EventArgs e)
        {
            int idBiciclist = GetSelectedBiciclistId();
            if (idBiciclist <= 0)
            { Validators.ShowError("Selectați un biciclist înainte de a adăuga un traseu!"); return; }

            string denumire = txtDenumire.Text.Trim();
            if (string.IsNullOrEmpty(denumire))
            { Validators.ShowError("Denumirea traseului nu poate fi goală!"); return; }

            if (!Validators.ValidateDistanta(txtDistanta.Text, out double distanta)) return;
            if (!Validators.ValidateDurata(txtDurata.Text, out int durata)) return;

            string dificultate = cmbDificultate.SelectedItem?.ToString() ?? "ușor";
            _db.AddTraseu(idBiciclist, denumire, distanta, dificultate, durata);

            txtDenumire.Clear(); txtDistanta.Clear(); txtDurata.Clear();
            LoadTrasee(idBiciclist);
            UpdateStatisticiGenerale();
            MessageBox.Show("Traseu adăugat cu succes!");
        }

        private void BtnStergeTraseu_Click(object sender, EventArgs e)
        {
            if (dvgTrasee.SelectedRows.Count == 0)
            { Validators.ShowError("Selectați un traseu de șters!"); return; }

            int idTraseu = Convert.ToInt32(dvgTrasee.SelectedRows[0].Cells["IdTraseu"].Value);
            if (MessageBox.Show("Sigur vrei să ștergi traseul selectat?", "Confirmare",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            _db.DeleteTraseu(idTraseu);
            pgDetalisTraseu.SelectedObject = null;
            LoadTrasee(GetSelectedBiciclistId());
            UpdateStatisticiGenerale();
        }

        private void BtnCautaDupaCnp_Click(object sender, EventArgs e)        {
            string cnp = txtCautareCnp.Text.Trim();
            if (string.IsNullOrEmpty(cnp)) { Validators.ShowError("Introduceți un CNP!"); return; }

            var b = _db.GetBiciclistByCnp(cnp);
            if (b == null) { Validators.ShowError("Nu s-a găsit niciun biciclist cu CNP-ul introdus!"); return; }

            for (int i = 0; i < lstBiciclist.Items.Count; i++)
                if (((Biciclist)lstBiciclist.Items[i]).Id == b.Id)
                { lstBiciclist.SelectedIndex = i; break; }

            MessageBox.Show($"Biciclist găsit: {b.Nume} (CNP: {b.Cnp})");
        }

        // ══════════════════════════════════════════════════════
        //  STATISTICI
        // ══════════════════════════════════════════════════════
        private void UpdateStatisticiBiciclist(int idBiciclist)
        {
            var stats = _db.GetStatisticiBiciclist(idBiciclist);
            lblStartTrasee.Text = $"Trasee: {stats.Item1}";
            lblStartDistanta.Text = $"Distanță totală: {stats.Item2:F1} km";
            lblStartLung.Text = $"Cel mai lung: {stats.Item4} ({stats.Item3:F1} km)";
        }

        private void UpdateStatisticiGenerale()
        {
            var statsGen = _db.GetStatisticiGenerale();
            lblStartBicclisti.Text = $"Total bicicliști: {statsGen.Item1}";
            lblStartTraseeBiciclisti.Text = $"Total trasee: {statsGen.Item2}";
        }

        // ══════════════════════════════════════════════════════
        //  HELPER
        // ══════════════════════════════════════════════════════
        private int GetSelectedBiciclistId()
        {
            if (lstBiciclist.SelectedItem is Biciclist b) return b.Id;
            return -1;
        }
    }
}
