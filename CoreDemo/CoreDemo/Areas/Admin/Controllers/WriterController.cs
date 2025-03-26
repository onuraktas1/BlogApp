using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var JsonWriters = JsonConvert.SerializeObject(writers);
            return Json(JsonWriters);
        }

        public IActionResult GetWriterById(int writerId)
        {
            WriterClass? findWriter = writers.FirstOrDefault(x => x.Id == writerId);

            var JsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(JsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;

            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);

        }
        public static List<WriterClass> writers = new List<WriterClass>()
        {
            new WriterClass{ Id=1,Name="Beyza"},
            new WriterClass{ Id=2,Name="Onur"},
            new WriterClass{ Id=3,Name="Göksel"}
        };
    }
}
