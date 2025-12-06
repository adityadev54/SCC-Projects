/** 
 * GROUP PROJECT #1
 * CPT - 206 
 * 
 * FAQ SUB FORM
**/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace _3Sports.UI.SubForms
{
    public partial class FaqView : Form
    {
        // Ensuring it's properly referenced
        private TextBox searchTextBox;

        public FaqView()
        {
            InitializeComponent();
            SetupRoundedSearchTextBox();
            DisplayAllFAQPanels();
            btnSearch.Click += btnSearch_Click;
        }

        private void SetupRoundedSearchTextBox()
        {
            searchTextBox = this.Controls.Find("searchBar", true).OfType<TextBox>().FirstOrDefault();

            if (searchTextBox != null)
            {
                searchTextBox.BorderStyle = BorderStyle.None;
                searchTextBox.BackColor = Color.White;
                searchTextBox.Font = new Font("Segoe UI", 10);

                // Wrapped inside a Panel for better padding controls
                Panel searchPanel = new Panel
                {
                    Location = searchTextBox.Location,
                    Size = new Size(searchTextBox.Width + 20, searchTextBox.Height + 4),
                    BackColor = Color.White
                };

                // Make the Panel rounded
                int radius = searchPanel.Height;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(searchPanel.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(searchPanel.Width - radius, searchPanel.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, searchPanel.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                searchPanel.Region = new Region(path);

                // Padding adjustment - Like (Move TextBox inside Panel)
                searchTextBox.Location = new Point(10, (searchPanel.Height - searchTextBox.Height) / 2);
                searchTextBox.Width = searchPanel.Width - 20;

                this.Controls.Add(searchPanel);
                searchPanel.Controls.Add(searchTextBox);
                searchTextBox.BringToFront();
            }
            else
            {
                MessageBox.Show("Error: TextBox named 'searchBar' not found!", "Setup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAllFAQPanels()
        {
            initialSetupPanel.Visible = true;
            statsPanel.Visible = true;
            leaguePanel.Visible = true;
            filtersPanel.Visible = true;
            troubleshootPanel.Visible = true;
            dataUpdatesPanel.Visible = true;
        }

        private void PerformSearch(string searchText)
        {
            string lowerSearchText = searchText.ToLower();
            Panel[] panels = { initialSetupPanel, statsPanel, leaguePanel, filtersPanel, troubleshootPanel, dataUpdatesPanel };

            foreach (Panel panel in panels)
            {
                bool panelMatch = false;

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    foreach (Label label in panel.Controls.OfType<Label>())
                    {
                        if (label.Text.ToLower().Contains(lowerSearchText))
                        {
                            panelMatch = true;
                            break;
                        }
                    }
                }
                else
                {
                    // Show all if search is empty
                    panelMatch = true;
                }

                panel.Visible = panelMatch;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (searchTextBox == null)
            {
                MessageBox.Show("Error: searchTextBox is NULL! Check Designer setup.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PerformSearch(searchTextBox.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var SoccerSport = new SoccerView();
            SoccerSport.Show();
            this.Close();
        }
    }
}
