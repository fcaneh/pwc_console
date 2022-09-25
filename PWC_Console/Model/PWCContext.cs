using Microsoft.EntityFrameworkCore;
using PWC_Model.Model;

namespace PWC_Console.Model
{
    public class PWCContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Ledger> Ledger { get; set; }
        public DbSet<Entry> Entry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=BaseTest.db");
        }
    }
}
