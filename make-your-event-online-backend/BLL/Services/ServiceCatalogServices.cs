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
    public class ServiceCatalogServices
    {
        public static ServiceCatalogDTO Add(ServiceCatalogDTO action)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceCatalogDTO, ServiceCatalog>();
                c.CreateMap<ServiceCatalog, ServiceCatalogDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<ServiceCatalog>(action);
            var rt = DataAccessFactory.ServiceCatalogDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<ServiceCatalogDTO>(rt);
            }
            return null;
        }

        public static List<ServiceCatalogDTO> Get()
        {
            var data = DataAccessFactory.ServiceCatalogDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceCatalog, ServiceCatalogDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<ServiceCatalogDTO>>(data);
        }
        public static ServiceCatalogDTO Get(int id)
        {
            var data = DataAccessFactory.ServiceCatalogDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceCatalog, ServiceCatalogDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ServiceCatalogDTO>(data);
        }


        public static ServiceCatalogDTO Update(ServiceCatalogDTO action)
        {

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceCatalogDTO, ServiceCatalog>();
                c.CreateMap<ServiceCatalog, ServiceCatalogDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<ServiceCatalog>(action);
            var rt = DataAccessFactory.ServiceCatalogDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<ServiceCatalogDTO>(rt);
            }
            return null;
        }

        public static ServiceCatalogDTO Delete(int id)
        {
            var data = DataAccessFactory.ServiceCatalogDataAccess().Delete(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceCatalog, ServiceCatalogDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ServiceCatalogDTO>(data);
        }
    }
}
