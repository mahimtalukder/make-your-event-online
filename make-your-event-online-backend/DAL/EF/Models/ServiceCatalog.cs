using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class ServiceCatalog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        [Required]
        public string Source{ get; set; }
        [Required]
        public bool IsThumbnail { get; set; }

        public virtual Service Service { get; set; }
    }
}
