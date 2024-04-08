using apbd_tutorial04.database;
using apbd_tutorial04.models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var animals = MyDatabase.Animals;
var visits = MyDatabase.Visits;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/animals", () => Results.Ok(animals))
    .WithName("GetAnimals")
    .WithOpenApi();

app.MapGet("/api/animals/{id:int}", (int id) =>
    {
        var animal = animals.FirstOrDefault(a => a.Id == id);
        return animal == null ? Results.NotFound($"Animal with {id} does not exist!") : Results.Ok(animal);
    })
    .WithName("GetAnimal")
    .WithOpenApi();

app.MapPost("/api/animals", (Animal animal) =>
    {
    animals.Add(animal);
    return Results.StatusCode(StatusCodes.Status201Created);
    })
    .WithName("AddAnimal")
    .WithOpenApi();

app.MapPut("/api/animals/{id:int}", (int id, Animal modifiedAnimal) =>
    {
        var animal = animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return Results.NotFound($"Ahimal with id {id} does not exist!");
        }

        modifiedAnimal.Id = animal.Id;
        animals.Remove(animal);
        animals.Add(modifiedAnimal);
        return Results.NoContent();
    })
    .WithName("UpdateAnimal")
    .WithOpenApi();

app.MapDelete("/api/animals/{id:int}", (int id) =>
    {
        var animal = animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return Results.NotFound($"Animal with id {id} does not exist!");
        }

        animals.Remove(animal);
        return Results.NoContent();
    })
    .WithName("DeleteAnimal")
    .WithOpenApi();

app.MapGet("/api/visits/{id:int}", (int id) =>
    {
        return visits.Where(v => v.Animal.Id == id);
    })
    .WithName("GetVistsByAnimalId")
    .WithOpenApi();

app.MapPost("/api/visits", (Visit visit) =>
    {
        visits.Add(visit);
        return Results.StatusCode(StatusCodes.Status201Created);
    })
    .WithName("AddVisit")
    .WithOpenApi();



app.Run();