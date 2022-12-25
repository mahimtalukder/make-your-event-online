using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BLL.Services
{
    public class CustomerOrderService
    {
        public static bool NewOrder(CustomerOrderDTO obj)
        {
            if (obj != null)
            {
                double Total = 0;
                var Custom = UserServices.Get(obj.CustomerId);
                foreach(var item in obj.Items)
                {
                    Total += item.PricePerUnit;
                }

                var OrderObj = new OrderDTO()
                {
                    TotalPrice = Total,
                    OrderDate = System.DateTime.Now.Date,
                    Status = 1,
                    DeliveryDate = obj.DeliveryDate.Date,
                    CustomerId = obj.CustomerId,
                    ShippingId = obj.ShippingId
                };
                var retOrder = OrderServices.Add(OrderObj);
                if(retOrder != null)
                {
                    var ReturnOrderDetail = new List<OrderDetailDTO>();
                    foreach(var item in obj.Items)
                    {
                        var OrderDetailObj = new OrderDetailDTO()
                        {
                            OrderId = retOrder.Id,
                            ServiceId = item.Id,
                            Price = item.PricePerUnit,
                            Status = 1
                        };

                        ReturnOrderDetail.Add(OrderDetailService.Add(OrderDetailObj,Custom.Username));
                    }
                    if(obj.Items.Count == ReturnOrderDetail.Count) 
                    {
                        return true;
                    }
                    return false;
                }
                return false;

            }
            return false;
        }
    }
}
