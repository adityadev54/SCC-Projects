/** 
 * GROUP PROJECT #1
 * CPT - 206 
 * 
 * ANALYSIS + PREDICT SERVICE INTEGRATION 
 * WITH ANALYSIS FORM
**/

using _3Sports.Services;
using _3Sports.Sport_Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3Sports.UI.SubForms
{
    public partial class AnalysisView : Form
    {
        private TeamPerfAnalysisService _teamAnalysisService;
        private MatchPredictionService _matchPredictionService;
        private DataTable _matchData;

        // Instance of the MultiFileDataService
        private MultiFileDataService _dataService;

        public AnalysisView()
        {
            InitializeComponent();
            LoadSoccerDataAsync();

            // Prediction Label Properties
            lblPredictionResult.AutoSize = false;
            lblPredictionResult.MaximumSize = new Size(200, 0);
            lblPredictionResult.Size = new Size(200, 60);
            lblPredictionResult.TextAlign = ContentAlignment.TopLeft;

        }

        private async void LoadSoccerDataAsync()
        {
            // Await for the async method
            await LoadSoccerData();
        }

        private async Task LoadSoccerData()
        {
            // defines the CSV URLs and their corresponding seasons
            Dictionary<string, string> csvUrlsWithSeasons = new Dictionary<string, string>()
            {
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0001.csv", "Season 1" },
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0102.csv", "Season 2" },
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0203.csv", "Season 3" },
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0304.csv", "Season 4" },
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0405.csv", "Season 5" },
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0506.csv", "Season 6" },
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0607.csv", "Season 7" },
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0708.csv", "Season 8" },
                { "https://raw.githubusercontent.com/datasets/football-datasets/refs/heads/main/datasets/premier-league/season-0809.csv", "Season 9" },
            };

            _dataService = new MultiFileDataService(new List<string>(csvUrlsWithSeasons.Keys));

            try
            {
                // Now the data will load asynchronously
                await _dataService.LoadDataAsync(csvUrlsWithSeasons);

                // And get the loaded dataTable
                _matchData = _dataService.GetAllData();

                if (_matchData != null && _matchData.Rows.Count > 0)
                {
                    // Then pass the dataTable to service
                    _teamAnalysisService = new TeamPerfAnalysisService(_matchData);

                    // and pass the dataTable to service
                    _matchPredictionService = new MatchPredictionService(_matchData);

                    // Lastly load the teams into their coressponding cmbBoxes after data is loaded.
                    LoadTeams();
                }
                else
                {
                    MessageBox.Show("Failed to load soccer data. Please check the CSV URLs and your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadTeams()
        {
            // Gets the unique team names from the loaded data
            List<string> teams = _matchData.AsEnumerable()
                                           .Select(row => row.Field<string>("HomeTeam"))
                                           .Distinct()
                                           .ToList();

            // Clears up existing items to avoid duplicates if LoadTeams is called multiple times
            cmbTeam1.Items.Clear();
            cmbTeam2.Items.Clear();
            cmbTeam3.Items.Clear();

            cmbTeam1.Items.AddRange(teams.ToArray());
            cmbTeam2.Items.AddRange(teams.ToArray());
            cmbTeam3.Items.AddRange(teams.ToArray());
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (cmbTeam1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a team!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedTeam = cmbTeam1.SelectedItem.ToString();
            var stats = _teamAnalysisService.GetTeamPerfStats(selectedTeam);

            lblWins.Text = $"Wins: {stats["Wins"]}";
            lblLosses.Text = $"Losses: {stats["Losses"]}";
            lblDraws.Text = $"Draws: {stats["Draws"]}";
            lblWinRate.Text = $"Win Rate: {stats["Win Rate (%)"]}%";
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            if (cmbTeam2.SelectedIndex == -1 || cmbTeam3.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both teams!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string team1 = cmbTeam2.SelectedItem.ToString();
            string team2 = cmbTeam3.SelectedItem.ToString();

            if (team1 == team2)
            {
                MessageBox.Show("Select two different teams!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get predictions
            var predictionResult = _matchPredictionService.PredictMatchOutcome(team1, team2);

            // Then engage amessage with the varied outcomes
            lblPredictionResult.Text = GetEnhancedPredictionMessage(team1, team2, predictionResult);
        }

        // Function to generate engaging predictions
        private string GetEnhancedPredictionMessage(string team1, string team2, string outcome)
        {
            Random rand = new Random();

            // Random goals for team1 and team2 (0-3)
            int randomScore2 = rand.Next(0, 4);
            int randomScore1 = rand.Next(0, 4);

            if (outcome.Contains("Win"))
            {
                return $"{outcome}! Final Score Prediction: {team1} {randomScore1} - {randomScore2} {team2}.";
            }
            else if (outcome.Contains("Draw"))
            {
                return $"It's predicted to be a close match! A {randomScore1}-{randomScore2} draw is likely.";
            }
            else
            {
                return $"A tough battle ahead! {team1} and {team2} are evenly matched.";
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            var SportSelection = new SportSelectView();
            SportSelection.Show();
            this.Close();
        }
    }
}