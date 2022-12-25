using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Models;
using System.Security.Cryptography.X509Certificates;

namespace BLL.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double PricePerUnit { get; set; }
        [Required]
        public int TentativeDeliveryDate { get; set; }
        public int ThumbnailId { get; set; }
        [Required]
        public int Availability { get; set; }
        [Required]
        public int OrganizerId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
