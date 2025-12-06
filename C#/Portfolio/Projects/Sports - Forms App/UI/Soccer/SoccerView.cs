/** 
 * GROUP PROJECT #1
 * CPT - 206 
 * 
 * SOCCER VIEW
**/


using _3Sports.classes;
using _3Sports.Services;
using _3Sports.UI.SubForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3Sports.UI
{
    public partial class SoccerView : Form
    {
        private readonly AuthService authService = new AuthService();

        // Service that will load and manage the soccer data
        private MultiFileDataService _dataService;

        // Then stores the URLs that are mapped to season names 
        private Dictionary<string, string> _csvUrlsWithSeasons;

        // Cache for pre-filtered data
        private Dictionary<string, DataTable> _preFilteredData = new Dictionary<string, DataTable>(); // Cache pre-filtered data

        public SoccerView()
        {
            InitializeComponent();
            authService = new AuthService();
            string username = UserSession.CurrentUsername;

            // Show the username
            lblUsername.Text = $"{username}";
        }

        private async void SoccerSport_Load(object sender, EventArgs e)
        {
            // Dic. that maps URLs to season names
            _csvUrlsWithSeasons = new Dictionary<string, string>()
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

            List<string> csvUrls = _csvUrlsWithSeasons.Keys.ToList();
            _dataService = new MultiFileDataService(csvUrls, "Soccer League Data");
            await _dataService.LoadDataAsync(_csvUrlsWithSeasons);

            // Populate the team selection dropdown if data is loaded successfully
            if (_dataService.GetAllData().Rows.Count > 0)
            {
                List<string> teams = _dataService.GetUniqueColumnValues("HomeTeam");
                cmbFavTeamSelection.Items.AddRange(teams.ToArray());

                // Restricted to manual input
                cmbFavTeamSelection.DropDownStyle = ComboBoxStyle.DropDownList;

                // Pre-filter data for each team
                await Task.Run(() =>
                {
                    foreach (string team in teams)
                    {
                        _preFilteredData[team] = _dataService.FilterDataByColumn("HomeTeam", team);
                    }
                });
            }
            else
            {
                MessageBox.Show("[Soccer League Data] Failed to load data in SoccerSport.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navigates to the League Form after the fav.team selection
        private void tournamentsCard_Click(object sender, System.EventArgs e)
        {
            if (cmbFavTeamSelection.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a team before proceeding!", "Team Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedTeam = cmbFavTeamSelection.SelectedItem.ToString();
            string selectedSeason = "Current";

            LeagueView tournaments = new LeagueView(_dataService, selectedTeam, selectedSeason, selectedTeam); // Pass selected team
            tournaments.Show();

            this.Hide();
        }

        // Opens the FAQ Section Form
        private void FAQsCard_Click(object sender, EventArgs e)
        {
            FaqView tournaments = new FaqView();
            tournaments.Show();
            this.Hide();
        }

        // Opens Data Analysis + Prediction Form
        private void btnAnalyzeData_Click_1(object sender, EventArgs e)
        {
            AnalysisView analysisForm = new AnalysisView();
            analysisForm.Show();

            this.Close();
        }

        // Navigate back to Sport Selection FOrm
        private void btnBack_Click(object sender, EventArgs e)
        {
            var SportSelection = new SportSelectView();
            SportSelection.Show();
            this.Close();
        }
    }
}

