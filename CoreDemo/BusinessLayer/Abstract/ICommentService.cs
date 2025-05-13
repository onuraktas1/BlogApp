using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService
	{
		void Add(Comment comment);
		//void Delete(Comment comment);
		//void Update(Comment comment);
		List<Comment> GetAll(int id);
		List<Comment> GetAllWithBlog();
		//Comment GetById(int id);
	}
}
