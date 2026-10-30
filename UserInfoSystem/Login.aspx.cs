using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace UserInfoSystem
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserInfoDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check for "Remember Me" cookie
                if (Request.Cookies["RememberMe"] != null)
                {
                    txtUsername.Text = Request.Cookies["RememberMe"].Value;
                    chkRememberMe.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT UserId, Username FROM Users WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Again, HASH!

                        con.Open();

                        // Use SqlDataReader for reading a single record
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 1. Store user ID in Session for security
                                Session["UserId"] = reader["UserId"].ToString();
                                Session["Username"] = reader["Username"].ToString();

                                // 2. Handle "Remember Me" Cookie
                                if (chkRememberMe.Checked)
                                {
                                    HttpCookie cookie = new HttpCookie("RememberMe");
                                    cookie.Value = txtUsername.Text;
                                    cookie.Expires = DateTime.Now.AddDays(30);
                                    Response.Cookies.Add(cookie);
                                }
                                else
                                {
                                    // Expire the cookie if unchecked
                                    if (Request.Cookies["RememberMe"] != null)
                                    {
                                        HttpCookie cookie = new HttpCookie("RememberMe");
                                        cookie.Expires = DateTime.Now.AddDays(-1);
                                        Response.Cookies.Add(cookie);
                                    }
                                }

                                // 3. Redirect to the main profile page
                                Response.Redirect("Profile.aspx"); // Create this page
                            }
                            else
                            {
                                ltlMessage.Text = "<p style='color:red;'>Invalid username or password.</p>";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "<p style='color:red;'>An error occurred: " + ex.Message + "</p>";
            }
        }
    }
}
