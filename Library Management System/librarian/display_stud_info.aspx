<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="display_stud_info.aspx.cs" Inherits="Library_Management_System.librarian.display_stud_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
        <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <center> <strong class="card-title">All Student Information</strong></center>
                           
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
                                         <tr  style="background:brown;color:white;">
                                             <th>Image</th>
                                             <th>Name</th>
                                             <th>Enrollment number</th>
                                             <th>Email</th>
                                             <th>Phone Number</th>
                                             <th>Stream</th>
                                             <th>Sem</th>
                                             <th>Status</th>
                                             <th >Active</th>
                                             <th >Deactive</th>
                                         </tr>
                                     
           <tbody>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                
                <td><center><%#checkimg(Eval("simg"),Eval("id") ) %></center></td>
                <td><%#Eval("snm") %></td>
                <td><%#Eval("eno") %></td>
                <td><%#Eval("email") %></td>
                <td><%#Eval("ph") %></td>
                <td><%#Eval("stream") %></td>
                <td><%#Eval("sem") %></td>
                <td><%#Eval("approved") %></td>
                <td ><a id="ac" href="active.aspx?id=<%#Eval("id") %>">Active</a></td>
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