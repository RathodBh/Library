<%@ Page Title="" Language="C#" MasterPageFile="~/student/student_menu.Master" AutoEventWireup="true" CodeBehind="stud_returned_books.aspx.cs" Inherits="Library_Management_System.student.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
     <link rel="stylesheet" href="../css/table.css" type="text/css" />
          <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />
    
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Returned Books</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid card-body" style="min-height:500px; background-color:white;">
        <asp:Repeater ID="r1" runat="server">
            <HeaderTemplate>
                <table class="table " style="color:white;background:black;">
                    <tr>

                        <th>ISBN Number</th>
                        <th>Book Name</th>
                        <th>Issued Date</th>
                        <th>Returned Date</th>
                      
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>

                    <td><%#Eval("isbn") %></td>
                    <td><%#Eval("bnm") %></td>
                    <td><%#Eval("issue_date") %></td>
                    <td><%#Eval("return_date") %></td>
                    
                </tr>
            </ItemTemplate>
         
            <FooterTemplate>
                </table>
                
            </FooterTemplate>
        </asp:Repeater>
        <center><asp:Label ID="Label1" runat="server" Text=""></asp:Label></center>
        
    </div>
</asp:Content>

