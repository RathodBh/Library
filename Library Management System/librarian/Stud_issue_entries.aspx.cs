using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/*
 * 
 * 
 * 
 * 
 * 


namespace Library_Management_System.librarian
{
    public partial class WebForm9 : System.Web.UI.Page
    {
         
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            load();

            
        }
        public void load()
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stud_issue_return where is_return='a'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            load();

        }
    }
}*/


namespace Library_Management_System.librarian
{
    public partial class Stud_issu_entries : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            //int id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stud_issue_return where is_return='a'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            int i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
                Label2.Text = "No Records found!";
            else
                Label1.Text = i + " Records Found";

         
            r1.DataSource = dt;
            r1.DataBind();
        }
    }
}