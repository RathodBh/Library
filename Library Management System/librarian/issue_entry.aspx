<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="issue_entry.aspx.cs" Inherits="Library_Management_System.librarian.issue_entry" %>



  <!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>LMS</title>

        
<!-- sweet Alert -->
    <script src="../sweetAlert/jquery.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/popper.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/sweetalert.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/functions.js"></script>
    <link rel="shortcut icon" href="../webforms/img/favicon.ico" />
  
  <!-- Responsive  -->
    <link rel="stylesheet" href="../css/tab.css" />
    <link rel="stylesheet" href="../css/phone.css" />

</head>

<body>
    <form runat="server">
    <div class="main">
        <h2>:: ADMIN ::</h2><br>
        <h1>LIBRARY MANAGEMENT SYSTEM</h1>
        <br>
          <asp:Button ID="btn" runat="server" Text="BACK" OnClick="btn_Click" />
        
    </div>
    </form>
</body>
<style>
    h1{
        color:brown;
    }
    h2{
        color:goldenrod;
    }
    body{
        height:100vh;
        background: linear-gradient(to bottom,#0f0c29, #302b63,#24243e);
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .main{
        height: 60vh;
        width:60vw;
        background-color: #fff;
        display: flex;
        align-items: center;
        justify-content: center;
        flex-direction: column;
        border-radius: 5%;
       
    }
    #btn{
        padding:15px 35px;
        background-color: #fff;
        color: green;
        border: 5px solid green;
        border-radius: 13%;
    }
    #btn:hover{
        border:1px solid rgb(241, 241, 241) ;
        background-color: green;
        color:#fff;
        font-weight: 700;
        cursor: pointer;
    }
</style>
</html>

