using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin, int, Admin> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<ActionList, int, ActionList> ActionListDataAccess()
        {
            return new ActionListRepo();
        }
        public static IRepo<Log, int, Log> LogDataAccess()
        {
            return new LogRepo();
        }
        public static IRepo<Review, int, Review> ReviewDataAccess()
        {
            return new ReviewRepo();
        }
        public static IRepo<ShippingAddress, int, ShippingAddress> ShippingAddressDataAccess()
        {
            return new ShippingAddressRepo();
        }

        public static IRepo<Organizer, int, Organizer> OrganizerDataAccess()
        {
            return new OrganizerRepo();
        }

        public static IRepo<OrganizingArea, int, OrganizingArea> OrganizingAreaDataAccess()
        {
            return new OrganizingAreaRepo();
        }

        public static IRepo<Location, int, Location> LocationDataAccess()
        {
            return new LocationRepo();
        }

        public static IRepo<Customer, int, Customer> CustomerDataAccess()
        {
            return new CustomerRepo();
        }
        public static IRepo<Order, int, Order> OrderDataAccess()
        {
            return new OrderRepo();
        }
        public static IRepo<OrderDetail, int, OrderDetail> OrderDetailDataAccess()
        {
            return new OrderDetailRepo();
        }
        public static IRepo<User, int, User> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }

        public static IRepo<Category, int, Category> CategoryDataAccess()
        {
            return new CategoryRepo();
        }

        public static IRepo<Service, int, Service> ServiceDataAccess()
        {
            return new ServiceRepo();
        }

        public static IRepo<ServiceCatalog, int, ServiceCatalog> ServiceCatalogDataAccess()
        {
            return new ServiceCatalogRepo();
        }
    }
}
