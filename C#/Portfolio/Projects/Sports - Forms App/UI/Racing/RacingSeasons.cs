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
    public partial class RacingSeasons : Form
    {
        public RacingSeasons()
        {
            InitializeComponent();
        }

        private void racesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.racesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.f1DB);

        }

        private void RacingSeasons_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'f1DB.Races' table. You can move, or remove it, as needed.
            this.racesTableAdapter.Fill(this.f1DB.Races);

            // Ensure the CircuitName column is visible 
            if (racesDataGridView.Columns.Contains("CircuitName"))
            {
                racesDataGridView.Columns["CircuitName"].Visible = true;
            }

            // Hide the CircuitID column 
            if (racesDataGridView.Columns.Contains("CircuitID"))
            {
                racesDataGridView.Columns["CircuitID"].Visible = false;
            }

            // Set the ComboBox display member to "Year" and bind it to the Races data
            racesComboBox.DisplayMember = "Year";
            racesComboBox.DataSource = this.f1DB.Races;

            // Get distinct years from the Races table, ordered by descending year
            var distinctYears = this.f1DB.Races.AsEnumerable()
                                   .Select(row => row.Field<int>("Year"))
                                   .Distinct()
                                   .OrderByDescending(year => year)
                                   .ToList();

            // Set distinct years as the DataSource for the ComboBox
            racesComboBox.DataSource = distinctYears;

            racesComboBox.SelectedIndexChanged += racesComboBox_SelectedIndexChanged;
        }
        private void racesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (racesComboBox.SelectedItem != null)
            {
                int selectedYear = (int)racesComboBox.SelectedItem;

                // Filter the races table to only show races from the selected year
                var filteredRaces = this.f1DB.Races.AsEnumerable()
                                                   .Where(row => row.Field<int>("Year") == selectedYear)
                                                   .CopyToDataTable();

                // Update DataGridView with the filtered races
                racesDataGridView.DataSource = filteredRaces;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
