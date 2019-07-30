using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Models
{
    public class UploadModel
    {

        public string Title { get; set; }
        public string Tags { get; set; }
        public IFormFile Upload { get; set; }
    }
}
