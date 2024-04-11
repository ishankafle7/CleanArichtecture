

using Application.StudentCRUD;
using Domain.StudentCRUD;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Infrastructure.StudentTask
{
	public class StudentService : IStudentService
	{
		private readonly ApplicationDBContext _dbContext;



		public StudentService(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Student> AddStudent(Student student)
		{
			var result = await _dbContext.Student.AddAsync(student);
			await _dbContext.SaveChangesAsync();
			return result.Entity;
		}


		public async Task<Student> DeleteStudents(string id)
		{
			var result = await _dbContext.Student.Where(s => s.Id.ToString() == id).ToListAsync();


			var result_ = _dbContext.Student.Remove(result[0]);
			await _dbContext.SaveChangesAsync();
			return result_.Entity;

		}
		public async Task<IEnumerable<Student>> GetAllStudent()
		{
			var result = _dbContext.Student.ToListAsync();
			await _dbContext.SaveChangesAsync();
			return result.Result;
		}

		public async Task<Student> UpdateStudent(Student _student)
		{

			Console.Write(_student);
			var student = await _dbContext.Student
				.FirstOrDefaultAsync(s => s.Id == _student.Id);
			student.Name = _student.Name;
			student.Address = _student.Address;
			await _dbContext.SaveChangesAsync();

			return student;

		}

		public async Task<IEnumerable<Student>> GetStudentById(string id)
		{
			var result = await _dbContext.Student.Where(s => s.Id.ToString() == id).ToListAsync();
			return result;
		}
	}
}
