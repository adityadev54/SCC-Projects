using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Population
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

            // Combox with sorting options
            cmbSortBox.Items.Add("Name");
            cmbSortBox.Items.Add("Ascending");
            cmbSortBox.Items.Add("Descending");
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            // First gets the selected sorting option from cmbSortBox
            string selectedOption = cmbSortBox.SelectedItem?.ToString();

            // Then checks if an option is selected
            if (string.IsNullOrEmpty(selectedOption))
            {
                MessageBox.Show("Select a sorting option.");
                return;
            }

            // Lastly, sorts the data in the Data Gridview
            if (selectedOption == "Ascending")
            {
                cityBindingSource.Sort = "Population ASC";
            }
            else if (selectedOption == "Descending")
            {
                cityBindingSource.Sort = "Population DESC";
            }
            else if (selectedOption == "Name")
            {
                cityBindingSource.Sort = "City ASC";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Adds a new row with the default data
            CityDBDataSet.CityRow newRow = this.cityDBDataSet.City.NewCityRow();
            newRow.City = "[Add City]";
            newRow.Population = 1000;
            newRow.State = "[Add State]";
            this.cityDBDataSet.City.AddCityRow(newRow);

            //cityBindingSource.EndEdit();
            //this.cityTableAdapter.Update(this.cityDBDataSet.City);
            popDataGridView.Refresh();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // It will delete the selected row
            if (popDataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)popDataGridView.SelectedRows[0].DataBoundItem;
                row.Delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Saves any changes to the database
            this.cityTableAdapter.Update(this.cityDBDataSet.City);
        }

        private void btnTotPop_Click(object sender, EventArgs e)
        {
            int totalPop = this.cityDBDataSet.City.Sum(row => row.Population);
            MessageBox.Show("The Total Population : " + totalPop);
        }

        private void btnAvgPop_Click(object sender, EventArgs e)
        {
            double avgeragePop = this.cityDBDataSet.City.Average(row => row.Population);
            MessageBox.Show("The Average Population : " + avgeragePop);
        }

        private void btnHighPop_Click(object sender, EventArgs e)
        {
            int highestPop = this.cityDBDataSet.City.Max(row => row.Population);
            MessageBox.Show("The Highest Population : " + highestPop);
        }

        private void btnLowPop_Click(object sender, EventArgs e)
        {
            int lowestPop = this.cityDBDataSet.City.Min(row => row.Population);
            MessageBox.Show("The Lowest Population : " + lowestPop);
        }
    }
}
