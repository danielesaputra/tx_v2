using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class MsCustomer
    {
        public int ID { get; set; }
        public int Customer_ID { get; set; }
        public string Customer_Email { get; set; }
        public int Customer_Balance { get; set; }
        public int Reward_Point { get; set; }
        public string Password { get; set; }
    }

    public class MsCustomerDBContext : DbContext
    {
        public DbSet<MsCustomer> MsCustomers { get; set; }
    }
}