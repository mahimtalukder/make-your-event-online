using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class ShippingAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Address{ get; set; }
        [Required]
        [StringLength(50)]
        public string Tag { get; set; }
        [Required]
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public virtual Location Location { get; set; }  
        public virtual Customer Customer { get; set; }
        public virtual List<Order> Orders { get; set; }  

        public ShippingAddress()
        {
            Orders = new List<Order>();
        }
    }
}
