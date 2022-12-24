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
    public class AdminServices
    {
        public static UserAdminDTO AddAdmin(UserAdminDTO admin)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
                c.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var user = new UserDTO()
            {
                Username = admin.Username,
                Password = admin.Password,
                UserType = admin.UserType,
            };
            var dbuser = DataAccessFactory.UserDataAccess().Add(mapper.Map<User>(user));

            if (dbuser != null)
            {
                var organizer = new OrganizerDTO()
                {
                    Id = dbuser.Id,
                    Name = admin.Name,
                    Email = admin.Email,
                    Phone = admin.Phone,
                    Address = admin.Address,
                    ProfilePicture = admin.ProfilePicture,
                };
                var dbadmin = DataAccessFactory.AdminDataAccess().Add(mapper.Map<Admin>(admin));

                if (dbuser != null)
                {
                    UserAdminDTO data = new UserAdminDTO()
                    {
                        Id = dbuser.Id,
                        Username = dbuser.Username,
                        Password = dbuser.Password,
                        UserType = dbuser.UserType,
                        Name = admin.Name,
                        Email = admin.Email,
                        Phone = admin.Phone,
                        Address = admin.Address,
                        ProfilePicture = admin.ProfilePicture,
                    };
                    return data;
                }
                return null;


            }
            return null;

        }

        public static List<UserAdminDTO> Get()
        {
            var UserList = UserServices.Get();
            var adminList = DataAccessFactory.AdminDataAccess().Get();
            var UserAdminList = new List<UserAdminDTO>();


            foreach (var admin in adminList)
            {
                var User = (from u in UserList
                            where u.Id == admin.Id
                            select u).SingleOrDefault();

                UserAdminList.Add(new UserAdminDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    UserType = User.UserType,
                    Name = admin.Name,
                    Email = admin.Email,
                    Phone = admin.Phone,
                    ProfilePicture = admin.ProfilePicture,
                });
            }
            return UserAdminList;
        }
        public static UserAdminDTO Get(int id)
        {
            var User = UserServices.Get(id);
            var admin = DataAccessFactory.AdminDataAccess().Get(id);

            if (User != null && admin != null)
            {
                var adminUser = new UserAdminDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    UserType = User.UserType,
                    Name = admin.Name,
                    Email = admin.Email,
                    Phone = admin.Phone,
                    ProfilePicture = admin.ProfilePicture,
                };
                return adminUser;
            }
            return null;
        }


        public static UserAdminDTO Update(UserAdminDTO Useradmin)
        {

            var User = new UserDTO()
            {
                Id = Useradmin.Id,
                Username = Useradmin.Username,
                UserType = Useradmin.UserType,
            };

            var admin = new AdminDTO()
            {
                Id = Useradmin.Id,
                Name = Useradmin.Name,
                Email = Useradmin.Email,
                Phone = Useradmin.Phone,
                ProfilePicture = Useradmin.ProfilePicture

            };
            if (User != null && admin != null)
            {
                var NewAdminUser = new UserAdminDTO()
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    UserType = User.UserType,
                    Name = admin.Name,
                    Email = admin.Email,
                    Phone = admin.Phone,
                    ProfilePicture = admin.ProfilePicture,
                };
                return NewAdminUser;
            }
            return null;
        }

        public static bool Delete(int Id)
        {
            if (DataAccessFactory.AdminDataAccess().Delete(Id))
            {
                if (DataAccessFactory.UserDataAccess().Delete(Id))
                {
                    return true;
                }
            }
            return false; ;
        }


    }
}
