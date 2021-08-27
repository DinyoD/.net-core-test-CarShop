namespace CarShop.Web.ViewModels.Cars
{
    using System.Collections.Generic;
    using System.Linq;

    using CarShop.Data.Models;
    using CarShop.Services.Mapping;
    using CarShop.Web.ViewModels.Issues;

    public class CarsViewModelInAllCarsPage : IMapFrom<Car>
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string PictureUrl { get; set; }

        public string PlateNumber { get; set; }

        public ICollection<IssueBaseViewModel> Issues { get; set; }

        public int RemainingIssues => this.Issues.Where(x => x.IsFixed == false).Count();

        public int FixedIssues => this.Issues.Where(x => x.IsFixed == true).Count();
    }
}
