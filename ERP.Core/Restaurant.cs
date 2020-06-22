using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Core
{

    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string ProductId { get; set; }
        [Required, StringLength(50)]
        public string ProductName { get; set; }
        [Required, StringLength(50)]
        public Units ProductUnit { get; set; }
        [Required, StringLength(50)]
        public ProductTypes ProductType { get; set; }
        //imagen
        public int ProductCfdiKey { get; set; }
        [Required, StringLength(200)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}