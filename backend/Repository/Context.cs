using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class Context : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}