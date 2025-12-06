/** 
 * ADITYA PATEL
 * CPT - 206
 * SPLASH VIEW
 * **/

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APatel_Lab__3
{
    public partial class SplashView : Form
    {
        public SplashView()
        {
            InitializeComponent();
        }

        private async void SplashView_Load(object sender, EventArgs e)
        {
            splashLoader.Minimum = 0;
            splashLoader.Maximum = 100;

            string[] messages = { "Preparing data...", "Almost ready...", "Getting things set..." };

            // Loading up a simulation with random UX messages
            for (int i = 0; i <= 100; i++)
            {
                splashLoader.Value = i;
                statusLabel.Text = messages[i % messages.Length];
                await Task.Delay(80);
            }

            this.Hide();
            MainView mainView = new MainView();
            mainView.Show();
        }
    }
}
