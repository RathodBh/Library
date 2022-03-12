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
    public partial class penalty : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from penalty";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
                old.Text ="Current Rate:  " + dr["penalty"].ToString();

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
        protected void btn_add_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            if(txt_penalty.Text=="" )
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank_all();", true);
            }
            else if (IsNumeric(txt_penalty.Text) == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "nan();", true);
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from penalty";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cnt = Convert.ToInt32(dt.Rows.Count.ToString());

                if (cnt == 0)
                {

                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into penalty values('" + txt_penalty.Text + "')";
                    cmd1.ExecuteNonQuery();
                    
                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "inserted();", true);
                }
                else
                {
                    //int id1 = 1;
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update penalty set penalty='" + txt_penalty.Text + "' where id='1' ";
                    cmd1.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "updated();", true);
                }
            }
           
         
        }
    }
}