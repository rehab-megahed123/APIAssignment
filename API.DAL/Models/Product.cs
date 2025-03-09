using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.DAL.Models
{
    public class Product
    {
        [RegularExpression(@"^\d+$", ErrorMessage = "Id must be number")]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must Positive.")]
        public  decimal? Price { get; set; }
        public int? Stock { get; set; }
        
        public string? ImageUrl { get; set; }
        [NotMapped]
        [RegularExpression(@"^[\w\-. ]+\.(jpg|png)$", ErrorMessage = "Invalid file extension. Only .jpg or .png allowed.")]


        public IFormFile? formFile { get; set; }
        
        public string? category { get; set; }
       


    }
}
