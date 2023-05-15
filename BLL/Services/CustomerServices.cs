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
    public class CustomerServices
    {
        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CustomerData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CustomerDTO>>(data);
            return mapped;
        }
        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomerDTO>(data);
            return mapped;

        }

        public static CustomerOrderDTO GetwithOrders(int id)
        {
            var data = DataAccessFactory.CustomerData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerOrderDTO>();
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomerOrderDTO>(data);
            return mapped;

        }

        public static bool Create(CustomerDTO customer)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Customer>(customer);
            var res = DataAccessFactory.CustomerData().Create(mapped);

            if (res) return true;
            return false;

        }

        public static bool Update(CustomerDTO customer)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerDTO, Customer>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Customer>(customer);
            var res = DataAccessFactory.CustomerData().Update(mapped);
            if (res) return true;
            return false;
        }

        public static bool DeleteCustomer(int id)
        {
            var res = DataAccessFactory.CustomerData().Delete(id);
            return res;
        }

       
    }
}
