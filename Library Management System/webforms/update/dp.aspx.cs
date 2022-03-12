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

    public partial class dp : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        String id;
        //int cnt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            //Response.AppendHeader("refresh", "dp.aspx");

            if (Session["s"].ToString() == "s")
            {
                s();
            }
            else if (Session["t"].ToString() == "t")
            {
                t();
            }
            else
            {
                Response.Redirect("../../student/stud_login.aspx");
            }

           
        }
        public void s()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stud_reg where email='" + Session["email"] + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            int i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i > 0)
            {
                id = Session["id"].ToString();
                //  Label1.Text = "Old Number: " + Session["ph"].ToString();
            }
            r1.DataSource = dt;
            r1.DataBind();
        }
        public void t()
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
                //  Label1.Text = "Old Number: " + Session["ph"].ToString();
            }
            r2.DataSource = dt;
            r2.DataBind();
        }
       
        public string checkimg(object o1, object id0)
        {
            if (Session["s"].ToString()=="s")
            {
                
                if (o1.ToString() == "")
                    return "<img src='../../student/img/stud_logo.jpg' style='width:150px;height:150px;border-radius:50%;'></img>";
                else
                {
                    o1 ="../../" + o1.ToString();
                    return "<img src='" + o1.ToString() + "' style='width:150px;height:150px;border-radius:50%;'></img>";
                    //return "<a href='" + o1.ToString() + "' style='color: green; '>View Image</a>";
                }
               // s();
            }
            if (Session["t"].ToString() == "t")
            {

                if (o1.ToString() == "")
                    return "<img src='../../teacher/img/teacher.jpeg' style='width:150px;height:150px;border-radius:50%;'></img>";
                else
                {
                    o1 = "../../" + o1.ToString();
                    return "<img src='" + o1.ToString() + "' style='width:150px;height:150px;border-radius:50%;'></img>";
                    //return "<a href='" + o1.ToString() + "' style='color: green; '>View Image</a>";
                }
                // s();
            }

            return "Invalid";
            
        }
       

        protected void btn_Click(object sender, EventArgs e)
        {
            String path_img = "";
            
            //if (fu_img.FileName.ToString() == "" || fu_pdf.FileName == "" || fu_vdo.FileName == null)
            // msg2.Style.Add("display", "block");
            // else
            // {   
            if (FileUpload1.FileName.ToString() != "")
            {

                if (!(System.IO.Path.GetExtension(FileUpload1.FileName).ToLower().Equals(".jpg") || System.IO.Path.GetExtension(FileUpload1.FileName).ToLower().Equals(".jpeg")))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "demo", "image_error();", true);
                }
                else
                {
                    //  string rr = Class2.GetRandomPassword(5);
                   if (Session["s"].ToString() == "s")
                    {
                        String snm=Session["snm"].ToString();
                        Random r = new Random(5);
                        int num = r.Next();
                        string img_nm = snm + num.ToString() + System.IO.Path.GetExtension(FileUpload1.FileName);

                        //fu_img.SaveAs(Server.MapPath("~/librarian/books_images/" + fu_img.FileName));
                        FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/student/img/" + img_nm.ToString());
                        path_img = "../student/img/" + img_nm.ToString();

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update stud_reg set simg='" + path_img + "' where id='" + id + "'";
                        cmd.ExecuteNonQuery();

                        ClientScript.RegisterStartupScript(this.GetType(), "demo", "done_dp();", true);
                        s();
                        
                    }   
                    if (Session["t"].ToString() == "t")
                    {
                        String tnm=Session["tnm"].ToString();
                        Random r = new Random(5);
                        int num = r.Next();
                        string img_nm = tnm + num.ToString() + System.IO.Path.GetExtension(FileUpload1.FileName);

                        //fu_img.SaveAs(Server.MapPath("~/librarian/books_images/" + fu_img.FileName));
                        FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/teacher/img/" + img_nm.ToString());
                        path_img = "../teacher/img/" + img_nm.ToString();

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update teacher_reg set timg='" + path_img + "' where id='" + id + "'";
                        cmd.ExecuteNonQuery();

                        ClientScript.RegisterStartupScript(this.GetType(), "demo", "done_dp();", true);
                        t();
                        
                    } 
                    

                }

            }
            else
            {
                 ClientScript.RegisterStartupScript(this.GetType(), "demo", " select_book_error();", true);
            }

        }

        protected void back_Click(object sender, EventArgs e)
        {
            if(Session["s"].ToString()=="s")
            {
                Response.Redirect("../../student/my_profile.aspx");
            }
            if (Session["t"].ToString() == "t")
            {
                Response.Redirect("../../teacher/my_profile.aspx");
            }

        }

        protected void reset_Click(object sender, EventArgs e)
        {
            if (Session["s"].ToString() == "s")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update stud_reg set simg=null where id='" + id + "'";
                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "demo", "remove_dp();", true);
                s();

            }
            if (Session["t"].ToString() == "t")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update teacher_reg set timg=null where id='" + id + "'";
                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "demo", "remove_dp();", true);
                t();

            }

        }
    }
}