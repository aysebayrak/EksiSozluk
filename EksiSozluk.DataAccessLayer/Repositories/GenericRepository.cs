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
    public class GenericRepository<T> : IGenericDal<T> where T : class , new()
    {

         public void Delete(T t)
        {
            using var context = new EksiSozlukContext();
            context.Remove(t);
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            using var context = new EksiSozlukContext();
            return context.Set<T>().Find(id);

        }

        public List<T> GetList()
        {
            using var context = new EksiSozlukContext();
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var context = new EksiSozlukContext();
            context.Add(t);
            context.SaveChanges();
        }

       

        public void Update(T t)
        {
            using var context = new EksiSozlukContext();
            context.Update(t);
            context.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            using var context = new EksiSozlukContext();
            return context.Set<T>().Where(filter).ToList();
        }
    }
}
