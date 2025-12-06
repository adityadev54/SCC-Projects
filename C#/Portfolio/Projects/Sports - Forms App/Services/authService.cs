using _3Sports.classes;
using _3Sports.Sport_Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data.SqlClient;


namespace _3Sports.Services
{
    public class AuthService
    {
        private readonly UserDb userDb = new UserDb();
        private readonly PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        // Register a User
        public bool RegisterUser(string username, string email, string password, string securityQuestion1, string securityAnswer1, string securityQuestion2, string securityAnswer2, string securityQuestion3, string securityAnswer3)

        {
            string hashedPassword = passwordHasher.HashPassword(null, password); // Use full reference

            using (SqlConnection connection = userDb.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, Email, PasswordHash, SecurityQuestion1, SecurityAnswer1, SecurityQuestion2, SecurityAnswer2, SecurityQuestion3, SecurityAnswer3) VALUES (@Email, @Username, @PasswordHash, @SecurityQuestion1, @SecurityAnswer1, @SecurityQuestion2, @SecurityAnswer2, @SecurityQuestion3, @SecurityAnswer3)"; // Removed extra "string" keywords

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 100) { Value = email });
                    command.Parameters.Add(new SqlParameter("@Username", System.Data.SqlDbType.NVarChar, 50) { Value = username });
                    command.Parameters.Add(new SqlParameter("@PasswordHash", System.Data.SqlDbType.NVarChar, 255) { Value = hashedPassword });
                    command.Parameters.AddWithValue("@SecurityQuestion1", securityQuestion1);
                    command.Parameters.AddWithValue("@SecurityAnswer1", securityAnswer1);
                    command.Parameters.AddWithValue("@SecurityQuestion2", securityQuestion2);
                    command.Parameters.AddWithValue("@SecurityAnswer2", securityAnswer2);
                    command.Parameters.AddWithValue("@SecurityQuestion3", securityQuestion3);
                    command.Parameters.AddWithValue("@SecurityAnswer3", securityAnswer3);

                    int result = command.ExecuteNonQuery();

                    // True if registration is successful
                    return result > 0;
                }
            }
        }

        // Login a User
        public bool LoginUser(string username, string password)
        {
            string trimmedUsername = username.Trim().ToLower();
            using (SqlConnection connection = userDb.GetConnection())
            {
                connection.Open();
                string query = "SELECT PasswordHash, Email, LastLoggedIn FROM Users WHERE LOWER(Username) = LOWER(@Username) COLLATE SQL_Latin1_General_CP1_CI_AS";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", trimmedUsername);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            string email = reader["Email"].ToString();

                            // Handle nullable DateTime
                            DateTime? lastLoggedIn = reader["LastLoggedIn"] as DateTime?;

                            // For debugging purposes - Logs the login attempt
                            Console.WriteLine($"Login attempt for Username: {trimmedUsername}");

                            // Logs the stored hash
                            Console.WriteLine($"Stored hash found: {storedHash}");

                            var result = passwordHasher.VerifyHashedPassword(null, storedHash, password);

                            // Logs the verification result
                            Console.WriteLine($"Password verification result: {result}");

                            if (result == PasswordVerificationResult.Success)
                            {
                                // Store the username, email, and LastLoggedIn in the session
                                UserSession.CurrentUsername = username;
                                UserSession.CurrentEmail = email;

                                // Store the LastLoggedIn date as a string
                                UserSession.LastLoggedIn = lastLoggedIn?.ToString();

                                UpdateLastLoggedIn(username);
                                return true;
                            }
                        }
                        else
                        {
                            // Logs if no hash is found
                            Console.WriteLine("Stored hash not found.");
                        }
                    }
                }
            }
            return false;
        }


        // Reset User Password
        public bool ResetPassword(string email, string newPassword)
        {
            // This will hash the new password before saving it to the database
            string hashedPassword = passwordHasher.HashPassword(null, newPassword);
            using (SqlConnection connection = userDb.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@Email", email);
                    int result = command.ExecuteNonQuery();

                    // Then return true if the update was successful
                    return result > 0;
                }
            }
        }

        // Get Security Questions
        public string[] GetSecurityQuestions(string email)
        {
            using (SqlConnection connection = userDb.GetConnection())
            {
                connection.Open();
                string query = "SELECT SecurityQuestion1, SecurityQuestion2, SecurityQuestion3 FROM Users WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new string[]
                            {
                        reader["SecurityQuestion1"].ToString(),
                        reader["SecurityQuestion2"].ToString(),
                        reader["SecurityQuestion3"].ToString()
                            };
                        }
                    }
                }
            }

            // Return null if no questions were found
            return null;
        }

        // Verify Security Answers
        public bool VerifySecurityAnswers(string email, string answer1, string answer2, string answer3)
        {
            using (SqlConnection connection = userDb.GetConnection())
            {
                connection.Open();
                string query = "SELECT SecurityAnswer1, SecurityAnswer2, SecurityAnswer3 FROM Users WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedAnswer1 = reader["SecurityAnswer1"].ToString();
                            string storedAnswer2 = reader["SecurityAnswer2"].ToString();
                            string storedAnswer3 = reader["SecurityAnswer3"].ToString();

                            // Answer comparison is case-sensitive
                            return storedAnswer1 == answer1 && storedAnswer2 == answer2 && storedAnswer3 == answer3;
                        }
                    }
                }
            }

            // Return false if answers don't match or user not found
            return false;
        }

        // Update the User's last login date
        private void UpdateLastLoggedIn(string username)
        {
            using (SqlConnection connection = userDb.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Users SET LastLoggedIn = @LastLoggedIn WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastLoggedIn", DateTime.Now);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}