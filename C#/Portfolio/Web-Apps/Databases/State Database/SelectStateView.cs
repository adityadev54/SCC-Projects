/** 
 * ADITYA PATEL
 * CPT - 206
 * SELECT STATE VIEW
 * **/

using System;
using System.Windows.Forms;

namespace APatel_Lab__3
{
    public partial class SelectStateView : Form
    {
        public SelectStateView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate the required fields
            if (string.IsNullOrWhiteSpace(txtStateName.Text) ||
                string.IsNullOrWhiteSpace(txtPopulation.Text) ||
                string.IsNullOrWhiteSpace(txtFlagDesc.Text) ||
                string.IsNullOrWhiteSpace(txtFlower.Text) ||
                string.IsNullOrWhiteSpace(txtBird.Text) ||
                string.IsNullOrWhiteSpace(txtColors.Text) ||
                string.IsNullOrWhiteSpace(txtLargCity1.Text) ||
                string.IsNullOrWhiteSpace(txtLargCity2.Text) ||
                string.IsNullOrWhiteSpace(txtLargCity3.Text) ||
                string.IsNullOrWhiteSpace(txtCapital.Text) ||
                string.IsNullOrWhiteSpace(txtMedianIncome.Text) ||
                string.IsNullOrWhiteSpace(txtComJobPercent.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error");
                return;
            }

            // Sanitized the numeric fields
            string populationText = txtPopulation.Text.Replace(",", "").Trim();
            string incomeText = txtMedianIncome.Text.Replace(",", "").Replace("$", "").Trim();
            string jobPercentText = txtComJobPercent.Text.Replace("%", "").Trim();

            // Validate the numeric fields
            if (!int.TryParse(populationText, out int population) ||
                !double.TryParse(incomeText, out double medianIncome) ||
                !double.TryParse(jobPercentText, out double jobPercentage))
            {
                MessageBox.Show("Population, Median Income, and Job Percentage must be valid numbers.", "Input Error");
                return;
            }

            // Create and save state objects
            State newState = new State
            {
                StateName = txtStateName.Text.Trim(),
                Population = population,
                FlagDescription = txtFlagDesc.Text.Trim(),
                StateFlower = txtFlower.Text.Trim(),
                StateBird = txtBird.Text.Trim(),
                StateColors = txtColors.Text.Trim(),
                LargestCity1 = txtLargCity1.Text.Trim(),
                LargestCity2 = txtLargCity2.Text.Trim(),
                LargestCity3 = txtLargCity3.Text.Trim(),
                StateCapital = txtCapital.Text.Trim(),
                MedianIncome = medianIncome,
                ComputerJobPercentage = jobPercentage
            };

            StateDataStore.States.Add(newState);
            MessageBox.Show("Atlas Nexus data is saved successfully!", "Success");

            // Navigate to DataView
            this.Hide();
            new DataCoreView().Show();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            // Return to MainView
            this.Hide();
            new MainView().Show();
        }
    }
}
