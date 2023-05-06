using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class BookServices
    {
        public static List<BookDTO> Get()
        {
            var data = DataAccessFactory.BookData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Book, BookDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BookDTO>>(data);
            return mapped;
        }
        public static BookDTO Get(int id)
        {
            var data = DataAccessFactory.BookData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Book, BookDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BookDTO>(data);
            return mapped;

        }

        public static BookOrderDTO GetwithOrders(int id)
        {
            var data = DataAccessFactory.BookData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Book, BookOrderDTO>();
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BookOrderDTO>(data);
            return mapped;

        }

        public static bool Create(BookDTO book)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BookDTO, Book>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Book>(book);
            var res = DataAccessFactory.BookData().Create(mapped);

            if (res) return true;
            return false;

        }

        public static bool Update(BookDTO book
            )
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookDTO, Book>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Book>(book);
            var res = DataAccessFactory.BookData().Update(mapped);
            if (res) return true;
            return false;
        }

        public static bool DeleteBook(int id)
        {
            var res = DataAccessFactory.BookData().Delete(id);
            return res;
        }
    }
}
