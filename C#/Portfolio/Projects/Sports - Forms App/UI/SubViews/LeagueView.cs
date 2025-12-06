/** 
 * GROUP PROJECT #1
 * CPT - 206 
 * 
 * LEAGUE VIEW 
**/


using _3Sports.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _3Sports.UI.SubForms
{
    public partial class LeagueView : Form
    {
        private DataTable _tournamentTable;
        private readonly MultiFileDataService _dataService;
        private readonly string _selectedLeague;
        private readonly string _selectedTeam;

        public LeagueView(MultiFileDataService dataService, string selectedLeague, string selectedSeason, string selectedTeam)
        {
            InitializeComponent();

            // This recieves the Data Service instance
            _dataService = dataService;

            // And this stores selected league for display
            _selectedLeague = selectedLeague;
            _selectedTeam = selectedLeague;
            lblChosenLeague.Text = $"{_selectedLeague}";
            LoadSoccerData();
        }

        private void LoadSoccerData()
        {
            if (_dataService == null)
            {
                MessageBox.Show("Data service is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_tournamentTable == null || _tournamentTable.Rows.Count == 0)
            {

                _tournamentTable = _dataService.GetAllData();

                if (_tournamentTable != null && _tournamentTable.Rows.Count > 0)
                {
                    // Apply initial team filter
                    var filteredByTeam = _tournamentTable.AsEnumerable()
                        .Where(row => row["HomeTeam"].ToString().Equals(_selectedTeam, StringComparison.OrdinalIgnoreCase));

                    _tournamentTable = filteredByTeam.Any() ? filteredByTeam.CopyToDataTable() : _tournamentTable.Clone();

                    dgvPL.DataSource = _tournamentTable;
                    PopulateSeasonFilterDropdown();
                    PopulateDateFilters();
                    PopulateHomeTeamFilters();
                }
                else
                {
                    MessageBox.Show("No tournament data loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                dgvPL.DataSource = _tournamentTable;
            }
        }

        private void ApplyFilters()
        {
            if (_tournamentTable == null || _tournamentTable.Rows.Count == 0)
                return;

            string searchKeyword = txtSearch.Text.Trim().ToLower();
            var selectedHomeTeams = chkFilterByHomeTeam.Controls.OfType<CheckBox>()
                .Where(cb => cb.Checked)
                .Select(cb => cb.Text)
                .ToList();
            var selectedDates = chkFilterByDate.Controls.OfType<CheckBox>()
                .Where(cb => cb.Checked)
                .Select(cb => cb.Text)
                .ToList();

            string selectedSeasonFilter = cmbSeasonFilter.SelectedItem?.ToString() ?? "All Seasons";

            var filteredRows = _tournamentTable.AsEnumerable().Where(row =>
                (string.IsNullOrWhiteSpace(searchKeyword) ||
                 row["HomeTeam"].ToString().ToLower().Contains(searchKeyword) ||
                 row["AwayTeam"].ToString().ToLower().Contains(searchKeyword)) && // Search in AwayTeam

                (selectedHomeTeams.Count == 0 || selectedHomeTeams.Contains(row["HomeTeam"].ToString())) &&

                (selectedDates.Count == 0 || selectedDates.Contains(row["Date"].ToString())) &&

                (selectedSeasonFilter == "All Seasons" || row["Season"].ToString().Equals(selectedSeasonFilter, StringComparison.OrdinalIgnoreCase))
            );

            dgvPL.DataSource = filteredRows.Any() ? filteredRows.CopyToDataTable() : _tournamentTable.Clone();

            ShowFilteredColumns(selectedDates.Count > 0, selectedHomeTeams.Count > 0);
        }

        private void ShowFilteredColumns(bool filterByDate, bool filterByHomeTeam)
        {
            // Always show all columns by default
            foreach (DataGridViewColumn column in dgvPL.Columns)
            {
                column.Visible = true;
            }

            // Hide columns if filtering by Date
            if (filterByDate)
            {
                foreach (DataGridViewColumn column in dgvPL.Columns)
                {
                    if (!(column.Name == "Date" ||
                          column.Name == "AwayTeam" ||
                          column.Name == "FTHG" ||
                          column.Name == "FTAG" ||
                          column.Name == "FTR" ||
                          column.Name == "Referee" ||
                          column.Name == "HS" ||
                          column.Name == "HST" ||
                          column.Name == "HF" ||
                          column.Name == "HC" ||
                          column.Name == "HY" ||
                          column.Name == "HR"))
                    {
                        // Hides irrelevant columns when filtering by date
                        column.Visible = false;
                    }
                }
            }

            // Hide columns if filtering by HomeTeam
            if (filterByHomeTeam)
            {
                foreach (DataGridViewColumn column in dgvPL.Columns)
                {
                    if (!(column.Name == "HomeTeam" ||
                          column.Name == "FTHG" ||
                          column.Name == "FTAG" ||
                          column.Name == "FTR" ||
                          column.Name == "HTHG" ||
                          column.Name == "HTR" ||
                          column.Name == "Referee" ||
                          column.Name == "AS" ||
                          column.Name == "AST" ||
                          column.Name == "AF" ||
                          column.Name == "AC" ||
                          column.Name == "AY" ||
                          column.Name == "AR"))
                    {
                        // Hide irrelevant columns when filtering by the HomeTeam
                        column.Visible = false;
                    }
                }
            }
        }

        private void PopulateDateFilters()
        {
            if (_tournamentTable == null) return;

            var uniqueDates = _tournamentTable.AsEnumerable()
                .Select(row => row["Date"].ToString())
                .Where(date => !string.IsNullOrWhiteSpace(date))
                .Distinct()
                .OrderBy(date => date)
                .ToList();

            chkFilterByDate.Controls.Clear();

            foreach (var date in uniqueDates)
            {
                var checkBox = new CheckBox
                {
                    Text = date,
                    AutoSize = true
                };
                checkBox.CheckedChanged += (sender, e) => ApplyFilters();
                chkFilterByDate.Controls.Add(checkBox);
            }
        }

        // Populate by Season 
        private void PopulateSeasonFilterDropdown()
        {
            if (_tournamentTable == null) return;

            cmbSeasonFilter.Items.Clear();
            cmbSeasonFilter.Items.Add("All Seasons");

            List<string> uniqueSeasons = _tournamentTable.AsEnumerable()
                .Select(row => row["Season"].ToString())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(season => season)
                .ToList();

            cmbSeasonFilter.Items.AddRange(uniqueSeasons.ToArray());

            // To default
            cmbSeasonFilter.SelectedIndex = 0;
            cmbSeasonFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        // Filter by Home team
        private void PopulateHomeTeamFilters()
        {
            if (_tournamentTable == null) return;

            chkFilterByHomeTeam.Controls.Clear();

            var uniqueHomeTeams = _tournamentTable.AsEnumerable()
                .Select(row => row["HomeTeam"].ToString())
                .Where(team => !string.IsNullOrWhiteSpace(team))
                .Distinct()
                .OrderBy(team => team)
                .ToList();

            foreach (var HT in uniqueHomeTeams)
            {
                var checkBox = new CheckBox
                {
                    Text = HT,
                    AutoSize = true
                };
                checkBox.CheckedChanged += (sender, e) => ApplyFilters();
                chkFilterByHomeTeam.Controls.Add(checkBox);
            }
        }

        private void btnHistoryData_Click(object sender, EventArgs e)
        {
            if (_dataService == null)
            {
                MessageBox.Show("Data service is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_tournamentTable == null || _tournamentTable.Rows.Count == 0)
            {
                _tournamentTable = _dataService.GetAllData();

                if (_tournamentTable != null && _tournamentTable.Rows.Count > 0)
                {
                    dgvPL.DataSource = _tournamentTable;
                    PopulateSeasonFilterDropdown();
                    PopulateDateFilters();
                    PopulateHomeTeamFilters();
                }
                else
                {
                    MessageBox.Show("No tournament data loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                dgvPL.DataSource = _tournamentTable;
            }

            // Hide all columns by default
            foreach (DataGridViewColumn column in dgvPL.Columns)
            {
                column.Visible = false;
            }

            // Show only the relevant columns for history data
            string[] historyColumns = { "Date", "HomeTeam", "AwayTeam", "FTHG", "FTAG", "FTR", "HTHG", "HTAG", "HTR", "Referee", "HS", "AS", "HST", "AST", "HF", "AF", "HC", "AC", "HY", "AY", "HR", "AR" };

            foreach (string columnName in historyColumns)
            {
                if (dgvPL.Columns.Contains(columnName))
                {
                    dgvPL.Columns[columnName].Visible = true;
                }
            }
        }



        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilters();
        private void cmbLeague_SelectedIndexChanged_1(object sender, EventArgs e) => ApplyFilters();
        private void chkFilterByDate_CheckedChanged(object sender, EventArgs e) => ApplyFilters();

        private void btnSearch_Click(object sender, EventArgs e) => ApplyFilters();
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            var SoccerSport = new SoccerView();
            SoccerSport.Show();
            this.Close();
        }
    }
}