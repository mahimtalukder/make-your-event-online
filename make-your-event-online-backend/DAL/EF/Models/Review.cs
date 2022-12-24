using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Review
    {
        [Key]
        [ForeignKey("OrderDetail")]
        public int Id { get; set; }
        [Required]
        public int Reating{ get; set; }
        [Required]
        [StringLength(100)]
        public string Comment{ get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }

    }
}
