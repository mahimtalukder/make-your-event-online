using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ServiceCatalogRepo: Repo, IRepo<ServiceCatalog, int, ServiceCatalog>
    {
        public ServiceCatalog Add(ServiceCatalog obj)
        {
            db.ServiceCatalogs.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var DbOrganizerArea = Get(id);
            db.ServiceCatalogs.Remove(DbOrganizerArea);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<ServiceCatalog> Get()
        {
            return db.ServiceCatalogs.ToList();
        }

        public ServiceCatalog Get(int id)
        {
            var OrganizerArea = db.ServiceCatalogs.SingleOrDefault(x => x.Id == id);
            if (OrganizerArea != null) return OrganizerArea;
            return null;
        }

        public ServiceCatalog Update(ServiceCatalog obj)
        {
            var dbServiceCatalog = Get(obj.Id);
            db.Entry(dbServiceCatalog).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
