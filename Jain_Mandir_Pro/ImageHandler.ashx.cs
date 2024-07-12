using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public class ImageHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int _Transact;
        if (int.TryParse(context.Request.QueryString["transact_id"], out _Transact))
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["myconnect"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ImageData FROM transact123 WHERE transact_id = @transact_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@transact_id", _Transact);

                    connection.Open();
                    byte[] imageData = command.ExecuteScalar() as byte[];
                    connection.Close();

                    if (imageData != null)
                    {
                        context.Response.ContentType = "image/jpeg"; // Adjust MIME type as needed
                        context.Response.BinaryWrite(imageData);
                    }
                }
            }
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }


}




