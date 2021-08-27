namespace CarShop.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class AllCarsViewModel
    {
        public ICollection<CarsViewModelInAllCarsPage> MyCars { get; set; }
    }
}
