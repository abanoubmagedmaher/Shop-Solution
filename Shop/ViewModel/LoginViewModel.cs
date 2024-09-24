using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Rememeber Me")]
        public bool RememberMe { get; set; }
    }
}
