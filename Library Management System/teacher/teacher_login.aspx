<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher_login.aspx.cs" Inherits="Library_Management_System.teacher.teacher_login" %>


<!doctype html>
<html>
<head runat="server">
    <title>teacher Login or Registration</title>
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
    <form id="Form1" runat="server">
        <div class="main">
            <input type="checkbox" id="chk" name="chk" checked/>
            <div class="login">
        
                <label id="l1"> Login </label>
                <asp:TextBox ID="log_email" runat="server" type="email" name="email" placeholder="Email"  class="input" ></asp:TextBox>
                <asp:TextBox ID="log_pwd" runat="server"  type="password" name="pass" placeholder="Password"  class="input" ></asp:TextBox>
                <asp:Button ID="btn2" runat="server"  class="button" Text="Login" 
                    onclick="btn2_Click" />
                <div id="e1" style="display:none;" runat="server">
                    
                </div>
            </div>
            <div class="signup">
                <label for="chk" class="l1"> Sign Up </label>
                <center>
                    <asp:Label ID="Label1" runat="server" Text="Select Usertype:"></asp:Label>

                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
                        <asp:ListItem Value="Student" Text="Student">Student</asp:ListItem>
                        <asp:ListItem  Selected="True" Text="Teacher">Teacher</asp:ListItem>
                    </asp:DropDownList> 
                    <br /><br />

                    <asp:Image ID="img"  CssClass="sl1" ImageUrl="~/teacher/img/teacher.jpeg" 
                        runat="server" ToolTip="Upload Image" >
                    </asp:Image>
             
                </center>

                <!-- popup -->
               
                <div class="center">
                    <input type="checkbox" id="click">
                    <label for="click" class="click-me">Upload Image</label>
       
                    <div class="content" >
                        <div class="header">
                            <h2>Teacher Image</h2>  
                        </div>

                        <br /> <br />

                        <asp:FileUpload ID="fu_teacher" runat="server"  
                            BorderStyle="None" BorderColor="#3333CC" ToolTip="upload teacher image" CssClass="fl" />
                        <div class="line"></div>
                        <label for="click" class="close-btn">Close</label>
                    </div>
                </div>
                <!-- End popup -->
            
                <!-- Teacher Data -->
                <asp:TextBox ID="t_tnm" runat="server" type="textbox" name="t_tnm" placeholder="Teacher name" class="input" ></asp:TextBox>
                <asp:TextBox ID="t_tid" runat="server" type="textbox" name="t_tid" placeholder="Teacher ID" class="input" ></asp:TextBox>
                <asp:TextBox ID="t_email" runat="server" type="email" name=email placeholder="Email" class="input" ></asp:TextBox>
                <asp:TextBox ID="t_ph" runat="server" type="textbox" name="phno" placeholder="Phone Number" class="input" ></asp:TextBox>
                <asp:TextBox ID="t_pwd" runat="server"  type="password" name=pass placeholder="Password"  class="input" ></asp:TextBox>
                <asp:TextBox ID="t_dept" runat="server" type="textbox" name="t_dept" placeholder="Department" class="input" ></asp:TextBox>
                 
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

                <asp:Button ID="btn1" runat="server" class="button" Text="Sign Up" onclick="btn1_Click"/>
    
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
                  #t_tnm,#t_tid,#t_email,#t_ph,#t_pwd,t_dept,#ss_sq{
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
              </style>
              

</body>

</html>
