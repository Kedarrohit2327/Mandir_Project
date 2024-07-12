using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jain_Mandir_Pro
{
    public partial class EditTithiMaster : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                string Tithis_id = Request.QueryString["tithis_id"];
                cmd.Connection = conn;
                cmd.CommandText = "select tithis_id,Year,Month,Tithi,Paksha,convert(varchar, tithi_master.Date, 23) as Date from tithi_master where tithis_id ='" + Tithis_id + "'";

                conn.Open();
                RepeatInformation.DataSource = cmd.ExecuteReader();
                RepeatInformation.DataBind();
                conn.Close();
            }

        }

        protected void RepeatInformation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string txttithis_id = Request.QueryString["tithis_id"];
                DateTime txtDate = Convert.ToDateTime(Request.Form["Date"]);
                string txtYear = Request.Form["Year"];
                string txtMonth = Request.Form["Month"];
                string txtTithi = Request.Form["Tithi"];
                string txtPaksha = Request.Form["Paksha"];

                SqlCommand cmd = new SqlCommand("update tithi_master set  Date = '" + txtDate.ToString("yyyy-MM-dd") + "',Year= '" + txtYear + "', Month = '" + txtMonth + "',Tithi='" + txtTithi + "',Paksha='" + txtPaksha + "' where tithis_id = '" + txttithis_id + "' ", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
   
                conn.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Response.Redirect("TithiMaster.aspx");
        }
    }
}