<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="show_lost_book.aspx.cs" Inherits="Library_Management_System.librarian.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
       <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card" runat="server">
                        <div class="card-header">
                            <strong class="card-title">lost Book </strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         <tr style="color:white;background:green;">
                                            <th scope="col">ISBN Number</th>                       
                                            <th scope="col">Book Title</th>
                                            <th scope="col">Lost By</th>
                                            <th scope="col">User ID</th>
                                            <th scope="col">User Type</th>
                                            <th scope="col">Date</th>
                                            
                                         </tr>
                                     
                                        <tbody>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <tr>
                                         <td scope="col"><%#Eval("isbn") %></td>                       
                                            <td scope="col"><%#Eval("bnm") %></td>
                                            <td scope="col"><%#Eval("lost_by") %></td>
                                            <td scope="col"><%#Eval("user_id") %></t>
                                            <td scope="col"><%#Eval("user_type") %></td>
                                            <td scope="col"><%#Eval("dt") %></td>
                                    </tr>
                                   
                                </ItemTemplate>


                                <FooterTemplate> 
                                </thead>
                                    </tbody>
                                   
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                             <asp:Label ID="l1" runat="server" Text=""></asp:Label>
                                    
                        </div>
                    </div>
                </div>
</asp:Content>
