<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="my_profile.aspx.cs" Inherits="Library_Management_System.librarian.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
     <link rel="stylesheet" href="../librarian/assets/css/font-awesome.min.css" />
      <link rel="stylesheet" type="text/css" href="../css/contact.css">
    <title>Follow Me</title>
</head>
<body>
    <form id="form1" >
         
<div class="row" style="margin-top:-20px;background:white;display:grid;place-items:center;">
  <div class="column">
    
      <div class="card" style="background:white;width:50vw;">
       
        <div class="container c1" style="color:grey;">
          <center>
                <br>
               <h2><asp:Label ID="Label1" runat="server" Text="My Profile" style="color:grey;"></asp:Label></h2>
             <hr style="width:25vw;"><br>
               <h2><asp:Label ID="name" runat="server" Text="" style="color:#FC6D6D;"></asp:Label></h2>
         
           <br>
          <p><b>Mobile No :</b> +91 <asp:Label ID="phno" runat="server" Text=""></asp:Label></p>
          <p><b>Email:</b> <asp:Label ID="email" runat="server" Text="Label"></asp:Label></p>
          
           
              
              <hr style="width:25vw;">
              
                             <p><b>Logout</b></p>
                  <a class="icons" href="../webforms/logout.aspx"><i class="fa fa-sign-out"></i></a>
                
          </center>
           </p><br><br />
          
        </div>
      </div>
    

  </div>


</div>
    </form>
</body>
</html>

</asp:Content>
