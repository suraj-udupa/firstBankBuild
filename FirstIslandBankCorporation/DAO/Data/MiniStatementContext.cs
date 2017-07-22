using DataObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MiniStatementContext : DbContext
    {
        public MiniStatementContext() : base("MiniStatementContext")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<MiniStatementContext, DAO.Migrations.Configuration>("MiniStatementContext"));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<UserAccounts> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
