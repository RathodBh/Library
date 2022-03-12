<%@ Page Title="" Language="C#" MasterPageFile="~/teacher/teacher_menu.Master" AutoEventWireup="true" CodeBehind="teacher_disp_book.aspx.cs" Inherits="Library_Management_System.teacher.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <link rel="stylesheet" href="../css/table.css" type="text/css" />
         <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />
    
    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">All Books</strong>
                        </div>
                        <div class="card-header">
                             <form runat="server">
                                <center>
                                 <asp:TextBox ID="TextBox2"  runat="server" class="card-title" placeholder="  Search.."  style="border-radius:15px;height: 40px;width:300px;padding:0px 5px;"  AutoPostBack="True" OnTextChanged="Button1_Click" ></asp:TextBox>
                                 <asp:Button ID="Button1" runat="server" Text="Search" style="padding:5px 10px;border-radius:10px;" OnClick="Button1_Click" />
                                    <br><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </center> 
                             </form>
                            
                        </div>
                        <div class="card-body">
                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>         
                                         <tr style="background:green;color:white;">
                                            <th scope="col">Books Image</th>
                                            <th scope="col">Book Title</th>
                                            <th scope="col">Books PDF</th>
                                            <th scope="col">Books Video</th>
                                            <th scope="col">Author Name</th>
                                            <th scope="col">ISBN Number</th>
                                            <th scope="col">Available Quentity</th>
                                            <th scope="col">Language</th>
                                            <th scope="col">Total Pages</th>
                                            <th scope="col">Price</th>
                                            <th scope="col">Place</th>
                                         </tr>
                                     
                                        <tbody>
                                </HeaderTemplate>


                                <ItemTemplate>
                                    <tr>
                                        <td><%#checkimg(Eval("bimg"),Eval("id") ) %></td>
                                        <td><%#Eval("bnm") %></td>
                                        <td> <%#checkpdf(Eval("pdf"),Eval("id")) %></td>
                                        <td> <%#checkvideo(Eval("vdo"),Eval("id")) %></td>
                                        <td><%#Eval("bauthor") %></td>
                                        <td><%#Eval("isbn") %></td>
                                        <td><%#Eval("qty") %></td>
                                        <td><%#Eval("lang") %></td>
                                        <td><%#Eval("pg") %></th>
                                        <td><%#Eval("price") %></td>
                                        <td><%#Eval("place") %></td>
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
