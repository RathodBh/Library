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
    public partial class librarian_menu : System.Web.UI.MasterPage
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        int cnt ;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from message where receiver ='librarian' and placed='no'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            cnt = Convert.ToInt32(dt.Rows.Count.ToString());
            notify1.Text = cnt.ToString();
            notify2.Text = cnt.ToString();

            r1.DataSource = dt;
            r1.DataBind();

            //Label1.Text = getTimer();
            
        }
       
        public string getShortMsg(object my)
        {
            String a,b;
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

        public string getTimer()
        {
            
            String h = DateTime.Now.Hour.ToString();
            String m = DateTime.Now.Minute.ToString();
            String s = DateTime.Now.Second.ToString();
            String ms = DateTime.Now.Millisecond.ToString();
            
            String tm = h + ":" + m + ":" + s + ":" + ms;

            
            return (tm);
            //getTimer();
        }
    }
}