/**
 * GROUP PROJECT #1
 * CPT - 206
 *
 * REGISTER VIEW
 **/

using _3Sports.Services;
using System;
using System.Windows.Forms;

namespace _3Sports.UI
{
    public partial class RegisterView : Form
    {
        private readonly AuthService authService = new AuthService();

        public RegisterView()
        {
            InitializeComponent();
            authService = new AuthService();

            // Manual population of security questions
            PopulateSecurityQuestions(cmbSecurityQuestion1);
            PopulateSecurityQuestions(cmbSecurityQuestion2);
            PopulateSecurityQuestions(cmbSecurityQuestion3);
        }

        private void PopulateSecurityQuestions(ComboBox comboBox)
        {
            comboBox.Items.Add("What is your mother's maiden name?");
            comboBox.Items.Add("What was the name of your first pet?");
            comboBox.Items.Add("What is the name of your favorite teacher?");
            comboBox.Items.Add("What was the name of your elementary school?");
            comboBox.Items.Add("What is your favorite childhood book?");
            comboBox.Items.Add("What is your favorite food?");
            comboBox.Items.Add("What is your dream travel destination?");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPwd.Text;

            // Get security questions and answers from the form controls
            string securityQuestion1 = cmbSecurityQuestion1.SelectedItem != null ? cmbSecurityQuestion1.SelectedItem.ToString() : string.Empty;
            string securityAnswer1 = txtSecurityAnswer1.Text;
            string securityQuestion2 = cmbSecurityQuestion2.SelectedItem != null ? cmbSecurityQuestion2.SelectedItem.ToString() : string.Empty;
            string securityAnswer2 = txtSecurityAnswer2.Text;
            string securityQuestion3 = cmbSecurityQuestion3.SelectedItem != null ? cmbSecurityQuestion3.SelectedItem.ToString() : string.Empty;
            string securityAnswer3 = txtSecurityAnswer3.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Your password does not match.");
                return;
            }

            // Validate security answers
            if (string.IsNullOrEmpty(securityAnswer1) || string.IsNullOrEmpty(securityAnswer2) || string.IsNullOrEmpty(securityAnswer3))
            {
                MessageBox.Show("Please answer all security questions.");
                return;
            }

            if (authService.RegisterUser(email, username, password, securityQuestion1, securityAnswer1, securityQuestion2, securityAnswer2, securityQuestion3, securityAnswer3))
            {
                MessageBox.Show($"Registration successful. {username} you can now login.");

                // Navigate to Login Form
                this.Hide();
                LoginView loginForm = new LoginView();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        // Navigate back to our login view
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginView loginForm = new LoginView();
            loginForm.Show();
        }

        // Navigate to our login view
        private void lblLLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginView loginForm = new LoginView();
            loginForm.Show();
            this.Close();
        }
    }
}