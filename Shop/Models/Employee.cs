using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Email { get; set; }
        public decimal Sallary { get; set; }
        public string JobTitle { get; set; }
        public string ImageURL { get; set; }

        //ForeignKey and List (M)
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
