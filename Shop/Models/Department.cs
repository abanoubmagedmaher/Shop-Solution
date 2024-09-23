using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Department
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Employee Name is required")]
        //[MaxLength(50)]
        //[MinLength(2)]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Employee Manager Name is required")]
        //[MaxLength(50)]
        //[MinLength(2)]
        public string ManagerName { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
