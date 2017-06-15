using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using DistributedPokerHelper.Entities;

namespace DistributedPokerHelper.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(): base("ApplicationContext") { }

        public DbSet<TournamentEntity> TournamentEntitySet { get; set; }
        public DbSet<BlindRoundEntity> BlindRoundEntitySet { get; set; }
        public DbSet<PlayerEntity> PlayerEntitySet { get; set; }
        public DbSet<TableEntity> TableEntitySet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Migrations.Configuration>());
        }
    }
}