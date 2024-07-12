using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xceed.Wpf.Toolkit;

namespace Jain_Mandir_Pro
{
    public partial class Transaction : System.Web.UI.Page       
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
            Label12.Visible = false;
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);

                string com = "Select Chadhava_id,Chadhava_name from Chadhava_M";
                SqlDataAdapter adpt1 = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt1.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.SelectedIndex = -1;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "Chadhava_name";
                DropDownList1.DataValueField = "Chadhava_id";
                DropDownList1.DataBind();

                string com1 = "Select iterate_id,iteration from iteration_master";
                SqlDataAdapter adpt2 = new SqlDataAdapter(com1, conn);
                DataTable dt1 = new DataTable();
                adpt2.Fill(dt1);
                DropDownList2.DataSource = dt1;
                DropDownList2.SelectedIndex = -1;
                DropDownList2.DataBind();
                DropDownList2.DataTextField = "iteration";
                DropDownList2.DataValueField = "iterate_id";
                DropDownList2.DataBind();

                string com2 = "Select Chadhava_id,Amount from Chadhava_M";
                SqlDataAdapter adpt3 = new SqlDataAdapter(com2, conn);
                DataTable dt2 = new DataTable();
                adpt3.Fill(dt2);
                DropDownList3.DataSource = dt2;
                DropDownList3.SelectedIndex = -1;
                DropDownList3.DataBind();
                DropDownList3.DataTextField = "Amount";
                DropDownList3.DataValueField = "Chadhava_id";
                DropDownList3.DataBind();


                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString);
                cmd.Connection = conn;
                cmd.CommandText = "select transact_id, Tithi,Month,Paksha,Year, convert(varchar, transact123.Date, 23) as Date, Chadhava_Name,Iteration,Amount ,Donar_Name,ImageName from transact123";
                conn.Open();
                Repeater1.DataSource = cmd.ExecuteReader();
                Repeater1.DataBind();
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string DateSelected = Request.Form["Select_date"];
            SqlCommand cmd = new SqlCommand("select Year,Month,Tithi,Paksha,convert(varchar, tithi_master.Date, 23) as Date from tithi_master where Date = '" + DateSelected + "'", conn);
            conn.Open();
            //tithi_id = cmd.ExecuteScalar();
            RepeatInformation.DataSource = cmd.ExecuteReader();
            RepeatInformation.DataBind();
            conn.Close();
        }
       
        protected void save_Click(object sender, EventArgs e)
        {
            int _Etry_Count = Convert.ToInt32(EntryCount.Text);           
            int count = 0;
            DateTime DateSelected1 = DateTime.Now;
            SqlCommand cmd1 = new SqlCommand("select count(*) from transact123 where Date='" + DateSelected1.ToString("yyyy-MM-dd") + "'", conn);
            conn.Open();
            count = (int)cmd1.ExecuteScalar();
            
            conn.Close();
            if (count > _Etry_Count)
            {
                Label12.Text = "Today's entry Completed.";
                Label12.Visible = true;
            }
            else
            {             
                try
                {
                    string _Tithi = Request.Form["tithi"];
                    string _Month = Request.Form["month"];
                    string _Paksha = Request.Form["paksha"];
                    string _Year = Request.Form["year"];
                    DateTime txtDate = Convert.ToDateTime(Request.Form["Date"]);
                    string _Chadhava_Name = (DropDownList1.SelectedItem.ToString());
                    string _Iteration = (DropDownList2.SelectedItem.ToString());
                    int _Amount = Convert.ToInt32(DropDownList3.SelectedItem.ToString());
                    string _Donar_Name = donar_name.Text;
                    string imageName = FileUpload1.FileName;
                    byte[] imageData = FileUpload1.FileBytes;
                    int _Entry = Convert.ToInt32(EntryCount.Text);

                    SqlCommand cmd = new SqlCommand("INSERT INTO transact123 (Tithi,Month,Paksha,Year,Date,Chadhava_Name,Iteration,Amount,Donar_Name, ImageData, ImageName,entry_count) VALUES (@Tithi,@Month,@Paksha,@Year, @Date,@Chadhava_Name,@Iteration,@Amount,@Donar_Name, CONVERT(VARBINARY(MAX), @ImageData),@ImageName,@entry_count)", conn);
                    cmd.Parameters.AddWithValue("@Tithi", _Tithi);
                    cmd.Parameters.AddWithValue("@Month", _Month);
                    cmd.Parameters.AddWithValue("@Paksha", _Paksha);
                    cmd.Parameters.AddWithValue("@Year", _Year);
                    cmd.Parameters.AddWithValue("@Date", txtDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Chadhava_Name", DropDownList1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Iteration", DropDownList2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Amount", DropDownList3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Donar_Name", _Donar_Name);
                    cmd.Parameters.AddWithValue("@ImageName", imageName);
                    cmd.Parameters.AddWithValue("@ImageData", imageData);
                    cmd.Parameters.AddWithValue("@entry_count", _Entry);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    int Entry_Count = 1;
                    SqlCommand cmd2 = new SqlCommand("SELECT TOP 1 entry_count FROM transact123 ORDER BY transact_id DESC ", conn);
                    conn.Open();

                    Entry_Count = (int)cmd2.ExecuteScalar();
                    
                    conn.Close();
                    EntryCount.Text = Entry_Count.ToString();     
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }           
            }                   
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void deleteBtn(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlInputButton btn = (System.Web.UI.HtmlControls.HtmlInputButton)sender;
           
            string _transact_id = btn.Attributes["data-id"];
          
            cmd.Connection = conn;
            cmd.CommandText = "delete from transact123 where transact_id= '" + _transact_id + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}