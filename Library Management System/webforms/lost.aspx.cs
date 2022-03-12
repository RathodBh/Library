using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management_System.student
{
    public partial class lost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BH\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
        // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bcaproject11\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");

        int id ;
        String isbn = "",bnm="",lost_by="",user_id="",user_type="",dt="",placed;

        protected void btn_Click(object sender, EventArgs e)
        {
            if (Session["s"].ToString() == "s")
                Response.Redirect("../student/lost_book.aspx");
            if (Session["t"].ToString() == "t")
                Response.Redirect("../teacher/teacher_lost_book.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "lost_entry_done();", true);

            if (Session["s"].ToString() == "" && Session["t"].ToString()=="")
                Response.Redirect("../student/stud_login.aspx");
            //String enrl = "";
           
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            String price = Request.QueryString["price"].ToString();

            SqlCommand cmd00 = con.CreateCommand();
            cmd00.CommandType = CommandType.Text;
            if (Session["s"].ToString() != "")
            {
                cmd00.CommandText = "select * from stud_issue_return where id=" + id + "";
                cmd00.ExecuteNonQuery();
                DataTable dt00 = new DataTable();
                SqlDataAdapter da00 = new SqlDataAdapter(cmd00);
                da00.Fill(dt00);

                dt = DateTime.Now.ToString();
                foreach (DataRow dr00 in dt00.Rows)
                {
                    isbn = dr00["isbn"].ToString();
                    bnm = dr00["bnm"].ToString();
                    lost_by = dr00["name"].ToString();
                    user_id = dr00["eno"].ToString();
                    user_type = "Student";
                    placed = "no";
                }
            }
            else if (Session["t"].ToString() != null)
            {
                cmd00.CommandText = "select * from teacher_issue_return where id=" + id + "";
                cmd00.ExecuteNonQuery();
                DataTable dt00 = new DataTable();
                SqlDataAdapter da00 = new SqlDataAdapter(cmd00);
                da00.Fill(dt00);

                dt = DateTime.Now.ToString();
                foreach (DataRow dr00 in dt00.Rows)
                {
                    isbn = dr00["isbn"].ToString();
                    bnm = dr00["bnm"].ToString();
                    lost_by = dr00["name"].ToString();
                    user_id = dr00["tid"].ToString();
                    user_type = "Teacher";
                    placed = "no";
                }
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into lost_book values('"+ isbn +"','"+ bnm + "','" + lost_by + "','" + user_id + "','" + user_type + "','" + dt + "', '" + placed +"')";
            cmd.ExecuteNonQuery();


            if (Session["s"].ToString() != null)
            { 
                //for the delete issued book
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "delete from stud_issue_return where id=" + id + "";
                cmd0.ExecuteNonQuery();

                //SqlCommand cmd1 = con.CreateCommand();
                //cmd1.CommandType = CommandType.Text;
                //cmd1.CommandText = "update stud_issue_return set is_return='yes' where id=" + id + "";
                //cmd1.ExecuteNonQuery();
                
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "lost_entry_done();", true);
                //l1.Text = "You need to pay" + price.ToString();
               Response.Write("<script>alert('Book Lost Entry done... You need to pay ' + '"  + price +  "');</script>");

            }
            else if (Session["t"].ToString() != null)
            {
                //for the delete issued book
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "delete from teacher_issue_return where id=" + id + "";
                cmd0.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "lost_entry_done();", true);
                //l1.Text = "You need to pay" + price.ToString();

                Response.Write("<script>alert('Book Lost Entry done... You need to pay ' + '" + price + "');</script>");
            }
        }
    }
}