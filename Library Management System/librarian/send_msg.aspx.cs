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
    public partial class send_msg : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            //Session["s1"] = "s1";
            //Session["t1"] = "";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stud_reg";
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
                return "<img src='" + o1.ToString() + "' ></img>";
                //return "<a href='" + o1.ToString() + "' style='color: green; '>View Image</a>";
            }
        }
    }
}