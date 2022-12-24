﻿using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrganizerServices
    {
        public static List<UserOrganizerDTO> Get()
        {
            var UserList = UserServices.Get();
            var OrganizerList = DataAccessFactory.OrganizerDataAccess().Get();
            var UserOrganizerList = new List<UserOrganizerDTO>();


            foreach (var Organizer in OrganizerList)
            {
                var User = (from u in UserList
                            where u.Id == Organizer.Id
                            select u).SingleOrDefault();

                UserOrganizerList.Add(new UserOrganizerDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    UserType = User.UserType,
                    Name = Organizer.Name,
                    Email = Organizer.Email,
                    Phone = Organizer.Phone,
                    Address = Organizer.Address,
                    ProfilePicture = Organizer.ProfilePicture,
                });
            }
            return UserOrganizerList;
        }

        public static UserOrganizerDTO Get(int id)
        {
            var User = UserServices.Get(id);
            var Organizer = DataAccessFactory.OrganizerDataAccess().Get(id);

            if (User != null && Organizer != null)
            {
                var OrganizerUser = new UserOrganizerDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    UserType = User.UserType,
                    Name = Organizer.Name,
                    Email = Organizer.Email,
                    Phone = Organizer.Phone,
                    Address = Organizer.Address,
                    ProfilePicture = Organizer.ProfilePicture
                };
                return OrganizerUser;
            }
            return null;
        }

        public static UserOrganizerDTO Add(UserOrganizerDTO OrganizerData)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
                c.CreateMap<OrganizerDTO, Organizer>();
                c.CreateMap<LogDTO, Log>();
            });
            var mapper = new Mapper(config);
            var user = new UserDTO()
            {
                Username = OrganizerData.Username,
                Password = OrganizerData.Password,
                UserType = OrganizerData.UserType,
            };
            var dbuser = DataAccessFactory.UserDataAccess().Add(mapper.Map<User>(user));

            if(dbuser != null)
            {
                var organizer = new OrganizerDTO()
                {
                    Id = dbuser.Id,
                    Name = OrganizerData.Name,
                    Email = OrganizerData.Email,
                    Phone = OrganizerData.Phone,
                    Address = OrganizerData.Address,
                    ProfilePicture = OrganizerData.ProfilePicture,
                };
                var dbornizer = DataAccessFactory.OrganizerDataAccess().Add(mapper.Map<Organizer>(organizer));

                if (dbuser != null)
                {
                    UserOrganizerDTO data = new UserOrganizerDTO()
                    {
                        Id = dbuser.Id,
                        Username = dbuser.Username,
                        Password = dbuser.Password,
                        UserType = dbuser.UserType,
                        Name = organizer.Name,
                        Email = organizer.Email,
                        Phone = organizer.Phone,
                        Address = organizer.Address,
                        ProfilePicture = organizer.ProfilePicture,
                    };

                    var log = new LogDTO()
                    {
                        ActionId = 6,
                        CreateTime = DateTime.Now,
                        UserId = dbuser.Id
                    };
                    DataAccessFactory.LogDataAccess().Add(mapper.Map<Log>(log));

                    return data;
                }
                return null;

               
            }
            return null;


           

        }

        public static UserOrganizerDTO Update(UserOrganizerDTO organizerUser)
        {
            var User = new UserDTO()
            {
                Id = organizerUser.Id,
                Username = organizerUser.Username,
                UserType = organizerUser.UserType,
            };

            var Organizer = new OrganizerDTO()
            {
                Id = organizerUser.Id,
                Name = organizerUser.Name,
                Email = organizerUser.Email,
                Phone = organizerUser.Phone,
                Address = organizerUser.Address,
                ProfilePicture = organizerUser.ProfilePicture

            };
            if (User != null && Organizer != null)
            {
                var NewOrganizerUser = new UserOrganizerDTO()
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    UserType = User.UserType,
                    Name = Organizer.Name,
                    Email = Organizer.Email,
                    Phone = Organizer.Phone,
                    Address = Organizer.Address,
                    ProfilePicture = Organizer.ProfilePicture,
                };
                return NewOrganizerUser;
            }
            return null;
        }

        public static bool Delete(int Id)
        {
            if (DataAccessFactory.OrganizerDataAccess().Delete(Id))
            {
                if (DataAccessFactory.UserDataAccess().Delete(Id))
                {
                    return true;
                }
            }
            return false;
        }

        public static double GetTotalRevenue(int id)
        {
            var serv = ServiceServices.Get();
            var orgServ = (from s in serv
                           where s.OrganizerId == id
                           select s).ToList();
            if (orgServ.Count > 0)
            {
                var orderDetail = OrderDetailService.Get();
                var detail = (from org in orgServ
                              from od in orderDetail
                              where od.ServiceId == org.Id && od.Status == 4
                              select od.Price).ToArray();
                if(detail.Length>0)
                {
                    return detail.Sum();
                }
            }
            return 0;
        }

        public static List<OrderDetailDTO> GetTotalPending(int id)
        {
            var services = ServiceServices.Get();
            var details = OrderDetailService.Get();
            var det = (from s in services
                       where s.OrganizerId == id
                       from d in details
                       where d.ServiceId == s.Id && d.Status == 1
                       select d).ToList();
            if (det.Count > 0)
            {
                object[,] array = new object[det.Count, 3];
                var count = 0;
                foreach (var item in det)
                {
                    var service = ServiceServices.Get(item.ServiceId);
                    var order = OrderServices.Get(item.OrderId);
                    array[count, 0] = det;
                    array[count, 1] = order;
                    array[count, 2] = det;
                    count++;
                }
                return det;
            }
            return null;
        }
    }
}
