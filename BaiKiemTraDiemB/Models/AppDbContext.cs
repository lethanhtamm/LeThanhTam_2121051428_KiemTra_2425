using Microsoft.EntityFrameworkCore;
using BaiKiemTraDiemB;

namespace BaiKiemTraDiemB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppContext> options) : base(options) { }
    public DbSet<DemoABC> DemoABC { get; set; }
}

