using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo: Repo, IRepo<User, int, User>, IAuth
    {
        public User Add(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public User Authenticate(string Username, string Password)
        {
            var obj = db.Users.FirstOrDefault(x => x.Username.Equals(Username) && x.Password.Equals(Password));
            return obj;
        }

        public bool Delete(int id)
        {
            db.Users.Remove(db.Users.SingleOrDefault(x => x.Id == id));
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            var DBUser = db.Users.SingleOrDefault(x => x.Id == id);
            if (DBUser != null)
            {
                return DBUser;
            }
            return null;
        }

        public User GetUser(string Username)
        {
            var obj = db.Users.FirstOrDefault(x => x.Username.Equals(Username));
            return obj;
        }

        public User Update(User obj)
        {
            var DBUser = Get(obj.Id);
            db.Entry(DBUser).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
            throw new NotImplementedException();
        }
    }
}
