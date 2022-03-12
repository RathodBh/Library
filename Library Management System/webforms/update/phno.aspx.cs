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
    public partial class phno : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
           
            if (Session["s"].ToString()=="s")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from stud_reg where email='"+ Session["email"] +"'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                int i = Convert.ToInt32(dt.Rows.Count.ToString());
                if(i>0)
                {
                    id = Session["id"].ToString();
                    Label1.Text = "Old Number: " + Session["ph"].ToString();
                }
            }
            else if (Session["t"].ToString() == "t")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from teacher_reg where email='" + Session["email"] + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                int i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i > 0)
                {
                    id = Session["id"].ToString();
                    Label1.Text = "Old Number: " + Session["ph"].ToString();
                }
            }
            else
            {
                Response.Redirect("../../student/stud_login.aspx");
            }

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
        protected void btn_Click(object sender, EventArgs e)
        {

            if (ph.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo", "phno_error();", true);
            }
            else
            {
                if (Session["s"].ToString() == "s")
                {
                    //Check for the Phone Number is already exists or not
                    SqlCommand cmd0 = con.CreateCommand();
                    cmd0.CommandText = "select * from stud_reg where ph= '" + ph.Text + "' ";
                    cmd0.ExecuteNonQuery();

                    DataTable dt0 = new DataTable();
                    SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                    da0.Fill(dt0);

                    int i = Convert.ToInt32(dt0.Rows.Count.ToString());
                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "demo", "ph_error();", true);
                    }
                    else
                    {
                        if (ph.Text != "" && ph.Text.Length == 10 && IsNumeric(ph.Text) == true)
                        {
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "update stud_reg set ph='" + ph.Text + "' where id='" + id + "'";
                            cmd1.ExecuteNonQuery();

                            ClientScript.RegisterStartupScript(this.GetType(), "demo", "updated();", true);
                        }
                        else if (IsNumeric(ph.Text) == false)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo", "nan_p();", true);
                        }

                        else if (ph.Text.Length != 10)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo", "len();", true);
                        }
                        else
                        {
                            Response.Write("<script>alert('Please Enter currect Phone number');</script>");
                        }
                    }

                }
                if (Session["t"].ToString() == "t")
                {
                    //Check for the Phone Number is already exists or not
                    SqlCommand cmd0 = con.CreateCommand();
                    cmd0.CommandText = "select * from teacher_reg where ph= '" + ph.Text + "' ";
                    cmd0.ExecuteNonQuery();

                    DataTable dt0 = new DataTable();
                    SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                    da0.Fill(dt0);

                    int i = Convert.ToInt32(dt0.Rows.Count.ToString());
                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "demo", "ph_error();", true);
                    }
                    else
                    {
                        if (ph.Text != "" && IsNumeric(ph.Text) == true && ph.Text.Length == 10)
                        {
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "update teacher_reg set ph='" + ph.Text + "' where id='" + id + "'";
                            cmd1.ExecuteNonQuery();

                            ClientScript.RegisterStartupScript(this.GetType(), "demo", "updated();", true);
                        }
                        else if (IsNumeric(ph.Text) == false)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo", "nan_p();", true);
                        }

                        else if (ph.Text.Length != 10)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo", "len();", true);
                        }

                        else
                        {
                            Response.Write("<script>alert('Please Enter currect Phone number');</script>");
                        }
                    }

                }

            }

        }

        protected void reset_Click(object sender, EventArgs e)
        {
            ph.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["s"].ToString() == "s")
                Response.Redirect("../../student/my_profile.aspx");
            if(Session["t"].ToString()=="t")
                Response.Redirect("../../teacher/my_profile.aspx");

        }
    }
}