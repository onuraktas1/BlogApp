using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Controllers;

public class EmployeeTestController : Controller
{
    
    public async Task<IActionResult> Index()
    {
        var httpClient = new HttpClient();
        var responseMessage = await httpClient.GetAsync("https://localhost:7081/api/Default");
        var jsonString = await responseMessage.Content.ReadAsStringAsync();
        var values =JsonConvert.DeserializeObject<List<Employee>>(jsonString);
        return View(values);
    }

    public IActionResult AddEmployee()
    {
        return View();
    }
    [HttpPost]
    public  async Task<IActionResult> AddEmployee(Employee p)
    {
        var httpClient = new HttpClient();
        var jsonEmployee = JsonConvert.SerializeObject(p);
        var content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
        var responseMessage = await httpClient.PostAsync("https://localhost:7081/api/Default", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(p);
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
} 