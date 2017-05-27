<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DotNetFlexGrid.aspx.cs" Inherits="DotNetFlexGrid" %>
<%@ Register src="~/dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <script language="javascript" type="text/javascript">
    function ShowCurrentRows() {
        var rows = DotNetFlexiGrid1.getSelectedRowsIds();
        for (var i = 0; i < rows.length; i++) {
            alert(rows[i]);
        }
    }
    function InsertNewRows() {
        var id = 'new_' + Math.round(Math.random() * 10000);
        DotNetFlexiGrid1.insertNewRow({
            id: id, //行的ID，后台绑定的是主键
            cell: [
            "guid",
            "f1",
            "f2",
            "f3",
            "f4",
            'f5',
            'f6',
            'f7',
            false
            ]
        });
    }
    function reflashData() {
        DotNetFlexiGrid1.reflashData();
    }
    function RemoveRows() {
        DotNetFlexiGrid1.deleteRows(DotNetFlexiGrid1.getSelectedRowsIds());
    }
    function getCellData() {
        var id = DotNetFlexiGrid1.getSelectedRowsIds()[0];
        if (id) {
            var array = DotNetFlexiGrid1.getCellDatas(id);
            if (array) {
                for (var i = 0; i < array.length; i++) {
                    alert(array[i]);
                }
            }
        }
    }
    //挂接事件
    DotNetFlexiGrid_onClick = function(e) {
        //alert(e);
    };
    DotNetFlexiGrid_onDbClick = function(e) {
        alert(e);
    };
    DotNetFlexiGrid_onChecked = function(e) {
        alert("onChecked" + e);
    };
    DotNetFlexiGrid_onUnChecked = function(e) {
        alert("onUnChecked" + e);
    };
    DotNetFlexiGrid_onLoad = function() {
        alert('onLoad');
    };
</script>
<body>
    <form id="form1" runat="server">
       <div>
        <uc1:dotNetFlexGrid ID="DotNetFlexiGrid1" runat="server" 
            EventOnClickFunc="DotNetFlexiGrid_onClick" 
            EventOnDbClickFunc="DotNetFlexiGrid_onDbClick" 
            EventOnCheckedFunc="" 
            EventOnUnCheckedFunc="" 
            EventOnLoadFunc="" 
            EventOnSelectedFunc=""
        />
    </div>
    <a href="javascript:ShowCurrentRows();">显示当前选择的Rows</a>
    <a href="javascript:InsertNewRows();">新增一行</a>
    <a href="javascript:RemoveRows();">删除当前选择的行</a>
    <a href="javascript:reflashData();">直接刷新Grid</a>
    <a href="javascript:getCellData();">获取一行数据</a>
    <br />
    </form>
</body>
</html>
