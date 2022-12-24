using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LocationDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Division { get; set; }
        [StringLength(50)]
        public string District { get; set; }
        [StringLength(50)]
        public string Thana { get; set; }
    }
}
