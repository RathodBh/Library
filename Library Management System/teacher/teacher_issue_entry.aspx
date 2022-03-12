<%@ Page Title="" Language="C#" MasterPageFile="~/teacher/teacher_menu.Master" AutoEventWireup="true" CodeFile="teacher_issue_entry.aspx.cs" Inherits="Library_Management_System.teacher.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
           <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Issue Entry</strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="rp1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                           <tr style="background:orange;color:white;">
                                            
                                            <th scope="col">Isuue</th>
                                            <th scope="col">Book Title</th>
                                            <th scope="col">Author Name</th>
                                            <th scope="col">ISBN Number</th>
                                            <th scope="col">Available Quentity</th>
                                            <th scope="col">Language</th>
                                            <th scope="col">Total Pages</th>
                                           
                                         </tr>
                                     
                                        <tbody>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <tr>
                                        <td><a id="ac" href="../webforms/issue_entry.aspx?id=<%#Eval("id") %>">Issue</a></td>
                                        <td><%#Eval("bnm") %></td>
                                        <td><%#Eval("bauthor") %></td>
                                        <td><%#Eval("isbn") %></td>
                                        <td><%#Eval("qty") %></td>
                                        <td><%#Eval("lang") %></td>
                                        <td><%#Eval("pg") %></td>
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
