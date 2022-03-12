using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System.student
{
    public partial class WebForm7 : System.Web.UI.Page
    {
      
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        String ph_var, sem_var;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            //if (Session["s"].ToString() == "s")
            //    Response.Redirect("../student/stud_login.aspx");

            name.Text = Session["snm"].ToString();
            email.Text = Session["email"].ToString();
            stream.Text = Session["stream"].ToString();
            eno.Text = Session["eno"].ToString();
            

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stud_reg where email='" + email.Text+"'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                ph_var = dr["ph"].ToString();
                sem_var = dr["sem"].ToString();
               
            }

            
            phno.Text = ph_var;
            sem.Text = sem_var;
           

            r1.DataSource = dt;
            r1.DataBind();
        }

        public string revStr(string str)
        {
            char[] chars = str.ToCharArray();
            for (int i=0, j=str.Length -1; i<j; i++,j--)
            {
                chars[i] = str[j];
                chars[j] = str[i];
            }
            return new string(chars);
        }
        public string checkimg(object o1, object id0)
        {
            if (o1.ToString() == "")
                return "<img src='img/stud_logo.jpg' style='width:150px;height:150px;border-radius:50%;'></img>";
            else
            {
                o1 =  o1.ToString();
                return "<img src='" + o1.ToString() + "' style='width:150px;height:150px;border-radius:50%;'></img>";
                //return "<a href='" + o1.ToString() + "' style='color: green; '>View Image</a>";
            }
        }

        

        protected void change_Click1(object sender, EventArgs e)
        {
            Response.Redirect("../webforms/update/dp.aspx");
        }
    }
}