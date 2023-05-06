using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderServices
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDTO>>(data);
            return mapped;
        }
        public static OrderDTO Get(int id)
        {
            var data = DataAccessFactory.OrderData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;

        }

        public static bool Create(OrderDTO order)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Order>(order);
            var res = DataAccessFactory.OrderData().Create(mapped);

            if (res) return true;
            return false;

        }

        public static bool Update(OrderDTO order)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDTO, Order>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Order>(order);
            var res = DataAccessFactory.OrderData().Update(mapped);
            if (res) return true;
            return false;
        }

        public static bool DeleteOrder(int id)
        {
            var res = DataAccessFactory.OrderData().Delete(id);
            return res;
        }
    }
}
