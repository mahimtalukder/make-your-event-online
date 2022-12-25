using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL.Services
{
    public class OrderDetailService
    {
        public static List<OrderDetailDTO> Get()
        {
            var data = DataAccessFactory.OrderDetailDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDetailDTO>>(data);
        }

        public static OrderDetailDTO Get(int id)
        {
            var data = DataAccessFactory.OrderDetailDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<OrderDetailDTO>(data);
        }

        public static OrderDetailDTO Add(OrderDetailDTO data, string Username)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDetailDTO, OrderDetail>();
                c.CreateMap<OrderDetail, OrderDetailDTO>();
                c.CreateMap<LogDTO, Log>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<OrderDetail>(data);
            var ret = DataAccessFactory.OrderDetailDataAccess().Add(dbobj);
            if (ret != null)
            {
                var user = UserServices.GetByUsername(Username);
                var log = new LogDTO()
                {
                    ActionId = 13,
                    CreateTime = DateTime.Now,
                    UserId = user.Id
                };
                DataAccessFactory.LogDataAccess().Add(mapper.Map<Log>(log));
                return mapper.Map<OrderDetailDTO>(ret);
            }
            return null;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderDetailDataAccess().Delete(id);
        }

        public static OrderDetailDTO Update(OrderDetailDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDetailDTO, OrderDetail>();
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<OrderDetail>(data);
            var ret = DataAccessFactory.OrderDetailDataAccess().Update(dbobj);
            return mapper.Map<OrderDetailDTO>(ret);
        }

        public static List<OrderDetailDTO> SingleService(int id)
        {
            var AllDetails = OrderDetailService.Get();
            var DetailByService = (from od in AllDetails
                                   where od.ServiceId == id
                                   select od).ToList();
            if (DetailByService.Count > 0) return DetailByService;
            return null;
        }

        public static List<OrderDetailDTO> AllService(List<ServiceDTO> services)
        {
            var DetailByService = new List<OrderDetailDTO>();
            foreach (var Service in services)
            {
                var ServiceDetails = SingleService(Service.Id);
                if (ServiceDetails != null) DetailByService.AddRange(ServiceDetails);
            }
            if(DetailByService.Count > 0) return DetailByService;
            return null;
        }

        public static List<OrderDetailDTO> GetByOrder(int Id)
        {
            var DetailList = OrderDetailService.Get();
            var ReturnList = (from od in DetailList
                              where od.OrderId == Id
                              select od).ToList();
            if(ReturnList.Count > 0) return ReturnList;
            return null;
        }

        public static List<OrderDetailDTO> GetByOrganizer(int Id)
        {
            var DetailListDB = OrderDetailService.Get();
            var ServiceDB = ServiceServices.GetAllByUser(Id);

            var DetailList = (from service in ServiceDB
                              from detail in DetailListDB
                              where detail.ServiceId == service.Id
                              select detail).ToList();  
            if(DetailList.Count> 0) return DetailList;
            return null;
        }

    }
}
