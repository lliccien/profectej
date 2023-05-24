using Microsoft.EntityFrameworkCore;
using projectef.Models;


namespace projectef;

public class TasksContext: DbContext
{
    public DbSet<Category> Categories {get;set;}
    public DbSet<Models.Task> Tasks {get;set;}
    public TasksContext(DbContextOptions<TasksContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        List<Category> categoryInit =  new List<Category>();
        categoryInit.Add(new Category() { 
            CategoryId = Guid.Parse("fab3c6b5-7b27-47be-a3c9-c997f2b7067b"),
            Name = "Actividades pendientes",
            Weight = 20
        });
        categoryInit.Add(new Category() { 
            CategoryId = Guid.Parse("8628d41c-2029-4a05-aa85-d462c032e85e"),
            Name = "Actividades personales",
            Weight = 20
        });
        

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);

            category.Property(p => p.Name).IsRequired().HasMaxLength(150);

            category.Property(p => p.Description).IsRequired(false);

            category.Property(p => p.Weight);

            category.HasData(categoryInit);
        });

        List<Models.Task> taskInit = new List<Models.Task>();
        taskInit.Add(new Models.Task() {
            TaskId = Guid.Parse("862589ec-ee6b-4be7-8412-c9727cd53bed"),
            CategoryId = Guid.Parse("fab3c6b5-7b27-47be-a3c9-c997f2b7067b"),
            Title = "Terminar la prueba",
            Description = "Terminar la prueba de una api en .Net Framework Core",
            PriorityTask = Priority.High,
            CreatedAt = DateTime.Now,
        });

        taskInit.Add(new Models.Task() {
            TaskId = Guid.Parse("5470a6ed-e36b-4f30-b0d9-58d4c9933758"),
            CategoryId = Guid.Parse("8628d41c-2029-4a05-aa85-d462c032e85e"),
            Title = "Arreglar la oficina",
            Description = "Arregalr la oficina por completo y ordenar el closet",
            PriorityTask = Priority.Low,
            CreatedAt = DateTime.Now,
        });


        modelBuilder.Entity<Models.Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);

            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);

            task.Property(p => p.Title).IsRequired().HasMaxLength(250);

            task.Property(p => p.Description);

            task.Property(p => p.PriorityTask);

            task.Property(p => p.CreatedAt);

            task.Ignore(p => p.Resume);

            task.HasData(taskInit);

        });
    }
    
}