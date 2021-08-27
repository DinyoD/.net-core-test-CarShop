namespace CarShop.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    using CarShop.Data.Models;
    using CarShop.Services.Mapping;
    using CarShop.Web.ViewModels.Issues;

    public class CarsForIssuesListVewModel : IMapFrom<Car>
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public ICollection<IssueListVewModel> Issues { get; set; }
    }
}
