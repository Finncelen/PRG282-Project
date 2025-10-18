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
        // Defines the filename used to store the generated summary report.
        private const string SummaryFile = "summary.txt";
        public HomeForm()
        {
            InitializeComponent();
        }

        // Loads all hero data from file into memory at application startup.
        private void HomeForm_Load(object sender, EventArgs e)
        {
            SuperHeroManager.LoadData();
        }

        //Generates the summary report and displays it on the form
        private void btnGenerateSum_Click(object sender, EventArgs e)
        {
            SuperHeroManager.GenerateSummaryReport();
            ShowSummaryOnForm();
            MessageBox.Show("Summary generated to summary.txt");
        }

        // Displays summary on Home form with error handeling
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

        //Opens the AddHero form as a modal dialog
        private void btnAddHero_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var dlg = new AddHero())
            {
                dlg.ShowDialog(this);
            }
            this.Show();
        }

        //Opens the ManageHeroes form as a modal dialog
        private void btnManage_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            using (var manageForm = new ManageHeroes())
            {
                manageForm.ShowDialog();
            }
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
