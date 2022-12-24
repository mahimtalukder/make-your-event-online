using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Division { get; set; }
        [StringLength(50)]
        public string District { get; set; }
        [StringLength(50)]
        public string Thana { get; set; }

        public virtual List<OrganizingArea> OrganizingAreas { get; set;}

        public virtual List<ShippingAddress> ShippingAddresses { get; set;}

        public Location()
        {
            OrganizingAreas= new List<OrganizingArea>();
            ShippingAddresses= new List<ShippingAddress>();
        }

    }
}
