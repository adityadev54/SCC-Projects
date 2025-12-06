/** 
 * GROUP PROJECT #1
 * CPT - 206 
 * 
 * SOCCER SELECT VIEW
**/

using _3Sports.classes;
using _3Sports.Services;
using _3Sports.UI.SubForms;
using System.Drawing;
using System.Windows.Forms;

namespace _3Sports.UI
{
    public partial class SportSelectView : Form
    {
        private string selectedSport = "";
        private readonly AuthService authService = new AuthService();

        public SportSelectView()
        {
            InitializeComponent();
            authService = new AuthService();
            string username = UserSession.CurrentUsername;

            // Show the username
            if (!string.IsNullOrEmpty(username))
            {
                lblUsername.Text = $"Welcome, {username}!";
            }
            else
            {
                lblUsername.Text = "Welcome, Guest!"; // Or handle the error appropriately
            }

            // Assigning the event handlers for the card selection
            racingBox.Click += (sender, e) => SelectSport("Racing", racingBox);
            soccerBox.Click += (sender, e) => SelectSport("Soccer", soccerBox);
            rugbyBox.Click += (sender, e) => SelectSport("Unknown", rugbyBox);

            // Initially disabled the continue button
            btnContinue.Enabled = false;
        }

        private void SelectSport(string sportName, GroupBox groupBox)
        {
            // This clears the highlight from all the cards
            ClearCardSelection();

            // Then this highlights the selected card
            groupBox.BackColor = Color.FromArgb(211, 211, 211);
            lblRacing.ForeColor = Color.Black;
            lblRTag.ForeColor = Color.Black;
            lblSoccer.ForeColor = Color.Black;
            lblSTag.ForeColor = Color.Black;
            lblUnknown.ForeColor = Color.Black;
            lblUTag.ForeColor = Color.Black;


            // Then stores the selected sport
            selectedSport = sportName;

            // Then enables the continue button
            btnContinue.Enabled = true;
        }

        private void ClearCardSelection()
        {
            // Reset the background color for all GropuBox controls
            racingBox.BackColor = Color.Transparent;
            soccerBox.BackColor = Color.Transparent;
            rugbyBox.BackColor = Color.Transparent;
        }

        private void btnContinue_Click(object sender, System.EventArgs e)
        {
            // Handle the navigation based on the selected sport
            if (!string.IsNullOrEmpty(selectedSport))
            {
                // Just used it for debugging purposes
                // MessageBox.Show($"You selected {selectedSport}");

                // After, we will proceed to the next form based on the selected sport
                if (selectedSport == "Racing")
                {
                    RacingSport racingForm = new RacingSport();
                    racingForm.Show();

                    // Hides the current form
                    this.Hide();
                }
                else if (selectedSport == "Soccer")
                {
                    SoccerView soccerForm = new SoccerView();
                    soccerForm.Show();

                    // Hides the current form
                    this.Hide();
                }
                else if (selectedSport == "Unknown")
                {
                    RugbyView unknownForm = new RugbyView();
                    unknownForm.Show();

                    // Hides the current form
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please select a sport to continue.");
            }
        }


        private void btnSetting_Click_1(object sender, System.EventArgs e)
        {
            this.Hide();
            AppInfo settingForm = new AppInfo();
            settingForm.Show();
        }
    }
}


