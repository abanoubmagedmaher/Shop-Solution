using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employee Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Employee Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Employee Mobile is required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Employee WhatsAppNumber is required")]
        public string WhatsAppNumber { get; set; }
        [Required(ErrorMessage = "Employee Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Employee Sallary is required")]
        public decimal Sallary { get; set; }
        [Required(ErrorMessage = "Employee JobTitle is required")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]

        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]


        //ForeignKey and List (M)
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
