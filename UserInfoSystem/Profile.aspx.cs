using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Linq;

namespace UserInfoSystem
{
    public partial class Profile : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
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
                                // Populate fields
                                ltlFullName.Text = HttpUtility.HtmlEncode($"{reader["FirstName"]} {reader["LastName"]}");
                                ltlUsername.Text = HttpUtility.HtmlEncode(reader["Username"].ToString());
                                ltlEmail.Text = HttpUtility.HtmlEncode(reader["Email"].ToString());
                                ltlPhone.Text = HttpUtility.HtmlEncode(reader["PhoneNumber"].ToString());
                                ltlGender.Text = HttpUtility.HtmlEncode(reader["Gender"].ToString());

                                // Handle potential NULL values
                                if (reader["Birthdate"] != DBNull.Value)
                                {
                                    DateTime bday = (DateTime)reader["Birthdate"];
                                    ltlBirthdate.Text = bday.ToString("dd MMMM, yyyy");
                                }
                                else
                                {
                                    ltlBirthdate.Text = "N/A";
                                }

                                // Build full address string
                                var addressParts = new[]
                                {
                                    reader["Address"].ToString(),
                                    reader["City"].ToString(),
                                    reader["State"].ToString()
                                };
                                string fullAddress = string.Join(", ", addressParts.Where(s => !string.IsNullOrEmpty(s)));
                                string pincode = reader["Pincode"].ToString();
                                if (!string.IsNullOrEmpty(pincode))
                                {
                                    fullAddress += " - " + pincode;
                                }
                                ltlAddress.Text = HttpUtility.HtmlEncode(string.IsNullOrWhiteSpace(fullAddress) ? "N/A" : fullAddress);


                                // Handle photo path
                                if (reader["PhotoPath"] != DBNull.Value && !string.IsNullOrEmpty(reader["PhotoPath"].ToString()))
                                {
                                    imgProfilePhoto.ImageUrl = reader["PhotoPath"].ToString();
                                }
                                else
                                {
                                    // Use a default/placeholder image if no photo is uploaded
                                    imgProfilePhoto.ImageUrl = "~/Uploads/default-avatar.png";
                                }
                            }
                            else
                            {
                                // This case should rarely happen if session is valid
                                ltlMessage.Text = "<p style='color:red;'>Could not find user profile.</p>";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "<p style='color:red;'>An error occurred while loading your profile: " + ex.Message + "</p>";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear and abandon the session to log the user out
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}
