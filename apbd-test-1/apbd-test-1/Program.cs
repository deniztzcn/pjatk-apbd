using apbd_example_test.Services.Abstractions;
using apbd_example_test.Services.Implementations;
using apbd_test_1.Controllers;
using apbd_test_1.Repositories.Abstractions;
using apbd_test_1.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IDbConnectionService,DbConnectionService>();
builder.Services.AddScoped<IProjectService,ProjectService>();
builder.Services.AddScoped<ITeamMemberRepository,TeamMemberRepository>();
builder.Services.AddScoped<IProjectRepository,ProjectRepository>();
builder.Services.AddScoped<ITaskRepository,TaskRepository>();
builder.Services.AddScoped<ITaskTypeRepository,TaskTypeRepository>();

var app = builder.Build();

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