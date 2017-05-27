using SQLDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class CreateUserModel
    {
        DataBaseLayer db = new DataBaseLayer();
        public string Name{get;set;}
        public string Email{get;set;}
        public string Password { get; set; }

        public int CreateUser( string name, string email, string password)
        {
            string str = "INSERT NewUser (name,Email ,Password) VALUES('" + name + "' ,'"+email+"','"+password+"')";
            int i=db.cmd_Execute(str);
            return i;
        }
    }
}