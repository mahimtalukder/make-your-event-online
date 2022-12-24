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
    public class ShippingAddressServices
    {
        public static ShippingAddressDTO AddShippingAddress(ShippingAddressDTO ShippingAddress)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ShippingAddressDTO, ShippingAddress>();
                c.CreateMap<ShippingAddress, ShippingAddressDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<ShippingAddress>(ShippingAddress);
            var rt = DataAccessFactory.ShippingAddressDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<ShippingAddressDTO>(rt);
            }
            return null;
        }

        public static List<ShippingAddressDTO> Get()
        {
            var data = DataAccessFactory.ShippingAddressDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ShippingAddress, ShippingAddressDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<ShippingAddressDTO>>(data);
        }
        public static ShippingAddressDTO Get(int id)
        {
            var data = DataAccessFactory.ShippingAddressDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ShippingAddress, ShippingAddressDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ShippingAddressDTO>(data);
        }


        public static ShippingAddressDTO Update(ShippingAddressDTO ShippingAddress)
        {

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ShippingAddressDTO, ShippingAddress>();
                c.CreateMap<ShippingAddress, ShippingAddressDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<ShippingAddress>(ShippingAddress);
            var rt = DataAccessFactory.ShippingAddressDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<ShippingAddressDTO>(rt);
            }
            return null;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ShippingAddressDataAccess().Delete(id);
        }
    }
}
