<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="display_teacher_info.aspx.cs" Inherits="Library_Management_System.librarian.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
   
      <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <center>
                            <strong class="card-title">All Teacher Information</strong>
                                </center>
                        </div>
                         <div class="card-header">
                             <form runat="server">
                                <center>
                                 <asp:TextBox ID="TextBox2"  runat="server" class="card-title" placeholder="  Search.."  style="border-radius:15px;height: 40px;width:300px;padding:0px 5px;"  AutoPostBack="True" OnTextChanged="Button1_Click" ></asp:TextBox>
                                 <asp:Button ID="Button1" runat="server" Text="Search" style="padding:5px 10px;border-radius:10px;" OnClick="Button1_Click" />
                                  <br>  <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </center> 
                             </form>
                            
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         <tr style="background:black;color:white;">
                                             <th>Image</th>
                                             <th>Name</th>
                                             <th>Teacher ID</th>
                                             <th>Email</th>
                                             <th>Phone Number</th>
                                             <th>Dept</th>
                                             <th>Status</th>
                                             <th>Active</th>
                                             <th>Deactive</th>
                                         </tr>
                                     
           <tbody>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%#checkimg(Eval("timg"),Eval("id") ) %></td>
                <td><%#Eval("tnm") %></td>
                <td><%#Eval("tid") %></td>
                <td><%#Eval("email") %></td>
                <td><%#Eval("ph") %></td>
                <td><%#Eval("dept") %></td>
                <td><%#Eval("approved") %></td>
                <td><a id="ac" href="active.aspx?id=<%#Eval("id") %>">Active</a></td>
                <td><a id="da" href="deactive.aspx?id=<%#Eval("id") %>">Deactive</a></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </thead>
                 </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
