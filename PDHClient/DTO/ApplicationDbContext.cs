using Microsoft.EntityFrameworkCore;

namespace PDHClient.DTO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }


        //  public DbSet<DiseasesInfo> DiseasesInfos { get; set; }


    }
}
