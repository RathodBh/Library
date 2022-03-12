using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System
{
    public partial class messages_send_from_librarian : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        String unm = "",msg="",l="librarian",dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            unm = Request.QueryString["username"].ToString();
            msg = Request.QueryString["msg"].ToString();
            dt = DateTime.Now.ToString("hh:mm tt (yyyy/MM/dd)");

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into message values('" + l + "','" + unm + "','"+ msg +"','no','" + dt + "')";
            cmd.ExecuteNonQuery();


        }
    }
}