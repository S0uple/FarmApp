using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class FarmDbContext(DbContextOptions<FarmDbContext> options) : DbContext(options)
{
    public DbSet<Animal> Animals { get; set; }
}
