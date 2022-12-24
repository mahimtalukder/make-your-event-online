using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        public int CustomerId { get; set; }
        public int ShippingId { get; set; }
    }
}
