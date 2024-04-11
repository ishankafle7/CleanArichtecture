

using Domain.StudentCRUD;
using DomainStudentCRUD;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.StudentTask
{
	public class ApplicationDBContext : IdentityDbContext<AppUser>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-EJIH7BA; Database=NetApiTesting; Trusted_Connection=True; TrustServerCertificate=True;MultipleActiveResultSets=True;");
		}

		public DbSet<Student> Student { get; set; }
	}
}