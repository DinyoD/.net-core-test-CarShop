namespace CarShop.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarShop.Common;
    using CarShop.Data.Models;
    using CarShop.Services.Data;
    using CarShop.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICarsService carsService;

        public CarsController(
            UserManager<ApplicationUser> userManager,
            ICarsService carsService)
        {
            this.userManager = userManager;
            this.carsService = carsService;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var model = new AllCarsViewModel();

            if (user.IsMechanic)
            {
                var cars = this.carsService.GetCarsWithIssues<CarsViewModelInAllCarsPage>();
                model.MyCars = cars;
            }
            else
            {
                var cars = this.carsService.GetCarsByClient<CarsViewModelInAllCarsPage>(user.Id);
                model.MyCars = cars;
            }

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.ClientRoleName)]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.ClientRoleName)]
        [HttpPost]
        public async Task<IActionResult> Add(CarsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var ownerId = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.carsService.AddCarAsync(input, ownerId.Id);
            }
            catch (System.Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
