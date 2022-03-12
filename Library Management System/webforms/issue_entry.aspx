<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="issue_entry.aspx.cs" Inherits="Library_Management_System.webforms.issue_entry" %>
<html>
    <!-- sweet Alert -->
    <script src="../sweetAlert/jquery.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/popper.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/sweetalert.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/bootstrap.min.css" type="text/javascript"></script>

    <script type="text/javascript" src="../js/functions.js"></script>
     
    <link rel="shortcut icon" href="img/favicon.ico" />
  
    <body>
        <form runat="server">
             <center>
            <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="OK" style="border-radius:5px;" OnClick="Button1_Click" Width="117px"></asp:Button>
        </center>
        </form>
       
    </body>
</html>
