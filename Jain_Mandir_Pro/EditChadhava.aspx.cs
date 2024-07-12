using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xceed.Wpf.Toolkit;

namespace Jain_Mandir_Pro
{
    public partial class EditChadhava : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
                string _Chadhava_id = Request.QueryString["Chadhava_id"];
                cmd.Connection = conn;
                cmd.CommandText = "select Chadhava_id, Chadhava_name, Iteration,convert(varchar, Chadhava_M.wef_date, 23) as wef_date,Amount from Chadhava_M where Chadhava_id= '" +_Chadhava_id + "'";
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
                string _Chadhava_id = Request.QueryString["Chadhava_id"];
                string txtChadhava_name = Request.Form["Chadhava_name"];
                string txtIteration = Request.Form["Iteration"];  
                string txtAmount = Request.Form["Amount"];
                DateTime txtwef_date = Convert.ToDateTime(Request.Form["wef_date"]);


                SqlCommand cmd = new SqlCommand("update Chadhava_M set  Chadhava_name = '" + txtChadhava_name + "', Iteration = '" + txtIteration + "',Amount='" + txtAmount + "',wef_date= '" + txtwef_date.ToString("yyyy-MM-dd") + "' where Chadhava_id = '" + _Chadhava_id + "' ", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }
            Response.Redirect("ChadavaMaster.aspx");

        }
    }
    
}