using ImageGallery.Data;
using ImageGallery.Interfaces;
using ImageGallery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly ImageGalleryDbContext _ctx;
        public ImageService(ImageGalleryDbContext ctx) {
            _ctx = ctx;

        }
        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages.Include(img => img.Tags);
        }
        public GalleryImage GetById(int id)
        {
            return GetAll().Where(img => img.Id == id).First();
        }

        public IEnumerable<GalleryImage> GetByTag(string tag)
        {
            return GetAll().Where(img
                => img.Tags.Any(t => t.Description == tag));
        }

        public CloudBlobContainer GetBlobContainer(string storageString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(storageString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }

        public async Task SetImage(string title, string tags, Uri uri)
        {
            var image = new GalleryImage
            {
                Title = title,

                Tags = tags != null ? ParseTags(tags): new List<ImageTag>(),
                Url = uri.AbsoluteUri
            };

            _ctx.Add(image);
            await _ctx.SaveChangesAsync();
        }

        public List<ImageTag> ParseTags(string tags)
        {
            return  tags.Split(",").ToList().Select(tag => new ImageTag {
                Description = tag
            }).ToList();

           
        }


    }

}
