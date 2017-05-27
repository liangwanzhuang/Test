using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace MvcApplication.Models
{
    public class DashboardModel
    {
        public List<Projec> list { get; set; }
        public List<AboutMe> listStyle { get; set; }
    }
    public class Projec
    {
        public string ProjectName { get; set; }
        public DateTime StartData { get; set; }
        public string Status { get; set; }
    }
    public class AboutMe
    {
        public string ProjectName { get; set; }
        public DateTime CreateMen { get; set; }
        public DateTime Rate { get; set; }
    }
}