using System.Text.Json;
using demo.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvcProject.Controllers;

public class HomeController : Controller
{
    private readonly ICityService _cityService;

    public HomeController(ICityService cityService)
    {
        _cityService = cityService;
    }


    private IEnumerable<SelectListItem> GetCitySelectList()
    {
        var cityList = new List<SelectListItem>();

        foreach (Cities city in Enum.GetValues(typeof(Cities)))
        {
            cityList.Add(new SelectListItem
            {
                Value = city.ToString(),
                Text = city.ToString()
            });
        }

        return cityList;
    }


    public IActionResult Index()
    {
        var model = new CityViewModel
        {
            CityList = GetCitySelectList()
        };
        return View(model);
    }


    [HttpPost]
    public async Task<string> GetCityInfo(CityViewModel model)
    {
        var selectedCity = model.SelectedCity.ToString();
        Logger.Instance.Log("city : " + selectedCity);
        var cityData = await _cityService.GetCityByName(selectedCity);
        return cityData.ToString();
    }

    [HttpPost]
    public  Task<string> GetUserInfo(int userAge)
    {

            Logger.Instance.Log("userAge : " + userAge);
            // Sample list of users
            List<User> users = new List<User>
            {
                new User { Id = 1, Name = "Alice", Age = 25 },
                new User { Id = 2, Name = "Bob", Age = 17 },
                new User { Id = 3, Name = "Charlie", Age = 30 },
                new User { Id = 4, Name = "David", Age = 15 },
                new User { Id = 5, Name = "Eve", Age = 22 }
            };

            // LINQ query to filter and sort users
            var filteredAndSortedUsers = users
                .Where(user => user.Age > userAge)
                .OrderBy(user => user.Name)
                .ToList();

             // Convert the filtered user list to JSON
            var result = JsonSerializer.Serialize(filteredAndSortedUsers);

            return Task.FromResult(result);
    }

}