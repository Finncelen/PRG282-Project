using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroHQ
{
    public partial class ManageHeroes : Form
    {
        private BindingList<SuperHero> binding;

        public ManageHeroes()
        {
            InitializeComponent();
        }

        private void ManageHeroes_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            // Always read latest from disk to stay consistent across forms
            SuperHeroManager.LoadData(); // uses ReadFromFile(...) and the shared list
            var list = SuperHeroManager.GetAllHeroes(); // shared in-memory list 

            binding = new BindingList<SuperHero>(list);
            dvgHeroes.AutoGenerateColumns = true;
            dvgHeroes.DataSource = binding;

            if (dvgHeroes.Columns.Contains(nameof(SuperHero.Rank)))
                dvgHeroes.Columns[nameof(SuperHero.Rank)].ReadOnly = true;
            if (dvgHeroes.Columns.Contains(nameof(SuperHero.ThreatLevel)))
                dvgHeroes.Columns[nameof(SuperHero.ThreatLevel)].ReadOnly = true;

            // Put columns in: ID, Name, Superpower, Age, ExamScore, Rank, ThreatLevel
            TryReorderColumns(
                nameof(SuperHero.HeroID),
                nameof(SuperHero.HeroName),
                nameof(SuperHero.Superpower),
                nameof(SuperHero.Age),
                nameof(SuperHero.ExamScore),
                nameof(SuperHero.Rank),
                nameof(SuperHero.ThreatLevel)
            );

            dvgHeroes.Columns[nameof(SuperHero.HeroID)].Width = 50;
            dvgHeroes.Columns[nameof(SuperHero.Age)].Width = 50;
            dvgHeroes.Columns[nameof(SuperHero.ExamScore)].Width = 50;
            dvgHeroes.Columns[nameof(SuperHero.Rank)].Width = 50;

            dvgHeroes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgHeroes.MultiSelect = false;
            dvgHeroes.AllowUserToAddRows = false;
            dvgHeroes.AllowUserToDeleteRows = false;
            dvgHeroes.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

        }

        private void TryReorderColumns(params string[] names)
        {
            int displayIndex = 0;
            foreach (var n in names)
            {
                if (dvgHeroes.Columns.Contains(n))
                    dvgHeroes.Columns[n].DisplayIndex = displayIndex++;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var id = numSearchID.Value;

            foreach (DataGridViewRow row in dvgHeroes.Rows)
            {
                if (row.DataBoundItem is SuperHero h && h.HeroID == id)
                {
                    row.Selected = true;
                    dvgHeroes.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }

            MessageBox.Show("Hero not found.");
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (dvgHeroes.CurrentRow?.DataBoundItem is SuperHero edited)
            {
                try
                {
                    // Build an updated snapshot; manager will re-calc Rank/Threat on update
                    var updated = new SuperHero(
                        id: edited.HeroID,
                        name: (edited.HeroName ?? "").Trim(),
                        superpower: (edited.Superpower ?? "").Trim(),
                        age: edited.Age,
                        examScore: edited.ExamScore,
                        rank: edited.Rank,
                        threatlevel: edited.ThreatLevel
                    );

                    SuperHeroManager.UpdateHero(SuperHeroManager.GetAllHeroes(), updated); // saves to file

                    MessageBox.Show("Hero updated.");
                    LoadGrid(); // refresh to show recalculated Rank/Threat
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update failed");
                }
            }
            else
            {
                MessageBox.Show("Select a hero row first.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dvgHeroes.CurrentRow?.DataBoundItem is SuperHero selected)
            {
                if (MessageBox.Show($"Delete {selected.HeroName} (ID: {selected.HeroID})?",
                                    "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SuperHeroManager.DeleteHero(SuperHeroManager.GetAllHeroes(), selected.HeroID); // saves
                    LoadGrid();
                }
            }
            else
            {
                MessageBox.Show("Select a hero row to delete.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // --- Validation helpers ---

        private void dvgHeroes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dvgHeroes.Columns[e.ColumnIndex].Name == nameof(SuperHero.Age))
            {
                if (!int.TryParse($"{e.FormattedValue}", out var age) || age < 0)
                {
                    e.Cancel = true;
                    dvgHeroes.Rows[e.RowIndex].ErrorText = "Age must be a non-negative integer.";
                }
                else dvgHeroes.Rows[e.RowIndex].ErrorText = string.Empty;
            }

            if (dvgHeroes.Columns[e.ColumnIndex].Name == nameof(SuperHero.ExamScore))
            {
                if (!int.TryParse($"{e.FormattedValue}", out var score) || score < 0 || score > 100)
                {
                    e.Cancel = true;
                    dvgHeroes.Rows[e.RowIndex].ErrorText = "Score must be 0–100.";
                }
                else dvgHeroes.Rows[e.RowIndex].ErrorText = string.Empty;
            }
        }

        private void dvgHeroes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Prevent crashes on parse errors; show friendly message
            MessageBox.Show("Invalid value. Please correct the field.");
            e.Cancel = true;
        }
    }
}
