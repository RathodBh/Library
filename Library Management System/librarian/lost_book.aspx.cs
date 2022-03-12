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
    public partial class WebForm6 : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            con.Close();
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from lost_book where placed='no'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            int i = Convert.ToInt32(dt.Rows.Count.ToString());
            
            if(i==0)
                Label2.Text = "No Records found!";
            else
                Label1.Text = i + " Records Found";
            r1.DataSource = dt;
            r1.DataBind();
        }
    }
}