using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class REVIEW
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int review_ID { get; set; }

        [ForeignKey("VENDOR_DATA")]
        public int vendordata_ID { get; set; }

        [ForeignKey("PROJECT_MASTER")]
        public int project_ID { get; set; }

        public string details { get; set; }
        public int point { get; set; }

        public virtual VENDOR_DATA VENDOR_DATA { get; set; }
        public virtual PROJECT_MASTER PROJECT_MASTER { get; set; }
    }
}