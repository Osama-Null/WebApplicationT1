using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication15.Models.SharedProp;

namespace WebApplication15.Models
{
    public class Student : BaseProp
    {
        [Display(Name = "ID")]
        public int StudentId { get; set; } // pk
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
    }
}
