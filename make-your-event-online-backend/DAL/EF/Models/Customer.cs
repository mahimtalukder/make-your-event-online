using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Customer
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
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public string ProfilePicture { get; set; }
        public int ShippingAreaId { get; set; }

        public virtual User User { get; set; } 
        public virtual List<Order> Orders { get; set; }
        public virtual List<ShippingAddress> ShippingAddresses { get; set; }
        public virtual List<Review> Reviews { get; set; }   

        public Customer() 
        {
            Orders = new List<Order>();
            ShippingAddresses= new List<ShippingAddress>();
            Reviews = new List<Review>();
        }
    }
}
