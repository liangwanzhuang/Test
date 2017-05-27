using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;

public partial class DotNetFlexGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        this.DotNetFlexiGrid1.InitConfig(
            new string[]{
                "title=标题",//标题
                "singleselected=false",//是否单选
                "resizable=true",//是否可以调整大小
                "usepager=true",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=200",//高度，可为auto或具体px值
                "width=auto",//宽度，可为auto或具体px值
                "striped=true",//是否显示行交替色
                "selectedonclick=true"//是否点击行自动选中checkbox
            },
            new dotNetFlexGrid.FieldConfig[]{
              new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("hospitalId","医院ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                        new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("decmothed","煎药方法",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("name","患者姓名",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("sex","性别",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("age","年龄",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("phone","手机号码",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("address","地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("department","科室",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("inpatientarea","病区号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("ward","病房号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("sickbed","病床号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("diagresult","诊断结果",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       
                        new dotNetFlexGrid.FieldConfig("takemethod","服用方式",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("takenum","次数",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       
                        new dotNetFlexGrid.FieldConfig("oncetime","煎药时间一",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("twicetime","煎药时间二",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("soakwater","浸泡加水量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("soaktime","浸泡时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("labelnum","标签数量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("remark","说明",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("doctor","医生",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("footnote","医生脚注",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("ordertime","下单时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("curstate","当前状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("person","操作人员",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dotime","接方时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbphone","快递电话",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbtype","配送类型",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("takeway","服用方法",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                         new dotNetFlexGrid.FieldConfig("RemarksA","备注A",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("RemarksB","备注B",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                
            },
            null,
            null

            );
        this.DotNetFlexiGrid1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);//绑定方法必须是public的
        this.DotNetFlexiGrid1.ServerShow();
    }
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 1000;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际


        string hospitalID = "0";
        if (p.extParam.ContainsKey("hospitalID"))
        {
            hospitalID = p.extParam["hospitalID"];
        }
        string Pspnum = "0";
        if (p.extParam.ContainsKey("Pspnum"))
        {
            Pspnum = p.extParam["Pspnum"];
        }
        string time = "0";
        if (p.extParam.ContainsKey("time"))
        {
            time = p.extParam["time"];
        }
        string patient = "0";
        if (p.extParam.ContainsKey("patient"))
        {
            patient = p.extParam["patient"];
        }
        string tisaneid = "0";
        if (p.extParam.ContainsKey("tisaneid"))
        {
            tisaneid = p.extParam["tisaneid"];
        }
        string doper = "0";
        if (p.extParam.ContainsKey("doper"))
        {
            doper = p.extParam["doper"];
        }

       // string jftime = System.DateTime.Now.ToString("yyyy-MM-dd");
        string jftime = "2017-03-2";


        if (p.extParam.ContainsKey("JTime"))
        {
            jftime = p.extParam["JTime"];
        }

        if (Pspnum == "")
        {
            Pspnum = "0";
        }
        if (time == "")
        {
            time = "0";
        }
        if (patient == "")
        {
            patient = "0";
        }
        if (tisaneid == "")
        {
            tisaneid = "0";
        }
        if (doper == "")
        {
            doper = "0";
        }

        RecipeModel rm = new RecipeModel();
        result.table = rm.findRecipeInfo(hospitalID, Pspnum, time, patient, tisaneid, doper, jftime);

        dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["sex"].ToString());
            if (a == 1)
            {
                return "男";
            }
            else
            {
                return "女";
            }
        };
        result.FieldFormator.Register("sex", proc2);
        dotNetFlexGrid.FieldFormatorHandle proc3 = delegate(DataRow dr)
        {

            int b = Convert.ToInt32(dr["decscheme"].ToString());
            if (b == 1)
            {
                return "微压（密闭）解表（15min）";
            }
            else if (b == 2)
            {
                return "微压（密闭）汤药（15min）";
            }
            else if (b == 3) { return "微压（密闭）补药（15min）"; }
            else if (b == 4) { return "常压解表（10min，10min）"; }
            else if (b == 5) { return "常压汤药（20min，15min）"; }
            else if (b == 6) { return "常压补药（25min，20min）"; }
            else if (b == 20) { return "先煎解表（10min，10min，10min）"; }
            else if (b == 21) { return "先煎汤药（10min，20min，15min）"; }
            else if (b == 22) { return "先煎补药（10min，25min，20min）"; }
            else if (b == 36) { return "后下解表（10min（3：7），10min）"; }
            else if (b == 37) { return "后下汤药（20min（13：7），15min）"; }
            else if (b == 38) { return "后下补药（25min（18：7），20min）"; }
            else if (b == 81) { return "微压自定义"; }
            else if (b == 82) { return "常压自定义"; }
            else if (b == 83) { return "先煎自定义"; }
            else { return "后下自定义"; }
        };
        result.FieldFormator.Register("decscheme", proc3);

        dotNetFlexGrid.FieldFormatorHandle proc4 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["decmothed"].ToString());
            if (a == 1)
            {
                return "先煎";
            }
            else if (a == 2)
            {
                return "后下";
            }
            else
            {
                return "加糖加蜜";
            }




        };
        result.FieldFormator.Register("decmothed", proc4);
        dotNetFlexGrid.FieldFormatorHandle proc6 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["takeway"].ToString());
            if (a == 1)
            {
                return "水煎餐后";
            }
            else
            {
                return "";
            }




        };
        result.FieldFormator.Register("takeway", proc6);
        dotNetFlexGrid.FieldFormatorHandle proc5 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["dtbtype"].ToString());
            if (a == 1)
            {
                return "顺丰";
            }
            else if (a == 2)
            {
                return "圆通";
            }
            else
            {
                return "中通";
            }




        };
        result.FieldFormator.Register("dtbtype", proc5);
        return result;
    }
}