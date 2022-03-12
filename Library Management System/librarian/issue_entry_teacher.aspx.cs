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
    public partial class issue_entry_teacher : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        String isbn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            int id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from teacher_issue_return where id=" + id;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
                isbn = dr["isbn"].ToString();
            int i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i > 0)
            {
                //update REtuRN=NO AND DATE
                string issue_date = DateTime.Now.ToString("yyyy/MM/dd");
                string approx_return_date = DateTime.Now.AddDays(10).ToString("yyyy/MM/dd");

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update teacher_issue_return set is_return='no' , issue_date='" + issue_date + "',approx_return_date='" + approx_return_date + "' where  isbn='" + isbn + "'";
                cmd1.ExecuteNonQuery();

                //for update book stock
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update book_info set qty=qty-1 where isbn='" + isbn + "'";
                cmd3.ExecuteNonQuery();

                //msg.Style.Add("display","block");
                ClientScript.RegisterStartupScript(this.GetType(), "demo", "done_issue_entry();", true);

            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("teacher_issue_entries.aspx");
        }
    }
}