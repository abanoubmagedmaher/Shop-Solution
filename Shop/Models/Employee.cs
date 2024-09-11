using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        [MaxLength(50)]
        [MinLength(2,ErrorMessage ="Must be greater than Three Character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employee Age is required")]
        [Range(20,100)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Employee Address is required")]
        [MaxLength(150)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Employee Mobile is required")]
        [RegularExpression("^01[0125][0-9]{8}$")]
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
        [RegularExpression(@"\w+\.(jpg|jpeg|png|gif|bmp|tiff|svg|webp|heic|JPG|JPEG|PNG|GIF|BMP|TIFF|SVG|WEBP|HEIC)$")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Employee ImageURL is required")]


        //ForeignKey and List (M)
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department? Department { get; set; }//= new Department();
    }
}
