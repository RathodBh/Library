using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.Adapters;
using System.Web.UI.HtmlControls;
using System.Configuration;


namespace Library_Management_System.librarian
{
    public partial class add_books : System.Web.UI.Page
    {
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BH\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");
    // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bcaproject11\Documents\Visual Studio 2019\Library Management System\App_Data\library.mdf;Integrated Security=True;Connect Timeout=30");

    int cnt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

           
        }

        protected void btn_addBook_Click(object sender, EventArgs e)
        {
            if (txt_author.Text == "" || txt_bookstitle.Text == "" || txt_isbn.Text == "" || txt_lang.Text == "" || txt_price.Text == "" || txt_qty.Text == "" || txt_place.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "demo()", "blank_all();", true);
                //msg2.Style.Add("display", "block");
            }
            
            else { 
            
                String path_img = "";
              
                String path_pdf = "";
                String path_video = "";
                //if (fu_img.FileName.ToString() == "" || fu_pdf.FileName == "" || fu_vdo.FileName == null)
                // msg2.Style.Add("display", "block");
                // else
                // {   
                if (fu_img.FileName.ToString() != "")
                {
                  
                    if (! (System.IO.Path.GetExtension(fu_img.FileName).ToLower().Equals(".jpg") || System.IO.Path.GetExtension(fu_img.FileName).ToLower().Equals(".jpeg")))
                    {
                        cnt = cnt + 1;
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "image_error();", true);
                       // Response.Write("<script>alert('Image file must be .jpg or .jpeg type');</script>");
                    }
                    else
                    {
                        //string rr = Class2.GetRandomPassword(5);

                        Random r = new Random(5);
                        int num = r.Next();
                        string img_nm = "img"+ num.ToString()+ fu_img.FileName.ToString() + System.IO.Path.GetExtension(fu_img.FileName);

                         //fu_img.SaveAs(Server.MapPath("~/librarian/books_images/" + fu_img.FileName));
                        fu_img.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + img_nm.ToString());
                            path_img = "../librarian/books_images/" + img_nm.ToString();
                    }
                }
                if (fu_pdf.FileName.ToString() != "")
                {
                    if (!(System.IO.Path.GetExtension(fu_pdf.FileName).ToLower().Equals(".pdf")))
                    {
                        cnt = cnt + 1; 
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "pdf_error();", true);
                        //Response.Write("<script>alert('PDF file must be .pdf type');</script>");
                    }
                    else
                    { 
                            Random r2 = new Random(4);
                            int num2 = r2.Next();
                            string pdf_nm = "pdf" + num2.ToString() + fu_pdf.FileName.ToString() + System.IO.Path.GetExtension(fu_pdf.FileName);

                            fu_pdf.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_pdf/" + pdf_nm.ToString());
                            path_pdf = "../librarian/books_pdf/" + pdf_nm.ToString();
                        }
                }
                if (fu_vdo.FileName.ToString() != "")
                {
                    if (!(System.IO.Path.GetExtension(fu_vdo.FileName).ToLower().Equals(".mp4")))
                    {
                        cnt = cnt + 1;
                        ClientScript.RegisterStartupScript(this.GetType(), "demo()", "vdo_error();", true);
                        //Response.Write("<script>alert('Video file must be .mp4 type');</script>");
                    }
                    else
                    { 
                            Random r3 = new Random(7);
                            int num3 = r3.Next();
                            string vdo_nm = "vdo" + num3.ToString() + fu_vdo.FileName.ToString() + System.IO.Path.GetExtension(fu_vdo.FileName);

                            fu_vdo.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_video/" + vdo_nm.ToString());
                                path_video = "../librarian/books_video/" + vdo_nm.ToString();
                        }
                }
                
                //}
                if(cnt==0)
                { 
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into book_info (isbn,bnm,bimg,bauthor,qty,pdf,vdo,lang,pg,price,place) values('" + txt_isbn.Text + "','" + txt_bookstitle.Text + "','" + path_img + "','" + txt_author.Text + "','" + txt_qty.Text + "','" + path_pdf + "','" + path_video + "','" + txt_lang.Text + "','" + txt_pg.Text + "','" + txt_price.Text + "', '" + txt_place.Text + "')";
                    cmd.ExecuteNonQuery(); 
                    
                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "done_add_books();", true);

                    //msg.Style.Add("display", "block");
                }
            }
            con.Close();
                
            
        }
    }
}