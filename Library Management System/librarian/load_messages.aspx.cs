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
    public partial class load_messages : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        String unm = "";
        String l = "librarian";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            unm = Request.QueryString["username"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from message where (sender='"+ unm + "' and receiver='" + l +"') or (receiver='" + unm + "' and sender='" + l + "')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Response.Write("<p style='text-align:right;'>");
                Response.Write("<font style='color:black;'>" + dr["sender"].ToString() + "</font>&nbsp;:&nbsp;&nbsp; " + dr["msg"].ToString() + "<br />" + dr["dt"].ToString());
                Response.Write("</p>");
                Response.Write("<hr>");

                if (dr["receiver"].ToString() == "librarian")
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update message set placed='yes' where id=" + dr["id"].ToString() + "";
                    cmd1.ExecuteNonQuery();

                }
            }
        }
    }
}