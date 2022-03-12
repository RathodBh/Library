<%@ Page Title="" Language="C#" MasterPageFile="~/teacher/teacher_menu.Master" AutoEventWireup="true" CodeBehind="teacher_home.aspx.cs" Inherits="Library_Management_System.teacher.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
      
      <!-- sweet Alert -->
    <script src="../sweetAlert/jquery.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/popper.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/sweetalert.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/functions.js"></script>

    <h3>Welcome <asp:Label ID="Label1" runat="server" Text="" style="color:blueviolet;"></asp:Label></h3>

    <script>
        swal("Login Successfully","Welcome","success");
    </script>

</asp:Content>
