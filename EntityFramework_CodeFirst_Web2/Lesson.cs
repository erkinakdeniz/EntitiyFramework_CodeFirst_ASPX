using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityFramework_CodeFirst_Web2
{
    //[Table("tblDers")]
    public class Lesson
    {
        public int ID { get; set; }
        //[Column("DersAdı")]
        public string Name { get; set; }
        public List<Student> Students { get; set; }//NavigationProperty
    }
}