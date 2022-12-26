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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.util;
using System.Web.UI.WebControls;
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
        public static byte[] GenerateReport(int id) // id = organizer id
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

                Paragraph title = new Paragraph("Organize Your Event Online", new Font(FontFamily.TIMES_ROMAN, 32, Font.BOLD, BaseColor.BLACK));
                title.SpacingAfter = 20;
                title.Alignment = Element.ALIGN_CENTER;
                report.Add(title);

                PdfPTable UserInfo = new PdfPTable(2);

                PdfPCell nameCell = new PdfPCell(new Phrase("Name: " + organizer.Name, new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                nameCell.Border = Rectangle.NO_BORDER;
                nameCell.HorizontalAlignment = Element.ALIGN_LEFT;
                nameCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(nameCell);

                PdfPCell BlankCell = new PdfPCell(new Phrase("\u00a0"));
                BlankCell.Border = Rectangle.NO_BORDER;
                BlankCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                BlankCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(BlankCell);

                PdfPCell EmailCell = new PdfPCell(new Phrase("Email: " + organizer.Email, new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                EmailCell.Border = Rectangle.NO_BORDER;
                EmailCell.HorizontalAlignment = Element.ALIGN_LEFT;
                EmailCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(EmailCell);

                UserInfo.AddCell(BlankCell);

                PdfPCell PhoneCell = new PdfPCell(new Phrase("Phone: " + organizer.Phone, new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                PhoneCell.Border = Rectangle.NO_BORDER;
                PhoneCell.HorizontalAlignment = Element.ALIGN_LEFT;
                PhoneCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(PhoneCell);

                PdfPCell dateCell = new PdfPCell(new Phrase("Date: " + DateTime.Now.Date.ToString(), new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                dateCell.Border = Rectangle.NO_BORDER;
                dateCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                dateCell.VerticalAlignment = Element.ALIGN_CENTER;
                UserInfo.AddCell(dateCell);


                UserInfo.SpacingAfter = 10;
                report.Add(UserInfo);

                PdfPTable DetailInfo = new PdfPTable(4);

                PdfPCell Serial = new PdfPCell(new Phrase("Serial", new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                Serial.BackgroundColor = BaseColor.CYAN;
                Serial.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                Serial.BorderWidthBottom = 1f;
                Serial.BorderWidthTop = 1f;
                Serial.BorderWidthLeft = 1f;
                Serial.BorderWidthRight = 1f;
                Serial.HorizontalAlignment = Element.ALIGN_CENTER;
                Serial.VerticalAlignment = Element.ALIGN_CENTER;
                DetailInfo.AddCell(Serial);

                PdfPCell ServiceTitle = new PdfPCell(new Phrase("Service Title", new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                ServiceTitle.BackgroundColor = BaseColor.CYAN;
                ServiceTitle.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                ServiceTitle.BorderWidthBottom = 1f;
                ServiceTitle.BorderWidthTop = 1f;
                ServiceTitle.BorderWidthLeft = 1f;
                ServiceTitle.BorderWidthRight = 1f;
                ServiceTitle.HorizontalAlignment = Element.ALIGN_CENTER;
                ServiceTitle.VerticalAlignment = Element.ALIGN_CENTER;
                DetailInfo.AddCell(ServiceTitle);

                PdfPCell OrderDate = new PdfPCell(new Phrase("Order Date", new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                OrderDate.BackgroundColor = BaseColor.CYAN;
                OrderDate.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                OrderDate.BorderWidthBottom = 1f;
                OrderDate.BorderWidthTop = 1f;
                OrderDate.BorderWidthLeft = 1f;
                OrderDate.BorderWidthRight = 1f;
                OrderDate.HorizontalAlignment = Element.ALIGN_CENTER;
                OrderDate.VerticalAlignment = Element.ALIGN_CENTER;
                DetailInfo.AddCell(OrderDate);

                PdfPCell Price = new PdfPCell(new Phrase("Price", new Font(FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK)));
                Price.BackgroundColor = BaseColor.CYAN;
                Price.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                Price.BorderWidthBottom = 1f;
                Price.BorderWidthTop = 1f;
                Price.BorderWidthLeft = 1f;
                Price.BorderWidthRight = 1f;
                Price.HorizontalAlignment = Element.ALIGN_CENTER;
                Price.VerticalAlignment = Element.ALIGN_CENTER;
                DetailInfo.AddCell(Price);

                int s = 1;
                foreach(var item in details)
                {
                    var da = (from o in orders
                              where o.Id == item.OrderId
                              select o.OrderDate.Date.ToShortDateString()).SingleOrDefault();
                    var serviceName = ServiceServices.Get(item.ServiceId).Name.ToString();

                    PdfPCell cell1 = new PdfPCell(new Phrase(s.ToString()));
                    PdfPCell cell2 = new PdfPCell(new Phrase(serviceName));
                    PdfPCell cell3 = new PdfPCell(new Phrase(da));
                    PdfPCell cell4 = new PdfPCell(new Phrase(item.Price.ToString()));

                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                    DetailInfo.AddCell(cell1);
                    DetailInfo.AddCell(cell2);
                    DetailInfo.AddCell(cell3);
                    DetailInfo.AddCell(cell4);
                    s++;
                }

                report.Add(DetailInfo);
                report.Close();



                writer.Close();
                byte[] content = ms.ToArray();
                return content;



            }

        }

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

            for (DateTime currDate = DateTime.Now; currDate >= cutOff; )
            {
                int detCount = 0;
                var order = (from o in Orders
                             where o.OrderDate.Date.ToShortDateString().Equals(currDate.Date.ToShortDateString())
                             select o).ToList();
                if (order.Count>0)
                {
                    detCount = (from o in Orders
                                    from det in Details
                                    where det.OrderId == o.Id
                                    select det).ToList().Count();
                }
                
                ReturnObj.Add(new DetailReportDTO()
                {
                    OrderDate = currDate,
                    OrderCount= detCount
                });
                order = null;
                currDate = currDate.AddDays(-1);
            }
            return ReturnObj;

        }
    }
}
