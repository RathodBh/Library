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
    public partial class WebForm12 : System.Web.UI.Page
    {
       
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    
        int id,cnt=0;

        protected void btn_update_Click(object sender, EventArgs e)
        {
            String path_img = "";

            String path_pdf = "";
            String path_video = "";
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

          
            if (fu_img.FileName.ToString() != "")
            {

                if (!(System.IO.Path.GetExtension(fu_img.FileName).ToLower().Equals(".jpg") || System.IO.Path.GetExtension(fu_img.FileName).ToLower().Equals(".jpeg")))
                {
                    cnt = cnt + 1;
                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "image_error();", true);
                }
                else
                {
                    //  string rr = Class2.GetRandomPassword(5);
                    Random r = new Random(5);
                    int num = r.Next();
                    string img_nm = "img" + fu_img.FileName.ToString() + num.ToString() + System.IO.Path.GetExtension(fu_img.FileName);

                    //fu_img.SaveAs(Server.MapPath("~/librarian/books_images/" + fu_img.FileName));
                    fu_img.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + img_nm.ToString());
                    path_img = "../librarian/books_images/" + img_nm.ToString();
                }
            }
            else
            {
                if (txt_img.Text != "")
                    path_img = txt_img.Text;
            }

            if (fu_pdf.FileName.ToString() != "")
            {
                if (!(System.IO.Path.GetExtension(fu_pdf.FileName).ToLower().Equals(".pdf")))
                {
                    cnt = cnt + 1;
                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "pdf_error();", true);
                 }
                else
                {
                    Random r2 = new Random(4);
                    int num2 = r2.Next();
                    string pdf_nm = "pdf" + fu_pdf.FileName.ToString() + num2.ToString() + System.IO.Path.GetExtension(fu_pdf.FileName);

                    fu_pdf.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_pdf/" + pdf_nm.ToString());
                    path_pdf = "../librarian/books_pdf/" + pdf_nm.ToString();
                }
            }
            else
            {
                if (txt_pdf.Text != "")
                    path_pdf = txt_pdf.Text;
            }
            if (fu_vdo.FileName.ToString() != "")
            {
                if (!(System.IO.Path.GetExtension(fu_vdo.FileName).ToLower().Equals(".mp4")))
                {
                    cnt = cnt + 1;
                    ClientScript.RegisterStartupScript(this.GetType(), "demo()", "vdo_error();", true);
                }
                else
                {
                    Random r3 = new Random(7);
                    int num3 = r3.Next();
                    string vdo_nm = "vdo" + fu_vdo.FileName.ToString() + num3.ToString() + System.IO.Path.GetExtension(fu_vdo.FileName);

                    fu_vdo.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_video/" + vdo_nm.ToString());
                    path_video = "../librarian/books_video/" + vdo_nm.ToString();
                }
            }
            else
            {
                if (txt_vdo.Text != "")
                    path_video = txt_vdo.Text;
            }
            if (txt_bookstitle.Text == "")
                txt_bookstitle.Text = t_bnm.Text;
            if (txt_author.Text == "")
                txt_author.Text = t_author.Text;
            if (txt_qty.Text == "")
                txt_qty.Text = t_qty.Text;
            if (txt_lang.Text == "")
                txt_lang.Text = t_lang.Text;
            if (txt_pg.Text == "")
                txt_pg.Text = t_pg.Text;
            if (txt_price.Text == "")
                txt_price.Text = t_price.Text;
            if (txt_place.Text == "")
                txt_place.Text = t_place.Text;

            if(cnt==0)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book_info set isbn='" + txt_isbn.Text + "', bnm='" + txt_bookstitle.Text + "', bimg='" + path_img + "', bauthor='" + txt_author.Text + "', qty='" + txt_qty.Text + "', pdf='" + path_pdf + "', vdo='" + path_video + "', lang='" + txt_lang.Text + "', pg='" + txt_pg.Text + "', price='" + txt_price.Text + "', place='" + txt_place.Text + "' where id=" + id + "";
                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "demo", "done_edit_books();", true);

            }


            //msg.Style.Add("display", "block");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from book_info where id="+id;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                txt_isbn.ReadOnly = true;
                t_bnm.ReadOnly=true;
                t_author.ReadOnly = true;
                t_lang.ReadOnly = true;
                t_pg.ReadOnly = true;
                t_place.ReadOnly = true;
                t_price.ReadOnly = true;
                t_qty.ReadOnly = true;

                txt_img.ReadOnly = true;
                txt_pdf.ReadOnly = true;
                txt_vdo.ReadOnly = true;

                t_bnm.Text = dr["bnm"].ToString();
                t_author.Text = dr["bauthor"].ToString();
                t_qty.Text = dr["qty"].ToString();
                t_lang.Text = dr["lang"].ToString();
                t_place.Text = dr["place"].ToString();
                t_pg.Text = dr["pg"].ToString();
                t_price.Text = dr["price"].ToString();
               
                txt_img.Text = dr["bimg"].ToString();
                txt_isbn.Text = dr["isbn"].ToString();
                txt_pdf.Text = dr["pdf"].ToString();
                txt_vdo.Text = dr["vdo"].ToString();
            }

        }

       
    }
}