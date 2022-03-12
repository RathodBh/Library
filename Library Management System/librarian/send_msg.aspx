<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="send_msg.aspx.cs" Inherits="Library_Management_System.librarian.send_msg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
 
     <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Send Message</strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         <tr style="background:blueviolet;color:white;">
                                             <th>Message</th>
                                             <th>Image</th>
                                             <th>Name</th>
                                             <th>Enrollment number</th>
                                             <th>Email</th>
                                             <th>Phone Number</th>
                                             <th>Stream</th>
                                             <th>Sem</th>
                                             <th>Status</th>
                                             
                                             
                                         </tr>
                                     
           <tbody>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td ><a id="ac" href="communication.aspx?username=<%#Eval("snm") %>">Message</a></td>
                <td><center><%#checkimg(Eval("simg"),Eval("id") ) %></center></td>
                <td><%#Eval("snm") %></td>
                <td><%#Eval("eno") %></td>
                <td><%#Eval("email") %></td>
                <td><%#Eval("ph") %></td>
                <td><%#Eval("stream") %></td>
                <td><%#Eval("sem") %></td>
                <td><%#Eval("approved") %></td>
                
                 </tr>
        </ItemTemplate>

        <FooterTemplate>
            </thead>
                 </tbody>
            </table
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
