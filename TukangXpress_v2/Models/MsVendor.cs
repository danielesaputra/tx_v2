using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class MsVendor
    {
        public int ID { get; set; }
        public int Vendor_ID { get; set; }
        public string Vendor_Email { get; set; }
        public int Vendor_Balance { get; set; }
        public string Password { get; set; }
    }

    public class MsVendorDBContext : DbContext
    {
        public DbSet<MsVendor> MsVendors { get; set; }
    }
}