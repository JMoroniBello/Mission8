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
        public TasksContext (DbContextOptions<TasksContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
       
        //seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category {CategoryId=1, CategoryName = "Home" },
                    new Category { CategoryId = 2, CategoryName="School"},
                    new Category { CategoryId = 3, CategoryName = "Work"},
                    new Category { CategoryId = 4, CategoryName = "Church"}
                
                );
        }
    }
}
