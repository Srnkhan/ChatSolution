using ChatCore.Configuration;
using ChatDb.DbConfigurations;
using ChatModals.DbModal;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatDb
{
    public class MainDbContext : DbContext
    {
        public readonly string _connectionString = string.Empty;

        public MainDbContext()
        {
            _connectionString = ConfigurationManager.GetInstance().GetConnectionString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlServer(_connectionString);
#endif
#if Release
    //asd
#endif
#if DebugMySql
            optionsBuilder.UseMySql(connectionString: _connectionString,            
            mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend));
#endif
#if ReleaseMySql
       //asd     
#endif

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ChannelConfiguration();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<Channel> Channel { get; set; }

    }
}
