using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Data
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }

        public virtual IEnumerable<ImageTag> Tags { get; set; }

    }
}
