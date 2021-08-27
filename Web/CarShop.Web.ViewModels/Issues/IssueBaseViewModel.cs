namespace CarShop.Web.ViewModels.Issues
{
    using CarShop.Data.Models;
    using CarShop.Services.Mapping;

    public class IssueBaseViewModel : IMapFrom<Issue>
    {
        public bool IsFixed { get; set; }
    }
}
