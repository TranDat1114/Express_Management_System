using Express_Management.Infrastructures.Extensions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Express_Management.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }
    }
}
