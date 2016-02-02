using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TukangXpress_v2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TukangXpress_v2.DAL
{
    public class TXContext : DbContext
    {
        public TXContext() : base("TXContext")
        {
        }

        public DbSet<CUSTOMER_LOGIN> CUSTOMER_LOGIN { get; set; }
        public DbSet<CUSTOMER_DATA> CUSTOMER_DATA { get; set; }
        public DbSet<VENDOR_LOGIN> VENDOR_LOGIN { get; set; }
        public DbSet<VENDOR_DATA> VENDOR_DATA { get; set; }
        public DbSet<PROJECT_MASTER> PROJECT_MASTER { get; set; }
        public DbSet<BIDDER> BIDDER { get; set; }
        public DbSet<TRANS_DETAILS> TRANS_DETAILS { get; set; }
        public DbSet<REVIEW> REVIEW { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}