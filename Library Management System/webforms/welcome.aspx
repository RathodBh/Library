<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="Library_Management_System.webforms.welcome1" %>

<!DOCTYPE html>
<html lang="en" class="no-js">
	<head>
		<meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
		<title>Welcome</title>
		<meta name="description" content="Circular Navigation Styles - Building a Circular Navigation with CSS Transforms | Codrops " />
		<meta name="keywords" content="css transforms, circular navigation, round navigation, circular menu, tutorial" />
		<meta name="author" content="Sara Soueidan for Codrops" />
		
		
		<link rel="shortcut icon" href="img/favicon.ico" />
		<link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/component2.css" />
		<script src="js/modernizr-2.6.2.min.js"></script>


		<style>
		    #loading {
		        position: fixed;
		        width: 100%;
		        height: 100vh;
		        background: yellow url('../gif/welcome_preloader.gif') no-repeat center;
		        z-index: 99999;
		    }	
			font{
				font-size:4.5vh;
			}
			.component{
					height:44vh;
				}
			@media screen and (max-width:768px){
				font{
				font-size:3vh;
				}
				
			}
		</style>


<script type="text/javascript">
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-7243260-2']);
_gaq.push(['_trackPageview']);
(function() {
var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();
</script>


	</head>
	<body  onload="load_gif()" style="width:100vw;height:100vh;user-select:none;">
		<div id="loading"></div>
		<div class="container" >
			<!-- Top Navigation -->
		
			<header>
				<img src="img/logo.png" style="height:23vh;user-select:none;"/>
				<font><span>Welcome to</span>LIBRARY MANAGEMENT SYSTEM </font>	
				
			</header>
			<div class="component" style="background:url('img/book2.png');background-position:center;">

					<!-- Start Nav Structure -->
				<button class="cn-button" id="cn-button">Menu</button>
				<div class="cn-wrapper" id="cn-wrapper">
					<ul>
						<li><a href="welcome.aspx"><span>HOME</span></a></li>
						<li><a href="about_us.aspx"><span>ABOUT<br>US</span></a></li>
						<li><a href="contact_us.aspx"><span>CONTACT<br>US</span></a></li>
						<li><a href="../student/stud_login.aspx"><span>LOGIN</span></a></li>
						<li><a href="../student/stud_login.aspx"><span>STUDENT<br>SIGNUP</span></a></li>
						<li><a href="../teacher/teacher_login.aspx"><span>FACULTY<br>SIGNUP</span></a></li>
						<li><a href="follow.aspx"><span>Follow</span></a></li>
					 </ul>
				</div>
				<!-- End of Nav Structure -->
			</div>
		
		</div><!-- /container -->
		<script src="js/polyfills.js"></script>
		<script src="js/demo2.js"></script>
		<!-- For the demo ad only -->   

	</body>
	<script type="text/javascript">
        var preloader = document.getElementById('loading');

        function load_gif() {
            preloader.style.display = "none";
        }
</script>
</html>
