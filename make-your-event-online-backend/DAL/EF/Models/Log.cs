using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("ActionList")]
        public int ActionId{ get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual ActionList ActionList { get; set; }
        public virtual User User { get; set; }
    }
}
