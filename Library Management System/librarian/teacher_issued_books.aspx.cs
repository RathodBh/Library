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
    public partial class WebForm16 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            String penalty = "0";
            double no_of_days = 0;
            String tid = "";

            Session["t"] = "";
            Session["s"] = "s";

            SqlCommand cmd01 = con.CreateCommand();
            cmd01.CommandType = CommandType.Text;
            cmd01.CommandText = "select * from penalty";
            cmd01.ExecuteNonQuery();
            DataTable dt01 = new DataTable();
            SqlDataAdapter da01 = new SqlDataAdapter(cmd01);
            da01.Fill(dt01);
            foreach (DataRow dr01 in dt01.Rows)
            {
                penalty = dr01["penalty"].ToString();
            }


            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from teacher_reg where email = '" + Session["teacher"] + "'";
            cmd0.ExecuteNonQuery();
            DataTable dt00 = new DataTable();
            SqlDataAdapter da00 = new SqlDataAdapter(cmd0);
            da00.Fill(dt00);
            foreach (DataRow dr00 in dt00.Rows)
            {
                tid = dr00["tid"].ToString();
            }

            //temporary data table
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("id");
            dt.Columns.Add("tid");
            dt.Columns.Add("isbn");
            dt.Columns.Add("bnm");
            dt.Columns.Add("issue_date");
            dt.Columns.Add("approx_return_date");
            dt.Columns.Add("name");
            dt.Columns.Add("is_return");
            dt.Columns.Add("return_date");
            dt.Columns.Add("latedays");
            dt.Columns.Add("penalty");

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from teacher_issue_return where is_return='no'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = dr1["id"].ToString();
                dr["tid"] = dr1["tid"].ToString();
                dr["isbn"] = dr1["isbn"].ToString();
                dr["bnm"] = dr1["bnm"].ToString();
                dr["issue_date"] = dr1["issue_date"].ToString();
                string v = dr1["approx_return_date"].ToString();
                dr["approx_return_date"] = v;
                dr["name"] = dr1["name"].ToString();
                dr["is_return"] = dr1["is_return"].ToString();
                dr["return_date"] = dr1["return_date"].ToString();

                //penalty calculation
                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                DateTime d2 = Convert.ToDateTime(dr1["approx_return_date"].ToString());
               // DateTime d2 = DateTime.Parse(dr1["approx_return_date"].ToString());
                d2 = Convert.ToDateTime(d2.ToString("yyyy/MM/dd"));
                if (d1 > d2)
                {
                    TimeSpan t = d1 - d2;
                    no_of_days = t.TotalDays;
                    dr["latedays"] = no_of_days.ToString();
                }
                else
                    dr["latedays"] = 0;

                if (Convert.ToInt32(dr["latedays"]) != 0)
                    //penalty
                    dr["penalty"] = Convert.ToString(Convert.ToDouble(no_of_days) * Convert.ToDouble(penalty));
                else
                    dr["penalty"] = 0;


                dt.Rows.Add(dr);

                // dr[""] = dr1[""].ToString();
            }
            dl1.DataSource = dt;
            dl1.DataBind();
        }
    }
}