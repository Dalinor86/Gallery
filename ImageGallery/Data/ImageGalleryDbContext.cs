using ImageGallery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Data
{
    public class ImageGalleryDbContext : DbContext
    {
        public ImageGalleryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
    }
}
