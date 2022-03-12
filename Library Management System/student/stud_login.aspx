<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stud_login.aspx.cs" Inherits="Library_Management_System.student.stud_login" %>

<!doctype html>
<html>

<head runat="server">
    <title> Login or Student Registration</title>
     
    <link rel="shortcut icon" href="../webforms/img/favicon.ico" />
  

    <link rel="stylesheet" type="text/css" media="screen" href="../css/login.css" />
    <link rel="stylesheet" href="../css/pic_upload_popup.css" />
    <link rel="stylesheet" href="../librarian/assets/css/font-awesome.min.css" />

   <%--<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>--%>
    
    <!--sweetAlert Javascript-->
    <script src="../sweetAlert/jquery.min.js" type="text/javascript"></script>
	<script src="../sweetAlert/popper.min.js" type="text/javascript"></script>
	<script src="../sweetAlert/sweetalert.min.js" type="text/javascript"></script>
   
    <script type="text/javascript" src="../js/functions.js"></script>

</head>

<body onload="load_gif()">
    <div id="loading"></div>
  
    <form id="Form1" runat="server" name="f1" >
      
        <div class="main">
   
            <input type="checkbox" id="chk" name="chk" />
    
            <div class="login">
              <label id="l1"> Login </label>
                <asp:TextBox ID="log_email" runat="server" type="email" name="email" placeholder="Email"  class="input" ></asp:TextBox>
                <asp:TextBox ID="log_pwd" runat="server"  type="password" name="pass" placeholder="Password"  class="input" ></asp:TextBox>
                 <p class="i_hold2" ><label for="click3"><i class="fa fa-question-circle ii" ></i> </label> </p>
                    <input type="checkbox" id="click3"  />
                
                <!-- popup for forget password -->
                <div class="main_fp">
                    <asp:Button ID="fp" runat="server"  class="button" Text="Forget Password?" style="background: transparent;" />
                    <hr />
                    <asp:TextBox ID="f_email" runat="server" type="email" name="f_email" placeholder="Email"  class="input" ></asp:TextBox>
                    <asp:TextBox ID="f_sq" runat="server" type="textbox" name="f_sq" placeholder="Answer of your Security question"  class="input" ></asp:TextBox>
                     <br />
                     <asp:TextBox ID="new_pwd" runat="server" type="email"  placeholder="Create New Password"  class="input" ></asp:TextBox>
                    <asp:TextBox ID="con_pwd" runat="server" type="textbox"  placeholder="Confirm Password"  class="input" ></asp:TextBox>
                    
                    
                    <asp:Button ID="fp_btn" runat="server"  class="button" Text="OK" OnCLick="forget_search"/><hr /><br /><br /><br />
                     <label for="click3" id="chk3" class="close-btn">Close</label>
                    
                </div>
                <!-- close popup for forget password -->

                <asp:Button ID="btn2" runat="server"  class="button" Text="Sign In" 
                   onclick="btn2_Click" />
                  
                <div id="e1" style="display:none;" runat="server">
                   
                </div>
                <span id="error_msg"></span>

            </div>
            <div class="signup">
        
                <label for="chk"  class="l1"> Sign Up</label>
                
                <center>
                    <asp:Label ID="Label1" runat="server" Text="Select Usertype:"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged" ToolTip="Select Usertype">
                        <asp:ListItem Selected="True" Text="Student">Student</asp:ListItem>
                        <asp:ListItem Text="Teacher">Teacher</asp:ListItem>
                    </asp:DropDownList>
                    <br /><br />
                    <asp:Image ID="Image1" CssClass="sl1" runat="server" ImageUrl="~/student/img/stud_logo.jpg" />
                </center>
                    
                <!-- popup for file upload-->
                <div class="center">
                    <input type="checkbox" id="click" />
                    
                    <label for="click" class="click-me">Upload Image</label>
       
                    <div class="content" >
                        <div class="header">
                              <h2>Student Image</h2>  
                        </div>

                        <br /> <br />

                        <asp:FileUpload ID="fu_student" runat="server"  BorderStyle="None" BorderColor="#3333CC" ToolTip="upload student image" CssClass="fl" />
                        <div class="line"></div>
                        <label for="click"  class="close-btn">Close</label>
                    </div>
             
                </div>
                <!-- End popup -->
              
                <!-- Student Data -->
                
                <asp:TextBox ID="ss_snm" runat="server" type="textbox" name="t_snm" placeholder="Student name" class="input" BackColor="White" ></asp:TextBox>
                <asp:TextBox ID="ss_eno" runat="server" type="textbox" name="t_eno" placeholder="Enrollment Number" class="input"></asp:TextBox>
                <asp:TextBox ID="ss_email" runat="server" type="email" name="t_email" placeholder="Email" class="input" ></asp:TextBox>
                <asp:TextBox ID="ss_phno" runat="server" type="textbox" name="t_phno" placeholder="Phone Number" class="input" ></asp:TextBox>
                <asp:TextBox ID="ss_pwd" runat="server"  type="password" name="t_pass" placeholder="Password"  class="input" ></asp:TextBox>
                
                <!-- security question popup -->
                <div class="sq_hold">  
                    <asp:TextBox ID="ss_sq" runat="server"  type="textbox" name="t_sq" placeholder="Security Question: Favourite place/ Nickname"  class="input" ></asp:TextBox>
                    <input type="checkbox" id="click2" />
                    <p class="i_hold" ><label for="click2"><i class="fa fa-question-circle ii" ></i> </label> </p>
                    <div class="pop">
                        <h1 style="color:white;">:: Security Question ::</h1>
                        <p> You can enter your nickname, favourite place, best friend name etc...</p>
                        <hr />
                        <p style="color:blueviolet;"> This answer will be use in future..</p>
                         <label for="click2" class="close-btn">Close</label>
                    </div>
                </div>
              
                <center>
                    <asp:Label ID="Label2" runat="server" Text="Stream:"></asp:Label>&nbsp;&nbsp;
                    <asp:DropDownList ID="dd_stream" runat="server" AutoPostBack="False" >
                        <asp:ListItem>BCA</asp:ListItem>
                        <asp:ListItem>Bcom</asp:ListItem>
                        <asp:ListItem>ISM</asp:ListItem>
                    </asp:DropDownList>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:Label ID="Label3" runat="server" Text="Semister:"></asp:Label>&nbsp;&nbsp;
                    <asp:DropDownList ID="dd_sem" runat="server" AutoPostBack="False" >
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                    
                         
                </center>
               
                <asp:Button ID="btn1" runat="server" class="button" Text="Sign Up" onclick="btn1_Click" />
               
                
            </div>

        </div>
      
    </form>

     <script type="text/javascript">
         var preloader = document.getElementById('loading');

         function load_gif() {
             preloader.style.display = "none";
         }
        
     </script>

     <style>
                   /* security question popup */
                  #ss_snm,#ss_eno,#ss_email,#ss_phno,#ss_pwd,#ss_sq{
                      padding: 7.2px;
                      margin: 13px auto;
                      height: 12px;
                  }
            
                  #ss_sq{
                     width: 65%;
                    border-top-right-radius: 0%;
                    border-bottom-right-radius: 0%;
                     transform: translateX(-4%);
                  }
                  .sq_hold{
                      position:relative;
                      
                  }
                  #click2{
                     display:none;
                  }
                  #click2:checked ~ .pop{
                      display:block;
                      transform: translate(10px, -300px);
                  }
                  .i_hold{
                     position: absolute;
                    top: -60%;
                    right: 13%;
                    cursor: pointer;
                    background: white;
                    border-top-right-radius: 13px;
                    border-bottom-right-radius: 13px;
                    padding: 4px 6px 4px 9px;
                  }
                  .pop{
                     display: none; 
                    position: absolute;
                    /* top: -337%; */
                    transform: translate(10px, 10px);
                    transition: 3s;
                    padding: 12px 27px;
                    text-align: center;
                    width: 95%;
                    box-sizing: border-box;
                    background: orange;
                  }
                  .ii:hover,.i_hold:hover{
                      cursor:pointer;
                      color:white;
                      background:black;
                      border-radius:50%;
                  }
                  .i_hold:hover ~ .pop{
                      display:block;
                       transform: translate(10px, -300px);
                  }

                  /* forget password */
                  #fp{
                      
                     /* position: absolute;
                      top: 24%;
                      right: 19%;*/
                      font-size:18px;
                      color: orange;
                      
                  }

                  #chk3{
                      background: #fff;
                      color:blueviolet;
                  }
                  #chk3:hover{
                      background: green;
                      color:white;
                  }
                  #btn2{
                      margin-top:25px;
                  }
                  #log_pwd{
                      width:67%;
                      position:relative;
                      left:-1%;
                  }
                  .i_hold2{
                    position: absolute;
                    top: 20.9%;
                    right: 13%;
                    background: #fff;
                    border-top-right-radius: 16px;
                    border-bottom-right-radius: 16px;
                    padding: 7px 13px 5px 13px;
                    
                  }
                  .i_hold2:hover,ii:hover{
                      background:black;
                      color:white;
                      border-radius:50%;
                  }
                  .main_fp{
                      display:none;
                      background:blueviolet;
                      border: 1px solid red;
                      padding: 10px;
                      width: 80%;
                      position: absolute;
                      top: 10%;
                      left: 8%;
                  }
                  #click3{
                      display:none;
                  }
                  #click3:checked ~ .main_fp{
                      display:block;
                  }
              </style>
              

</body>
   
</html>
