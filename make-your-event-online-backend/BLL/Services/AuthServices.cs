using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthServices
    {
        public static TokenDTO Authenticate(string Username, string Password)
        {
            var user = DataAccessFactory.AuthDataAccess().Authenticate(Username, Password);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Token, TokenDTO>();
                c.CreateMap<LogDTO, Log>();
            });
            var mapper = new Mapper(cfg);

            if (user != null)
            {

                if (user.UserType == "organizer")
                {
                    var log = new Log()
                    {
                        ActionId = 3,
                        CreateTime = DateTime.Now,
                        UserId = user.Id
                    };
                    DataAccessFactory.LogDataAccess().Add(mapper.Map<Log>(log));
                }

                if (user.UserType.Equals("Customer"))
                {
                    var log = new Log()
                    {
                        ActionId = 2,
                        CreateTime = DateTime.Now,
                        UserId = user.Id
                    };
                    DataAccessFactory.LogDataAccess().Add(mapper.Map<Log>(log));
                }

                if (user.UserType.Equals("Admin"))
                {
                    var log = new Log()
                    {
                        ActionId = 1,
                        CreateTime = DateTime.Now,
                        UserId = user.Id
                    };
                    DataAccessFactory.LogDataAccess().Add(mapper.Map<Log>(log));
                }

                var tk = new Token();
                tk.UserId = user.Id;
                tk.CreatedDate = DateTime.Now;
                tk.ExpDate = null;
                tk.LoginToken = Guid.NewGuid().ToString();
                var rttk = DataAccessFactory.TokenDataAccess().Add(tk);
                if (rttk != null)
                {
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }
            }
            return null;
        }
        public static TokenDTO IsTokenValid(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk != null && tk.ExpDate == null)
            {
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(cfg);
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;
        }

        public static bool ExpToken(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk != null && tk.ExpDate == null)
            {
                tk.ExpDate = DateTime.Now;
                var uptk = DataAccessFactory.TokenDataAccess().Update(tk);
                if (uptk != null)
                {
                    return true;
                }
                return false;

            }
            return false;


        }
    }
}
