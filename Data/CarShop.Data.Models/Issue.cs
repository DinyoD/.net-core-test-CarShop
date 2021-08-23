namespace CarShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CarShop.Data.Common.Models;

    public class Issue : BaseDeletableModel<string>
    {
        public Issue()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Descripition { get; set; }

        [Required]
        public bool IsFixed { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }
    }
}
