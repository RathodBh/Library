<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="penalty.aspx.cs" Inherits="Library_Management_System.librarian.penalty" %>

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
                <strong class="card-title">Add or Edit Penalty</strong>
            </div>
            <div class="card-body">
                <div id="pay-invoice">
                    <div class="card-body">

                        <form action="" method="post" novalidate="novalidate" id="f1" runat="server">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Penalty</label>
                                <br>
                                <asp:TextBox ID="old" runat="server" class="form-control" ReadOnly></asp:TextBox>
                                <asp:TextBox ID="txt_penalty" placeholder="Enter new penalty" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div>

                                <asp:Button ID="btn_add" runat="server" Text="OK"
                                    class="btn btn-lg btn-info btn-block" OnClick="btn_add_Click"  />
                            </div>
                            <div id="msg" runat="server" class="alert alert-danger"
                                style="margin-top:10px; display: none;">
                                <strong>Your penalty is added/updated...!</strong>
                            </div>
                        </form>
                    </div>
                </div>

            </div>
        </div>


</asp:Content>
