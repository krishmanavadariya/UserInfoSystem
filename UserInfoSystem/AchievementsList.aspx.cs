using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInfoSystem
{
    public partial class AchievementsList : System.Web.UI.Page
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserInfoDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. SECURITY: Check if user is logged in
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindAchievementsGrid();
            }
        }

        private void BindAchievementsGrid()
        {
            string sqlQuery = "SELECT AchievementId, AchievementType, InstitutionName, Grade, YearOfCompletion FROM Achievements WHERE UserId = @UserId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());

                    // 2. Use SqlDataAdapter to fill a DataTable
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        gvAchievements.DataSource = dt;
                        gvAchievements.DataBind();
                    }
                }
            }
        }

        // 3. Handle the 'Delete' command from the GridView
        protected void gvAchievements_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteAchievement")
            {
                int achievementId = Convert.ToInt32(e.CommandArgument);
                DeleteAchievement(achievementId);
                BindAchievementsGrid(); // Refresh the grid
            }
        }

        private void DeleteAchievement(int achievementId)
        {
            string sqlQuery = "DELETE FROM Achievements WHERE AchievementId = @AchievementId AND UserId = @UserId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@AchievementId", achievementId);
                    cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString()); // Extra security check

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
