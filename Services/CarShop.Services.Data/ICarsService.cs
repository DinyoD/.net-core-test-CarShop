namespace CarShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarShop.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task AddCarAsync(CarsInputModel car, string ownerId);

        ICollection<T> GetCarsWithIssues<T>();

        ICollection<T> GetCarsByClient<T>(string ownerId);

        string GetCarModelById(string id);
    }
}
