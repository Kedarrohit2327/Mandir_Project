using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jain_Mandir_Pro
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object session = Session["username"];
            Console.WriteLine("Hello" + session);
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}