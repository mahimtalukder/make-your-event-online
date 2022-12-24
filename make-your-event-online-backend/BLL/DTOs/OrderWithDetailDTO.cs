using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    internal class OrderWithDetailDTO
    {
        public virtual List<OrderDetailDTO> OrderDetails { get; set; }
        public OrderWithDetailDTO()
        {
            OrderDetails = new List<OrderDetailDTO>();
        }
    }
}
