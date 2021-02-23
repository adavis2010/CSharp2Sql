using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class Student {

        public int Id {get; set;}
        public string Firstname {get; set;}
        public string Lastname {get; set;}
        public string Statecode { get; set;}
        public int SAT { get; set; }
        public decimal GPA { get; set;}
        public int? MajorId { get; set;}
    } }
