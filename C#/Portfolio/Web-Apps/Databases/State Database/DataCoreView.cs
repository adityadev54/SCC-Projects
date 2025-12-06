/** 
 * ADITYA PATEL
 * CPT - 206
 * DATA CORE VIEW
 * **/

using System;
using System.Data;
using System.Windows.Forms;

namespace APatel_Lab__3
{
    public partial class DataCoreView : Form
    {
        private DataTable stateTable;
        private string selectedState;

        public DataCoreView() // Default constructor that initializes the UI components
        {
            InitializeComponent();
            LoadData();
            ConfigureDataGrid();
        }

        public DataCoreView(string state) : this()
        {
            selectedState = state;
            DisplaySelectedState();
        }

        // Loas state data into a DataTable
        private void LoadData()
        {
            stateTable = new DataTable();

            stateTable.Columns.Add("State Name");
            stateTable.Columns.Add("Population");
            stateTable.Columns.Add("Flag Description");
            stateTable.Columns.Add("State Flower");
            stateTable.Columns.Add("State Bird");
            stateTable.Columns.Add("State Colors");
            stateTable.Columns.Add("Largest City 1");
            stateTable.Columns.Add("Largest City 2");
            stateTable.Columns.Add("Largest City 3");
            stateTable.Columns.Add("State Capital");
            stateTable.Columns.Add("Median Income");
            stateTable.Columns.Add("Computer Jobs %");

            // Pre-defined Data
            stateTable.Rows.Add("Florida", "21,477,737", "Sunshine Flag", "Orange Blossom", "Northern Mockingbird", "Orange and Green", "Jacksonville", "Miami", "Tampa", "Tallahassee", "$57,703", "7.4%");
            stateTable.Rows.Add("Illinois", "12,671,821", "Prairie State Flag", "Violet", "Northern Cardinal", "Blue and White", "Chicago", "Aurora", "Naperville", "Springfield", "$65,886", "6.7%");
            stateTable.Rows.Add("New York", "19,453,561", "Empire Flag", "Rose", "Eastern Bluebird", "Blue and Gold", "New York City", "Buffalo", "Rochester", "Albany", "$64,894", "6.3%");
            stateTable.Rows.Add("Texas", "28,995,881", "Lone Star Flag", "Bluebonnet", "Northern Mockingbird", "Blue, White, Red", "Houston", "San Antonio", "Dallas", "Austin", "$59,570", "5.2%");

            for (int i = 0; i < StateDataStore.States.Count; i++)
            {
                State state = StateDataStore.States[i];
                stateTable.Rows.Add(state.StateName, state.Population, state.FlagDescription, state.StateFlower, state.StateBird, state.StateColors, state.LargestCity1, state.LargestCity2, state.LargestCity3, state.StateCapital, state.MedianIncome, state.ComputerJobPercentage);
            }

            dgvStates.DataSource = stateTable;
        }

        private void DisplaySelectedState()
        {
            if (!string.IsNullOrEmpty(selectedState))
            {
                foreach (DataGridViewRow row in dgvStates.Rows)
                {
                    if (row.Cells["State Name"].Value?.ToString() == selectedState)
                    {
                        row.Selected = true;
                        dgvStates.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
        }

        private void ConfigureDataGrid()
        {
            dgvStates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStates.ReadOnly = true;

            // Format Population and Median Income with commas
            dgvStates.Columns["Population"].DefaultCellStyle.Format = "#,0";
            dgvStates.Columns["Median Income"].DefaultCellStyle.Format = "#,0";

            // Format Computer Jobs % to show as percentage
            dgvStates.Columns["Computer Jobs %"].DefaultCellStyle.Format = "P1";  // P1 is for 1 decimal place percentage formatting

            // Attach event handlers
            btnSearch.Click += btnSearch_Click;
            btnReset.Click += btnReset_Click;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                DataView dv = stateTable.DefaultView;
                dv.RowFilter = $"[State Name] LIKE '%{searchTerm}%' OR [State Capital] LIKE '%{searchTerm}%'";
            }
        }

        // Reset the filter
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            stateTable.DefaultView.RowFilter = string.Empty;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainView mainView = new MainView(); // Navigate Back
            mainView.Show();
        }
    }
}
