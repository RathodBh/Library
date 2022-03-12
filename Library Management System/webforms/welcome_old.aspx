<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome_old.aspx.cs" Inherits="Library_Management_System.webforms.welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/welcome_page.css" />
    
</head>
<body onload="load_gif()">
    
    <form id="form1" runat="server">
        <div id="loading"></div>
        <div class="a1"></div>   
        <div class="b1">
            <div class="in1">
                <div class="content">
                    <h3>welcome to</h3>
                    <h1>Library Management System</h1><br />
                    <h3>Created By Rathod Bhavesh</h3><br /><br /><br />
                   
                    <asp:Button ID="Button1" class="btn success" runat="server" Text="GET STARTED" onclick="button1_Click" />
                    
                </div>
            </div>
            
        </div>

    </form>
    <script type="text/javascript">
        var preloader = document.getElementById('loading');

        function load_gif() {
            preloader.style.display = "none";
        }
    </script>
</body>

</html>

