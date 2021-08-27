namespace CarShop.Web.ViewModels.Issues
{
    using CarShop.Data.Models;
    using CarShop.Services.Mapping;

    public class IssueListVewModel : IMapFrom<Issue>
    {
        public string Id { get; set; }

        public string Descripition { get; set; }

        public bool IsFixed { get; set; }
    }
}
