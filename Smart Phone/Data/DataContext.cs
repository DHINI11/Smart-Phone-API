using Microsoft.EntityFrameworkCore;
using Smart_Phone.Model;

namespace Smart_Phone.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MobileModel> Mobiles { get; set; }
    }
}
