
using Domain.StudentCRUD;

namespace Application.StudentCRUD
{
	public interface IStudentService
	{
		Task<Student> AddStudent(Student student);
		Task<Student> UpdateStudent(Student student);
		Task<Student> DeleteStudents(string id);
		Task<IEnumerable<Student>> GetStudentById(string id);
		Task<IEnumerable<Student>> GetAllStudent();
	}
}
