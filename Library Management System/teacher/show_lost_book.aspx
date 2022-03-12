<%@ Page Title="" Language="C#" MasterPageFile="~/teacher/teacher_menu.Master" AutoEventWireup="true" CodeBehind="show_lost_book.aspx.cs" Inherits="Library_Management_System.teacher.WebForm5" %>
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
                <table class="table table-bordered" id="table1">
                      <tr style="background:green;color:white;">
                        <th>ISBN Number</th>
                        <th>Book Name</th>
                        <th>Price</th>
                        <th>Date</th>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>

                    <td><%#Eval("isbn") %></td>
                    <td><%#Eval("bnm") %></td>
                    <td><%#Eval("price") %></td>
                    <td><%#Eval("dt") %></td>

                    
                </tr>
            </ItemTemplate>
         
            <FooterTemplate>
                </table>
              
            </FooterTemplate>
        </asp:DataList>
    </div>
      <asp:Label ID="Label1" runat="server" Text="" ForeColor="Black"></asp:Label>
</asp:Content>
