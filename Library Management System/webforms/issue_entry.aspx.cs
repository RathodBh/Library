using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management_System.webforms
{
    public partial class issue_entry : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BH\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
        // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bcaproject11\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
        int found = 0;
        String unm = "",enrl="",isbn="",tid="",qty="",bnm="";

        protected void Button1_Click(object sender, EventArgs e)
        {
            pageDirect();
        }

        public void pageDirect()
        {
            if (Session["t"].ToString() == "t")
                Response.Redirect("../teacher/teacher_issue_entry.aspx");
            else if (Session["s"].ToString() == "s")
                Response.Redirect("../student/stud_issue_entry.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            if (Session["s"].ToString() == "s" && Session["t"].ToString() == "t")
                Response.Redirect("../student/stud_login.aspx");
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());

            //for the getting BOOK ISBN using id
            SqlCommand cmddd = con.CreateCommand();
            cmddd.CommandType = CommandType.Text;
            cmddd.CommandText = "select * from book_info where id="+id;
            cmddd.ExecuteNonQuery();
            DataTable dttt = new DataTable();
            SqlDataAdapter daaa = new SqlDataAdapter(cmddd);
            daaa.Fill(dttt);

            foreach (DataRow drrr in dttt.Rows)
            {
                isbn = drrr["isbn"].ToString();
                qty = drrr["qty"].ToString();
                bnm = drrr["bnm"].ToString();
            }
            if(Session["s"].ToString()=="s")
            {
                
                    unm = Session["snm"].ToString();
                    enrl = Session["eno"].ToString();
                    
            }
            else if (Session["t"].ToString() == "t")
            {
                unm = Session["tnm"].ToString();
                tid = Session["tid"].ToString();
            }




            //query for student/teacher have already this book or not

            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            if (Session["s"].ToString() == "s")
                cmd0.CommandText = "select * from stud_issue_return where eno='" + enrl + "' and isbn='" + isbn + "' and is_return= 'no' "; /*(is_return = 'no' or is_return = 'a' )*/
            if (Session["t"].ToString() == "t")
                cmd0.CommandText = "select * from teacher_issue_return where tid='" + tid + "' and isbn='" + isbn + "' and is_return= 'no'";
            cmd0.ExecuteNonQuery();

            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);

            found = Convert.ToInt32(dt0.Rows.Count.ToString());

            if (found > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "already_book();", true);
               // Session["issue_entry"] = "already_book";
               // pageDirect();
            }
            else
            { 
                //query for check the stock info.
                if (qty == "0")
                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "error_qty();", true);
                else
                {
                   string issue_date = "";
                   string approx_return_date ="";

                    //string issue_date = DateTime.Now.ToString("yyyy/MM/dd");
                    //string approx_return_date = DateTime.Now.AddDays(10).ToString("yyyy/MM/dd");
                    //string unm = "", bnm = "";
                    //query for get the student's name

                    if (Session["s"].ToString()=="s")
                    {
                        unm =Session["snm"].ToString();
                        //query for student/teacher have already this book or not

                        SqlCommand cmd01 = con.CreateCommand();
                        cmd01.CommandType = CommandType.Text;
                        cmd01.CommandText = "select * from stud_issue_return where eno='" + enrl + "' and isbn='" + isbn + "' and is_return= 'a' "; /*(is_return = 'no' or is_return = 'a' )*/
                        cmd01.ExecuteNonQuery();

                        DataTable dt01 = new DataTable();
                        SqlDataAdapter da01 = new SqlDataAdapter(cmd01);
                        da01.Fill(dt01);

                        found = Convert.ToInt32(dt01.Rows.Count.ToString());

                        if (found > 0)
                        {
                           
                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "err_entry();", true);

                        }
                        else
                        {
                            //for insert record of issue book STUDENT
                            SqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "insert into stud_issue_return values('" + enrl + "','" + isbn + "','" + bnm.ToString() + "','" + issue_date.ToString() + "', '" + approx_return_date.ToString() + "','" + unm + "','a','no')";
                            cmd2.ExecuteNonQuery();
                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "done_entry();", true);
                        }
                    }

                    //query for get the teacher's name
                    if (Session["t"].ToString() == "t")
                    {
                        unm = Session["tnm"].ToString();
                        
                        //query for student/teacher have already this book or not

                        SqlCommand cmd01 = con.CreateCommand();
                        cmd01.CommandType = CommandType.Text;
                        cmd01.CommandText = "select * from teacher_issue_return where tid='" + tid + "' and isbn='" + isbn + "' and is_return= 'a' "; /*(is_return = 'no' or is_return = 'a' )*/
                        cmd01.ExecuteNonQuery();

                        DataTable dt01 = new DataTable();
                        SqlDataAdapter da01 = new SqlDataAdapter(cmd01);
                        da01.Fill(dt01);

                        found = Convert.ToInt32(dt01.Rows.Count.ToString());

                        if (found > 0)
                        {

                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "err_entry();", true);

                        }
                        //for insert record of issue book TEACHER
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "insert into teacher_issue_return values('" + tid + "','" + isbn + "','" + bnm.ToString() + "','" + issue_date.ToString() + "', '" + approx_return_date.ToString() + "','" + unm + "','a','no')";
                        cmd2.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "done_entry();", true);
                    }
                    if (Session["t"].ToString() == "t" || Session["s"].ToString() == "s")
                    {
                        ////for update book stock
                        //SqlCommand cmd3 = con.CreateCommand();
                        //cmd3.CommandType = CommandType.Text;
                        //cmd3.CommandText = "update book_info set qty=qty-1 where isbn='" + isbn + "'";
                        //cmd3.ExecuteNonQuery();

                        //msg.Style.Add("display","block");

                     
                    }
                }
            }
        }
    }
}