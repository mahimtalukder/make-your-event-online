using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
