<%@ Page Title="" Language="C#" MasterPageFile="~/student/student_menu.Master" AutoEventWireup="true" CodeBehind="stud_issue_entry.aspx.cs" Inherits="Library_Management_System.student.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
          <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

   
    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                          <center>
                            <strong class="card-title">Book Issue Entry</strong>
                          </center>
                        </div>
                        <div class="card-header">
                             <form runat="server">
                                   
                                <center>
                                 <asp:TextBox ID="TextBox2"  runat="server" class="card-title" placeholder="  Search.."  style="border-radius:15px;height: 40px;width:300px;padding:0px 5px;"  AutoPostBack="True" OnTextChanged="Button1_Click" ></asp:TextBox>
                                 <asp:Button ID="Button1" runat="server" Text="Search" style="padding:5px 10px;border-radius:10px;" OnClick="Button1_Click" />
                                </center> 
                             </form>
                            
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         <tr style="background:#4352ff;color:white;">
                                            
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
