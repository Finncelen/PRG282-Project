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
    public partial class AddHero : Form
    {
        public AddHero()
        {
            InitializeComponent();
        }

        // Form load: set up simple defaults
        private void AddHero_Load(object sender, EventArgs e)
        {
            txtName.MaxLength = 60;
            txtSuperpower.MaxLength = 60; 
        }

        // Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtName.Text.Trim();
                var spwr = txtSuperpower.Text.Trim(); 

                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("Please enter a name.");

                if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 0)
                    throw new Exception("Age must be a number 0 or greater.");

                if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100)
                    throw new Exception("Exam score must be a number from 0 to 100.");

                // Create hero; ID will be assigned and Rank/Threat computed in AddHero()
                var newHero = new SuperHero(
                    id: 0,
                    name: txtName.Text.Trim(),
                    superpower: txtSuperpower.Text.Trim(),
                    age: int.Parse(txtAge.Text.Trim()),
                    examScore: int.Parse(txtScore.Text.Trim()),
                    rank: "",
                    threatlevel: ""
                );

                // Add to in-memory list and save to file
                SuperHeroManager.AddHero(SuperHeroManager.GetAllHeroes(), newHero); // assigns ID & saves

                // Show the auto-assigned ID back to the user
                txtHeroID.Text = newHero.HeroID.ToString();

                MessageBox.Show("Hero added successfully!", "Saved");

                // Clear inputs for the next entry (keep ID showing)
                txtName.Clear();
                txtAge.Clear();
                txtSuperpower.Clear();
                txtScore.Clear();
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not add hero");
            }
        }

        // Return button
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
