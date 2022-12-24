using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(12)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string UserType { get; set; }

        public virtual Admin Admin { get; set; }    
        public virtual Organizer Organizer { get; set; }
        public virtual Customer Customer { get; set; }  

        public virtual List<Log> Logs { get; set; }
        public virtual List<Token> Tokens { get; set; }
        public User()
        {
            Tokens = new List<Token>();
            Logs = new List<Log>();
        }


    }
}
