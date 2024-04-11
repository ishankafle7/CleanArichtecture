using System.ComponentModel.DataAnnotations;

namespace Domain.StudentCRUD
{
	public class Student
	{
		[Key]
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Address { get; set; }
	}
}
