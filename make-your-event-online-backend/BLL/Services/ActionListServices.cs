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
    public class ActionListServices
    {
        public static ActionListDTO AddActionList(ActionListDTO action)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ActionListDTO, ActionList>();
                c.CreateMap<ActionList, ActionListDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<ActionList>(action);
            var rt = DataAccessFactory.ActionListDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<ActionListDTO>(rt);
            }
            return null;
        }

        public static List<ActionListDTO> Get()
        {
            var data = DataAccessFactory.ActionListDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ActionList, ActionListDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<ActionListDTO>>(data);
        }
        public static ActionListDTO Get(int id)
        {
            var data = DataAccessFactory.ActionListDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ActionList, ActionListDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ActionListDTO>(data);
        }


        public static ActionListDTO Update(ActionListDTO action)
        {

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ActionListDTO, ActionList>();
                c.CreateMap<ActionList, ActionListDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<ActionList>(action);
            var rt = DataAccessFactory.ActionListDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<ActionListDTO>(rt);
            }
            return null;
        }

        public static ActionListDTO Delete(int id)
        {
            var data = DataAccessFactory.ActionListDataAccess().Delete(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ActionList, ActionListDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ActionListDTO>(data);
        }
    }
}
