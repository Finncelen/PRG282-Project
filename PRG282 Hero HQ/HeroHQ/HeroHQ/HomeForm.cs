using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroHQ
{
    public partial class HomeForm : Form
    {
        private const string SummaryFile = "summary.txt";
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            SuperHeroManager.LoadData();
        }

        private void btnGenerateSum_Click(object sender, EventArgs e)
        {
            SuperHeroManager.GenerateSummaryReport();
            ShowSummaryOnForm();
            MessageBox.Show("Summary generated to summary.txt");
        }

        private void ShowSummaryOnForm()
        {
            try
            {
                txtSummary.Text = File.ReadAllText(SummaryFile);
                txtSummary.Visible = true;     // reveal the box the first time
            }
            catch (Exception ex)
            {
                txtSummary.Visible = true;
                txtSummary.Text = $"Could not read summary:\r\n{ex.Message}";
            }
        }

        private void btnAddHero_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var dlg = new AddHero())
            {
                dlg.ShowDialog(this);
            }
            this.Show();
        }
    }
}
