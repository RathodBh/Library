<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="lost_book.aspx.cs" Inherits="Library_Management_System.librarian.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    
  <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Lost Book Entries</strong><br>
                            <center><asp:Label ID="Label1" runat="server" Text=""></asp:Label></center>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         <tr style="color:white;background:red;">
                                            <th scope="col">ISBN Number</th>                       
                                            <th scope="col">Book Title</th>
                                            <th scope="col">Lost By</th>
                                            <th scope="col">User ID</th>
                                            <th scope="col">User Type</th>
                                            <th scope="col">Date</th>
                                            <th scope="col">Payment </th>
                                         </tr>
                                     
                                        <tbody>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <tr>
                                         <td scope="col"><%#Eval("isbn") %></td>                       
                                            <td scope="col"><%#Eval("bnm") %></td>
                                            <td scope="col"><%#Eval("lost_by") %></td>
                                            <td scope="col"><%#Eval("user_id") %></td>
                                            <td scope="col"><%#Eval("user_type") %></td>
                                            <td scope="col"><%#Eval("dt") %></td>
                                            <td scope="col"><a href="lost.aspx?id=<%#Eval("id") %>" id="da">Done </a> </td></tr>
                                   
                                </ItemTemplate>


                                <FooterTemplate> 
                                </thead>
                                    </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                             <center><asp:Label ID="Label2" runat="server" Text=""></asp:Label></center>
                        </div>
                    </div>
                </div>

</asp:Content>
