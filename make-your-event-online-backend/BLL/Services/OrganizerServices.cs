using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.Font;

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
            var orgServ = ServiceServices.GetAllByUser(id);
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

        public static object GetPending(int id)
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
                    array[count, 0] = service;
                    array[count, 1] = order;
                    array[count, 2] = det;
                    count++;
                }
                return array;
            }
            return null;
        }

        public static object GetConfirmed(int id)
        {
            var services = ServiceServices.Get();
            var details = OrderDetailService.Get();
            var det = (from s in services
                       where s.OrganizerId == id
                       from d in details
                       where d.ServiceId == s.Id && d.Status == 2
                       select d).ToList();
            if (det.Count > 0)
            {
                object[,] array = new object[det.Count, 3];
                var count = 0;
                foreach (var item in det)
                {
                    var service = ServiceServices.Get(item.ServiceId);
                    var order = OrderServices.Get(item.OrderId);
                    array[count, 0] = service;
                    array[count, 1] = order;
                    array[count, 2] = det;
                    count++;
                }
                return array;
            }
            return null;
        }

        public static object GetShipping(int id)
        {
            var services = ServiceServices.Get();
            var details = OrderDetailService.Get();
            var det = (from s in services
                       where s.OrganizerId == id
                       from d in details
                       where d.ServiceId == s.Id && d.Status == 3
                       select d).ToList();
            if (det.Count > 0)
            {
                object[,] array = new object[det.Count, 3];
                var count = 0;
                foreach (var item in det)
                {
                    var service = ServiceServices.Get(item.ServiceId);
                    var order = OrderServices.Get(item.OrderId);
                    array[count, 0] = service;
                    array[count, 1] = order;
                    array[count, 2] = det;
                    count++;
                }
                return array;
            }
            return null;
        }

        public static object GetCompleted(int id)
        {
            var services = ServiceServices.Get();
            var details = OrderDetailService.Get();
            var det = (from s in services
                       where s.OrganizerId == id
                       from d in details
                       where d.ServiceId == s.Id && d.Status == 4
                       select d).ToList();
            if (det.Count > 0)
            {
                object[,] array = new object[det.Count, 3];
                var count = 0;
                foreach (var item in det)
                {
                    var service = ServiceServices.Get(item.ServiceId);
                    var order = OrderServices.Get(item.OrderId);
                    array[count, 0] = service;
                    array[count, 1] = order;
                    array[count, 2] = det;
                    count++;
                }
                return array;
            }
            return null;
        }
        /*
        public static object GenerateReport(int id) // id = organizer id
        {
            var organizer = OrganizerServices.Get(id);
            var services = ServiceServices.GetAllByUser(id);
            if (services.Count <= 0) return null; 
            var detailsDB = OrderDetailService.AllService(services);
            if(detailsDB.Count <= 0) return null;
            var orderDB = OrderServices.Get();
            var cutoff = DateTime.Now.Date.AddDays(-7);
            var orders = (from det in detailsDB
                          from o in orderDB
                          where o.Id == det.OrderId
                          select o).ToList();
            orders.RemoveAll(o => o.OrderDate < cutoff);
            if(orders.Count <= 0) return null;
            var details = (from o in orders
                           from det in detailsDB
                           where det.OrderId == o.Id
                           select det).ToList();
            if(details.Count<= 0) return null;
            using(MemoryStream ms = new MemoryStream())
            {
                Document report = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(report, ms);
                report.Open();

                Paragraph title = new Paragraph("Organize Your Event Online", new Font(FontFamily.TIMES_ROMAN, 24, Font.BOLD, BaseColor.BLACK));
                title.SpacingAfter = 20;
                report.Add(title);

                PdfPTable UserInfo = new PdfPTable(2);

                PdfPCell nameCell = new PdfPCell(new Phrase("Name: " + organizer.Name, new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                nameCell.Border = Rectangle.NO_BORDER;
                nameCell.HorizontalAlignment = Element.ALIGN_LEFT;
                nameCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(nameCell);

                PdfPCell dateCell = new PdfPCell(new Phrase("Date: " + DateTime.Now.Date.ToString(), new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                dateCell.Border = Rectangle.NO_BORDER;
                dateCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                dateCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(dateCell);

                PdfPCell EmailCell = new PdfPCell(new Phrase("Email: " + organizer.Email, new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                EmailCell.Border = Rectangle.NO_BORDER;
                EmailCell.HorizontalAlignment = Element.ALIGN_LEFT;
                EmailCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(EmailCell);

                PdfPCell BlankCell = new PdfPCell(new Phrase("\u00a0"));
                BlankCell.Border = Rectangle.NO_BORDER;
                BlankCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                BlankCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(BlankCell);

                PdfPCell PhoneCell = new PdfPCell(new Phrase("Email: " + organizer.Phone, new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                EmailCell.Border = Rectangle.NO_BORDER;
                EmailCell.HorizontalAlignment = Element.ALIGN_LEFT;
                EmailCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(EmailCell);

                UserInfo.AddCell(BlankCell);
                report.Add(UserInfo);

                PdfPTable DetailInfo = new PdfPTable(4);
                PdfPCell Serial = new PdfPCell(new Phrase("Serial", new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                Serial.BackgroundColor = BaseColor.
                UserInfo.AddCell(Serial);


            }

        }*/

        public static int TotalServiceOrders(int id)
        {
            var details = OrderDetailService.SingleService(id);
            if (details == null)
            {
                return 0;
            }
            return details.Count;
        }

        public static List<OrderDetailDTO> AllServiceOrders(int id)
        {
            var details = OrderDetailService.SingleService(id);
            if (details.Count > 0) return details;
            return null;
        }

        public static object GetLastMonthDetail(int id)
        {
            var DetailDb = OrderDetailService.GetByOrganizer(id);
            if (DetailDb == null) return null;
            var OrderDb = OrderServices.Get();
            if (OrderDb == null) return null;
            var cutOff = System.DateTime.Now.AddDays(-30);
            OrderDb.RemoveAll(x => x.OrderDate < cutOff);
            if(OrderDb == null) return null;

            var Orders = (from det in DetailDb
                          from od in OrderDb
                          where od.Id == det.OrderId
                          select od).ToList();
            if(Orders.Count <= 0) return null;

            var Details = (from od in OrderDb
                           from Det in DetailDb
                           where Det.OrderId == od.Id
                           select Det).ToList();

            List<DetailReportDTO> ReturnObj = new List<DetailReportDTO>();

            for (DateTime currDate = DateTime.Now; currDate < cutOff; currDate.AddDays(-1))
            {
                var order = (from o in Orders
                             where DbFunctions.TruncateTime(o.OrderDate) == DbFunctions.TruncateTime(currDate)
                             select o).ToList();
                var detCount = (from o in Orders
                                from det in Details
                                where det.OrderId == o.Id
                                select det).ToList().Count();

                ReturnObj.Add(new DetailReportDTO()
                {
                    OrderDate = currDate,
                    OrderCount= detCount
                });
            }
            return ReturnObj;

        }
    }
}
