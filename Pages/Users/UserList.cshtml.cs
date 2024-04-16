using Express_Management.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Express_Management.Pages.Users
{
    [Authorize]
    public class UserListModel : PageModel
    {
        public UserListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }





    }
}
