using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SQLDAL
{
    public class UserDAL
    {
        public DataBaseLayer db = new DataBaseLayer();
        public bool VerifyUser(string name, string password)
        {
            //select ID,JobNum,EName,Role,Sex,Age,Phone,Address,Nation,Origin,WorkTime,WorkContent,pwd from Employee where id
            string sql = "select * from [dbo].[User] where password=" + "'" + password + "'" + " and name=" + "'" + name + "'";
            SqlDataReader rr = db.get_Reader(sql);
            if (rr.Read())
            {
                return true;
            }
            return false;

        }

        public int CreateUser(string name, string email, string password)
        {
            string str = "INSERT [dbo].[User] (name,Email ,Password) VALUES('" + name + "' ,'" + email + "','" + password + "')";
            int i = db.cmd_Execute(str);
            return i;
        }


    }
}