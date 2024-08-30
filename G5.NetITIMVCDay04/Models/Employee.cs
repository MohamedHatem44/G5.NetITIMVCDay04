using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G5.NetITIMVCDay04.Models
{
    public class Employee
    {
        /*---------------------------------------------------------*/
        public int Id { get; set; }


        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "Name is Required.")]
        [DisplayName("Employee Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Age is Required.")]
        [Range(20, 50, ErrorMessage = "Age must be between 20 and 50.")]
        [DisplayName("Employee Age")]
        public int Age { get; set; }


        [Range(1000, 10000, ErrorMessage = "Salary must be between 1000 and 10000.")]
        [DisplayName("Employee Salary")]
        [Column(TypeName = "decimal(8,2)")]      // => 123456.78
        public decimal Salary { get; set; }


        [Required(ErrorMessage = "Address is Required.")]
        [MinLength(8, ErrorMessage = "Address must be more than 8 character")]
        [MaxLength(20, ErrorMessage = "Address must be less than 20 character")]
        [DisplayName("Employee Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        [DisplayName("Employee Email")]
        public string Email { get; set; }
        /*---------------------------------------------------------*/
        //[ForeignKey("Department")]
        public int DepartmentId { get; set; }
        //[ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
        /*---------------------------------------------------------*/
    }
}
