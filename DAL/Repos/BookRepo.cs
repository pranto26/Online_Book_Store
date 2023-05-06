using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookRepo : Repo, IRepo<Book, int, bool>
    {
        public bool Create(Book obj)
        {

            db.Books.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Books.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Book> Read()
        {
            return db.Books.ToList();
        }

        public Book Read(int id)
        {
            return db.Books.Find(id);
        }

        public bool Update(Book obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
