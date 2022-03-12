<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="Edit_page.aspx.cs" Inherits="Library_Management_System.librarian.WebForm12" %>
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
                <strong class="card-title">Edit Books</strong>
            </div>
            <div class="card-body">
                <div id="pay-invoice">
                    <div class="card-body">
                            <div id="msg" runat="server" class="alert alert-success"
                                style="margin-top:10px; display: none;">
                                <strong>Your books Updated successfully...!</strong>
                            </div>
                              <div id="msg2" runat="server" class="alert alert-danger"
                                style="margin-top:10px; display: none;">
                                <strong>Please Enter all the details...!</strong>
                            </div>
                            <div id="msg3" runat="server" class="alert alert-success"
                                style="margin-top:10px; display: none;">
                                <strong>Files is not uploaded..!</strong>
                            </div>
                        <form  method="post" novalidate="novalidate" id="f1" runat="server">

                            <div class="form-group">
                                
                                <label for="" class="control-label mb-1">Books Title</label>
                                <asp:TextBox ID="t_bnm" runat="server" class="form-control"></asp:TextBox>
                                <asp:TextBox ID="txt_bookstitle" runat="server" class="form-control"></asp:TextBox>
                               
                            </div>

                            <div class="form-group">
                                 
                                <label for="" class="control-label mb-1">Book's Author Name</label>
                                <asp:TextBox ID="t_author" runat="server" class="form-control"></asp:TextBox>
                                <asp:TextBox ID="txt_author" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books ISBN Number</label>
                                <asp:TextBox ID="txt_isbn" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books Quentity</label>
                                <asp:TextBox ID="t_qty" runat="server" class="form-control"></asp:TextBox>
                                <asp:TextBox ID="txt_qty" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Language</label>
                                <asp:TextBox ID="t_lang" runat="server" class="form-control"></asp:TextBox>
                                <asp:TextBox ID="txt_lang" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Total Pages</label>
                                <asp:TextBox ID="t_pg" runat="server" class="form-control"></asp:TextBox>
                                <asp:TextBox ID="txt_pg" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Price</label>
                                <asp:TextBox ID="t_price" runat="server" class="form-control"></asp:TextBox>
                                <asp:TextBox ID="txt_price" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Place</label>
                                <asp:TextBox ID="t_place" runat="server" class="form-control"></asp:TextBox>
                                <asp:TextBox ID="txt_place" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books Image</label>
                                <asp:TextBox ID="txt_img" runat="server" class="form-control"></asp:TextBox>
                                <asp:FileUpload ID="fu_img" runat="server" class="form-control" />
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books PDF</label>
                                <asp:TextBox ID="txt_pdf" runat="server" class="form-control"></asp:TextBox>
                                <asp:FileUpload ID="fu_pdf" runat="server" class="form-control" />
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books Video</label>
                                <asp:TextBox ID="txt_vdo" runat="server" class="form-control"></asp:TextBox>
                                <asp:FileUpload ID="fu_vdo" runat="server" class="form-control" />
                            </div>


                            <div>
                                <asp:Button ID="btn_update" runat="server" Text="Update"
                                    class="btn btn-lg btn-info btn-block" OnClick="btn_update_Click"  />
                            </div>

                        </form>
                    </div>
                </div>

            </div>
        </div>
</asp:Content>
