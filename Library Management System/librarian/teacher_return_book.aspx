<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="teacher_return_book.aspx.cs" Inherits="Library_Management_System.librarian.teacher_return_book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
     <link rel="stylesheet" href="../css/table.css" type="text/css" />
    
      <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Teacher's Return books</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid card-body" style="min-height:500px; background-color:white;">
        <asp:DataList ID="dl1" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered" id="table1">
                    <tr style="background:orange;color:white;">
                        <th>Return Book</th>
                        <th>Teacher ID</th>
                        <th>ISBN Number</th>
                        <th>Book Name</th>
                        <th>Issued Date</th>
                        <th>Approx Return Date</th>
                        <th>Name</th>
                        <th>Is Return?</th>
                        <th>Returned Date</th>
                        <th>Latedays</th>
                        <th>Penalty</th>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background:white;">
                     <td  id="da"><a style="color:white;" href="returnBook.aspx?id=<%#Eval("id") %>">Done</a></td>
                    <td><%#Eval("tid") %></td>
                    <td><%#Eval("isbn") %></td>
                    <td><%#Eval("bnm") %></td>
                    <td><%#Eval("issue_date") %></td>
                    <td><%#Eval("approx_return_date") %></td>
                    <td><%#Eval("name") %></td>
                    <td><%#Eval("is_return") %></td>
                    <td><%#Eval("return_date") %></td>
                    <td><%#Eval("latedays") %></td>
                    <td><%#Eval("penalty") %></td>
                   
                </tr>
            </ItemTemplate>
         
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>
</asp:Content>
