using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_APSNETCORE.Models
{
    public enum Gender { Male, Female }
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("[а-яА-Я]+")]
        public string FirstName { get; set; } = "";

        [Required]
        [RegularExpression("[а-яА-Я]+")]
        public string LastName { get; set; } = "";

        [BirthdayValidation(120)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; } = DateTime.Now;
        public Gender Gender { get; set; } = Gender.Male;
    }
    public class BirthdayValidationAttribute : ValidationAttribute
    {
        public int MaxAge { get; set; }
        public BirthdayValidationAttribute(int maxAge)
        {
            MaxAge = maxAge;
        }
        public BirthdayValidationAttribute() : this(100)
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime))
                return ValidationResult.Success;
            DateTime date = (DateTime)value;
            var diff = DateTime.Now - date;
            DateTime zeroTime = new DateTime(1, 1, 1);
            var diffYears = (zeroTime + diff).Year - 1;
            if (diffYears > MaxAge)
                return new ValidationResult("Date is too old");
            else
                return ValidationResult.Success;
        }
    }
}
