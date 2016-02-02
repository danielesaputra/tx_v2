using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class BIDDER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int bidder_ID { get; set; }

        [ForeignKey("VENDOR_DATA")]
        public int vendordata_ID { get; set; }

        [ForeignKey("PROJECT_MASTER")]
        public int project_ID { get; set; }

        public int ammount { get; set; }
        public bool winning_status { get; set; }

        public virtual VENDOR_DATA VENDOR_DATA { get; set; }
        public virtual PROJECT_MASTER PROJECT_MASTER { get; set; }
    }
}