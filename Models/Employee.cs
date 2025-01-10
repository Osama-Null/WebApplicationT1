using System.ComponentModel.DataAnnotations;
using WebApplication15.Models.SharedProp;

namespace WebApplication15.Models
{
    public class Employee:BaseProp
    {
        [Display(Name = "ID")]
        public int EmployeeId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Date")]
        public DateTime HDate { get; set; } 
    }
}

