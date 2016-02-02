using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class VENDOR_LOGIN
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int vendorlogin_ID { get; set; }

        public string vendor_email { get; set; }
        public string vendor_password { get; set; }

        public virtual ICollection<VENDOR_DATA> VENDOR_DATA { get; set; }
    }
}