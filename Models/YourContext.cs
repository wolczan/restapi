using Microsoft.EntityFrameworkCore;

namespace RestApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        // Define your DbSets here
        // public DbSet<YourModel> YourModels { get; set; }
    }
}
