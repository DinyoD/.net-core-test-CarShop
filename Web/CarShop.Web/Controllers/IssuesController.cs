namespace CarShop.Web.Controllers
{
    using System.Threading.Tasks;
    using CarShop.Common;
    using CarShop.Services.Data;
    using CarShop.Web.ViewModels.Cars;
    using CarShop.Web.ViewModels.Issues;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class IssuesController : BaseController
    {
        private readonly IIssuesService issuesService;
        private readonly ICarsService carsService;

        public IssuesController(IIssuesService issuesService, ICarsService carsService)
        {
            this.issuesService = issuesService;
            this.carsService = carsService;
        }

        public IActionResult CarIssues(string id)
        {
            var issues = this.issuesService.GetIssuesByCarId<IssueListVewModel>(id);

            var model = this.carsService.GetCarModelById(id);

            var viewModel = new CarsForIssuesListVewModel
            {
                Model = model,
                Id = id,
                Issues = issues,
            };

            return this.View(viewModel);
        }

        public IActionResult Add(string id)
        {
            var model = new IssuesInputModel
            {
                CarId = id,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(IssuesInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
                await this.issuesService.AddIssueAsync(input);
            }
            catch (System.Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction(nameof(this.CarIssues), new { id = input.CarId });
        }

        [Authorize(Roles = GlobalConstants.MechanicRoleName)]
        public async Task<IActionResult> Fix(string carId, string issueId)
        {
            await this.issuesService.FixIssueByIdAsync(issueId);
            return this.RedirectToAction(nameof(this.CarIssues), new { id = carId });
        }

        public async Task<IActionResult> Delete(string carId, string issueId)
        {
            await this.issuesService.DeleteIssueByIdAsync(issueId);
            return this.RedirectToAction(nameof(this.CarIssues), new { id = carId });
        }
    }
}
