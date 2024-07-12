using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xceed.Wpf.Toolkit;

namespace Jain_Mandir_Pro
{
    public partial class Contact : Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            object session = Session["username"];
            Console.WriteLine("Hello" + session);
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
             

                string com1 = "Select iterate_id,iteration from iteration_master";
                SqlDataAdapter adpt1 = new SqlDataAdapter(com1, conn);
                DataTable dt1 = new DataTable();
                adpt1.Fill(dt1);
                DropDownList2.DataSource = dt1;
                DropDownList2.SelectedIndex = -1;
                DropDownList2.DataBind();
                DropDownList2.DataTextField = "iteration";
                DropDownList2.DataValueField = "iterate_id";
                DropDownList2.DataBind();
                
              
            }
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
            cmd.Connection = conn;
            cmd.CommandText = "select Chadhava_id, Chadhava_name, Iteration,convert(varchar, Chadhava_M.wef_date, 23) as wef_date,Amount from Chadhava_M";
            conn.Open();
            RepeatInformation.DataSource = cmd.ExecuteReader();
            RepeatInformation.DataBind();
            conn.Close();
            if (Session["Strings"] == null)
            {
                Session["Strings"] = Request.UserLanguages[0];
            }
            if (!IsPostBack)
            {
                LoadString();
            }
        }
        private void LoadString()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Strings"].ToString());
            rm = new ResourceManager("Jain_Mandir_Pro.App_GlobalResources.Strings", Assembly.GetExecutingAssembly());
            ci = Thread.CurrentThread.CurrentCulture;

            //Head_Chadhava.InnerText = rm.GetString("Head_Chadhava", ci);
            //lblChadhava.InnerHtml = rm.GetString("lblChadhava", ci);

            //lbleIteration.Text = rm.GetString("lbleIteration", ci);

            //lblAmount.InnerHtml = rm.GetString("lblAmount", ci);

            //lblWEF_Date.InnerHtml = rm.GetString("lblWEF_Date", ci);

            //lblImage.Text = rm.GetString("lblImage", ci);
            //Btn_Save.Text = rm.GetString("Btn_Save", ci);
            //Btn_Cancel.Text = rm.GetString("Btn_Cancel", ci);




        }



        protected void savechadava_click(object sender, EventArgs e)
        {
            try
            {             
                string _chadhava = Request.Form["Chadhava_Name"];
                string dateString = Request.Form["TxtSelect_date"];
                DateTime dateValue, dateValue1;

                if (DateTime.TryParse(dateString, out dateValue))
                {
                    dateValue1 = dateValue;
                }
                int Iteration_id = Convert.ToInt32(DropDownList2.SelectedValue);
                string _amount = Convert.ToString(Request.Form["amount"]);
                string imageName = FileUpload1.FileName;
                byte[] imageData = FileUpload1.FileBytes;

                //Session["chadhava"] = chadhava_id.Text;

                SqlCommand cmd = new SqlCommand("INSERT INTO Chadhava_M (Chadhava_name,Iteration,iteration_id,wef_date,Amount, ImageData, ImageName) VALUES (@Chadhava_name,@Iteration,@iteration_id,@wef_date, @Amount,  CONVERT(VARBINARY(MAX), @ImageData),@ImageName)", conn);
                
                cmd.Parameters.AddWithValue("@Chadhava_name", _chadhava);
                cmd.Parameters.AddWithValue("@Iteration", DropDownList2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@iteration_id", Iteration_id);
                cmd.Parameters.AddWithValue("@wef_date", dateString);
                cmd.Parameters.AddWithValue("@Amount", _amount);
                cmd.Parameters.AddWithValue("@ImageName", imageName);
                cmd.Parameters.AddWithValue("@ImageData", imageData);
               
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();                            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void deleteBtn(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlInputButton btn =(System.Web.UI.HtmlControls.HtmlInputButton)sender;
            string chadhava_id = btn.Attributes["data-id"];
            cmd.Connection = conn;
            cmd.CommandText="delete from Chadhava_M where Chadhava_id= '"+ chadhava_id + "'";
            conn.Open();
            cmd.ExecuteNonQuery();          
        }
    }
}