using Microsoft.EntityFrameworkCore;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;



namespace Mission8.Models

{
    public class TasksContext : DbContext
    {
        //Constructor

        public TasksContext(DbContextOptions<TasksContext> options) : base(options)
        {
            //Leave blank for now

        }
        public DbSet<TaskResponse> Responses { get; set; }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Home" },
                    new Category { CategoryId = 2, CategoryName = "School" },
                    new Category { CategoryId = 3, CategoryName = "Work" },
                    new Category { CategoryId = 4, CategoryName = "Church" }
                );

            //Seeding the database with a few entries
            mb.Entity<TaskResponse>().HasData(

                new TaskResponse

                {
                    TaskId = 1,
                    CategoryId = 1,
                    Task = "Eat",
                    DueDate = "Today",
                    Quadrant = 1,
                    Completed = false

                },

                new TaskResponse

                {
                    TaskId = 2,
                    CategoryId = 2,
                    Task = "Eat",
                    DueDate = "Today",
                    Quadrant = 2,
                    Completed = true
                },

                new TaskResponse
                {
                    TaskId = 3,
                    CategoryId = 3,
                    Task = "Eat",
                    DueDate = "Today",
                    Quadrant = 3,
                    Completed = false
                },

                new TaskResponse
                {
                    TaskId = 4,
                    CategoryId = 4,
                    Task = "Eat",
                    DueDate = "Today",
                    Quadrant = 4,
                    Completed = true
                }
            );
        }
    }
}

