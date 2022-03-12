<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about_us.aspx.cs" Inherits="Library_Management_System.webforms.about_us" %>

<!DOCTYPE html>
<html>

<head runat="server">
  <link rel="stylesheet" type="text/css" href="../css/about.css">
    <link rel="shortcut icon" href="img/favicon.ico" />
  <link rel="stylesheet" href="../librarian/assets/css/font-awesome.min.css" />

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
  <div class="about-section">

      <button class="back" onclick="back_click()"><i class="fa fa-arrow-circle-left back_i"></i></button>

    <h1 id="main_title">About Us </h1>
    <img src="img/logo.png" id="logo">
    <p id="lms">Library Management System</p>
    <div class="wrapper">
      <ul class="text">
        <li><span>There is no friend as loyal as a book...</span></li>
        <li><span>A room without books is like a body without soul...</span></li>
        <li><span>I guess there are never enough books... </span></li>
        <li><span>Reading brings us unknown friends...</span></li>

      </ul>
    </div>
  </div>

  <div class="main_about">
    <h3>About</h3>
    <div class="sub_about">
      <p class="about_p">The library management system is software which fulfills all the needs of the librarian to
        complete the task of library easily.</p>
      <hr>
      <p class="about_p">The main purpose of the Library Management System to enhance collage library from manual to
        automated system.
        This is software that uses to maintain the record of library. This system will increase your library’s
        efficiency, save valuable time, lead to better educational experience for students.</p>
      <hr>
      <p class="about_p">It mainly focuses on basic operations in a library like adding new student, new teacher, and
        new books, updating new book information, searching books and members and facility to borrow and return books.
      </p>
      <hr>
      <p class="about_p"> This project provides remainder for students and simple chat between student and librarian.
      </p>
    </div>
  </div>

  <h2 style="text-align:center;color:black;font-size: 26px;">About Me</h2>
  
  <div class="row">
    <div class="column">
      
        <div class="card">
         <!-- <centre><img src="img/my_pic.jpg" alt="BH" class="my_pic" ></centre> -->
          
          <div class="container">
              
            <p class="title">: Created by :</p>
            <h2>RATHOD BHAVESH</h2>
            
            
            <p style="font-size:15px;">For more information click on Contact</p>
              <form runat="server">
                      <p> <asp:Button class="button" ID="Button1" runat="server" Text="Contact Me" OnClick="Button1_Click"/></p>
            
              </form>
           
          </div>
        </div>
      

    </div>


  </div>

</body>

</html>