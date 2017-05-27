<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetInfoList.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Script/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen"/>
    <link rel="stylesheet" href="Script/bootstrap/css/page.css"/>
    <script src="Script/bootstrap/js/bootstrap.js"></script>
    <script src="Script/bootstrap/js/jquery-3.1.0.min.js"></script>
    <script src="Script/bootstrap/js/page.js"></script>
    <style type="text/css">
      tr.change:hover
        {
          background-color:	#DA70D6
         }
</style>
</head>
<body>
    <div>
        <table class="table table-condensed" id="tb" style="margin-left:20px;width:100%">
           <thead>
                <tr>
                        
                     <th>ID</th>
                     <th>处方号</th>
                     <th>姓名</th>
                     <th>性别</th>
                     <th>年龄</th>
                     <th>次数</th>
                     <th>付数</th>
                     <th>医生</th>
                     </tr>
            </thead>
            <tbody>
                          
            </tbody>
            
        </table>
    </div>
<%--    <button type="button" id="bt" onclick="button(1)">Click Me!</button>--%>
    <div class="pageList"></div>
    <script>
        window.onload = myfunction;
        var index = 1;
        function myfunction()
        {
            //alert(index)
                $.ajax({
                    url: "GetInfoList.aspx/GetList",
                    type: "post",
                    data: "{" + 'path:' + index + ',pathCount:' + 16 + " }",
                        //+ "{" + 'pathCount:' + 123 + " }",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var obj = $.parseJSON(data.d);
                        var newTr = "";
                        for (var i = 0; i < obj.length; i++) {
                            //alert(obj[i].ID)
                            newTr += "<tr class='change' id='" + obj[i].ID + "' onclick='button(" + obj[i].ID + ")'><td>" + obj[i].ID + "</td><td>" + obj[i].Pspnum + "</td><td>" + obj[i].name + "</td><td>" + obj[i].sex + "</td><td>" + obj[i].age + "</td><td>" + obj[i].takenum + "</td><td>" + obj[i].dose + "</td><td>" + obj[i].doctor + "</td></tr>";
                            //<td><button type='button' id='" + obj[i].ID + "'onclick='button(" + obj[i].ID + ")'>Click Me!</button><td>
                        }
                        $("#tb  tr:not(:first)").html("");
                        $("#tb").append(newTr);
                    }
                });
        }
       
        //分页div
        var pageDiv = $("div.pageList");
        //参数列表
        var options = {
            index: 1,//初始页码
            total: 16,//总页数
            numbers: 6,//显示页码数
            //...其他自定义参数
        };
        //初始化分页对象
        Page.init(pageDiv, options, function (data) {
            console.info(data);

            index = data.index;
            myfunction();
        });
        function button( buttonId )
        {
           alert(buttonId)
        }
        
</script>
</body>
</html>
