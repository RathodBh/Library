<%@ Page Title="" Language="C#" MasterPageFile="~/teacher/teacher_menu.Master" AutoEventWireup="true" CodeBehind="my_profile.aspx.cs" Inherits="Library_Management_System.teacher.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
        
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
     <link rel="stylesheet" href="../librarian/assets/css/font-awesome.min.css" />
      <link rel="stylesheet" type="text/css" href="../css/contact.css">
    <title>Profile</title>
    <style>
        .card
        {
            width:50vw;
        }
        .change{
            background:green;
            color:white;
            border-radius:10px;
            height:25px;
            width:140px;
            font-size:14px;
            position:absolute;
            left:36%;
            top:33%;
        }
        .change:hover{
            background:blue;
        }
        @media screen and (max-width: 650px)
        {
            .card{
                width:100vw;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
          
<div class="row" style="margin-top:-20px;background:white;display:grid;place-items:center;">
  <div class="column">
    
      <div class="card"   style="background:white;">
       
        <div class="container c1">
          <center>
                <br>
               <h2><asp:Label ID="Label1" runat="server" Text="My Profile" style="color:grey;"></asp:Label></h2>
             <hr style="width:25vw;">
               <asp:Repeater ID="r1" runat="server">
                   <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         
                                     
                                        <tbody>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <tr>
                                        
                                        <td><center><%#checkimg(Eval("timg"),Eval("id") ) %></center></td>
                                        
                                    </tr>
                                   
                                </ItemTemplate>


                                <FooterTemplate> 
                                </thead>
                                    </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
               <center><asp:Button ID="change" CssClass="change" Text="EDIT" runat="server" style="" OnClick="change_Click"/></center>
               <h2><asp:Label ID="name" runat="server" Text="" style="color:#FC6D6D;"></asp:Label></h2>
         <br>
          
          <p><b>Mobile No :</b> +91 <asp:Label ID="phno" runat="server" Text=""></asp:Label> <a class="icons" href="../webforms/update/phno.aspx" style="font-size:20px;border:none;"><i style="font-size:20px;margin:0px;" class="fa fa-pencil-square-o"></i></a></p>
          <p><b>Email:</b> <asp:Label ID="email" runat="server" Text=""></asp:Label></p>
          
              <hr style="width:25vw;">

               <p><b>Teacher ID:</b> <asp:Label ID="tid" runat="server" Text=""></asp:Label></p>
               <p><b>Department:</b> <asp:Label ID="dept" runat="server" Text=""></asp:Label> <a class="icons" href="../webforms/update/dept.aspx" style="font-size:20px;border:none;"><i style="font-size:20px;margin:0px;" class="fa fa-pencil-square-o"></i></a></p>
              
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
