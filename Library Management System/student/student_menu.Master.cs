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
    public partial class student_menu : System.Web.UI.MasterPage
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            private const string V = "snm";

        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BH\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
        // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bcaproject11\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
        
        int cnt;
        String nm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from stud_reg where email='"+ Session["stud"].ToString() +"'";
            cmd0.ExecuteNonQuery();

            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);
            foreach (DataRow dr0 in dt0.Rows)
            {
                nm = dr0[V].ToString();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from message where receiver ='"+ nm +"' and placed='no'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            cnt = Convert.ToInt32(dt.Rows.Count.ToString());
            notify1.Text = cnt.ToString();
            notify2.Text = cnt.ToString();

            r1.DataSource = dt;
            r1.DataBind();

        }

        public string getShortMsg(object my)
        {
            String a, b;
            a = Convert.ToString(my.ToString());

            if (a.Length < 15)
            {
                b = a.ToString();
                return b;
            }

            else
            {
                b = a.Substring(0, 15);
                return b.ToString() + "...";
            }
        }
    }
}