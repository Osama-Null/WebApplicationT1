using System.ComponentModel.DataAnnotations;

namespace WebApplication15.Models.SharedProp
{
    public class BaseProp
    {
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
