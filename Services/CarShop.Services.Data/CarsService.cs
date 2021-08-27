namespace CarShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarShop.Data.Common.Repositories;
    using CarShop.Data.Models;
    using CarShop.Services.Mapping;
    using CarShop.Web.ViewModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carRepo;

        public CarsService(IDeletableEntityRepository<Car> carRepo)
        {
            this.carRepo = carRepo;
        }

        public async Task AddCarAsync(CarsInputModel car, string ownerId)
        {
            var carToAdd = new Car
            {
                Model = car.Model,
                Year = car.Year,
                PictureUrl = car.PictureUrl,
                PlateNumber = car.PlateNumber,
                OwnerId = ownerId,
            };

            await this.carRepo.AddAsync(carToAdd);
            await this.carRepo.SaveChangesAsync();
        }

        public string GetCarModelById(string id)
        {
            var car = this.carRepo.All().FirstOrDefault(x => x.Id == id);

            return car.Model;
        }

        public ICollection<T> GetCarsByClient<T>(string ownerId)
        {
            return this.carRepo.All().Where(x => x.OwnerId == ownerId).To<T>().ToList();
        }

        public ICollection<T> GetCarsWithIssues<T>()
        {
            return this.carRepo.All().Where(x => x.Issues.Any(i => i.IsFixed != true)).To<T>().ToList();
        }
    }
}
