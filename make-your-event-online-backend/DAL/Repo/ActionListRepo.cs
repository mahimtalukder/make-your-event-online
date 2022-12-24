using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ActionListRepo : Repo, IRepo<ActionList, int, ActionList>
    {
        public ActionList Add(ActionList obj)
        {
            db.ActionLists.Add(obj);
            if(db.SaveChanges()> 0)
            { return obj; }
            return null;

        }

        public bool Delete(int id)
        {
            var action = Get(id);
            db.ActionLists.Remove(action);
            if(db.SaveChanges()>0)return true;
            return false;

        }

        public List<ActionList> Get()
        {
            return db.ActionLists.ToList();
        }

        public ActionList Get(int id)
        {
            return db.ActionLists.Find(id);
        }

        public ActionList Update(ActionList obj)
        {
            var action = Get(obj.Id);
            db.Entry(action).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
