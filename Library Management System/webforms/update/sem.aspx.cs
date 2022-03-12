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
    
    public partial class sem : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        int sem1;
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
        public void s()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stud_reg where email='" + Session["email"] + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            int i = Convert.ToInt32(dt.Rows.Count.ToString());
            foreach (DataRow dr in dt.Rows)
                sem1 = Convert.ToInt32(dr["sem"].ToString());

            Label1.Text = sem1.ToString();
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            if (sem2.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo", "sem_error();", true);
            }
            else if (IsNumeric(sem2.Text) == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo", "nan();", true);
            }
            else if (Convert.ToInt32(sem2.Text) > 6 || Convert.ToInt32(sem2.Text) < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo", "sem_invalid();", true);
            }
            else if (sem1 > Convert.ToInt32(sem2))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo", "sem_min();", true);
            }
            else
            {
               
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update stud_reg set sem='" + sem2.Text + "' where email='" + Session["email"] + "'";
                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "demo", "updated();", true);
            }


        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../student/my_profile.aspx");
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            sem2.Text = "";
        }
    }
}