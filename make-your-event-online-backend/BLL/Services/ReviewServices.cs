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
    public class ReviewServices
    {
        public static ReviewDTO AddReview(ReviewDTO Review)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ReviewDTO, Review>();
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Review>(Review);
            var rt = DataAccessFactory.ReviewDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<ReviewDTO>(rt);
            }
            return null;
        }

        public static List<ReviewDTO> Get()
        {
            var data = DataAccessFactory.ReviewDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<ReviewDTO>>(data);
        }
        public static ReviewDTO Get(int id)
        {
            var data = DataAccessFactory.ReviewDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ReviewDTO>(data);
        }


        public static ReviewDTO Update(ReviewDTO Review)
        {

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ReviewDTO, Review>();
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Review>(Review);
            var rt = DataAccessFactory.ReviewDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<ReviewDTO>(rt);
            }
            return null;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ReviewDataAccess().Delete(id);
        }
    }
}
