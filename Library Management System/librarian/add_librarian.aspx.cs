using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System.librarian
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();


        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

            if (txt_lnm.Text == "" || txt_email.Text == "" || txt_pwd.Text == "" || txt_ph.Text == "" )
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank_all();", true);
                //msg2.Style.Add("display", "block");
            }

            else
            {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into librarian_reg values('" + txt_lnm.Text + "','" + txt_email.Text + "','" + txt_pwd.Text + "','" + txt_ph.Text + "')";
                    cmd.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "done_add_lnm();", true);

                    //msg.Style.Add("display", "block");
                
            }
            con.Close();


        }
    }
}