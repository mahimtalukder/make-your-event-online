using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static CustomerDTO Getlast()
        {
            var data = DataAccessFactory.CustomerDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var data2= mapper.Map<List<CustomerDTO>>(data);
            var last= data2.LastOrDefault();
            return last;    
            
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

        public static List<ServiceDTO> SearchService(string text)
        {
            var ServicesList = ServiceServices.Get();
            string[] textQuery = Array.ConvertAll(text.Split(new char[] { ' ', '-' }), d => d.ToLower());
            var result = new List<ServiceDTO>();
            foreach(string query in textQuery)
            {
                var list = (from s in ServicesList
                            where s.Name.ToLower().Contains(query)
                            select s).ToList();
                result.AddRange(list);
            }
            if(result.Count > 0) {
                return result.GroupBy(x => x.Id).Select(y => y.First()).ToList();
            }
            return null;
        }

    }
}
