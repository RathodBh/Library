<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="teacher_issue_entries.aspx.cs" Inherits="Library_Management_System.librarian.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

      <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Book Issuing Entries for Student</strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         <tr style="background:green;">
                                            
                                            <th scope="col">Issue</th>
                                            <th scope="col">Book Title</th>
                                            <th scope="col">ISBN Number</th>
                                            <th scope="col">name</th>
                                            <th scope="col">Teacher ID</th>
                                           
                                           
                                         </tr>
                                     
                                        <tbody>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <tr>
                                        <td><a id="ac" href="issue_entry_teacher.aspx?id=<%#Eval("id") %>">Done</a></td>
                                        <td><%#Eval("bnm") %></td>
                                        <td><%#Eval("isbn") %></td>
                                        <td><%#Eval("name") %></td>
                                        <td><%#Eval("tid") %></td>
                                        
                                    </tr>
                                   
                                </ItemTemplate>


                                <FooterTemplate> 
                                </thead>
                                    </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                </div>
</asp:Content>
