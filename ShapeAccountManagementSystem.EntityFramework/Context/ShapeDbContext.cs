using Microsoft.EntityFrameworkCore;
using ShapeAccountManagementSystem.EntityFramework.Entities;

namespace ShapeAccountManagementSystem.EntityFramework.Context
{
    public class ShapeDbContext : DbContext
    {
        public ShapeDbContext() : base()
        {

        }
        public ShapeDbContext(DbContextOptions<ShapeDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
