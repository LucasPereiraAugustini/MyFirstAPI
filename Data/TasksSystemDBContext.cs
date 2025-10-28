using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebAPI.Data.Map;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class TasksSystemDBContext : DbContext
    {
        public TasksSystemDBContext(DbContextOptions<TasksSystemDBContext> options) 
            : base(options)
        { 
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
