using Microsoft.AspNetCore.Mvc.Rendering;

namespace Express_Management.Infrastructures.Currencies
{
    public interface ICurrencyService
    {
        ICollection<SelectListItem> GetCurrencies();
    }
}
