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
    public partial class WebForm5 : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BH\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
    // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bcaproject11\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");

    protected void Page_Load(object sender, EventArgs e)
        {
            
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            if (Session["stud"].ToString() == "")
                Response.Redirect("stud_login.aspx");

            load();
            

            //string entry = Session["issue_entry"] as string;
            //if (entry=="already_book")
            //    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "already_book();", true);
         
        }
       public void load()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from book_info";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            r1.DataSource = dt;
            r1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from book_info where bnm like '%'+'" + TextBox2.Text + "'+'%' or isbn like '%'+'" + TextBox2.Text + "'+'%' or bauthor like '%'+'" + TextBox2.Text + "'+'%' or lang like '%'+'" + TextBox2.Text + "'+'%' or qty like '%'+'" + TextBox2.Text + "'+'%' or pg like '%'+'" + TextBox2.Text + "'+'%' ";
            //cmd0.Parameters.AddWithValue("bnm",TextBox2.Text);
            cmd0.ExecuteNonQuery();

            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);


            r1.DataSource = dt0;
            r1.DataBind();

        }
    }
}