using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFramework_CodeFirst_Web2
{/*
   Bu class CodeFirst yapısıyla veritabanına veri kaydetmeye yarar.
    DropCreateDatabaseIfModelChanges<SchoolDBContext> miras almayı unutmuyoruz.
     */
    public class SchoolDBContextSeeder: DropCreateDatabaseIfModelChanges<SchoolDBContext>
    {
        //override ctrl+space tuşuna basarak seed metodunu bulduk.
        protected override void Seed(SchoolDBContext context)
        {
            Lesson lesson1 = new Lesson()
            {
                //Id kısmını boş bırakıyoruz çünkü primary key
                Name = "Yönetim ve Organizasyon",
                Students = new List<Student>()
                {
                    new Student()
                    {
                        NameAndLastname="Mustafa Karadağlı"
                    },
                    new Student()
                    {
                        NameAndLastname="Ömer Hayyam"
                    },
                    new Student()
                    {
                        NameAndLastname="Zeynep Bastik"
                    },
                    new Student()
                    {
                        NameAndLastname="Ceylan Oğuzlar"
                    }
                }
            };
            Lesson lesson2 = new Lesson()
            {
                Name = "Pazarlama İlkeleri",
                Students = new List<Student>()
                {
                    new Student()
                    {
                        NameAndLastname="Nisan Karadağlı"
                    },
                    new Student()
                    {
                        NameAndLastname="Murat Hayyam"
                    },
                    new Student()
                    {
                        NameAndLastname="Dilara Bastik"
                    },
                    new Student()
                    {
                        NameAndLastname="Kazım Oğuzlar"
                    }
                }
            };
            //veritabanına kaydetmek
            context.Lessons.Add(lesson1);
            context.Lessons.Add(lesson2);
            base.Seed(context);
        }
    }
}