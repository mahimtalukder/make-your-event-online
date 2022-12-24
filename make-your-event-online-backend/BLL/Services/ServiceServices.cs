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
    public class ServiceServices
    {
        public static List<ServiceDTO> Get()
        {
            var data = DataAccessFactory.ServiceDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Service, ServiceDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ServiceDTO>>(data);
        }

        public static ServiceDTO Get(int id)
        {
            var data = DataAccessFactory.ServiceDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Service, ServiceDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ServiceDTO>(data);
        }

        public static ServiceDTO Add(ServiceDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<ServiceDTO, Service>();
                c.CreateMap<Service, ServiceDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Service>(data);
            var ret = DataAccessFactory.ServiceDataAccess().Add(dbobj);
            return mapper.Map<ServiceDTO>(ret);
        }

        public static bool Delete(int id)
        {
            var orderdetail = OrderDetailService.Get();
            var order = OrderServices.Get();

            var serv = (from od in orderdetail
                        where od.ServiceId == id
                        select od).ToList();
            bool flag = true;
            foreach (var s in serv)
            {
                var or = (from o in order
                          where o.Id == s.Id
                          select o).SingleOrDefault();
                if (or.Status != 4)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                return DataAccessFactory.ServiceDataAccess().Delete(id);
            }
            return flag;
        }

        public static ServiceDTO Update(ServiceDTO data)
        {
            var orderdetail = OrderDetailService.Get();
            var order = OrderServices.Get();

            var serv = (from od in orderdetail
                        where od.ServiceId == data.Id
                        select od).ToList();
            bool flag = true;
            foreach (var s in serv)
            {
                var or = (from o in order
                          where o.Id == s.Id
                          select o).SingleOrDefault();
                if (or.Status != 4)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                var config = new MapperConfiguration(c => {
                    c.CreateMap<ServiceDTO, Service>();
                    c.CreateMap<Service, ServiceDTO>();
                });
                var mapper = new Mapper(config);
                var dbobj = mapper.Map<Service>(data);
                var ret = DataAccessFactory.ServiceDataAccess().Update(dbobj);
                return mapper.Map<ServiceDTO>(ret);
            }
            return null;
        }

        public static List<ServiceDTO> GetAllByUser(int Id)
        {
            var data = Get();
            var ServiceList = (from d in data
                               where d.OrganizerId == Id
                               select d).ToList();
            if(ServiceList.Count > 0) return ServiceList;
            return null;
        }


    }
}
