using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System.teacher
{
    public partial class WebForm8 : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        String ph_no, dept_var;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            //if (Session["l"].ToString() == "l")
            //    Response.Redirect("../student/stud_login.aspx");

            name.Text = Session["tnm"].ToString();
            email.Text = Session["email"].ToString();
            
            dept.Text = Session["dept"].ToString();
            tid.Text = Session["tid"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from teacher_reg where email='" + email.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                ph_no = dr["ph"].ToString();
                dept_var = dr["dept"].ToString();
            }
            phno.Text = ph_no;
            dept.Text = dept_var;
            r1.DataSource = dt;
            r1.DataBind();
        }
        public string checkimg(object o1, object id0)
        {
            if (o1.ToString() == "")
                return "<img src='img/teacher.jpeg' style='width:150px;border-radius:50%;height:150px;border-radius:50%;'></img>";
            else
            {
                o1 = o1.ToString();
                return "<img src='" + o1.ToString() + "' style='width:150px;border-radius:50%;height:150px;border-radius:50%;'></img>";
                //return "<a href='" + o1.ToString() + "' style='color: green; '>View Image</a>";
            }
        }

        protected void change_Click(object sender, EventArgs e)
        {
            Response.Redirect("../webforms/update/dp.aspx");
        }
    }
}