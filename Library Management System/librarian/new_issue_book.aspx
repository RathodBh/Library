<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="new_issue_book.aspx.cs" Inherits="Library_Management_System.librarian.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
   
  <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

<div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Book Issue</strong>
            </div>
            <div class="card-body">
                <div id="pay-invoice">
                    <div class="card-body">
                        
                    <!-- sweet Alert -->
                        <script src="../sweetAlert/jquery.min.js" type="text/javascript"></script>
                        <script src="../sweetAlert/popper.min.js" type="text/javascript"></script>
                        <script src="../sweetAlert/sweetalert.min.js" type="text/javascript"></script>

                        <script type="text/javascript" src="../js/functions.js"></script>
    
                        <form id="f1" runat="server">
                              
                            <div class="form-group">
                         
                                <center>
                                <label for="" class="control-label mb-1">Select User Type </label><br />
                                <asp:DropDownList ID="d_type"  AutoPostBack="True" runat="server" CssClass="form-control" OnSelectedIndexChanged="d_type_SelectedIndexChanged"  >
                                    
                                    <asp:ListItem Text="Student" Value="Student">Student</asp:ListItem>
                                    <asp:ListItem Text="Teacher" Value="Teacher">Teacher</asp:ListItem>
                                </asp:DropDownList>
                                </center>
                            
                            
                            </div>
                            <asp:Panel ID="p_stud" runat="server" Visible="true">
                                <div class="form-group">
                                    <asp:Label ID="l_eno" runat="server" Text="Select Enrollment Number" class="control-label mb-1"></asp:Label>
                                    <asp:DropDownList ID="d_eno" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="eno" DataValueField="eno"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [eno] FROM [stud_reg]"></asp:SqlDataSource>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="p_teacher" runat="server" Visible="false">
                                 <div class="form-group">
                                    <asp:Label ID="l_tid" runat="server" Text="Select Teacher ID" class="control-label mb-1"></asp:Label>
                                    <asp:DropDownList ID="d_tid" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="tid" DataTextField="tid" DataValueField="tid"></asp:DropDownList>
                                    <asp:SqlDataSource ID="tid" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [tid] FROM [teacher_reg]"></asp:SqlDataSource>
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="p_book" runat="server" Visible="true">
                                 <div class="form-group">
                                    <label for="" class="control-label mb-1">Books ISBN</label>
                                    <asp:DropDownList ID="d_book_isbn" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="isbn" DataTextField="isbn" DataValueField="isbn" OnSelectedIndexChanged="d_book_isbn_SelectedIndexChanged" >
                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:SqlDataSource ID="isbn" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [isbn] FROM [book_info]"></asp:SqlDataSource>
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="p_book_details" runat="server">
                            <div class="form-group" >
                                <center>
                                <asp:Image ID="img_book" runat="server" Height="150" Width="150" Visible="False" /><br />
                                <asp:Label ID="l_books_name"  runat="server" ></asp:Label><br />
                                <asp:Label ID="l_stock_book"  runat="server"></asp:Label><br />
                                </center>
                            </div>
                            </asp:Panel>
                            
                            <div id="msg" runat="server" class="alert alert-danger"
                                style="margin-top:10px; display:none;">
                                <strong>Book issued successfully...!</strong>
                            </div>
                         
                            <div>

                                <asp:Button ID="btn_issueBook" runat="server" Text="Issue Books"
                                    class="btn btn-lg btn-info btn-block" OnClick="btn_issueBook_Click"  />
                            </div>
                            
                        </form>
                    </div>
                </div>

            </div>
        </div>

</asp:Content>
