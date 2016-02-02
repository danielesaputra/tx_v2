using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class CUSTOMER_LOGIN
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int customerlogin_ID { get; set; }

        public string customer_email { get; set; }
        public string customer_password { get; set; }

        public virtual ICollection<CUSTOMER_DATA> CUSTOMER_DATA { get; set; }
    }
}