using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace UserInfoSystem
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserInfoDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. SECURITY: Check if user is logged in
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // 2. Load data only on the first visit, not on "Save" click
            if (!IsPostBack)
            {
                LoadUserData();
            }
        }

        /// <summary>
        /// Reads the user's data from the database and populates the form fields.
        /// </summary>
        private void LoadUserData()
        {
            string sqlQuery = "SELECT * FROM Users WHERE UserId = @UserId";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the form fields with data from the database
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtLastName.Text = reader["LastName"].ToString();
                                ltlUsername.Text = reader["Username"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                                txtAddress.Text = reader["Address"].ToString();
                                txtPincode.Text = reader["Pincode"].ToString();
                                txtCity.Text = reader["City"].ToString();
                                txtState.Text = reader["State"].ToString();

                                // Safely set RadioButtonList
                                if (reader["Gender"] != DBNull.Value)
                                {
                                    rblGender.SelectedValue = reader["Gender"].ToString();
                                }

                                // Safely set Date, formatting for TextMode="Date"
                                if (reader["Birthdate"] != DBNull.Value)
                                {
                                    DateTime bday = (DateTime)reader["Birthdate"];
                                    txtBirthdate.Text = bday.ToString("yyyy-MM-dd");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "<p style='color:red;'>Error loading profile: " + ex.Message + "</p>";
            }
        }

        /// <summary>
        /// Saves the updated form data back to the database.
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Define the UPDATE query.
            // (Note: We are not updating Username or Password here)
            string sqlQuery = @"
                UPDATE Users 
                SET FirstName = @FirstName, 
                    LastName = @LastName, 
                    Gender = @Gender, 
                    Birthdate = @Birthdate, 
                    Email = @Email, 
                    PhoneNumber = @PhoneNumber, 
                    Address = @Address, 
                    Pincode = @Pincode, 
                    City = @City, 
                    State = @State
                WHERE UserId = @UserId";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        // 2. Add all parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);

                        // Handle potential null date
                        cmd.Parameters.AddWithValue("@Birthdate", string.IsNullOrEmpty(txtBirthdate.Text)
                            ? (object)DBNull.Value
                            : Convert.ToDateTime(txtBirthdate.Text));

                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Pincode", txtPincode.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text);
                        cmd.Parameters.AddWithValue("@State", txtState.Text);

                        // The all-important WHERE clause
                        cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());

                        // 3. Execute the command
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // 4. Redirect back to the profile page on success
                Response.Redirect("Profile.aspx");
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "<p style='color:red;'>Error saving profile: " + ex.Message + "</p>";
            }
        }
    }
}
