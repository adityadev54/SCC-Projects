using _3Sports.classes;
using System;
using System.Windows.Forms;

namespace _3Sports.UI.SubForms
{
    public partial class RugbyPlayersView : Form
    {
        string username = UserSession.CurrentUsername;
        public RugbyPlayersView()
        {
            InitializeComponent();
        }

        
        //a series of click events that query the database for the proper information regarding the players
        private void picBristol_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.BristolPlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.BristolPlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void picExeter_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.ExeterPlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.ExeterPlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void picGloucester_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.GloucesterPlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.GloucesterPlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void picLeicester_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.LeicesterPlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.LeicesterPlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void picHarlequins_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.HarlequinsPlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.HarlequinsPlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void picNorthampton_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.NorthamptonPlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.NorthamptonPlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void picSale_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.SalePlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.SalePlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void picNewcastle_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.NewcastlePlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.NewcastlePlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void picSaracens_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.SaracensPlayerSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.SaracensPlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void btnBack_Click(object sender, EventArgs e)// returns to the previous form 
        {
            RugbyView teams = new RugbyView();
            this.Close();
            teams.ShowDialog();
            
        }
        //sets the user label to show the username of the current user
        private void RugbyPlayersView_Load(object sender, EventArgs e)
        {
            lblUser.Text = username;
        }

        private void picBath_Click(object sender, EventArgs e)
        {
            this.players2024TableAdapter.BathPlayersSelect(this.premiershipRugbyDataDataSet.Players2024);
            this.players2025TableAdapter.BathPlayerSelect(this.premiershipRugbyDataDataSet.Players2025);
        }

        private void btnExit_Click(object sender, EventArgs e)//exits the application 
        {
            Application.Exit();
        }
    }
    
}
