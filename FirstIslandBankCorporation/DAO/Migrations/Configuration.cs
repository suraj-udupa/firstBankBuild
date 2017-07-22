namespace DAO.Migrations
{
    using Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAO.MiniStatementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAO.MiniStatementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Accounts.AddOrUpdate(a => a.AccountId, MockData.GetAccounts().ToArray());
            //context.SaveChanges();

            //context.Users.AddOrUpdate(u => u.UserId, MockData.GetUsers().ToArray());
            //context.SaveChanges();

            //context.Transactions.AddOrUpdate(t => t.TransactionId, MockData.GetTransactions(context).ToArray());
            //context.SaveChanges();

            //context.UserAccounts.AddOrUpdate(ua => ua.Id, MockData.GetUserAccounts(context).ToArray());
            //context.SaveChanges();
        }
    }
}
