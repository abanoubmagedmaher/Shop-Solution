using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
