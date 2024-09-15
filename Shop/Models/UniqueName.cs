using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class UniqueName:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string NewName = value.ToString();
            ShopContext dbcontext=new ShopContext();
            var checkuniqueName = dbcontext.Employee.FirstOrDefault(e => e.Name== NewName);
            if (checkuniqueName!= null)
            {
                return new ValidationResult("Name Must be Unique ");
            }
            return ValidationResult.Success;
        }
    }
}
