using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyMouse.Models
{
    public class UserRole
    {
        public decimal userid { get; set; }
        public string userphone { get; set; }
        public string username { get; set; }
        public string userpwd { get; set; }
        public System.DateTime? jointime { get; set; }
        public bool? isDel { get; set; }
        public string comment { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
    }
}