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
    public partial class WebForm5 : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            if (Session["teacher"] == null)
                Response.Redirect("teacher_login.aspx");

            String id = "";
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from teacher_reg where email='" + Session["teacher"].ToString() + "'";
            cmd0.ExecuteNonQuery();
            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);
            foreach (DataRow dr0 in dt0.Rows)
            {
                id = dr0["tid"].ToString();
            }

            //temporary datatable
            DataTable dt00 = new DataTable();
            dt00.Clear();
            dt00.Columns.Add("isbn");
            dt00.Columns.Add("bnm");
            dt00.Columns.Add("price");
            dt00.Columns.Add("lost_by");
            dt00.Columns.Add("user_id");
            dt00.Columns.Add("user_type");
            dt00.Columns.Add("dt");





            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select* from lost_book where placed='yes' and user_id='" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);

            int i = Convert.ToInt32(dt1.Rows.Count.ToString());
            if (i <= 0)
                Label1.Text = "Record Not Available";
            foreach (DataRow dr1 in dt1.Rows)
            {
                DataRow dr = dt00.NewRow();
                // dr["id"] = dr1["id"].ToString();
                dr["isbn"] = dr1["isbn"].ToString();

                SqlCommand cmdd = con.CreateCommand();
                cmdd.CommandType = CommandType.Text;
                cmdd.CommandText = "select * from book_info where isbn='" + dr["isbn"].ToString() + "'";
                cmdd.ExecuteNonQuery();

                DataTable dtt = new DataTable();
                SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                daa.Fill(dtt);
                foreach (DataRow drr in dtt.Rows)
                {
                    dr["price"] = drr["price"].ToString();
                }


                dr["bnm"] = dr1["bnm"].ToString();
                dr["lost_by"] = dr1["lost_by"].ToString();
                dr["user_id"] = dr1["user_id"].ToString();
                dr["user_type"] = dr1["user_type"].ToString();
                dr["dt"] = dr1["dt"].ToString();

                dt00.Rows.Add(dr);
            }
            dl1.DataSource = dt00;
            dl1.DataBind();
        }
    }
}