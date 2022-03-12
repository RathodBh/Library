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
    public partial class lost : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        int id;
        String isbn = "",bnm,lost_by,user_id,user_type,dt;//,placed

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("lost_book.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            id = Convert.ToInt32(Request.QueryString["id"].ToString());


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from lost_book where id="+ id;
            cmd.ExecuteNonQuery();

            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd);
            da0.Fill(dt0);

            foreach (DataRow dr0 in dt0.Rows)
            {
                isbn = dr0["isbn"].ToString();
                bnm = dr0["bnm"].ToString();
                lost_by = dr0["lost_by"].ToString();
                user_id = dr0["user_id"].ToString();
                user_type = dr0["user_type"].ToString();
                dt = dr0["dt"].ToString();
               
            }


            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update lost_book set placed='yes' where id="+id;
            cmd1.ExecuteNonQuery();

            ClientScript.RegisterStartupScript(this.GetType(), "demo", "done_lost();", true);
        }
    }
}