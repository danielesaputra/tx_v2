using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class VENDOR_DATA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int vendordata_ID { get; set; }

        [ForeignKey("VENDOR_LOGIN")]
        public int vendorlogin_ID { get; set; }

        public string vendor_name { get; set; }
        public string vendor_ownername { get; set; }
        public string vendor_phone { get; set; }
        public string vendor_address { get; set; }
        public int vendor_balance { get; set; }

        public virtual ICollection<BIDDER> BIDDER { get; set; }
        public virtual ICollection<TRANS_DETAILS> TRANS_DETAILS { get; set; }
        public virtual ICollection<REVIEW> REVIEW { get; set; }

        public virtual VENDOR_LOGIN VENDOR_LOGIN { get; set; }
    }
}