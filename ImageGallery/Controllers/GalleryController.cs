using ImageGallery.Data;
using ImageGallery.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            List<ImageTag> testImageTags = new List<ImageTag>();
            List<ImageTag> cityImageTags = new List<ImageTag>();

            ImageTag tag1 = new ImageTag()
            {
                Description = "Adventure",
                Id = 0
            };

            ImageTag tag2 = new ImageTag()
            {
                Description = "cool",
                Id = 1
            };

            ImageTag tag3 = new ImageTag()
            {
                Description = "London",
                Id = 2
            };


            testImageTags.AddRange(new List<ImageTag>{ tag1, tag2 });
            cityImageTags.Add(tag3);


            List<GalleryImage> imageList = new List<GalleryImage>()         
            {
                new GalleryImage()
                {
                    Title = "Test",
                    Url = "https://files.adme.ru/files/news/part_70/704610/preview-26276115-650x341-98-1481879211.jpg",
                    Created = DateTime.Now,
                    Tags = testImageTags

                },

                new GalleryImage()
                {
                    Title = "Test1",
                    Url = "https://fullpicture.ru/wp-content/uploads/2016/02/traveling-dog1.jpg",
                    Created = DateTime.Now,
                    Tags = testImageTags

                },

                new GalleryImage()
                {
                    Title = "Test2",
                    Url = "https://st.depositphotos.com/2138251/3697/i/950/depositphotos_36972971-stock-photo-dog-in-the-boat.jpg",
                    Created = DateTime.Now,
                    Tags = cityImageTags

                },
            };

            GalleryIndexModel model = new GalleryIndexModel()
            {
                Images = imageList
            };

            return View(model);
        }
    }
}
