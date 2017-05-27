using AjaxPro;
using ModelInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.Web.Services;  

public partial class TestScreen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //System.Timers.Timer t = new System.Timers.Timer(1000);
        //t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；

        //t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；

        //t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        //BindLisView();
    }

    [WebMethod]
    public static string GetList(int id, int? page)
    {
        string siteName = ConfigurationManager.AppSettings["test"];
        int topNum = Convert.ToInt32(siteName);
        TisanInfoModel rm = new TisanInfoModel();

        DataTable dt = rm.GetTisanInfio(1,20);
        string strJson = DataTableToJson(dt);
        return strJson;//返回一个json字符串
    }

/// <summary>
/// DataTable转化json 字符串
/// </summary>
/// <param name="dataTable"></param>
/// <returns></returns>
    private static string DataTableToJson(DataTable dataTable)
    {
        var JsonString = new StringBuilder();
        if (dataTable.Rows.Count > 0)
        {
            JsonString.Append("[");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                JsonString.Append("{");
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (j < dataTable.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dataTable.Columns[j].ColumnName.ToString() + "\":" + "\"" + dataTable.Rows[i][j].ToString() + "\",");
                    }
                    else if (j == dataTable.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dataTable.Columns[j].ColumnName.ToString() + "\":" + "\"" + dataTable.Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == dataTable.Rows.Count - 1)
                {
                    JsonString.Append("}");
                }
                else
                {
                    JsonString.Append("},");
                }
            }
            JsonString.Append("]");
        }
        return JsonString.ToString();
    }
}