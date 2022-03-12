<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact_us.aspx.cs" Inherits="Library_Management_System.webforms.contact_us" %>

<!DOCTYPE html>
<html>

<head>
     <link rel="shortcut icon" href="img/favicon.ico" />
  
    <link rel="stylesheet" type="text/css" href="../css/about.css">
    <link rel="stylesheet" type="text/css" href="../css/contact.css">
    <link rel="stylesheet" href="../librarian/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../librarian/assets/css/bootstrap.min.css" />

    <!-- sweet Alert -->
    <script src="../sweetAlert/jquery.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/popper.min.js" type="text/javascript"></script>
    <script src="../sweetAlert/sweetalert.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/functions.js"></script>

    
    <!-- back button css and javascript -->
    <style>
        .back{
            background:transparent;border:none;position:absolute; left:3%; top:5%;
        }
        .back_i{
            font-size:40px;color:white;background:transparent;
        }
        .back:hover{

            border-radius:50%;
        }
        .back_i:hover{
            color: grey;
        }
    </style>
    <script> function back_click(){ history.go(-1); }</script>
</head>

<body>
    <div class="about-section" style="background: #e8f09f;">
         <button class="back" onclick="back_click()"><i class="fa fa-arrow-circle-left back_i"></i></button>

        <h1 id="main_title">CONTACT US</h1>
        <img src="img/logo.png" id="logo">
        <p id="lms">Library Management System</p>
        <div class="wrapper">
            <ul class="text">
                <li><span>.....WELCOME.....</span></li>
                <li><span>CREATED BY...</span></li>
                <li><span>Rathod Bhavesh...</span></li>
                <li><span>Email: LMS.by.bh@gmail.com. </span></li>
            </ul>
        </div>
    </div>

    <div class="main">
        <div class="sub">
            <div class="part1">
                <iframe
                    src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3687.8144182984097!2d72.58947161453342!3d22.436009785253237!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395efdecb2050d8d%3A0xd0ee62250eae3a12!2sSwaminarayan%20Temple!5e0!3m2!1sen!2sin!4v1615897211977!5m2!1sen!2sin"
                    id="map1" style="border: 0;" allowfullscreen="no" loading="lazy"></iframe>
            </div>
            <div class="part2">
                <center>
        <h2>GET IN TOUCH</h2>
     <br>
          <form runat="server">
              <asp:TextBox ID="TextBox1" class="i1" runat="server" placeholder="Name"></asp:TextBox><br>
              <asp:TextBox ID="TextBox2" class="i1" placeholder="Email" runat="server" ></asp:TextBox> <br> 
              <asp:TextBox ID="TextBox3" class="i1" placeholder="Contact No" runat="server"></asp:TextBox> <br>
              <asp:TextBox ID="TextBox4"  style="height:60px;" class="i1" placeholder="Message" runat="server"></asp:TextBox>
              <br /><br>        
     
                <asp:Button ID="b1" runat="server" Text="SUBMIT" OnClick="b1_Click"></asp:Button>
                  
              
         </form>
          </center>
            </div>
        </div>
    </div>

    <br>
    <br>
    <br>

    <h2 style="text-align: center">Contact Me</h2>
    <br>
    <br>
    <div class="row" style="background: grey; display: flex;height:100vh; align-items: center;justify-content:center;">
       

            <div class="card" style="background: white;height:auto;width:60vw; ">

                <div class="container c1" style="height:auto;">
                    <center>
                <br>
               <p class="title">Created by :</p>
               <h2>Rathod Bhavesh</h2>
         
           <br><br />
          <p><b>Contact:</b> +91 7600636383</p>
          <p><b>Email:</b> LMS.by.bh@gmail.com</p><br /><br />
          
              <p style="color:#FC6D6D;"><b>Social Media</b></p><hr style="width:25vw;"><br><br />
              
             
                  <a class="icons" href="http://api.whatsapp.com/send?phone=+917600636383&text=welcome..."><i class="fa fa-whatsapp"></i></a>
                  <a class="icons" href="https://www.instagram.com/bh007_rathod"><i class="fa fa-instagram"></i></a>
                  <a class="icons" href="https://twitter.com/Bh_rathod007?s=08"><i class="fa fa-twitter"></i></a>
                  <a class="icons icon4" href="https://www.facebook.com/bhaveshsinh.rathod.1"><i class="fa fa-facebook"></i></a>
              <div style="display:block;height:100px;padding:100px;"></div>
          </center>


                </div>
            </div>


        </div>


    </div>

</body>

</html>
