namespace CarShop.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    public class CarsInputModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Range(1900, 2021)]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string PictureUrl { get; set; }

        [Required]
        [RegularExpression("^[A-B]{2}[0-9]{4}[A-B]{2}$")]
        public string PlateNumber { get; set; }
    }
}
