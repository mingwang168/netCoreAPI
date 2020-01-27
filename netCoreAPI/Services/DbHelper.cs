using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreAPI.Services
{
    public class ToDo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(
                new { Id = 1, Description = "Clean house", IsComplete = false,Priority=1,CreatedOn=DateTime.Now },
                new { Id = 2, Description = "Bake cake", IsComplete = false, Priority = 3, CreatedOn = DateTime.Now }
            );
            modelBuilder.Entity<Product>().HasData(
                new { Id = 1, Title = "AWS Project", CreatedOn = DateTime.Now },
                new { Id = 2, Title = "Laravel Project", CreatedOn = DateTime.Now }
            );
        }
               
    }




    //public class ProjectContext : DbContext
    //{
    //    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
    //    public DbSet<Projects> Projects { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<ToDo>().HasData(
    //            new { Id = 1, ProjectName = "AWS Project" },
    //            new { Id = 2, ProjectName = "Laravel Project" }
    //        );
    //    }
    //}
}
