/**
 * GROUP PROJECT #1
 * CPT - 206
 *
 * LOGIN VIEW
 **/

using _3Sports.Services;
using System;
using System.Windows.Forms;

namespace _3Sports.UI
{
    public partial class LoginView : Form
    {
        private readonly AuthService authService = new AuthService();
        public LoginView()
        {
            InitializeComponent();
            authService = new AuthService();

            // Hides the password
            txtPassword.PasswordChar = '\u25CF';
        }

        // Handle the login process through the button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            try
            {
                if (authService.LoginUser(username, password))
                {
                    MessageBox.Show("Login successful.");

                    // Navigate to Sport Selection View
                    this.Hide();
                    SportSelectView sportSelectView = new SportSelectView();
                    sportSelectView.Show();
                }
                else
                {
                    MessageBox.Show("Invalid login credentials.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured during login:  {ex.Message}");
            }
        }

        // Handle the Forgot Password View
        private void lblLForgotPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // This will open the Password Reset Form
            this.Hide();
            PasswordResetView passwordResetForm = new PasswordResetView();
            passwordResetForm.Show();
        }

        // Handle the Register View
        private void lblLRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterView registerForm = new RegisterView();
            registerForm.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                // Shows the password
                // And this will also show a null character for plain text
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                // Hides the password
                txtPassword.PasswordChar = '\u25CF'; // Or '\u25CF' for dots
            }
        }
    }
}
