
using Microsoft.AspNetCore.Mvc.Rendering;

public enum Cities
{
    Jodhpur,
    Ajmer,
    Jaipur,
    Udaipur,
    Bikaner
}


public class CityViewModel
{
    public Cities SelectedCity { get; set; }
    public IEnumerable<SelectListItem> CityList { get; set; }
}