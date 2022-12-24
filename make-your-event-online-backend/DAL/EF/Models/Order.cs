using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("ShippingAddress")]
        public int? ShippingId { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

    }
}
