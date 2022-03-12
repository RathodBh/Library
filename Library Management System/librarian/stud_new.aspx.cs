using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/*
 * 


namespace Library_Management_System.librarian
{
    public partial class display_stud_info : System.Web.UI.Page
    {
         
       
       
    }
}
 * */
namespace Library_Management_System.librarian
{
    public partial class stud_new : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            Label1.Text = "";
            Session["s1"] = "s1";
            Session["t1"] = "";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stud_reg where approved='new'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            r1.DataSource = dt;
            r1.DataBind();
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from stud_reg where approved='new' and ( eno like '%'+'" + TextBox2.Text + "'+'%' or snm like '%'+'" + TextBox2.Text + "'+'%'  or email like '%'+'" + TextBox2.Text + "'+'%' or ph like '%'+'" + TextBox2.Text + "'+'%' or simg like '%'+'" + TextBox2.Text + "'+'%' or approved like '%'+'" + TextBox2.Text + "'+'%' or stream like '%'+'" + TextBox2.Text + "'+'%' or sem like '%'+'" + TextBox2.Text + "'+'%')";
            //cmd0.Parameters.AddWithValue("bnm",TextBox2.Text);
            cmd0.ExecuteNonQuery();

            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);

            int i = Convert.ToInt32(dt0.Rows.Count.ToString());
            if(i<=0)
            {
                Label1.Text = "No Search Found..!";
            }
            else
            {
                Label1.Text = i + " Results match...";
            }

            r1.DataSource = dt0;
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