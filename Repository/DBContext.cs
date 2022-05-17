using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<User> User => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuidler)
        {
            base.OnModelCreating(modelBuidler);

            //var user = modelBuidler.Entity<User>();
        }
    }
}
