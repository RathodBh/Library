using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System.webforms
{
    public partial class about_us : System.Web.UI.Page
    {

      
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("follow.aspx");
        }
    }
}