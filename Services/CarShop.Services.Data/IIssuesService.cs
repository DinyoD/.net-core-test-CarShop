namespace CarShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarShop.Web.ViewModels.Issues;

    public interface IIssuesService
    {
        ICollection<T> GetIssuesByCarId<T>(string id);

        Task AddIssueAsync(IssuesInputModel input);

        Task FixIssueByIdAsync(string issueId);

        Task DeleteIssueByIdAsync(string issueId);
    }
}
