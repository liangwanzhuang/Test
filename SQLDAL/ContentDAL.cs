using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SQLDAL
{
    public class ContentDAL
    {
        public DataBaseLayer db = new DataBaseLayer();
        public int CreateContent(string title,int id,string content)
        {
            string str = "INSERT INTO [dbo].[contentInfo]([contentTitle],[userid] ,[createDatetime],[editTime])VALUES('" + title + "' ," + id + " ,'" + DateTime.UtcNow + "','" + DateTime.UtcNow + "')";
            int i = db.cmd_Execute(str);
            string str2="select IDENT_CURRENT('contentInfo') as id";
            SqlDataReader  r= db.get_Reader(str2);
            if(r.Read())
            {
                return InsertContent(r[0].ToString(), content);
            }
            return 0;
        }
        public int InsertContent(string id, string content)
        {
            string str = "INSERT INTO [TestDB].[dbo].[Content](contentInfoId,createTime,editTime,content)VALUES(" + id + ",'" + DateTime.UtcNow + "','" + DateTime.UtcNow + "','" + content + "')";
            int i = db.cmd_Execute(str);
            return i;
        }
    }
}