using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TukangXpress_v2.Models
{
    public class PROJECT_MASTER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int project_ID { get; set; }

        [ForeignKey("CUSTOMER_DATA")]
        public int customerdata_ID { get; set; }

        public string project_category { get; set; }
        public DateTime project_duedate { get; set; }
        public string project_additionalinfo { get; set; }
        //public ? project_photo { get; set; }

        public virtual ICollection<BIDDER> BIDDER { get; set; }
        public virtual ICollection<REVIEW> REVIEW { get; set; }
        public virtual ICollection<TRANS_DETAILS> TRANS_DETAILS { get; set; }

        public virtual CUSTOMER_DATA CUSTOMER_DATA { get; set; }
    }
}