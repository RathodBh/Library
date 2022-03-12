<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dp.aspx.cs" Inherits="Library_Management_System.webforms.update.dp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="../img/favicon.ico" />
  
    <style>
        .btn{
            width:100px;
            background:blue;
            color:white;
        }
        .btn:hover{
            background:green;
        }
        
        .input{
            border-radius:15px;
            border:2px solid black;
        }
        .input:focus{
            border:2px solid orange;
            
        }
        
    </style>
                    <!-- sweet Alert -->
    <script src="../../sweetAlert/jquery.min.js" type="text/javascript"></script>
    <script src="../../sweetAlert/popper.min.js" type="text/javascript"></script>
    <script src="../../sweetAlert/sweetalert.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../js/functions.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
      
    <div style="display:grid;height:100vh;place-items:center;background:url('../img/book2.png') no-repeat;background-size:cover ;">
        <div style="height:80vh;width:80vw;background:rgba(255, 216, 0,0.7);border-radius:15px;">
            <center>
                <br><br>
                 <asp:Repeater ID="r1" runat="server">
                   <HeaderTemplate>
                                    <table class="table">
                                        <thead>    
                                        <tbody>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <tr>
                                        
                                        <td><center><%#checkimg(Eval("simg"),Eval("id") ) %></center></td>
                                    </tr>
                                    
                                   
                                </ItemTemplate>


                                <FooterTemplate> 
                                </thead>
                                    </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                <asp:Repeater ID="r2" runat="server">
                   <HeaderTemplate>
                                    <table class="table">
                                        <thead>    
                                        <tbody>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <tr>
                                        
                                        <td><center><%#checkimg(Eval("timg"),Eval("id") ) %></center></td>
                                    </tr>
                                    
                                   
                                </ItemTemplate>


                                <FooterTemplate> 
                                </thead>
                                    </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                <br><br>
                <h3>UPDATE PROFILE PICTURE</h3>
                <br><br>
                <asp:FileUpload ID="FileUpload1" runat="server" style="border:1px solid blue;" OnLoad="Page_Load" OnDisposed="Page_Load"></asp:FileUpload>
                <br><br>
                <asp:Button ID="btn" runat="server" class="btn" Text="Update"  OnClick="btn_Click" ></asp:Button>
            &nbsp;&nbsp;<asp:Button class="btn" ID="reset" runat="server" Text="Remove" OnClick="reset_Click" ></asp:Button><br><br>
                <asp:Button ID="back" runat="server" class="btn" Text="BACK" style="width:220px;background: orange;color:black;cursor:pointer;" OnClick="back_Click" />
            </center>
        </div>
    </div>
    </form>
</body>
</html>