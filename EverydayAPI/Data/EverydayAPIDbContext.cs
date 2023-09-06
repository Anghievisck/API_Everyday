using EverydayAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EverydayAPI.Data {
    public class EverydayAPIDbContext : DbContext {
        public EverydayAPIDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Autor> autors { get; set; }
        public DbSet<Jornal> jornais { get; set; }
        public DbSet<User> users { get; set; }
    }
}
