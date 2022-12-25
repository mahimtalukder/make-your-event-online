namespace DAL.Migrations
{
    using DAL.EF.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.OrganizeYourEventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(DAL.EF.OrganizeYourEventContext context)
        {
            List<ActionList> actionlist = new List<ActionList>();
            List<Location> actionlist2 = new List<Location>();
            List<User> actionlist3 = new List<User>();
            /*
            List<Customer> actionlist4 = new List<Customer>();
            List<Organizer> actionlist5 = new List<Organizer>();
            List<Admin> actionlist6 = new List<Admin>();
            */
            string[] actions = new string[] { "Admin Login","Customer Login","Organization Login","Create Admin", "Create Customer","Create Organization","Edit Admin","Edit Costomer","Edit Organization","Delete Admin","Delete Costomer","Delete Organization","Location Added","Organizing Area Added" };

            string[] divison = new string[] { "dhaka", "Chattogram", "Barishal", "dhaka", "Chattogram" };
            string[] district = new string[] { "dhaka", "Cox's Bazar", "Barishal", "Cumilla", "Narayanganj" };

            string[] name = new string[] { "Mahim", "Akash", "Zarif" };
            string[] pass = new string[] { "Mahim123", "Akash123", "Zarif123" };
            string[] type = new string[] { "Organizer", "Customer", "Admin" };
            int[] id = new int[] { 1,2,3 };

            for (int i = 0; i <= actions.Length - 1; i++)
            {
                actionlist.Add(new ActionList()
                {
                    Name = actions[i]
                });
            }

            for (int i = 0; i <= divison.Length - 1; i++)
            {

                actionlist2.Add(new Location()
                {
                    Division = divison[i],
                    District = district[i],
                    Thana = district[i]

                });


            }
            for (int i = 0; i <3; i++)
            {

                actionlist3.Add(new User()
                {
                    Id = id[i],
                    Username = name[i],
                    Password = pass[i],
                    UserType = type[i]

                });


            }
            /*
            actionlist4.Add(new Customer()
            {
                Id = 2,
                Name= "Akash",
                Email="Akash@gmail.com",
                Phone= "01952453562",
                Address="Santinogor",
                ProfilePicture= "https://localhost:44335/Images/default.jpg",
                ShippingAreaId=1

            });


            actionlist5.Add(new Organizer()
            {
                Id= 1,
                Name = "Mahim",
                Email = "Mahim@gmail.com",
                Phone = "01952453562",
                Address = "Uttra",
                ProfilePicture = "https://localhost:44335/Images/default.jpg"

            });

            actionlist6.Add(new Admin()
            {
                Id=3,
                Name = "Zarif",
                Email = "Zarif@gmail.com",
                Phone = "01952453562",
                ProfilePicture = "https://localhost:44335/Images/default.jpg"

            });
*/

            context.ActionLists.AddOrUpdate(actionlist.ToArray());
            context.Locations.AddOrUpdate(actionlist2.ToArray());
            context.Users.AddOrUpdate(actionlist3.ToArray());
            /*
            context.Customers.AddOrUpdate(actionlist4.ToArray());
            context.Organizers.AddOrUpdate(actionlist5.ToArray());
            context.Admins.AddOrUpdate(actionlist6.ToArray());
            */
        }


    }
}
