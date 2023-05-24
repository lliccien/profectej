using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("tasksDB"));
builder.Services.AddDbContext<TasksContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("psql"))
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    // return Results.Ok("Databse in memory runing: " + dbContext.Database.IsInMemory());
    return Results.Ok("Database in postgreSQL runing: " + dbContext.Database.IsNpgsql());
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) => {
    return Results.Ok(dbContext.Tasks.Include(p => p.Category));
});

app.MapGet("/api/tasks-priority-low", async ([FromServices] TasksContext dbContext) => {
    return Results.Ok(dbContext.Tasks.Include(p => p.Category).Where(p => p.PriorityTask == projectef.Models.Priority.Low));
});

app.Run();
