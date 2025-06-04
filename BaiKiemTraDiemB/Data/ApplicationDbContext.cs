using Microsoft.EntityFrameworkCore;
using BaiKiemTraDiemB.Models;

namespace BaiKiemTraDiemB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet <DemoABC> DemoABCs { get; set; }
        public object DemoABC { get; internal set; }
    }
}