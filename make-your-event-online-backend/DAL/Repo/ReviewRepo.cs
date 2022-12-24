using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ReviewRepo : Repo, IRepo<Review, int, Review>
    {
        public Review Add(Review obj)
        {
            db.Reviews.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var Review = Get(id);
            db.Reviews.Remove(Review);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Review> Get()
        {
            return db.Reviews.ToList();
        }

        public Review Get(int id)
        {
            return db.Reviews.Find(id);
        }

        public Review Update(Review obj)
        {
            var Review = Get(obj.Id);
            db.Entry(Review).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
