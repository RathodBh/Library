using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System.webforms
{
    public partial class follow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b11_Click(object sender, EventArgs e)
        {
            Response.Write("<script>history.go(-1);</script>");
        }
    }
}