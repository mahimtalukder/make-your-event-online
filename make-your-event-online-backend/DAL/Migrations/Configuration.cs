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

            string[] actions = new string[] { "Admin Login","Customer Login","Organization Login","Create Admin", "Create Customer","Create Organization","Edit Admin","Edit Costomer","Edit Organization","Delete Admin","Delete Costomer","Delete Organization","Location Added","Organizing Area Added" };

            for (int i = 0; i <= actions.Length - 1; i++)
            {
                actionlist.Add(new ActionList()
                {
                    Name = actions[i]
                });
            }

            context.ActionLists.AddOrUpdate(actionlist.ToArray());

        }


    }
}
