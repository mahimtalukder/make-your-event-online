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
    public class UserServices
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data);
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserDTO>(data);
        }

        public static UserDTO GetByUsername(string username)
        {
            var data = DataAccessFactory.AuthDataAccess().GetUser(username);
            var config = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserDTO>(data);
        }

        public static UserDTO Add(UserDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<User>(data);
            var ret = DataAccessFactory.UserDataAccess().Add(dbobj);
            return mapper.Map<UserDTO>(ret);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }

        public static UserDTO Update(UserDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<User>(data);
            var ret = DataAccessFactory.UserDataAccess().Update(dbobj);
            return mapper.Map<UserDTO>(ret);
        }
    }
}
