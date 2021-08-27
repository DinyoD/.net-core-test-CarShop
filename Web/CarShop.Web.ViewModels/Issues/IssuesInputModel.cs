namespace CarShop.Web.ViewModels.Issues
{
    using System.ComponentModel.DataAnnotations;

    public class IssuesInputModel
    {
        [Required]
        [MinLength(5)]
        [Display(Name = "Description")]
        public string Descripition { get; set; }

        [Required]
        public string CarId { get; set; }
    }
}
