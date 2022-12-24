using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OrganizingArea
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("Organizer")]
        public int OrganizerId { get; set; }
        [Required]
        public bool MainArea { get; set; }

        public virtual Organizer Organizer { get; set; }    
        public virtual Location Location { get; set; }

    }
}
