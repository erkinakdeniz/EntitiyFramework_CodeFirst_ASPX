using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFramework_CodeFirst_Web2
{
    /*
     Veritabanı tarafında tabloları üretmek için oluşturuldu.
     DBContext'ten miras almayı unutmuyoruz.
         */
    public class SchoolDBContext:DbContext
    {
       public DbSet<Lesson> Lessons { get; set; }
       public DbSet<Student> Students { get; set; }
    }
}