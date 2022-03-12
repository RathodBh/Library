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
    public partial class active : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BH\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
    // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bcaproject11\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
        
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            //if the user is student then update student record otherwise update teacher record
            if (Session["s1"].ToString() == "s1")
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update stud_reg set approved='yes' where id=" + id;
                cmd.ExecuteNonQuery();

                Response.Redirect("display_stud_info.aspx");
            }
            else if (Session["t1"].ToString() == "t1")
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update teacher_reg set approved='yes' where id=" + id;
                cmd.ExecuteNonQuery();

                Response.Redirect("display_teacher_info.aspx");
            }
        }
    }
}