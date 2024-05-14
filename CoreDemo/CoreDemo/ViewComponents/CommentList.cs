using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var data = new List<UserComment>
            {
                new() { Id=1, UserName="Onur aktaş"},
                new() { Id=2, UserName="Sefa Eker"},
                new(){ Id=3, UserName="Göksel Yüksel"}

            };
            return View(data);
        }
    }
}
