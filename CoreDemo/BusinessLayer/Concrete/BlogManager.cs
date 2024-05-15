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
			throw new NotImplementedException();
		}

		public void Delete(Blog blog)
		{
			throw new NotImplementedException();
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
			//throw new NotImplementedException();
			return _blogDal.GetAll(x => x.WriterId == id);
		}
	}
}
