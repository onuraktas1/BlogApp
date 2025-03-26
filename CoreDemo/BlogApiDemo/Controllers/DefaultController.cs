using BlogApiDemo.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        Context _context = new();
        [HttpGet]
        public IActionResult EmployeeList()
        {
            List<Employee> employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return Ok("Ekleme Başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            Employee? e = _context.Employees.Find(id);
            if (e != null)
            {
                return Ok(e);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            Employee e = _context.Employees.Find(id);
            if (e != null)
            {
                _context.Employees.Remove(e);
                _context.SaveChanges();
                return Ok("Silinme işlemi başarılı");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee e)
        {
            Employee? employee = _context.Employees.Find(e.Id);
            if (employee != null)
            {
                employee.Name = e.Name;
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return Ok("Güncelleme başarılı");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
