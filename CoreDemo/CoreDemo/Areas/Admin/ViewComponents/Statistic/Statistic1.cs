using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        private readonly BlogManager _blogManager = new(new EfBlogRepository());
        private readonly Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _blogManager.GetAll().Count;
            ViewBag.v2 = _context.Contacts.Count();
            ViewBag.v3 = _context.Comments.Count();

            string api = "992f842f3d12380d829547db33291a2c";
            string sehir = "istanbul";
            string connection = $"https://api.openweathermap.org/data/2.5/weather?q={sehir}&mode=xml&lang=tr&units=metric&appid={api}";

            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
