using ImageGallery.Data;
using ImageGallery.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Interfaces
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetByTag(string tag);
        GalleryImage GetById(int id);

        CloudBlobContainer GetBlobContainer(string ConnectionString, string containerName);
        Task SetImage(string title, string tags, Uri uri);
        List<ImageTag> ParseTags(string tags);
    }
}
