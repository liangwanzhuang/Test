using ModelInfo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //
    [WebMethod]
    public static string GetList(string path,string pathCount)
    {
        string siteName = ConfigurationManager.AppSettings["test"];
        int topNum = Convert.ToInt32(siteName);
        TisanInfoModel rm = new TisanInfoModel();

        DataTable dt = rm.GetTisanInfio(Convert.ToInt32(path), Convert.ToInt32(pathCount));
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