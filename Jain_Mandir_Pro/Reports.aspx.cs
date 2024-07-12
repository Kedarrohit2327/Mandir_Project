using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using A = DocumentFormat.OpenXml.Drawing;
using P = DocumentFormat.OpenXml.Presentation;

namespace Jain_Mandir_Pro
{
    public partial class Reports : System.Web.UI.Page
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
            if (!IsPostBack) { 
                LoadImages();
            }

        }
        private void LoadImages()
        {
            //string connectionString = WebConfigurationManager.ConnectionStrings["myconnect"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(connectionString))
            string sqlQuery = "select transact_id, ImageName, Donar_Name,Tithi,Paksha,Month,Year,convert(varchar, Date, 23) as Date,Chadhava_Name,Amount from transact123";

            string connectionString = ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    repeaterData.DataSource = dataTable;
                    repeaterData.DataBind();
                    conn.Close();
                }
            }
        }
    }
}