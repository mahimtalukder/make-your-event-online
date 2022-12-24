using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerServices
    {
        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CustomerDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CustomerDTO>>(data);
        }

        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CustomerDTO>(data);
        }

        public static CustomerDTO Add(CustomerDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Customer>(data);
            var ret = DataAccessFactory.CustomerDataAccess().Add(dbobj);
            return mapper.Map<CustomerDTO>(ret);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CustomerDataAccess().Delete(id);
        }
        
        public static CustomerDTO Update(CustomerDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Customer>(data);
            var ret = DataAccessFactory.CustomerDataAccess().Update(dbobj);
            return mapper.Map<CustomerDTO>(ret);
        }

    }
}
