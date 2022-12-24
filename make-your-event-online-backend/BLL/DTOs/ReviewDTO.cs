using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        [Required]
        public int Reating { get; set; }
        [Required]
        [StringLength(100)]
        public string Comment { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
