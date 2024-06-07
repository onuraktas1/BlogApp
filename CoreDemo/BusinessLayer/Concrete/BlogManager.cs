using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetAll(int id)
        {
            return _blogDal.GetAll(x => x.Id == id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }

        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);

        }

        public List<Blog> GetListByWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterId == id);
        }
    }
}
