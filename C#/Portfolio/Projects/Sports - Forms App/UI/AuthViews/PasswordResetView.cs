/**
 * GROUP PROJECT #1
 * CPT - 206
 *
 * PASSWORD RESET VIEW
 **/

using _3Sports.Services;
using System;
using System.Windows.Forms;

namespace _3Sports.UI
{
    public partial class PasswordResetView : Form
    {
        private readonly AuthService authService = new AuthService();

        // Flags to track if questionas and answers are shown and verified
        private bool questionsShown = false;
        private bool answersVerified = false;

        public PasswordResetView()
        {
            InitializeComponent();

            // Hide the answer fields, new password fields, and submit button initially
            txtAnswer1.Visible = false;
            subtitle.Visible = true;
            question1.Visible = true;
            question2.Visible = true;
            question3.Visible = true;
            lblQuestion1.Visible = true;
            lblQuestion2.Visible = true;
            lblQuestion3.Visible = true;
            txtAnswer2.Visible = false;
            txtAnswer3.Visible = false;
            txtNewPwd.Visible = false;
            txtConfirmNewPwd.Visible = false;
            btnSubmit.Visible = false;
        }

        // This event handler is  triggered when the Next button is pressed
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address.");
                return;
            }

            if (!questionsShown)
            {
                string[] securityQuestions = authService.GetSecurityQuestions(email);

                if (securityQuestions != null && securityQuestions.Length == 3)
                {
                    // Show the security questions
                    lblQuestion1.Text = securityQuestions[0];
                    lblQuestion2.Text = securityQuestions[1];
                    lblQuestion3.Text = securityQuestions[2];

                    // Show answer fields
                    txtAnswer1.Visible = true;
                    txtAnswer2.Visible = true;
                    txtAnswer3.Visible = true;

                    // Disable the email field to prevent changes 
                    txtEmail.Enabled = false;

                    questionsShown = true; // Mark up the questions as shown
                }
                else
                {
                    MessageBox.Show("Failed to retrieve security questions. Please try again.");
                }
            }
            else if (!answersVerified)
            {
                // Security answer verification
                string answer1 = txtAnswer1.Text;
                string answer2 = txtAnswer2.Text;
                string answer3 = txtAnswer3.Text;

                if (string.IsNullOrWhiteSpace(answer1) || string.IsNullOrWhiteSpace(answer2) || string.IsNullOrWhiteSpace(answer3))
                {
                    MessageBox.Show("Please provide answers to all security questions.");
                    return;
                }

                if (authService.VerifySecurityAnswers(email, answer1, answer2, answer3))
                {
                    answersVerified = true; // Mark up the answers as verified

                    // Then show the password fields
                    txtNewPwd.Visible = true;
                    txtConfirmNewPwd.Visible = true;
                    btnSubmit.Visible = true;

                    // Change the Next button to "Submit"
                    btnNext.Visible = false;
                }
                else
                {
                    MessageBox.Show("Incorrect security answers. Please try again.");
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string newPassword = txtNewPwd.Text;
            string confirmPassword = txtConfirmNewPwd.Text;

            // Validation to check if the fields are filled
            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Validation to check if the passwords match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (authService.ResetPassword(email, newPassword))
            {
                MessageBox.Show("Password reset successfully");

                // Then navigate back to the login view
                LoginView loginForm = new LoginView();
                loginForm.Show();

                // and this will close the current view
                this.Close();
            }
            else
            {
                MessageBox.Show("Password reset failed. Please try again.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // This will hide the current view (Password Reset View))
            this.Hide();

            LoginView loginForm = new LoginView();

            // Then show the login view
            loginForm.Show();
        }
    }
}
