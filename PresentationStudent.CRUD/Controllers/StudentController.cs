using System.Runtime.InteropServices;
using Application.StudentCRUD;
using Domain.StudentCRUD;
using Microsoft.AspNetCore.Mvc;

namespace Week19thMarch.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			this._studentService = studentService;
		}

		[HttpPost, Route("AddStudent")]
		public async Task<IActionResult> AddStudent(Student student)
		{
			var addStudent = await _studentService.AddStudent(student);
			return Ok(addStudent);

		}

		[HttpGet, Route("GetStudent")]
		public async Task<IActionResult> GetAllStudent()
		{
			var addStudent = await _studentService.GetAllStudent();
			return Ok(addStudent);
		}

		[HttpGet, Route("GetStudentById")]
		public async Task<IActionResult> GetStudentById(Student student)
		{
			var addStudent = await _studentService.GetStudentById(student.Id.ToString());
			return Ok(addStudent);

		}
		[HttpDelete, Route("DeleteStudent")]

		public async Task<IActionResult> RemoveStudent(string id)
		{
			var addStudent = await _studentService.DeleteStudents(id);
			return Ok(addStudent);

		}
		[HttpDelete, Route("UpdateStudent")]

		public async Task<IActionResult> Update(Student student)
		{
			var addStudent = await _studentService.UpdateStudent(student);
			return Ok(addStudent);

		}

	}
}
