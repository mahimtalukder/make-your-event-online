using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Service Service { get; set; }
        public virtual Order Order { get; set; }
        public virtual Review Review { get; set; }


    }
}
