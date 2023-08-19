using EksiSozluk.DataAccessLayer.Abstract;
using EksiSozluk.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly EksiSozlukContext _context;
        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
            
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges(); 
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
           return _context.Set<T>().Where(filter).ToList();
        }

        public void Update(T t)
        {
           _context.Update(t);
            _context.SaveChanges();
        }
    }
}
