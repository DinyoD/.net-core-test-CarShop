namespace CarShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarShop.Data.Common.Repositories;
    using CarShop.Data.Models;
    using CarShop.Services.Mapping;
    using CarShop.Web.ViewModels.Issues;

    public class IssuesService : IIssuesService
    {
        private readonly IDeletableEntityRepository<Issue> issueRepo;

        public IssuesService(IDeletableEntityRepository<Issue> issueRepo)
        {
            this.issueRepo = issueRepo;
        }

        public async Task AddIssueAsync(IssuesInputModel input)
        {
            var issue = new Issue
            {
                Descripition = input.Descripition,
                CarId = input.CarId,
                IsFixed = false,
            };

            await this.issueRepo.AddAsync(issue);
            await this.issueRepo.SaveChangesAsync();
        }

        public async Task DeleteIssueByIdAsync(string issueId)
        {
            var issue = this.issueRepo.All().FirstOrDefault(x => x.Id == issueId); 
            this.issueRepo.Delete(issue);
            await this.issueRepo.SaveChangesAsync();
        }

        public async Task FixIssueByIdAsync(string issueId)
        {
            var issue = this.issueRepo.All().FirstOrDefault(x => x.Id == issueId);
            issue.IsFixed = true;
            await this.issueRepo.SaveChangesAsync();
        }

        public ICollection<T> GetIssuesByCarId<T>(string id)
        {
            return this.issueRepo.All().Where(x => x.CarId == id).To<T>().ToList();
        }
    }
}
