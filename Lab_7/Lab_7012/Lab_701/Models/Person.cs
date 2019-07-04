using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_701.Models
{
    public class Person
    {
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(10, MinimumLength = 6)]
        public string Phone { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(30, MinimumLength = 1)]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        [StringLength(30, MinimumLength = 1)]
        public string Firstname { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(30, MinimumLength = 1)]
        public string Middlename { get; set; }

        [Display(Name = "Дата рождения")]
        [DataRange(-120)]
        [DataType(DataType.Date)]
        public DateTime BDay { get; set; }
    }
}