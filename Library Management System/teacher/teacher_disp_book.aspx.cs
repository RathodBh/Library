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
    public partial class WebForm1 : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {


            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            if (Session["teacher"] == null)
                Response.Redirect("../student/stud_login.aspx");

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
        public string checkimg(object o1, object id0)
        {
            if (o1.ToString() == "")
                return "Not available";
            else
            {
                o1 = "../librarian/" + o1.ToString();
                return "<img src='" + o1.ToString() + "'></img>";
                //return "<a href='" + o1.ToString() + "' style='color: green; '>View Image</a>";
            }
        }
        public string checkvideo(object o1, object id)
        {
            if (o1.ToString() == "")
                return "Not available";
            else
            {
                o1 = "../librarian/" + o1.ToString();
                return "<a href='" + o1.ToString() + "' style='color: green; '>View Video</a>";
            }
        }
        public string checkpdf(object o2, object id2)
        {
            if (o2.ToString() == "")
                return "Not available";
            else
            {
                o2 = "../librarian/" + o2.ToString();
                return "<a href='" + o2.ToString() + "' style='color: green; '>View PDF</a>";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from book_info where bnm like '%'+'" + TextBox2.Text + "'+'%' or isbn like '%'+'" + TextBox2.Text + "'+'%' or bauthor like '%'+'" + TextBox2.Text + "'+'%' or lang like '%'+'" + TextBox2.Text + "'+'%' or qty like '%'+'" + TextBox2.Text + "'+'%' or place like '%'+'" + TextBox2.Text + "'+'%' or price like '%'+'" + TextBox2.Text + "'+'%'";
            //cmd0.Parameters.AddWithValue("bnm",TextBox2.Text);
            cmd0.ExecuteNonQuery();

            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);

            int i = Convert.ToInt32(dt0.Rows.Count.ToString());
            if (i <= 0)
            {
                Label1.Text = "No Search Found..!";
            }
            else
            {
                Label1.Text = i + " Results match...";
            }

            r1.DataSource = dt0;
            r1.DataBind();
        }
    }
}