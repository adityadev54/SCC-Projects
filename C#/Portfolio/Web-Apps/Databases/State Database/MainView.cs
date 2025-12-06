/** 
 * ADITYA PATEL
 * CPT - 206
 * MAIN VIEW
 * **/

using System;
using System.Windows.Forms;

namespace APatel_Lab__3
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            ConfigureUI();
        }

        private void ConfigureUI()
        {
            LoadStateCmbStates();

            // Ensures that there is no default selection
            cmbStates.SelectedIndex = -1;

            //btnSelectState.Click += btnSelectState_Click_1;
            btnDataView.Click += btnDataView_Click_1;
        }
        private void LoadStateCmbStates()
        {
            //cmbStates.Items.Clear();
            cmbStates.Items.AddRange(new string[] {
                "Florida",
                "Illinois",
                "New York",
                "Texas",
            });

            for (int i = 0; i < StateDataStore.States.Count; i++)
            {
                string stateName = StateDataStore.States[i].StateName;
                cmbStates.Items.Add(stateName);
            }
        }

        private void btnSelectState_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SelectStateView selectStateView = new SelectStateView();
            selectStateView.Show();
        }

        private void btnDataView_Click_1(object sender, EventArgs e)
        {
            if (cmbStates.SelectedItem != null)
            {
                string selectedState = cmbStates.SelectedItem.ToString();

                DataCoreView dataView = new DataCoreView(selectedState);
                this.Hide();
                dataView.Show();
            }
            else
            {
                MessageBox.Show("Please select a state to view data.", "Selection Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
