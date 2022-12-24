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
    public class LocationServices
    {
        public static List<LocationDTO> Get()
        {
            var data = DataAccessFactory.LocationDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Location, LocationDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<LocationDTO>>(data);
        }

        public static LocationDTO Get(int id)
        {
            var data = DataAccessFactory.LocationDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Location, LocationDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<LocationDTO>(data);
        }

        public static LocationDTO Add(LocationDTO data, string Username)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<LocationDTO, Location>();
                c.CreateMap<Location, LocationDTO>();
                c.CreateMap<LogDTO, Log>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Location>(data);
            var ret = DataAccessFactory.LocationDataAccess().Add(dbobj);
            if(ret != null)
            {
                var user = UserServices.GetByUsername(Username);
                var log = new LogDTO()
                {
                    ActionId = 13,
                    CreateTime = DateTime.Now,
                    UserId = user.Id
                };
                DataAccessFactory.LogDataAccess().Add(mapper.Map<Log>(log));
                return mapper.Map<LocationDTO>(ret);
            }
            return null;    
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.LocationDataAccess().Delete(id);
        }

        public static LocationDTO Update(LocationDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<LocationDTO, Location>();
                c.CreateMap<Location, LocationDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Location>(data);
            var ret = DataAccessFactory.LocationDataAccess().Update(dbobj);
            return mapper.Map<LocationDTO>(ret);
        }
    }
}
