using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jain_Mandir_Pro
{
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            error_msg.Text = "";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            try
            {
                SqlCommand cmd = new SqlCommand("select * from mandir_login where username = '" + username + "' and password='" + password + "'", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Session["username"] = username;
                    Session["password"] = password;
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    error_msg.Text = "Incorrect Username & password";
                }
              
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}