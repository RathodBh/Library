<%@ Page Title="" Language="C#" MasterPageFile="~/teacher/teacher_menu.Master" AutoEventWireup="true" CodeBehind="teacher_lost_book.aspx.cs" Inherits="Library_Management_System.teacher.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
 <link rel="stylesheet" href="../css/table.css" type="text/css" />
    
          <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Lost books</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid card-body" style="min-height:500px; background-color:white;">
        <asp:DataList ID="dl1" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered" >
                      <tr style="background:orange;color:white;">
                        <th>Lost</th>
                        <th>ISBN Number</th>
                        <th>Book Name</th>
                        <th>Price</th>
                        <th>Issued Date</th>
                        <th>Approx Return Date</th>
                        <th>Name</th>
                        <th>Is Return?</th>
                        <th>Returned Date</th>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td ><a href="../webforms/lost.aspx?id=<%#Eval("id") %> &price=<%#Eval("price") %>" id="da">LOST</a></td>
                    <td><%#Eval("isbn") %></td>
                    <td><%#Eval("bnm") %></td>
                    <td><%#Eval("price") %></td>
                    <td><%#Eval("issue_date") %></td>
                    <td><%#Eval("approx_return_date") %></td>
                    <td><%#Eval("name") %></td>
                    <td><%#Eval("is_return") %></td>
                    <td><%#Eval("return_date") %></td>
                    
                </tr>
            </ItemTemplate>
         
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>
</asp:Content>
