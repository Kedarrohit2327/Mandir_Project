using DocumentFormat.OpenXml.Office.Word;
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
    public partial class EditTransact : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
                string _transact_id = Request.QueryString["transact_id"];
                cmd.Connection = conn;
                cmd.CommandText = "select Tithi,Month,Paksha,Year,convert(varchar, transact123.Date, 23) as Date,Chadhava_Name,Iteration,Amount,Donar_Name from transact123 where transact_id= '" + _transact_id + "'";
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
                string _transact_id = Request.QueryString["transact_id"];           
                string txtTithi = Request.Form["Tithi"];
                string txtMonth = Request.Form["Month"];              
                string txtPaksha = Request.Form["Paksha"];
                string txtYear = Request.Form["Year"];
                DateTime txtDate = Convert.ToDateTime(Request.Form["Date"]);
                string txtChadhava_name = Request.Form["Chadhava_name"];
                string txtIteration = Request.Form["Iteration"];
                string txtAmount = Request.Form["Amount"];
                string txtDonar = Request.Form["Donar_name"];

                SqlCommand cmd = new SqlCommand("update transact123 set  Tithi = '" + txtTithi + "',Month='"+txtMonth+"',Paksha='"+txtPaksha+"',Year='"+txtYear+ "',Date= '" + txtDate.ToString("yyyy-MM-dd") + "', Chadhava_Name='"+ txtChadhava_name + "', Iteration = '" + txtIteration + "',Amount='" + txtAmount + "',Donar_Name='"+ txtDonar + "' where transact_id = '" + _transact_id + "' ", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Response.Redirect("Transaction.aspx");
        }
    }
}