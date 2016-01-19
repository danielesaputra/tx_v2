using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class CustomerData
    {
        public int ID { get; set; }
        public int Customer_Data_ID { get; set; }
        public int Customer_ID { get; set; }

        //public virtual MsCustomer CustID { get; set; }

        public string Facebook_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerDataDBContext : DbContext
    {
        public DbSet<CustomerData> CustomerDatas { get; set; }
    }
}