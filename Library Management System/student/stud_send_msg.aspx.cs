using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System.student
{
   
    public partial class send_msg : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("stud_send_msg.aspx");
        }
    }
}