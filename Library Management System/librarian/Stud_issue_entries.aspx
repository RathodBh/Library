<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="Stud_issue_entries.aspx.cs" Inherits="Library_Management_System.librarian.Stud_issu_entries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

      <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Book Issuing Entries of Students</strong><br>
                             <form runat="server">

                             
                            <center> 
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br>
                                </center>
                                 </form>
                        </div>
                        <div class="card-body" style="overflow-x:auto;">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         <tr style="background:green;color:white;">
                                            
                                            <th scope="col">Issue</th>
                                            <th scope="col">Book Title</th>
                                            <th scope="col">ISBN Number</th>
                                            <th scope="col">name</th>
                                            <th scope="col">eno</th>
                                           
                                           
                                         </tr>
                                     
                                        <tbody>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <tr>
                                        <td><a id="ac" href="issue_entry.aspx?id=<%#Eval("id") %>">Done</a></td>
                                        <td><%#Eval("bnm") %></td>
                                        
                                        <td><%#Eval("isbn") %></td>
                                        <td><%#Eval("name") %></td>
                                        <td><%#Eval("eno") %></td>
                                        
                                    </tr>
                                   
                                </ItemTemplate>


                                <FooterTemplate> 
                                </thead>
                                    </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                           <center> <asp:Label ID="Label2" runat="server" Text=""></asp:Label> </center>
                        </div>
                    </div>
                </div>

</asp:Content>
