<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="display_all_books.aspx.cs" Inherits="Library_Management_System.librarian.display_all_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    
      <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <style>
         @media screen and (max-width:400px){
            .a{
                width:100vw;
                overflow:auto;
            }
         }
     </style>
    <div class="col-lg-12 a">
                    <div class="card">
                        <div class="card-header">
                            <center>
                                <strong class="card-title">All Books</strong>
                            </center>
                        </div>
                         <div class="card-header">
                             <form runat="server">
                                <center>
                                 <asp:TextBox ID="TextBox2"  runat="server" class="card-title" placeholder="  Search.."  style="border-radius:15px;height: 40px;width:300px;padding:0px 5px;"  AutoPostBack="True" OnTextChanged="Button1_Click" ></asp:TextBox>
                                 <asp:Button ID="Button1" runat="server" Text="Search" style="padding:5px 10px;border-radius:10px;" OnClick="Button1_Click" />
                                    <br><asp:Label runat="server" Text="" id="Label1"></asp:Label>
                                </center> 
                             </form>
                            
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table class="table border" id="example">
                                        <thead>         
                                         <tr style="background:blue;color:white;">
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
                                        <td><%#checkvideo(Eval("vdo"),Eval("id")) %></td>
                                        <td><%#Eval("bauthor") %></th>
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

