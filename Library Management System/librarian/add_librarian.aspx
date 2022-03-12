<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="add_librarian.aspx.cs" Inherits="Library_Management_System.librarian.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
 <!-- sweet Alert -->
    <script src="../sweetAlert/jquery.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/popper.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/sweetalert.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/functions.js"></script>

    <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Add New Librarian</strong>
            </div>
            <div class="card-body">
                <div id="pay-invoice">
                    <div class="card-body">
                      
                           <%-- 
                               <div id="msg" runat="server" class="alert alert-success"
                                style="margin-top:10px; display: none;">
                                <strong>Your books added successfully...!</strong>
                            </div>
                              <div id="msg2" runat="server" class="alert alert-danger"
                                style="margin-top:10px; display: none;">
                                <strong>Please Enter all the details...!</strong>
                            </div>
                            <div id="msg3" runat="server" class="alert alert-success"
                                style="margin-top:10px; display: none;">
                                <strong>Files is not uploaded..!</strong>
                            </div>
                               --%>
                        <form action="" method="post" novalidate="novalidate" id="f1" runat="server">
                             
    
                            <div class="form-group">
                                <label for="" class="control-label mb-1">Name</label>
                                <asp:TextBox ID="txt_lnm" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Email ID</label>
                                <asp:TextBox ID="txt_email" type="email" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Password</label>
                                <asp:TextBox ID="txt_pwd" type="password" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Phone Number</label>
                                <asp:TextBox ID="txt_ph" runat="server" class="form-control"></asp:TextBox>
                            </div>

                           

                            <div>

                                <asp:Button ID="btn_add" runat="server" Text="Add New Librarian"
                                    class="btn btn-lg btn-info btn-block" OnClick="btn_add_Click" />
                            </div>
                          
                            
                        </form>
                    </div>
                </div>
                

            </div>
        </div>

</asp:Content>
