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
    public partial class returnBook_aspx : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        int id;
        String isbn = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

             id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if(Session["s"].ToString()=="s")
            {
                //update student's book return date
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update stud_issue_return set is_return='yes' , return_date='"+ DateTime.Now.ToString("yyyy/MM/dd") +"' where id="+ id;
                cmd.ExecuteNonQuery();

                //get the isbn number of book from student
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from stud_issue_return where id=" + id;
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                foreach (DataRow dr2 in dt2.Rows)
                {
                    isbn = dr2["isbn"].ToString();
                }
            }
            else if (Session["t"].ToString() == "t")
            {
                //update teacher's book return date
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update teacher_issue_return set is_return='yes' , return_date='" + DateTime.Now.ToString("yyyy/MM/dd") + "' where id=" + id;
                cmd.ExecuteNonQuery();

                //get the isbn number of book from Teacher
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from teacher_issue_return where id=" + id;
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                foreach (DataRow dr2 in dt2.Rows)
                {
                    isbn = dr2["isbn"].ToString();
                }

            }

            if (Session["s"].ToString() == "s" || Session["t"].ToString() == "t")
            {
                //update the book stock
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update book_info set qty=qty + 1 where isbn='" + isbn + "'";
                cmd3.ExecuteNonQuery();
            }
            if (Session["s"].ToString() == "s")
                Response.Redirect("stud_return_book.aspx");
            else if ( Session["t"].ToString() == "t")
                Response.Redirect("teacher_return_book.aspx");
        }
    }
}