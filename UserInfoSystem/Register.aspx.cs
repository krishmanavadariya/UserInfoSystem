using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace UserInfoSystem
{
    public partial class Register : System.Web.UI.Page
    {
        // Get the connection string from the Web.config file
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserInfoDB"].ConnectionString;

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string photoPath = null;

            // 1. Handle File Upload
            if (filePhoto.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(filePhoto.FileName);
                    string savePath = Server.MapPath("~/Uploads/") + filename;
                    filePhoto.SaveAs(savePath);
                    photoPath = "~/Uploads/" + filename; // Store the relative path
                }
                catch (Exception ex)
                {
                    ltlMessage.Text = "<p style='color:red;'>Photo upload failed: " + ex.Message + "</p>";
                    return;
                }
            }

            // 2. Use ADO.NET to INSERT data
            string sqlQuery = @"
                INSERT INTO Users 
                (FirstName, LastName, Gender, Birthdate, PhotoPath, Email, PhoneNumber, Address, Pincode, City, State, Username, Password)
                VALUES 
                (@FirstName, @LastName, @Gender, @Birthdate, @PhotoPath, @Email, @PhoneNumber, @Address, @Pincode, @City, @State, @Username, @Password)";

            // 'using' blocks ensure connections are closed even if errors occur
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        // 3. Add parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                        cmd.Parameters.AddWithValue("@Birthdate", string.IsNullOrEmpty(txtBirthdate.Text) ? (object)DBNull.Value : txtBirthdate.Text);
                        cmd.Parameters.AddWithValue("@PhotoPath", string.IsNullOrEmpty(photoPath) ? (object)DBNull.Value : photoPath);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Pincode", txtPincode.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text);
                        cmd.Parameters.AddWithValue("@State", txtState.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // IMPORTANT: Always hash passwords in a real app!

                        con.Open();
                        cmd.ExecuteNonQuery(); // Execute the INSERT command
                    }
                }

                // Redirect to login page on success
                Response.Redirect("Login.aspx");
            }
            catch (SqlException ex)
            {
                // Handle errors, e.g., duplicate username
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                {
                    ltlMessage.Text = "<p style='color:red;'>Username or Email already exists.</p>";
                }
                else
                {
                    ltlMessage.Text = "<p style='color:red;'>An error occurred: " + ex.Message + "</p>";
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "<p style='color:red;'>An error occurred: " + ex.Message + "</p>";
            }
        }
    }
}
