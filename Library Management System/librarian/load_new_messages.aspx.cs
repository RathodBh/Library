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
    public partial class load_new_messages : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        String unm = "",msg="",l="librarian";
        int cnt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            unm = Request.QueryString["username"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from message where receiver='"+ l +"' and placed='no'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cnt++;
                if (cnt == 1)
                    msg =  dr["sender"].ToString() + ":  " + dr["msg"].ToString()  + dr["dt"].ToString();
                else
                    msg = msg + "||abcd||" + dr["sender"].ToString() + ":" + dr["msg"].ToString()  + dr["dt"].ToString();
                
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update message set placed='yes' where id=" + dr["id"].ToString() + "";
                cmd1.ExecuteNonQuery();
            }

            if (cnt == 0)
                Response.Write("0");
            else
                Response.Write(msg.ToString());
            
        }
    }
}