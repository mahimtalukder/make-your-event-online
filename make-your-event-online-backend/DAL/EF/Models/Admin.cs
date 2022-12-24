using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Admin
    {
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
        public string ProfilePicture { get; set; }

        public virtual User User { get; set; }
    }
}
