using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Organizer
    {
        /*[Key]
        [ForeignKey("User")]
        public string Username { get; set; }*/

        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required]
        [StringLength(14)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public string ProfilePicture { get; set; }
        //[ForeignKey("Location")]
        //public int LocationId { get; set; }
        //public virtual Location Location { get; set; }

        public virtual User User { get; set; } 
        public virtual List<Service> Services { get; set; }
        public virtual List<OrganizingArea> OrganizingAreas { get; set; }   

        public Organizer()
        {   
            Services = new List<Service>();
            OrganizingAreas = new List<OrganizingArea>();
        }
    }
}
