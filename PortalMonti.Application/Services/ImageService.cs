using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PortalMonti.Application.Interfaces;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace PortalMonti.Application.Services
{
    public class ImageService : IImageService

    {
        private readonly INotyfService _notyf;
        private readonly IImageRepository _imageRepo;
       
        public ImageService(IImageRepository imageRepo, INotyfService notyf)
        {
            _imageRepo = imageRepo;
            _notyf = notyf;

        }
        public string AddImage(IFormFile file)
        {
            _notyf.Success("Success Notification");
            var path=  UploadFile(file);
            PortalMonti.Domain.Model.Image image = new PortalMonti.Domain.Model.Image()
            {
                Path = path,
                Date = DateTime.Now
                
            };
            _imageRepo.AddImage(image);
            return path;
        }

        public IQueryable<PortalMonti.Domain.Model.Image> GetAllImages()
        {
            return _imageRepo.GetAllImages();
        }

        public PortalMonti.Domain.Model.Image GetImageById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PortalMonti.Domain.Model.Image> GetUserImages(string appUserId)
        {
            return _imageRepo.GetAllImages().Where(p => p.AppUserId == appUserId);
        }

        public void ProfileSet(string path)
        {
            _imageRepo.ProfileSet(path);
        }

        public string UploadFile(IFormFile file)
        {
            
            string path = "";
            string pathEnd = "";
            string filename;
            bool iscopied = false;
            try
            {
                
                if (file.Length > 0)
                {
                    filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload"));
                    string fullpath = Path.Combine(path, filename);
                    using (var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream())) //tu uzywam klasy z wtyczki a nie wlasnego modelu Image
                    {
                        string newsize = ImageResize(image, 600, 600); //tu ustalam docelowy rozmiar skompresowanego zdjecia
                        string[] sizearray = newsize.Split(',');
                        image.Mutate(x => x.Resize(Convert.ToInt32(sizearray[1]), Convert.ToInt32(sizearray[0])));
                        image.Save(fullpath);
                        
                    }
                    iscopied = true;
                    
                    
                    pathEnd =  filename;  ///w fullpath jest pelna sciezka ale ja biore sama nazwe bo wczesniej gdzie indziej tak robilem uzywam : SixLabors.ImageSharp; i SixLabors.ImageSharp.Processing;
                }
                else
                {
                    iscopied = false;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return pathEnd;
        }

        public string ImageResize(SixLabors.ImageSharp.Image img, int MaxWidth, int MaxHeght)
        {
            if (img.Width > MaxWidth || img.Height>MaxHeght)
            {
                double widthratio = (double)img.Width / (double)MaxWidth;
                double heightratio = (double)img.Height / (double)MaxWidth;
                double ratio = Math.Max(widthratio, heightratio);
                int newWidth = (int)(img.Width / ratio);
                int newHeight = (int)(img.Height / ratio);
                return newHeight.ToString() + "," + newWidth.ToString();

            }
            else
            {
                return img.Height.ToString() + "," + img.Width.ToString();
            }
        }

      
    }
}


//public async Task<string> UploadFile(IFormFile file)
//{
//    string path = "";
//    string pathEnd = "";
//    string filename;
//    bool iscopied = false;
//    try
//    {
//        if (file.Length > 0)
//        {
//            filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
//            path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload"));
//            using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
//            {
//                await file.CopyToAsync(filestream);
//            }
//            iscopied = true;

//            //pathEnd = path + "\\" + filename;
//            pathEnd = filename;
//        }
//        else
//        {
//            iscopied = false;
//        }
//    }
//    catch (Exception)
//    {
//        throw;
//    }

//    return pathEnd;
//}