using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double PricePerUnit { get; set; }
        [Required]
        public DateTime TentativeDeliveryDate { get; set; }
        [Required]
        public int ThumbnailId { get; set; }
        [Required]
        public int Availability { get; set; }
        [Required]
        [ForeignKey("Organizer")]
        public int OrganizerId { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Organizer Organizer { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<ServiceCatalog> ServiceCatalogs { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
        public Service()
        {
            ServiceCatalogs= new List<ServiceCatalog>();
            OrderDetails= new List<OrderDetail>();
        }
    }
}
