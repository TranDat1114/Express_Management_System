using Microsoft.AspNetCore.Mvc.Rendering;

namespace Express_Management.Infrastructures.Countries
{
    public interface ICountryService
    {
        ICollection<SelectListItem> GetCountries();
    }
}
