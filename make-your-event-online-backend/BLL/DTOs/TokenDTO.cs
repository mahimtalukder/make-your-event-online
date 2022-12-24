using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        [Required]
        public string LoginToken { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpDate { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
