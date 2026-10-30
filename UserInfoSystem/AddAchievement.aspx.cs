using System;
using System.Configuration;
using System.Data.SqlClient;

namespace UserInfoSystem
{
    public partial class AddAchievement : System.Web.UI.Page
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Define the INSERT query.
            string sqlQuery = @"
                INSERT INTO Achievements 
                    (UserId, AchievementType, InstitutionName, Grade, YearOfCompletion) 
                VALUES 
                    (@UserId, @AchievementType, @InstitutionName, @Grade, @YearOfCompletion)";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        // 2. Add all parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());
                        cmd.Parameters.AddWithValue("@AchievementType", ddlAchievementType.SelectedValue);
                        cmd.Parameters.AddWithValue("@InstitutionName", txtInstitutionName.Text);

                        // Handle potential null/empty strings for non-required fields
                        cmd.Parameters.AddWithValue("@Grade", string.IsNullOrEmpty(txtGrade.Text)
                            ? (object)DBNull.Value
                            : txtGrade.Text);

                        // Handle potential null/empty year
                        cmd.Parameters.AddWithValue("@YearOfCompletion", string.IsNullOrEmpty(txtYearOfCompletion.Text)
                            ? (object)DBNull.Value
                            : Convert.ToInt32(txtYearOfCompletion.Text));

                        // 3. Execute the command
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // 4. Redirect back to the achievements list on success
                Response.Redirect("AchievementsList.aspx");
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "<p style='color:red;'>Error saving achievement: " + ex.Message + "</p>";
            }
        }
    }
}
