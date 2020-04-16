using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFramework_CodeFirst_Web2
{/*
    Verileri yönetme sınıfı
     */
    public class SchoolRepository
    {
        public List<Lesson> GetLessons()
        {
            SchoolDBContext context = new SchoolDBContext();
            //Include("Students") kullanmamızın sebebi Student tablosunu LessonID'ye göre bize getirmesini sağlar.
            return context.Lessons.Include("Students").ToList();
        }
    }
}