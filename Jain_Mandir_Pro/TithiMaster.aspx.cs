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
    public partial class About : Page
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
            
        }
        protected void RepeatInformation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Find the textbox control within the item
                TextBox Tithis = (TextBox)e.Item.FindControl("tithis_id");

                // Retrieve the ID value
                string idValue = Tithis.Text;

                Session["SelectedDate"] = idValue; // Storing the date in session
                //Response.Redirect("Chadhava Master.aspx") ;
                // Now you can use the idValue as needed
            }
            else
            {
                // If idValue is empty, set a default date
                Session["SelectedDate"] = DateTime.Now.ToShortDateString(); // Using current date as default
            }
        }

        protected void date_SelectionChanged(object sender, EventArgs e)
        {
            string Date = date.SelectedDate.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("select tithis_id,Year,Month,Tithi,Paksha,convert(varchar, tithi_master.Date, 23) as Date from tithi_master where Date = '" + Date + "'", conn);
            conn.Open();
          
            RepeatInformation.DataSource = cmd.ExecuteReader();
            RepeatInformation.DataBind();
            conn.Close();
        }

        protected void RepeatInformation_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}