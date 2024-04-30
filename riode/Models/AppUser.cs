using Microsoft.AspNetCore.Identity;

namespace riode.Models
{
	public class AppUser : IdentityUser
	{
		public string FullName { get; set; }
		public bool IsActive { get; set; }
	}
}
