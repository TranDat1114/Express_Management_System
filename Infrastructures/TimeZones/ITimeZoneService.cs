using Microsoft.AspNetCore.Mvc.Rendering;

namespace Express_Management.Infrastructures.TimeZones
{
    public interface ITimeZoneService
    {
        ICollection<SelectListItem> GetAllTimeZones();
    }
}
