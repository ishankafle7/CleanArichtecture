using DomainStudentCRUD;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationStudent.CRUD.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = new AppUser { UserName = model.Email, Email = model.Email };

			// Check if the specified role exists
			var roleExists = await _roleManager.RoleExistsAsync(model.Role);
			if (!roleExists)
			{
				// If the role doesn't exist, return error
				return BadRequest("Invalid role specified.");
			}

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				// Assign the specified role to the user
				await _userManager.AddToRoleAsync(user, model.Role);



				return Ok("User registered successfully.");
			}

			return BadRequest(result.Errors);
		}
	}
}
