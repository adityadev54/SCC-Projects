/** 
 * GROUP PROJECT #1
 * CPT - 206 
 * 
 * SPLASH VIEW -- Opening screen for the Sports Insight+ application
**/

using System.Drawing;
using System.Windows.Forms;

namespace _3SPorts
{
    public partial class SplashView : Form
    {
        // Timer for loading
        private Timer loadingTimer;

        // Timer for image slideshow
        private Timer imageTimer;

        // Index to track slideshow images
        private int imageIndex = 0;

        // An array to store slideshow images
        private Image[] images;

        public SplashView()
        {
            InitializeComponent();
            LoadImages();
            SetupUI();
            LoadingAnimation();
            ImageSlideshow();
        }

        private void LoadImages()
        {
            images = new Image[]
            {
                _3Sports.Properties.Resources.CarPoster,
                _3Sports.Properties.Resources.FIFAPlayers,
                _3Sports.Properties.Resources.RaceCar,
                _3Sports.Properties.Resources.MessiAgen,
            };
        }

        // Sets up the UI bar
        private void SetupUI()
        {
            // Progress Indicator
            loadProgress = new ProgressBar
            {
                Size = new Size(300, 10),
                Location = new Point((this.Width - 300) / 2, 450),
                Style = ProgressBarStyle.Marquee,
            };
            this.Controls.Add(loadProgress);
        }

        private void LoadingAnimation()
        {
            loadingTimer = new Timer
            {
                // This will update the progress every 90ms
                Interval = 90,
            };
            int progress = 0;
            loadingTimer.Tick += (s, e) =>
            {
                loadProgress.Value = progress;
                progress += 1;
                if (progress >= 100)
                {
                    loadingTimer.Stop();

                    // This will hide Splah View
                    this.Hide();
                    //var SportSelectView = new _3Sports.UI.SportSelectView();

                    // Then show Sport Selection view
                    //SportSelectView.Show();

                    // ........................................................
                    // Add it when the auth is implemented

                    _3Sports.UI.LoginView loginForm = new _3Sports.UI.LoginView();
                    loginForm.Show();  // And then show up the Login View
                }
            };
            loadingTimer.Start();
        }

        // Image Slideshow method
        private void ImageSlideshow()
        {
            imageTimer = new Timer
            {
                Interval = 3000,
            };
            imageTimer.Tick += (s, e) =>
            {
                imageIndex = (imageIndex + 1) % images.Length;
                slideshowBox.Image = images[imageIndex];
                slideshowBox.Refresh();
            };
            imageTimer.Start();
        }
    }
}
