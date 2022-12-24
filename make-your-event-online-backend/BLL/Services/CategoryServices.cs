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
    public class CategoryServices
    {
        public static List<CategoryDTO> Get()
        {
            var data = DataAccessFactory.CategoryDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CategoryDTO>>(data);
        }

        public static CategoryDTO Get(int id)
        {
            var data = DataAccessFactory.CategoryDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CategoryDTO>(data);
        }

        public static CategoryDTO Add(CategoryDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CategoryDTO, Category>();
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Category>(data);
            var ret = DataAccessFactory.CategoryDataAccess().Add(dbobj);
            return mapper.Map<CategoryDTO>(ret);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CategoryDataAccess().Delete(id);
        }

        public static CategoryDTO Update(CategoryDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CategoryDTO, Category>();
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Category>(data);
            var ret = DataAccessFactory.CategoryDataAccess().Update(dbobj);
            return mapper.Map<CategoryDTO>(ret);
        }

        public static CategoryWithServiceDTO GetWithService(int id)
        {
            var data = DataAccessFactory.CategoryDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Category, CategoryWithServiceDTO>();
                c.CreateMap<Service, ServiceDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CategoryWithServiceDTO>(data);
        }
    }
}
