using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo: Repo, IRepo<Token, string, Token>
    {
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
            { return obj; }
            return null;
        }

        public bool Delete(string id)
        {
            var token = Get(id);
            db.Tokens.Remove(token);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string id)
        {

            return (from tk in db.Tokens
                    where tk.LoginToken == id
                    select tk).SingleOrDefault();
        }

        public Token Update(Token obj)
        {
            var token = Get(obj.LoginToken);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return obj;
        }
    }
}
