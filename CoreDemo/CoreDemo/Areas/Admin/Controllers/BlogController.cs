using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;

                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;

                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
            // return View();
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModel = new List<BlogModel>
            {
                new BlogModel{Id=1, BlogName="C# Programlamaya Giriş"},
                new BlogModel {Id=2,BlogName="Nesne Tabanlı Programlama"},
                new BlogModel {Id=3,BlogName="Yeni Teknolojiler"}

            };

            return blogModel;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;

                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;

                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
            return View();
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> blogModel2 = new List<BlogModel2>();
            using (var context = new Context())
            {
                blogModel2 = context.Blogs.Select(x => new BlogModel2
                {
                    Id = x.Id,
                    BlogName = x.Title
                }).ToList();
            }

            return blogModel2;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
