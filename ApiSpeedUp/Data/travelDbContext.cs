using ApiSpeedUp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSpeedUp.Data
{
    public class travelDbContext : DbContext
    {
        public travelDbContext(DbContextOptions<travelDbContext> options) : base(options)
        {
            
        }

        public DbSet<ApiExecutionTime> ApiExecutionTimes { get; set; }

    }
}