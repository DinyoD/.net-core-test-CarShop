namespace CarShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CarShop.Data.Common.Models;

    public class Car : BaseDeletableModel<string>
    {

        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Issues = new HashSet<Issue>();
        }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string PictureUr { get; set; }

        [Required]
        public string PlateNUmber { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}
