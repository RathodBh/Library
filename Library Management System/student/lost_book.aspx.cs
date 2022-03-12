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
    public partial class lost_book : System.Web.UI.Page
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BH\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
    // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bcaproject11\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");

    String enrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            if (Session["stud"] == null)
                Response.Redirect("stud_login.aspx");
            //String enrl = "";

            //for the getting enrollment number
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from stud_reg where email = '" + Session["stud"] + "'";
            cmd0.ExecuteNonQuery();
            DataTable dt00 = new DataTable();
            SqlDataAdapter da00 = new SqlDataAdapter(cmd0);
            da00.Fill(dt00);
            foreach (DataRow dr00 in dt00.Rows)
            {
                enrl = dr00["eno"].ToString();
            }

          

            //temporary data table
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("id");
            dt.Columns.Add("price");
            dt.Columns.Add("isbn");
            dt.Columns.Add("bnm");
            dt.Columns.Add("issue_date");
            dt.Columns.Add("approx_return_date");
            dt.Columns.Add("name");
            dt.Columns.Add("is_return");
            dt.Columns.Add("return_date");
           

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from stud_issue_return where eno='" + enrl + "' and is_return='no'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = dr1["id"].ToString();
                dr["isbn"] = dr1["isbn"].ToString();

                SqlCommand cmdd = con.CreateCommand();
                cmdd.CommandType = CommandType.Text;
                cmdd.CommandText = "select * from book_info where isbn='"+ dr["isbn"].ToString() +"'";
                cmdd.ExecuteNonQuery();

                DataTable dtt = new DataTable();
                SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                daa.Fill(dtt);
                int i = Convert.ToInt32(dtt.Rows.Count.ToString());
                if (i <= 0)
                    Label1.Text = "You don't have any book";
                foreach(DataRow drr in dtt.Rows)
                {
                    dr["price"] = drr["price"].ToString();
                }
                 

                dr["bnm"] = dr1["bnm"].ToString();
                dr["issue_date"] = dr1["issue_date"].ToString();
                string v = dr1["approx_return_date"].ToString();
                dr["approx_return_date"] = v;
                dr["name"] = dr1["name"].ToString();
                dr["is_return"] = dr1["is_return"].ToString();
                dr["return_date"] = dr1["return_date"].ToString();

                dt.Rows.Add(dr);

            }
            dl1.DataSource = dt;
            dl1.DataBind();
        }

        
    }
}