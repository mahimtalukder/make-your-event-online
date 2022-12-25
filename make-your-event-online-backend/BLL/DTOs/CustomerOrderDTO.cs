using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerOrderDTO
    {
        public virtual List<ServiceDTO> Items { get; set; }
        public List<OrderDetailDTO> Details { get; set; }
        public List<OrganizerDTO> Organizers { get; set; }
        public double TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int ShippingId { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public CustomerOrderDTO()
        {
            Items = new List<ServiceDTO>();
            Organizers = new List<OrganizerDTO>();
            Details = new List<OrderDetailDTO>();
        }


    }
}
