using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CategoryRepo: Repo, IRepo<Category, int, Category>
    {
        public Category Add(Category obj)
        {
            db.Categories.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var DBCategory = Get(id);
            db.Categories.Remove(DBCategory);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            var DBCategory = db.Categories.SingleOrDefault(x => x.Id == id);
            if (DBCategory != null)
            {
                return DBCategory;
            }
            return null;
        }

        public Category Update(Category obj)
        {
            var DBCategory = Get(obj.Id);
            db.Entry(DBCategory).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
            throw new NotImplementedException();
        }
    }
}
