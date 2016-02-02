using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class TRANS_DETAILS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int trans_ID { get; set; }

        [ForeignKey("VENDOR_DATA")]
        public int vendordata_ID { get; set; }

        [ForeignKey("PROJECT_MASTER")]
        public int project_ID { get; set; }

        public virtual VENDOR_DATA VENDOR_DATA { get; set; }
        public virtual PROJECT_MASTER PROJECT_MASTER { get; set; }
    }
}