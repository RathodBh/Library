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
    public partial class teacher_login : System.Web.UI.Page
    {
       
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        String path_img;
        int cnt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "Student")
                Response.Redirect("../student/stud_login.aspx");

        }

        protected void btn2_Click(object sender, EventArgs e)
        {

            if (log_email.Text == "" || log_pwd.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank();", true);
                //Response.Write("<script>alert('Please Enter Email ID and password ');window.location.href=window.location.href;</script>");
            }
            else
            {
                //librarian login
                int i = 0;

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from librarian_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Session["l"] = "l";
                        Session["lnm"] = dr["lnm"].ToString();
                        Session["lemail"] = dr["email"].ToString();
                        Session["lph"] = dr["ph"].ToString();
                    }
                    Response.Redirect("../librarian/demo.aspx");
                }
                else
                {
                    
                    //student login
                    //approved=no
                    SqlCommand cmd0 = con.CreateCommand();
                    cmd0.CommandType = CommandType.Text;
                    cmd0.CommandText = "select * from stud_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='no'";
                    cmd0.ExecuteNonQuery();
                    SqlDataAdapter da20 = new SqlDataAdapter(cmd0);
                    da20.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());

                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "wait();", true);
                       // System.Threading.Thread.Sleep(5000);
                    }
                    else
                    {  //approved=new
                        SqlCommand cmd000 = con.CreateCommand();
                        cmd000.CommandType = CommandType.Text;
                        cmd000.CommandText = "select * from stud_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='new'";
                        cmd000.ExecuteNonQuery();
                        SqlDataAdapter da0000 = new SqlDataAdapter(cmd000);
                        da0000.Fill(dt);
                        i = Convert.ToInt32(dt.Rows.Count.ToString());

                        if (i > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "not_approved();", true);
                            // System.Threading.Thread.Sleep(5000);
                        }
                        else { 
                        cmd.CommandText = "select * from stud_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='yes'";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        i = Convert.ToInt32(dt.Rows.Count.ToString());

                        if (i > 0)
                        {


                            Session["s"] = "s";
                            Session["t"] = "";
                            Session["stud"] = log_email.Text;
                            Session["teacher"] = "";
                            foreach (DataRow drr in dt.Rows)
                            {
                                Session["snm"] = drr["snm"].ToString();
                                Session["eno"] = drr["eno"].ToString();
                                Session["ph"] = drr["ph"].ToString();
                                Session["email"] = drr["email"].ToString();
                                Session["stream"] = drr["stream"].ToString();
                                Session["sem"] = drr["sem"].ToString();
                            }
                            Response.Redirect("../student/stud_home.aspx");
                        }
                        else
                        {
                            //teacher login
                            //check approved=no
                            SqlCommand cmd01 = con.CreateCommand();
                            cmd01.CommandType = CommandType.Text;
                            cmd01.CommandText = "select * from teacher_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='no'";
                            cmd01.ExecuteNonQuery();
                            SqlDataAdapter da10 = new SqlDataAdapter(cmd01);
                            da10.Fill(dt);
                            i = Convert.ToInt32(dt.Rows.Count.ToString());

                            if (i > 0)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "wait();", true);
                                System.Threading.Thread.Sleep(5000);
                            }
                            else
                            {
                                //check for approved=new
                                SqlCommand cmd0001 = con.CreateCommand();
                                cmd0001.CommandType = CommandType.Text;
                                cmd0001.CommandText = "select * from teacher_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='new'";
                                cmd0001.ExecuteNonQuery();
                                
                                SqlDataAdapter da100 = new SqlDataAdapter(cmd0001);
                                da100.Fill(dt);
                                i = Convert.ToInt32(dt.Rows.Count.ToString());

                                if (i > 0)
                                {
                                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "not_approved();", true);
                                        System.Threading.Thread.Sleep(5000);
                                }
                                else 
                                {
                                    
                                cmd.CommandText = "select * from teacher_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='yes'";
                                cmd.ExecuteNonQuery();
                                SqlDataAdapter da3 = new SqlDataAdapter(cmd);
                                da3.Fill(dt);
                                i = Convert.ToInt32(dt.Rows.Count.ToString());

                                if (i > 0)
                                {

                                    Session["s"] = "";
                                    Session["t"] = "t";
                                    Session["stud"] = "";
                                    Session["teacher"] = log_email.Text;


                                    foreach (DataRow drr in dt.Rows)
                                    {
                                        Session["tid"] = drr["tid"].ToString();
                                        Session["tnm"] = drr["tnm"].ToString();
                                        Session["email"] = drr["email"].ToString();
                                        Session["ph"] = drr["ph"].ToString();
                                        Session["dept"] = drr["dept"].ToString();

                                    }
                                    //log_pwd.Text = "jsn";
                                    Response.Redirect("../teacher/teacher_home.aspx");
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "hey();", true);
                                }
                                //Response.Write("<script>alert('Email Id or Password Wrong...');</script>");

                                }
                            }

                             }//end else1
                        }
                    }
                    
                } //end-else2
            }//main_else
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

        //Registration 
        protected void btn1_Click(object sender, EventArgs e)
        {
            if (t_tnm.Text == null || t_email.Text == null || t_tid.Text == "" || t_pwd.Text == null || t_ph.Text == null || ss_sq.Text==null)
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank_all();", true);
            //Response.Write("<script>alert('Please Enter All details');window.location.href=window.location.href;</script>");
            else if (t_ph.Text.Length < 10 || t_ph.Text.Length > 10)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "len();", true);
            }
            //Response.Write("<script>alert('Please Enter valid Phone number ');window.location.href=window.location.href;</script>");
            else if (IsNumeric(t_ph.Text) == false)
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "nan_p();", true);
            else
            {
                String timg_path = "";

                cnt = 0;
                //Check for the Enrollment Number is same or not
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "select * from teacher_reg where tid= '" + t_tid.Text + "'";
                cmd0.ExecuteNonQuery();

                DataTable dt0 = new DataTable();
                SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                da0.Fill(dt0);

                int i = Convert.ToInt32(dt0.Rows.Count.ToString());
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "err_tid();", true);
                }
                else
                {
                    //Check for the Email is already exists or not
                    // SqlCommand cmd00 = con.CreateCommand();
                    // cmd00.CommandType = CommandType.Text;
                    cmd0.CommandText = "select * from teacher_reg where email='" + t_email.Text + "'";
                    cmd0.ExecuteNonQuery();

                    dt0 = new DataTable();
                    da0 = new SqlDataAdapter(cmd0);
                    da0.Fill(dt0);

                    i = Convert.ToInt32(dt0.Rows.Count.ToString());
                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "email_error();", true);
                        //t_tnm.Text = "err_eno";
                        // Response.Write("<script>alert('Email is already Exist');</script>");
                    }
                    else
                    {
                        //Check for the Phone Number is already exists or not
                        // SqlCommand cmd0 = con.CreateCommand();
                        // cmd0.CommandType = CommandType.Text;
                        cmd0.CommandText = "select * from teacher_reg where ph='" + t_ph.Text + "'";
                        cmd0.ExecuteNonQuery();

                        dt0 = new DataTable();
                        da0 = new SqlDataAdapter(cmd0);
                        da0.Fill(dt0);

                        i = Convert.ToInt32(dt0.Rows.Count.ToString());
                        if (i > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "ph_error();", true);
                            //t_tnm.Text = "err_eno";
                            //Response.Write("<script>alert('Phone Number is already Exist');</script>");
                        }
                        else
                        {
                            if (fu_teacher.FileName.ToString() != "")
                            {
                                if (!(System.IO.Path.GetExtension(fu_teacher.FileName).ToLower().Equals(".jpg") || System.IO.Path.GetExtension(fu_teacher.FileName).ToLower().Equals(".jpeg")))
                                {
                                     cnt = cnt + 1;
                                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "image_error();", true);
                                    //Response.Write("<script>alert('Image file must be .jpg or .jpeg type');</script>");
                                }
                                else
                                {
                                    //  string rr = Class2.GetRandomPassword(5);

                                    Random r = new Random(5);
                                    int num = r.Next();
                                    string img_nm = num.ToString() + System.IO.Path.GetExtension(fu_teacher.FileName);

                                    //fu_img.SaveAs(Server.MapPath("~/librarian/books_images/" + fu_img.FileName));
                                    fu_teacher.SaveAs(Request.PhysicalApplicationPath + "/teacher/img/" + img_nm.ToString());
                                    path_img = "../teacher/img/" + img_nm.ToString();

                                }
                            }
                            if(cnt==0)
                            {
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "insert into teacher_reg values('" + t_tid.Text + "','" + t_tnm.Text + "','" + t_email.Text + "','" + t_pwd.Text + "','" + t_ph.Text + "','" + t_dept + "','new','" + timg_path + "','"+ ss_sq.Text +"')";
                                cmd.ExecuteNonQuery();
                                
                                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "done();", true);

                                // t_tnm.Text = "abc222";
                                //Response.Write("<script>alert('Registration Successfully...');</script>");
                            }
                        }
                    }

                }
            }

        }
    }
}