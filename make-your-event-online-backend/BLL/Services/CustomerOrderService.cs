using BLL.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
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

        public static List<OrderDTO> AllCustomerOrders(int Id)
        {
            var Orders = OrderServices.Get();
            var ReturnOrders = (from o in Orders
                                where o.CustomerId == Id
                                select o).ToList();
            if (ReturnOrders.Count > 0) return ReturnOrders;
            return null;
        }

        public static CustomerOrderDTO CustomerOrderDetail(int Id)
        {
            var Order = OrderServices.Get(Id);
            var DetailList = OrderDetailService.GetByOrder(Id);
            var org = OrganizerServices.Get();
            var serv = ServiceServices.Get();
            var Services = (from d in DetailList
                            from s in serv
                            where s.Id == d.ServiceId
                            select s).ToList();
            var Organizer = (from s in Services
                             from o in org
                             where o.Id == s.OrganizerId
                             select new OrganizerDTO()
                             {      
                                 Id = o.Id,
                                 Name= o.Name,
                                 Email = o.Email,
                                 Phone = o.Phone,
                                 Address = o.Address,
                                 ProfilePicture = o.ProfilePicture
                             }).ToList();
            var shippingAddress = ShippingAddressServices.Get(Order.ShippingId);
            var ReturnObject = new CustomerOrderDTO
            {
                TotalPrice = Order.TotalPrice,
                ShippingAddress = shippingAddress.Address,
                OrderDate = Order.OrderDate,
                DeliveryDate = Order.DeliveryDate,
                Details = DetailList,
                Organizers = Organizer,
                Items = Services
            };
            return ReturnObject;

        }
    }
}
