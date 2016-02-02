using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class CUSTOMER_DATA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int customerdata_ID { get; set; }

        [ForeignKey("CUSTOMER_LOGIN")]
        public int customerlogin_ID { get; set; }

        //public ? customer_photo { get; set; }
        public string customer_firstname { get; set; }
        public string customer_lastname { get; set; }
        public DateTime customer_birthdate { get; set; }
        public string customer_phone { get; set; }
        public string customer_address { get; set; }
        public string customer_facebook { get; set; }
        public int customer_balance { get; set; }
        public int customer_rewardpt { get; set; }

        public virtual ICollection<PROJECT_MASTER> PROJECT_MASTER { get; set; }

        public virtual CUSTOMER_LOGIN CUSTOMER_LOGIN { get; set; }
    }
}