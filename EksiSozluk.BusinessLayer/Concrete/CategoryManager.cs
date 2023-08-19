﻿using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.DataAccessLayer.Abstract;
using EksiSozluk.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal; //

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public void TInsert(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }

        public List<Category> GetActiveCategories()
        {
            return _categoryDal.GetAll().Where(c => c.CategoryStatus).ToList();
        }
    }
}
