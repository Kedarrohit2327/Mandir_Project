using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Jain_Mandir_Pro
{
    public partial class IterationMaster : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            object session = Session["username"];
            Console.WriteLine("Hello" + session);
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Label2.Visible = true;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
            cmd.Connection = conn;
            cmd.CommandText = "select * from iteration_master";
            conn.Open();
            RepeatInformation.DataSource = cmd.ExecuteReader();
            RepeatInformation.DataBind();
            conn.Close();
        }

        protected void save_click(object sender, EventArgs e)
        {
            int count = 0;
            SqlCommand cmd1 = new SqlCommand("select count(*) from iteration_master where iteration='" + iteration.Text + "'", conn);
            conn.Open();
            count = (int)cmd1.ExecuteScalar();
            
            conn.Close();
            if (count > 0)
            {
                Label2.Text = "Iteration Already Exist";
                Label2.Visible = true;
            }
            else
            {
                try
                {
                    string iterate = iteration.Text;
                    SqlCommand cmd2 = new SqlCommand("Insert into iteration_master (iteration) values('" + iterate + "')", conn);
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    
                    Response.Redirect("IterationMaster.aspx");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}