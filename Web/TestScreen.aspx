<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestScreen.aspx.cs" Inherits="TestScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="Script/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen"/>
    <script src="Script/bootstrap/js/bootstrap.js"></script>
     <script src="Script/jquery-3.1.0.min.js"></script>
     <script type="text/javascript">
         setInterval("myInterval()", 1000);//1000为1秒钟
         function myInterval() {
             shu();
         }
         var s =1;
         window.onload = myfunction;
         var obj = "";
         function shu()
         {
             //alert(s);
             s++;
             if (obj.length % 21== 0)
             {

             }
         }
         function myfunction() {

             $.ajax({
                 //url: "Handler.ashx",
                 //type: "GET",
                 type: "POST",
                 url: "TestScreen.aspx/GetList",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     obj = $.parseJSON(data.d);
                     debugger
                     creactTr(0);
                 }

             });
             
         };

         function creactTr(s)
         {
             debugger
             var newTr = "";
             for (var i =s; i < obj.length; i++) {
                 newTr += "<tr class='success'><td>" + obj[i].医院名称 + "</td><td>" + obj[i].科室 + "</td><td>" + obj[i].处方号 + "</td><td>" + obj[i].姓名 + "</td><td>" + obj[i].付数 + "</td><td>" + obj[i].次数 + "</td><td>" + obj[i].包装量 + "</td><td>" + obj[i].当前状态 + "</td></tr>";
                 
                 if (i!==0&&i %20 == 0)
                 {
                    
                     break;
                 }
             }
             $("#tb  tr:not(:first)").html("");

             $("#tb").append(newTr);
         }
 </script>
</head>
    
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table table-condensed" id="tb" style="margin-left:20px;width:100%">
           <thead>
                        <tr>
                        
                        <th>医院名称</th>
                        <th>科室</th>
                        <th>处方号</th>
                        <th>姓名</th>
                        <th>付数</th>
                        <th>次数</th>
                        <th>包装量</th>
                        <th>当前状态</th>
                        </tr>
                     </thead>
            <tbody>
                          
            </tbody>
            
        </table>
    </div>
    </form>
</body>
</html>
