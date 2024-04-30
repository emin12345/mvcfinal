using riode.Helpers.Enums;
using riode.Models;
using System.ComponentModel.DataAnnotations;

namespace riode.Areas.Admin.ViewModel
{
    public class UserViewModel
    {
        public AppUser User { get; set; }
        public IList<string> Roles { get; set; } = null!;
    }
}
