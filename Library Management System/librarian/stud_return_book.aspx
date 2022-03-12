<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="stud_return_book.aspx.cs" Inherits="Library_Management_System.librarian.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
 <link rel="stylesheet" href="../css/table.css" type="text/css" />
  
    <script src="https://code.jquery.com/jquery-3.5.1.js" ></script>
    
      <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="breadcrumbs">
        <div class="col-lg-12">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Student's Return Books</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid card-body" style=" background-color:white;">
        <asp:DataList ID="dl1" runat="server">
            <HeaderTemplate>
                <table class="table" style="width:100%">
                    <thead>

                 
                    <tr style="color:white;background:green;">
                         <th>Return Book</th>
                        <th>Enrollment Number</th>
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
                           </thead>
                    
            </HeaderTemplate>
            <ItemTemplate>
                <tbody >
                <tr>
                    <td><a id="da" href="returnBook.aspx?id=<%#Eval("id") %>">Done</a></td>
                    <td><%#Eval("eno") %></td>
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
                 </tbody>
            </ItemTemplate>
         
            <FooterTemplate>
               
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable();
        });
    </script>
</asp:Content>
