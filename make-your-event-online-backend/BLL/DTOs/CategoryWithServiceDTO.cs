using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryWithServiceDTO
    {
        public virtual List<Service> Services { get; set; }
        public CategoryWithServiceDTO()
        {
            Services = new List<Service>();
        }
    }
}
