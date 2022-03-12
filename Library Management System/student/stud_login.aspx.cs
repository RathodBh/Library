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

    public partial class stud_login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        int mmm = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            btn2_Click(sender, e);

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "Teacher")
                Response.Redirect("../teacher/teacher_login.aspx");

        }
        protected void forget_search(object sender, EventArgs e)
        {
            if(f_email.Text == null || f_sq.Text == null || new_pwd.Text== null || con_pwd.Text==null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank_all();", true);
            }
            else //else1
            {
                f_sq.Text = f_sq.ToString().ToLower();
                int i = 0;

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from stud_reg where email='"+ f_email.Text+"' and sq='"+ f_sq.Text +"'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i > 0)
                {
                    if(new_pwd.Text == con_pwd.Text)
                    {
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "update stud_reg set pwd='" + con_pwd.Text + "' where email='" + f_email.Text + "' and sq='" + f_sq.Text + "'";
                        cmd1.ExecuteNonQuery();

                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "pwd_success();", true);
                     
                    }
                    else //else3
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "pwd_err();", true);
                    } //else 3
                }
                else //else2
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from teacher_reg where email='" + f_email.Text + "' and sq='" + f_sq.Text + "'";
                    cmd2.ExecuteNonQuery();

                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);

                    i = Convert.ToInt32(dt2.Rows.Count.ToString());

                    if(i > 0)
                    {
                        if (new_pwd.Text == con_pwd.Text)
                        {
                            SqlCommand cmd3 = con.CreateCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.CommandText = "update teacher_reg set pwd='" + con_pwd.Text + "' where email='" + f_email.Text + "' and sq='" + f_sq.Text + "'";
                            cmd3.ExecuteNonQuery();

                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "pwd_success();", true);

                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "pwd_err();", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "wrongg();", true);
                    }
                } //end else2
            } //end else1
        }
     
        protected void btn2_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(10000);
            if (log_email.Text == "" || log_pwd.Text == "")
            {
               
                if(mmm!=0)
                     ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank();", true);
                // System.Threading.Thread.Sleep(5000);  
                mmm++;
            }
            else //main_else
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
                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "success();", true);
                    //System.Threading.Thread.Sleep(5000);

                    Response.Redirect("../librarian/demo.aspx");
                }
                else //else2
                {

                    //student login
                    //check approved=no
                    SqlCommand cmd0 = con.CreateCommand();
                    cmd0.CommandType = CommandType.Text;
                    cmd0.CommandText = "select * from stud_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='no'";
                    cmd0.ExecuteNonQuery();

                    // DataTable dt0 = new DataTable();
                    SqlDataAdapter da20 = new SqlDataAdapter(cmd0);
                    da20.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());

                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "wait();", true);
                        //System.Threading.Thread.Sleep(5000);
                    }
                    else //else3
                    {
                        //check approved=new
                        SqlCommand cmd000 = con.CreateCommand();
                        cmd000.CommandType = CommandType.Text;
                        cmd000.CommandText = "select * from stud_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='new'";
                        cmd000.ExecuteNonQuery();

                        // DataTable dt0 = new DataTable();
                        SqlDataAdapter da200 = new SqlDataAdapter(cmd000);
                        da200.Fill(dt);
                        i = Convert.ToInt32(dt.Rows.Count.ToString());

                        if (i > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "not_approved();", true);
                            //System.Threading.Thread.Sleep(5000);
                            //Response.Write("<script>alert('wah');</script>");
                        }
                        else //else4
                        {
                            
                            cmd.CommandText = "select * from stud_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='yes'";
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                            da2.Fill(dt);
                            int j = Convert.ToInt32(dt.Rows.Count.ToString());

                            if (j > 0)
                            {

                                Session["s"] = "s";
                                Session["t"] = "";
                                Session["stud"] = log_email.Text;
                                Session["teacher"] = "";
                                foreach (DataRow drr in dt.Rows)
                                {
                                    Session["id"] = drr["id"].ToString();
                                    Session["snm"] = drr["snm"].ToString();
                                    Session["eno"] = drr["eno"].ToString();
                                    Session["ph"] = drr["ph"].ToString();
                                    Session["email"] = drr["email"].ToString();
                                    Session["stream"] = drr["stream"].ToString();
                                    Session["sem"] = drr["sem"].ToString();
                                }
                                // log_pwd.Text = "jsn";
                                Response.Redirect("../student/stud_home.aspx");
                            }
                            else //else5
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
                                else //else6
                                {
                                    //check approved=new
                                    SqlCommand cmd0001 = con.CreateCommand();
                                    cmd0001.CommandType = CommandType.Text;
                                    cmd0001.CommandText = "select * from teacher_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='new'";
                                    cmd0001.ExecuteNonQuery();
                                    SqlDataAdapter da1000 = new SqlDataAdapter(cmd0001);
                                    da1000.Fill(dt);
                                    i = Convert.ToInt32(dt.Rows.Count.ToString());

                                    if (i > 0)
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "not_approved();", true);
                                        //System.Threading.Thread.Sleep(5000);
                                    }
                                    else //else 7
                                    {

                                        cmd.CommandText = "select * from teacher_reg where email='" + log_email.Text + "' and pwd='" + log_pwd.Text + "' and approved='yes'";
                                        cmd.ExecuteNonQuery();
                                        SqlDataAdapter da3 = new SqlDataAdapter(cmd);
                                        da3.Fill(dt);
                                        int k = Convert.ToInt32(dt.Rows.Count.ToString());

                                        if (k > 0)
                                        {

                                            Session["s"] = "";
                                            Session["t"] = "t";
                                            Session["stud"] = "";
                                            Session["teacher"] = log_email.Text;


                                            foreach (DataRow drr in dt.Rows)
                                            {
                                                Session["id"] = drr["id"].ToString();
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

                                    } //end else7
                                } //end else6
                            }//end else5
                        }//else 4
                    } //end else3
                } //end-else2
            }//main_else
        }
        
        public bool IsNumeric(String str)
        {
            try
            {
                if(!string.IsNullOrEmpty(str))
                {
                    long num;
                    if(long.TryParse(str,out num))
                    {
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return false;
        }

        //Sign Up
        protected void btn1_Click(object sender, EventArgs e)
        {


            if (ss_snm.Text == null || ss_email.Text == null || ss_eno.Text == "" || ss_pwd.Text == null || ss_phno.Text == null || ss_sq.Text == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank_all();", true);
                //ss_snm.Text = "abc111";
                //  System.Threading.Thread.Sleep(10000);
            }
            //Response.Write("<script>alert('Please Enter All details');window.location.href=window.location.href;</script>"); 
            else if (ss_phno.Text.Length < 10 || ss_phno.Text.Length > 10)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "len();", true);
            }
            //Response.Write("<script>alert('Please Enter valid Phone number ');window.location.href=window.location.href;</script>");
            else if (IsNumeric(ss_phno.Text) == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "nan_p();", true);
               // Response.Write("<script>alert('Please Enter only Number ');window.location.href=window.location.href;</script>");
               // ss_phno.Text = "txt";
            }
            else
            {
                        String path_img = "";
                        int cnt = 0;

                        //Check for the Enrollment Number is same or not
                        SqlCommand cmd0 = con.CreateCommand();
                        cmd0.CommandType = CommandType.Text;
                        cmd0.CommandText = "select * from stud_reg where eno=" + ss_eno.Text;
                        cmd0.ExecuteNonQuery();

                        DataTable dt0 = new DataTable();
                        SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                        da0.Fill(dt0);

                        int i = Convert.ToInt32(dt0.Rows.Count.ToString());
                        if (i > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "demo()", "err_eno();", true);

                            //ss_snm.Text = "err_eno";
                            // Response.Write("<script>alert('Enrollment Number is already Exist');windows.location.href=windows.location.herf;</script>");
                        }
                        else
                        {
                            //Check for the Email is already exists or not
                            // SqlCommand cmd00 = con.CreateCommand();
                            // cmd00.CommandType = CommandType.Text;
                            cmd0.CommandText = "select * from stud_reg where email= '"+ ss_email.Text +"'";
                            cmd0.ExecuteNonQuery();

                            dt0 = new DataTable();
                            da0 = new SqlDataAdapter(cmd0);
                            da0.Fill(dt0);

                            i = Convert.ToInt32(dt0.Rows.Count.ToString());
                            if (i > 0)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "email_error();", true);

                                //ss_snm.Text = "err_eno";
                               // Response.Write("<script>alert('Email is already Exist');</script>");
                            }
                            else
                            {
                                //Check for the Phone Number is already exists or not
                                // SqlCommand cmd0 = con.CreateCommand();
                                // cmd0.CommandType = CommandType.Text;
                                cmd0.CommandText = "select * from stud_reg where ph=" + ss_phno.Text;
                                cmd0.ExecuteNonQuery();

                                dt0 = new DataTable();
                                da0 = new SqlDataAdapter(cmd0);
                                da0.Fill(dt0);

                                i = Convert.ToInt32(dt0.Rows.Count.ToString());
                                if (i > 0)
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "ph_error();", true);

                                    //ss_snm.Text = "err_eno";
                                    // Response.Write("<script>alert('Phone Number is already Exist');</script>");
                                }
                                else
                                {
                                    if (fu_student.FileName.ToString() != "")
                                    {
                                        if (!(System.IO.Path.GetExtension(fu_student.FileName).ToLower().Equals(".jpg") || System.IO.Path.GetExtension(fu_student.FileName).ToLower().Equals(".jpeg")))
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
                                            string img_nm = num.ToString() + System.IO.Path.GetExtension(fu_student.FileName);

                                            //fu_img.SaveAs(Server.MapPath("~/librarian/books_images/" + fu_img.FileName));
                                            fu_student.SaveAs(Request.PhysicalApplicationPath + "/student/img/" + img_nm.ToString());
                                            path_img = "/student/img/" + img_nm.ToString();

                                        }
                                    }
                                    if(cnt==0)
                                    {
                                         ss_sq.Text = ss_sq.ToString().ToLower();
                                            
                                        SqlCommand cmd = con.CreateCommand();
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandText = "insert into stud_reg values('" + ss_eno.Text + "','" + ss_snm.Text + "','" + ss_email.Text + "','" + ss_pwd.Text + "','" + ss_phno.Text + "','" + path_img + "','new','" + dd_stream.SelectedItem.Text + "','" + dd_sem.SelectedItem.Text + "','" + ss_sq.Text + "')";
                                        cmd.ExecuteNonQuery();
                                        //ss_snm.Text = "abc222";
                                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "done();", true);

                                       // Response.Write("<script>alert('Registration Successfully...');</script>");

                                    }
                                }
                            }

                        }
            }

        }
    }
}