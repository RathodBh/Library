<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian_menu.Master" AutoEventWireup="true" CodeBehind="communication.aspx.cs" Inherits="Library_Management_System.librarian.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <style type="text/css">
        .right-align{
            text-align:right;
        }
        
    </style>
    <div class="row" style="margin:10px;">
         <div class="col-lg-12" style="height:40px; border: 2px solid green;border-radius:10px; justify-content:right;  background:#fff url('images/msg.png') no-repeat; margin-top:10px;display:grid;place-items:right;">  
         
             
             <a href="send_msg.aspx" style="border-radius:50%;border:1px solid black; color:black;margin:5px 0px;padding:0px 7px ; "><i class="fa fa-close"></i></a>
            
            </div>
         <div class="col-lg-12" style="height:5px;"></div>
        <div class="col-lg-12" style="height:60vh; border: 2px solid black; background-color:white; overflow:auto;" id="msgarea"  >


        </div>
         <div class="col-lg-12" style="height:80px;border-radius:20px; border-style:solid; border-width: 2px; background-color:white; margin-top:5px;">
             <div class="col-lg-10">
                 <br />
                 <input  id="t1" class="form-control">

             </div>
             <div class="col-lg-2">
                 <br />
                 <input type="button" id="b1" class="form-control" value="SEND" onclick="send_message();" style="background:green;color:white;"/>

             </div>

        </div>
    </div>
    
    <script type="text/javascript">

        //this is for testing only

        var username = getUrlVars()["username"];



        function send_message() {
            var xmlhttp = new XMLHttpRequest();
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

                    var theDiv = document.getElementById("msgarea");
                    var x = document.createElement("P");
                    var t = document.createTextNode("librarian:" + document.getElementById("t1").value);
                    x.appendChild(t);
                    theDiv.appendChild(x);
                    var y = document.createElement("HR");
                    theDiv.appendChild(y);
                    theDiv.scrollTop = theDiv.scrollHeight;
                    document.getElementById("t1").value = "";

                }
            };
            xmlhttp.open("GET", "messages_send_from_librarian.aspx?username=" + username + "&msg=" + document.getElementById("t1").value, true);
            xmlhttp.send();

        }

        //end here for testing


        function load_messages() {
            var xmlhttp = new XMLHttpRequest();
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById("msgarea").innerHTML = xmlhttp.responseText;
                }
            };
            xmlhttp.open("GET", "load_messages.aspx?username=" + username, true);
            xmlhttp.send();
        }
        load_messages();


        function add_inside_new_message() {
            var xmlhttp = new XMLHttpRequest();
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

                    if (xmlhttp.responseText != "0") {

                        var strArray = xmlhttp.responseText.split("||abcd||");

                        for (var i = 0; i < strArray.length; i++) {

                            var theDiv = document.getElementById("msgarea");
                            var x = document.createElement("P");
                            var t = document.createTextNode(strArray[i]);
                            x.appendChild(t);
                            theDiv.appendChild(x);
                            var y = document.createElement("HR");
                            theDiv.appendChild(y);
                            theDiv.scrollTop = theDiv.scrollHeight;


                        }
                    }

                }
            };
            xmlhttp.open("GET", "load_new_messages.aspx?username=" + username, true);
            xmlhttp.send();
        }

        setInterval(function () {
            add_inside_new_message();
        }, 10000);


        function getUrlVars() {
            var vars = {};
            var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
                vars[key] = value;
            });
            return vars;
        }



    </script>

</asp:Content>
