using cannabis_entities.Models;
using Microsoft.EntityFrameworkCore;

namespace cannabis_web_api.Data 

{
    public class AppDbContext : DbContext

    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Report> Reports { get; set; }

        // other models, define DbSets for them here as well

        // public DbSet<OtherModel> OtherModels { get; set; }

    }

}
