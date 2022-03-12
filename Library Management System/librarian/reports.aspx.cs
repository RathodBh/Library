using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace Library_Management_System.librarian
{
    public partial class WebForm14 : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        String path = ConfigurationManager.ConnectionStrings["path_report"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        private DataTable stud_issue_return()
        {
            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from stud_issue_return", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;

        }
        
        private DataTable teacher_issue_return()
        {
            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from teacher_issue_return", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;

        }
        private DataTable stud_data()
        {
            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from stud_reg", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;

        }
        private DataTable teacher_data()
        {
            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from teacher_reg", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;

        }
        private DataTable book_data()
        {
            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from book_info", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;

        }
        private DataTable lost_book()
        {
            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from lost_book", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource stud = new ReportDataSource("DataSet1",stud_issue_return());
          
            ReportViewer1.LocalReport.DataSources.Add(stud);
            ReportViewer1.LocalReport.ReportPath = path + @"\stud_issued.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
          //  ReportDataSource stud = new ReportDataSource("DataSet1", stud_issue_return());
            ReportDataSource teacher = new ReportDataSource("DataSet1", teacher_issue_return());

           // ReportViewer1.LocalReport.DataSources.Add(stud);
            ReportViewer1.LocalReport.DataSources.Add(teacher);
            ReportViewer1.LocalReport.ReportPath = path +  @"\Report_teacher_issue_return.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource stud = new ReportDataSource("stud_teacher", stud_data());
           
            ReportViewer1.LocalReport.DataSources.Add(stud);
            ReportViewer1.LocalReport.ReportPath = path + @"\stud_data.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource teacher = new ReportDataSource("stud_teacher", teacher_data());

            ReportViewer1.LocalReport.DataSources.Add(teacher);
            ReportViewer1.LocalReport.ReportPath = path +  @"\teacher_data.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
           ReportViewer1.Reset();
            ReportDataSource bk = new ReportDataSource("book", book_data());
            ReportViewer1.LocalReport.DataSources.Add(bk);
            ReportViewer1.LocalReport.ReportPath = path +  @"\book_data.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource bk = new ReportDataSource("book", lost_book());
            ReportViewer1.LocalReport.DataSources.Add(bk);
            ReportViewer1.LocalReport.ReportPath = path + @"\lost_book.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }
    }
}