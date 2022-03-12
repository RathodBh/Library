using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;

namespace Library_Management_System.librarian
{
    public partial class WebForm5 : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            
            if (IsPostBack) return;
 
            d_eno.Items.Clear();
            d_book_isbn.Items.Clear();
           
        }

        protected void d_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (d_type.SelectedValue.ToString() == "Student")
            {
                p_stud.Visible = true;
                p_book.Visible = true;
                p_teacher.Visible = false;
            }
            else if (d_type.SelectedValue.ToString() == "Teacher")
            {
                p_teacher.Visible = true;
                p_book.Visible = true;
                p_stud.Visible = false;
            }
            else
            {
                p_teacher.Visible = false;
                p_book.Visible = false;
                p_stud.Visible = false;
            }
        }

        protected void btn_issueBook_Click(object sender, EventArgs e)
        {
            //if user select isbn=Select==>give error
            if (d_book_isbn.SelectedValue.ToString() == "Select")
                ClientScript.RegisterStartupScript(this.GetType(), "demo", "select_book_error();", true);
            else
            {
                //query for student/teacher have already this book or not
                int found = 0;
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                if (d_type.SelectedValue.ToString() == "Student")
                    cmd0.CommandText = "select * from stud_issue_return where eno='" + d_eno.SelectedValue.ToString() + "' and isbn='" + d_book_isbn.SelectedValue.ToString() + "' and is_return= 'no' ";
                if (d_type.SelectedValue.ToString() == "Teacher")
                    cmd0.CommandText = "select * from teacher_issue_return where tid='" + d_tid.SelectedValue.ToString() + "' and isbn='" + d_book_isbn.SelectedValue.ToString() + "' and is_return= 'no' ";
                cmd0.ExecuteNonQuery();

                DataTable dt0 = new DataTable();
                SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                da0.Fill(dt0);

                found = Convert.ToInt32(dt0.Rows.Count.ToString());

                if (found > 0)
                    ClientScript.RegisterStartupScript(this.GetType(), "demo", "already_book();", true);
                else
                {

                    //query for check the stock info.
                    if (l_stock_book.Text == "0")
                        ClientScript.RegisterStartupScript(this.GetType(), "demo", "error_qty();", true);
                    else
                    {
                        string issue_date = DateTime.Now.ToString("yyyy/MM/dd");
                        string approx_return_date = DateTime.Now.AddDays(10).ToString("yyyy/MM/dd");
                        string unm = "",bnm="";
                        //query for get the student's name
                        if (d_type.SelectedValue.ToString() == "Teacher" || d_type.SelectedValue.ToString() == "Student")
                        {

                            //for the get book name
                            SqlCommand cmd000 = con.CreateCommand();
                            cmd000.CommandType = CommandType.Text;
                            cmd000.CommandText = "select bnm from book_info where isbn='" + d_book_isbn.SelectedItem.ToString() + "'";
                            cmd000.ExecuteNonQuery();

                            DataTable dt000 = new DataTable();
                            SqlDataAdapter da000 = new SqlDataAdapter(cmd000);
                            da000.Fill(dt000);

                            foreach (DataRow dr000 in dt000.Rows)
                                bnm = dr000["bnm"].ToString();

                        }
                        if (d_type.SelectedValue.ToString() == "Student")
                        {
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select * from stud_reg where eno='" + d_eno.SelectedItem.ToString() + "'";
                            cmd.ExecuteNonQuery();

                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                            img_book.Visible = true;
                            foreach (DataRow dr in dt.Rows)
                                unm = dr["snm"].ToString();


                            //for insert record of issue book STUDENT
                            SqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "insert into stud_issue_return values('" + d_eno.SelectedItem.ToString() + "','" + d_book_isbn.SelectedItem.ToString() + "','" + bnm + "','" + issue_date.ToString() + "', '" + approx_return_date.ToString() + "','" + unm.ToString() + "','no','no')";
                            cmd2.ExecuteNonQuery();

                        }
                       
                        //query for get the teacher's name
                        if (d_type.SelectedValue.ToString() == "Teacher")
                        {
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select * from teacher_reg where tid='" + d_tid.SelectedItem.ToString() + "'";
                            cmd.ExecuteNonQuery();

                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                            img_book.Visible = true;
                            foreach (DataRow dr in dt.Rows)
                                unm = dr["tnm"].ToString();


                            //for insert record of issue book TEACHER
                            SqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "insert into teacher_issue_return values('" + d_tid.SelectedItem.ToString() + "','" + d_book_isbn.SelectedItem.ToString() + "','" + bnm + "','" + issue_date.ToString() + "', '" + approx_return_date.ToString() + "','" + unm.ToString() + "','no','no')";
                            cmd2.ExecuteNonQuery();
                        }
                        if (d_type.SelectedValue.ToString() == "Student" || d_type.SelectedValue.ToString() == "Teacher")
                        {
                            //for update book stock
                            SqlCommand cmd3 = con.CreateCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.CommandText = "update book_info set qty=qty-1 where isbn='" + d_book_isbn.SelectedItem.ToString() + "'";
                            cmd3.ExecuteNonQuery();

                            ClientScript.RegisterStartupScript(this.GetType(), "demo", "done_issue_entry();", true);

                        }
                    }
                }

            }
        }

        protected void d_book_isbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            img_book.ImageUrl = "";
            l_books_name.Text = "";
            l_stock_book.Text = "";

            //query for print the book info
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from book_info where isbn='" + d_book_isbn.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            img_book.Visible = true;
            foreach (DataRow dr in dt.Rows)
            {
                img_book.ImageUrl = dr["bimg"].ToString();
                l_books_name.Text = "Book Name :       " + dr["bnm"].ToString();
                l_stock_book.Text = "Available Stock : " + dr["qty"].ToString();

            }
        }
    }
}