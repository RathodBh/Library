<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Library_Management_System.librarian.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
 
      <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Contacts/ Feedback</strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table border" id="example" style="background:brown;color:white;">
                                        <thead>         
                                         <tr >
                                            <th scope="col">Name</th>
                                            <th scope="col">Email</th>
                                            <th scope="col">Contact</th>
                                            <th scope="col">Message</th>
                                         </tr>
                                     
                                        <tbody>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <tr>                 
                                       <td><%#Eval("Name") %></td>
                                        <td><%#Eval("Email") %></th>
                                        <td><%#Eval("phno") %></td>
                                        <td><%#Eval("msg") %></td>
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

     <script type="text/javascript">
        $(document).ready(function() {
            $('#example').DataTable({ "pagingType": "full_numbers" });
        } );
     </script>
</asp:Content>
