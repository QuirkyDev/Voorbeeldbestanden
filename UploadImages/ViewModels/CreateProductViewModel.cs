using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.Models;

namespace UploadImages.ViewModels
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }

        public IFormFile Afbeelding { get; set; }
    }
}
