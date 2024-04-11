using Application.StudentCRUD;
using DomainStudentCRUD;
using Infrastructure.StudentTask;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddDbContext<ApplicationDBContext>();
	*/
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<ApplicationDBContext>();
builder.Services.AddIdentityCore<AppUser>()
	.AddEntityFrameworkStores<ApplicationDBContext>().AddApiEndpoints();

var app = builder.Build();
app.MapIdentityApi<AppUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

