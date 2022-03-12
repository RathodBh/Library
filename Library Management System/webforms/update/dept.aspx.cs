using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System.webforms.update
{
    public partial class dept : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (dept2.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo", "dept_error();", true);
            }

            else
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update teacher_reg set dept='" + dept2.Text + "' where email='" + Session["email"] + "'";
                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "demo", "dept_updated();", true);
            }


        }

        protected void reset_Click(object sender, EventArgs e)
        {
            dept2.Text = "";
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../teacher/my_profile.aspx");
        }
    }
}