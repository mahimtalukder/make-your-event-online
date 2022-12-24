using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class OrganizingAreaRepo : Repo, IRepo<OrganizingArea, int, OrganizingArea>
    {
        public OrganizingArea Add(OrganizingArea obj)
        {
            db.OrganizingAreas.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var DbOrganizerArea = Get(id);
            db.OrganizingAreas.Remove(DbOrganizerArea);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<OrganizingArea> Get()
        {
            return db.OrganizingAreas.ToList();
        }

        public OrganizingArea Get(int id)
        {
            var OrganizerArea = db.OrganizingAreas.SingleOrDefault(x => x.Id == id);
            if (OrganizerArea != null) return OrganizerArea;
            return null;
        }

        public OrganizingArea Update(OrganizingArea obj)
        {
            var dbOrganizingArea = Get(obj.Id);
            db.Entry(dbOrganizingArea).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
