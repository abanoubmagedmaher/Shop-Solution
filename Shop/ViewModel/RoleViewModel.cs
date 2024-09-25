using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
