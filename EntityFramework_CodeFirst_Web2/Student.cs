using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
/*
 Bu class School veritabanına Student adında tablo oluşturur.
 Tablo isminde bir class oluşturduk.
 Tablonun kolonlarını belirtmek için içine metotlar girdik.
     */
namespace EntityFramework_CodeFirst_Web2
{
    //Tablonun ismini değiştirmek istiyorsak [Table("tablo_adi")]
    //[Table("tblStudent")]
    public class Student
    {
        public int ID { get; set; }
        //Kolon adını değiştirmek için [Column("kolon_adi")]
        //[Column("AdveSoyad")]
        public string NameAndLastname { get; set; }
        //[Column("DersID")]
        //LessonID hangi öğrenci hangi derse girdiğini görmek için yazıldı.
        public int LessonID { get; set; }
        [ForeignKey("LessonID")]
        public Lesson Lessons { get; set; }//NavigationProperty
    }
}