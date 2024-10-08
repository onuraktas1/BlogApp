﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Writer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string About { get; set; }
		public string Image { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
		public bool status { get; set; }
		public int BlogId { get; set; }
		public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message2> WriterSender { get; set; }
        public virtual ICollection<Message2> WriterReceiver { get; set; }
    }
}
