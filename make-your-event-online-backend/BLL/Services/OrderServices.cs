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
    internal class OrderServices
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);
        }

        public static OrderDTO Get(int id)
        {
            var data = DataAccessFactory.OrderDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<OrderDTO>(data);
        }

        public static OrderDTO Add(OrderDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDTO, Order>();
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Order>(data);
            var ret = DataAccessFactory.OrderDataAccess().Add(dbobj);
            return mapper.Map<OrderDTO>(ret);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderDataAccess().Delete(id);
        }

        public static OrderDTO Update(OrderDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDTO, Order>();
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Order>(data);
            var ret = DataAccessFactory.OrderDataAccess().Update(dbobj);
            return mapper.Map<OrderDTO>(ret);
        }

        public static OrderWithDetailDTO GetWithDetail(int id)
        {
            var data = DataAccessFactory.OrderDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderWithDetailDTO>();
                c.CreateMap<OrderDetail, OrderDetailDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<OrderWithDetailDTO>(data);
        }
    }
}
