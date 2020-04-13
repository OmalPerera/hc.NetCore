using System;
using Microsoft.EntityFrameworkCore;

namespace HC_netCore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}

