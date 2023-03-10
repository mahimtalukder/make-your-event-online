using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
