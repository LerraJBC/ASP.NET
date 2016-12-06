using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsCRUD.Models
{
    public class Student
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string course { get; set; }
        public string major { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
    }
}