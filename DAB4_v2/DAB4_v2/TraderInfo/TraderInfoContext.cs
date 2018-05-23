using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB4.Models;

namespace TraderInfo
{
    public class TraderInfoContext : DbContext
    {
        public TraderInfoContext() : base("name=production_I4DABGr13")
        {
        }

        public DbSet<TransferWindow> TransferWindows { get; set; }
        public DbSet<Trade> Trades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransferWindow>()
                .HasMany(a => a.Trades)
                .WithOptional() // or `WithRequired() in case Car requires Person
                .WillCascadeOnDelete(true);
        }
    }
}
