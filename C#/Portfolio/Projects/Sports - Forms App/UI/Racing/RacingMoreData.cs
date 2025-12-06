using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3Sports.UI
{
    public partial class RacingMoreData : Form
    {
        public RacingMoreData()
        {
            InitializeComponent();
        }

        private void currentConstructorsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.currentConstructorsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.f1DB);

        }

        private BindingList<string> raceNamesBindingList = new BindingList<string>();
        private void RacingMoreData_Load(object sender, EventArgs e)
        {

            F1DB.ResultsDataTable table = this.resultsTableAdapter.GetDataByResult();
            // Get distinct years from the Results table 
            var distinctYears = table.AsEnumerable()
                         .Select(row => row.Field<int>("Year"))
                         .Distinct()
                         .OrderByDescending(Year => Year)
                         .ToList();

            //Set the ComboBox DataSource to the list of distinct years
            cboxYear.DataSource = distinctYears;
            cboxYear.DisplayMember = "Year";

            //Set ListBox data source to the BindingList
            resultsListBox.DataSource = raceNamesBindingList;

            //ComboBox's SelectedIndexChanged event
            cboxYear.SelectedIndexChanged += CboxYear_SelectedIndexChanged;

            this.resultsListBox.SelectedIndexChanged += new System.EventHandler(this.ResultsListBox_SelectedIndexChanged);

        }

        // Separate event handler for ComboBox SelectedIndexChanged
        private void CboxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure the selected item is an int (year)
            if (cboxYear.SelectedItem != null)
            {
                int selectedYear = (int)cboxYear.SelectedItem;

                // Fetch race data for the selected year from the database
                var raceDataForSelectedYear = this.resultsTableAdapter.GetDataByResult()
                    .AsEnumerable()  // Convert DataTable to IEnumerable to use LINQ
                    .Where(row => row.Field<int>("Year") == selectedYear)  // Filter by year
                    .OrderBy(row => row.Field<int>("RaceRound"))  // Sort by RaceRound
                    .Select(row => new
                    {//we will need these later to populate the textboxes
                        RaceName = row.Field<string>("RaceName"),
                        RaceRound = row.Field<int>("RaceRound"),
                        ResultID = row.Field<int> ("ResultID"),
                        Winner = row.Field<string>("Winner"),
                        DriverID = row.Field<int>("DriverID"),
                        RaceID = row.Field<int>("RaceID"),
                        Number = row.Field<int>("Number"),
                        Grid = row.Field<int>("Grid"),
                        Points = row.Field<decimal>("Points"),
                        Laps = row.Field<int>("Laps"),
                        Constructor = row.Field<string>("Constructor"),
                    })
                    .ToList();

                // Clear the BindingList instead of the ListBox
                raceNamesBindingList.Clear();

                // Populate the BindingList, which is automatically in the ListBox
                foreach (var race in raceDataForSelectedYear)
                {
                    raceNamesBindingList.Add($"{race.RaceRound}: {race.RaceName}");
                }
            }
        }

        // Handle the selection of a race in the ListBox
        private void ResultsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure the user has selected a race round
            if (resultsListBox.SelectedItem != null)
            {
                // Extract the selected race round text
                string selectedRaceText = resultsListBox.SelectedItem.ToString();

                // Find the race round and name from the text (the format is "RaceRound: RaceName")
                string[] raceInfo = selectedRaceText.Split(':');
                int selectedRaceRound = int.Parse(raceInfo[0].Trim());

                // Fetch the race data for the selected race round (same year selected earlier)
                var selectedRace = this.resultsTableAdapter.GetDataByResult()
                    .AsEnumerable()
                    .Where(row => row.Field<int>("Year") == (int)cboxYear.SelectedItem)  // Filter by year
                    .Where(row => row.Field<int>("RaceRound") == selectedRaceRound)  // Filter by race round
                    .FirstOrDefault();  // Get the first match (but there should be only one)

                if (selectedRace != null)
                {
                    // Populate the TextBoxes with the race details
                    raceIDTextBox.Text = selectedRace.Field<int>("RaceID").ToString();
                    winnerTextBox.Text = selectedRace.Field<string>("Winner");
                    raceNameTextBox.Text = selectedRace.Field<string>("RaceName");
                    raceRoundTextBox.Text = selectedRace.Field<int>("RaceRound").ToString();
                    driverIDTextBox.Text = selectedRace.Field<int>("DriverID").ToString();
                    numberTextBox.Text = selectedRace.Field<int>("Number").ToString();
                    constructorTextBox.Text = selectedRace.Field<string>("Constructor");
                    gridTextBox.Text = selectedRace.Field<int>("Grid").ToString();
                    pointsTextBox.Text = selectedRace.Field<decimal>("Points").ToString();
                    lapsTextBox.Text = selectedRace.Field<int>("Laps").ToString();

                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
