<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="Library_Management_System.librarian.WebForm14" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
   
   <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <form id="form1" runat="server">
        <center>
            <asp:Button ID="Button1" runat="server" BackColor="#00FFCC" Text="Student Book Issue"  OnClick="Button1_Click1" Width="190px" /> &nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" BackColor="#00FFCC" Text="Show All Students" OnClick="Button3_Click"  Width="190px"/> &nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" BackColor="#00FFCC" Text="Show Books" OnClick="Button5_Click" Width="190px" />&nbsp;&nbsp;<br><br>

            <asp:Button ID="Button2" runat="server" BackColor="#00FF99" OnClick="Button2_Click" Text="Teacher Book Issue" Width="190px"/>&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" BackColor="#00FF99" Text="Show All Teachers" OnClick="Button4_Click" Width="190px"/>&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" BackColor="#00FF99" Text="Lost Books" Width="190px" OnClick="Button6_Click" />&nbsp;&nbsp;
            <br />
            <br />
        </center>
        
        <br />
        <div class="card-body rp">
             <rsweb:ReportViewer ID="ReportViewer1" runat="server" width="774px" ></rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">  </asp:ScriptManager>
        </div>
       
      
    </form>
    
</asp:Content>
