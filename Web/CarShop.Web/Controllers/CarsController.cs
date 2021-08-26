namespace CarShop.Web.Controllers
{
    using CarShop.Data.Models;
    using CarShop.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public CarsController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult All()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.ClientRoleName)]
        public IActionResult Add()
        {
            return this.View();
        }
    }
}
