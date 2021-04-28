using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public DateTime ContributionDate { get; set; }
        public float Amount { get; set; }
        public virtual Event Event { get; set; }


        public virtual UserConsomi Users { get; set; }

        public Donation()
        {

        }
    }
}
