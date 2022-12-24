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
    public class OrganizingAreaServices
    {
        public static List<OrganizingAreaDTO> Get()
        {
            var data = DataAccessFactory.OrganizingAreaDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrganizingArea, OrganizingAreaDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrganizingAreaDTO>>(data);
        }

        public static OrganizingAreaDTO Get(int id)
        {
            var data = DataAccessFactory.OrganizingAreaDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrganizingArea, OrganizingAreaDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<OrganizingAreaDTO>(data);
        }

        public static OrganizingAreaDTO Add(OrganizingAreaDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrganizingAreaDTO, OrganizingArea>();
                c.CreateMap<OrganizingArea, OrganizingAreaDTO>();
                c.CreateMap<LogDTO, Log>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<OrganizingArea>(data);
            var ret = DataAccessFactory.OrganizingAreaDataAccess().Add(dbobj);
            if(ret != null)
            {
                var log = new LogDTO()
                {
                    ActionId = 14,
                    CreateTime = DateTime.Now,
                    UserId = ret.OrganizerId,
                };
                DataAccessFactory.LogDataAccess().Add(mapper.Map<Log>(log));
                return mapper.Map<OrganizingAreaDTO>(ret);
            }
            return null;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.OrganizingAreaDataAccess().Delete(id);
        }

        public static OrganizingAreaDTO Update(OrganizingAreaDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrganizingAreaDTO, OrganizingArea>();
                c.CreateMap<OrganizingArea, OrganizingAreaDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<OrganizingArea>(data);
            var ret = DataAccessFactory.OrganizingAreaDataAccess().Update(dbobj);
            return mapper.Map<OrganizingAreaDTO>(ret);
        }
    }
}
