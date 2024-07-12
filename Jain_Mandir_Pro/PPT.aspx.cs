using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using Xpertdoc.DocumentServices.AddIn;
using System.Runtime.InteropServices;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Jain_Mandir_Pro
{
    public partial class PPT : System.Web.UI.Page
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

        protected void ppt_Click(object sender, EventArgs e)
        {
            LoadImages();
            Application pptApplication = new Application();

            // Create a new presentation
            Presentation pptPresentation = pptApplication.Presentations.Add();

            // Set slide size (optional)
            pptPresentation.PageSetup.SlideWidth = 1200; // Set the width of the slide
            pptPresentation.PageSetup.SlideHeight = 1000; // Set the height of the slide

            string DateSelected = Request.Form["Select_date"];
            

            string sqlQuery = "select transact_id, ImageName, Donar_Name,Tithi,Paksha,Month,Year,convert(varchar, Date, 23) as Date,Chadhava_Name,Amount from transact123 where Date = '" + DateSelected + "' ";

            //string sqlQuery = "SELECT transact.Donar_Name, '" + DateSelected.Substring(0, 8) + "'+cast(datepart(dd, tithis.Date) as varchar) as Date, convert(varchar, tithis.Date, 23) as Date1, tithis.Tithi, tithis.Month, tithis.Paksha,chadhava.chadhava_id,chadhava.Chadhava_name, chadhava.Iteration, chadhava.Amount, chadhava.ImageName FROM transact INNER JOIN tithis ON transact.tithi_id = tithis.tithis_id INNER JOIN chadhava ON transact.chadhava_id = chadhava.chadhava_id where iteration= 'Monthly' and  datepart(dd,wef_date) = '" + DateSelected.Substring(DateSelected.Length - 2) + "' ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString))
            {
                string backgroundImagePath = "D:\\IMAGES\\bag_image1.jpg"; // Replace with your image path
                Microsoft.Office.Interop.PowerPoint.Design design = pptPresentation.Designs[1];
                design.SlideMaster.Background.Fill.UserPicture(backgroundImagePath);

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Read data and add to the PowerPoint slides
                    while (reader.Read())
                    {
                        // Add a new slide
                        Slide slide = pptPresentation.Slides.Add(pptPresentation.Slides.Count + 1, PpSlideLayout.ppLayoutBlank);

                        // Access the text frame of the slide and set the content
                        Microsoft.Office.Interop.PowerPoint.TextFrame textFrame = slide.Shapes.AddTextbox(
                            MsoTextOrientation.msoTextOrientationHorizontal,

                            Left: 100, // Set the left position of the text frame
                            Top: 100,  // Set the top position of the text frame
                            Width: 1000, // Set the width of the text frame
                            Height: 2000 // Set the height of the text frame

                        ).TextFrame;

                        textFrame.TextRange.Text = " \t\t\t\t\t  આજ ના લાભાર્થી  \n\n\n";

                        // Insert data from the current row


                        string imagepath = "";

                        imagepath = "C:\\Image\\" + reader["ImageName"].ToString();
                        slide.Shapes.AddPicture(imagepath, MsoTriState.msoFalse, MsoTriState.msoCTrue, Left: 380, Top: 450, Width: 400, Height: 350);
                        textFrame.TextRange.InsertAfter("તારીખ: " + reader["Date"].ToString() + "\t\t\t\t");
                        textFrame.TextRange.InsertAfter("તિથિ: " + reader["Tithi"].ToString() + "\t\t");
                        textFrame.TextRange.InsertAfter(reader["Month"].ToString() + "\t");
                        textFrame.TextRange.InsertAfter(reader["Paksha"].ToString() + "\n");
                        textFrame.TextRange.InsertAfter("ચડાવા નામ : " + reader["Chadhava_name"].ToString() + "\t\t");
                        textFrame.TextRange.InsertAfter("લાભાર્થી નામ : " + reader["Donar_Name"].ToString() + "\n\n\n");
                        //textFrame.TextRange.InsertAfter(reader["ImageName"].ToString() + "");
                        // Apply color, font size, etc. as desired
                        textFrame.TextRange.Font.Color.RGB = (int)Office.MsoRGBType.msoRGBBlue;
                        textFrame.TextRange.Font.Size = 30;
                        textFrame.TextRange.ParagraphFormat.SpaceAfter = 25;
                    }
                    reader.Close();
                }
                connection.Close();
                // Save the presentation
                pptPresentation.SaveAs("D:/powerpoint/Donation_Details1.pptx");


                // Close PowerPoint
                pptPresentation.Close();
                pptApplication.Quit();
                Marshal.ReleaseComObject(pptPresentation);
                Marshal.ReleaseComObject(pptApplication);
                pptPresentation = null;
                pptApplication = null;

            }
        }
        private void LoadImages()
        {

        }

    }
}
