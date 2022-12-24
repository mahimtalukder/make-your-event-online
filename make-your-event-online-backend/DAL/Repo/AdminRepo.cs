using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>
    {
        public Admin Add(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var admin = Get(id);
            db.Admins.Remove(admin);
            if(db.SaveChanges()>0)return true;
            return false;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin Update(Admin obj)
        {
            var admin = Get(obj.Id);
            db.Entry(admin).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
