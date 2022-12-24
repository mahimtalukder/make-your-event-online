using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrganizingAreaDTO
    {

        public int Id { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int OrganizerId { get; set; }
        [Required]
        public bool MainArea { get; set; }
    }
}
