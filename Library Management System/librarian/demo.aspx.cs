using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System.librarian
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "demo()", "demo();", true);
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            if (Session["l"].ToString() == "l")
            {
                Label1.Text = Session["lnm"].ToString();
            }
            else
            {
                Response.Redirect("stud_login.aspx");
            }
        }

    }
}