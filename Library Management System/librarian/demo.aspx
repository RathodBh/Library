<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="Library_Management_System.librarian.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    
    <!--sweetAlert Javascript-->
    <script src="../sweetAlert/jquery.min.js" type="text/javascript"></script>
	<script src="../sweetAlert/popper.min.js" type="text/javascript"></script>
	<script src="../sweetAlert/sweetalert.min.js" type="text/javascript"></script>
   
   
<h3>Welcome <asp:Label ID="Label1" runat="server" Text="" style="color:blueviolet;"></asp:Label></h3>
    <br />
     <script>

             swal({
                 title: "Login successfully!",
                 text: "Hello Admin!",
                 icon: "success",
             });
         
     </script>
   
    
</asp:Content>
