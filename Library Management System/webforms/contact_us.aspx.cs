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
   
    public partial class contact_us : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BH\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
        // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bcaproject11\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
        }
        public bool IsNumeric(String str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    long num;
                    if (long.TryParse(str, out num))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return false;
        }
        protected void b1_Click(object sender, EventArgs e)
        {
           

            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank_all();", true);
            }
            else if(IsNumeric(TextBox3.Text)==false)
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "nan_p();", true);
            else if (TextBox3.Text.Length != 10)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "len();", true);
            }
            else
            {
                //if(TextBox1.Text=="" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == ""  )

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into contact_us values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "done_contact();", true);

            }

        }
    }
}