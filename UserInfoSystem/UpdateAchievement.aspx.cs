using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace UserInfoSystem
{
    public partial class UpdateAchievement : System.Web.UI.Page
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserInfoDB"].ConnectionString;
        private int _achievementId;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. SECURITY: Check login
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // 2. Read ID from Query String
            if (Request.QueryString["id"] == null || !int.TryParse(Request.QueryString["id"], out _achievementId))
            {
                Response.Redirect("AchievementsList.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadAchievementData();
            }
        }

        private void LoadAchievementData()
        {
            string sqlQuery = "SELECT * FROM Achievements WHERE AchievementId = @AchievementId AND UserId = @UserId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@AchievementId", _achievementId);
                    cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 3. Populate the form fields
                            ddlAchievementType.SelectedValue = reader["AchievementType"].ToString();
                            txtInstitution.Text = reader["InstitutionName"].ToString();
                            txtGrade.Text = reader["Grade"].ToString();
                            txtYear.Text = reader["YearOfCompletion"].ToString();
                        }
                        else
                        {
                            // ID doesn't exist or doesn't belong to this user
                            Response.Redirect("AchievementsList.aspx");
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = @"
                UPDATE Achievements 
                SET AchievementType = @Type, 
                    InstitutionName = @Institution, 
                    Grade = @Grade, 
                    YearOfCompletion = @Year
                WHERE AchievementId = @AchievementId AND UserId = @UserId";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Type", ddlAchievementType.SelectedValue);
                        cmd.Parameters.AddWithValue("@Institution", txtInstitution.Text);
                        cmd.Parameters.AddWithValue("@Grade", txtGrade.Text);
                        cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(txtYear.Text));
                        cmd.Parameters.AddWithValue("@AchievementId", _achievementId);
                        cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Redirect("AchievementsList.aspx");
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "<p style='color:red;'>An error occurred: " + ex.Message + "</p>";
            }
        }
    }
}
