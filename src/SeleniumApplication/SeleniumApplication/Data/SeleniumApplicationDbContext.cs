using Microsoft.EntityFrameworkCore;
using SeleniumApplication.Models;

namespace SeleniumApplication.Data;

public class SeleniumApplicationDbContext : DbContext
{
    public virtual DbSet<Job> Jobs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("server=localhost,1433;database=SeleniumDb;uid=sa;pwd=pro247!!;TrustServerCertificate=true;MultipleActiveResultSets=true");
        base.OnConfiguring(optionsBuilder);
    }
}
