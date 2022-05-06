using Microsoft.EntityFrameworkCore;
using TodosTask.Models.Entities;

namespace TodoTask.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoWork> TodoWork { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

    }
}
