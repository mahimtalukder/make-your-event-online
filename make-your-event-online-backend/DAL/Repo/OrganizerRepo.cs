using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class OrganizerRepo : Repo,IRepo<Organizer, int, Organizer>
    {
        public Organizer Add(Organizer obj)
        {
            db.Organizers.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var DbOrganizer = Get(id);
            db.Organizers.Remove(DbOrganizer);
            if(db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Organizer> Get()
        {
            return db.Organizers.ToList();
        }

        public Organizer Get(int id)
        {
            var Organizer = db.Organizers.SingleOrDefault(x => x.Id == id);
            if (Organizer != null)
            {
                return Organizer;
            }
            return null;
        }

        public Organizer Update(Organizer obj)
        {
            var dbOrganizer = Get(obj.Id);
            db.Entry(dbOrganizer).CurrentValues.SetValues(obj);
            if(db.SaveChanges()>0) return obj;
            return obj;

        }
    }
}
