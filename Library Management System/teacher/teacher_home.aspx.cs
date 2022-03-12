using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System.teacher
{
    public partial class WebForm2 : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            if (Session["t"].ToString() == "t")
            {
                Label1.Text = Session["tnm"].ToString();
            }
            else
            {
                Response.Redirect("../student/stud_login.aspx");
            }
        }
    }
}