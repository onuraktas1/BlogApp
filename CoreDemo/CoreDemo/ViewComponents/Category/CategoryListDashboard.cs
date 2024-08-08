using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager _categoryManager = new(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var data = _categoryManager.GetAll();
            return View(data);
        }
    }
}
