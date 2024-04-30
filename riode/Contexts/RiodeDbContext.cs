using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using riode.Models;

namespace riode.Contexts;

public class RiodeDbContext : IdentityDbContext<AppUser>
{
	public RiodeDbContext(DbContextOptions<RiodeDbContext> options) : base(options)
	{
	}

}
