using Microsoft.EntityFrameworkCore;
using SolarLab.Models;

namespace SolarLab.Infrastructure;

public class MyDbContext : DbContext
{
    public DbSet<BirthdayPerson> BirthdayPersons { get; set; }
    
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }
}