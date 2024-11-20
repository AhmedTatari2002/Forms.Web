using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.ViewModel
{
    public class CreateProductViewModel
    {
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        [Display(Name = "Product Price")]
        public float Price { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; }
    }
}
