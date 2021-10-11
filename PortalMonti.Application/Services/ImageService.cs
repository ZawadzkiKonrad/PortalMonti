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

namespace PortalMonti.Application.Services
{
    public class ImageService : IImageService

    {
        private readonly IImageRepository _imageRepo;
       
        public ImageService(IImageRepository imageRepo)
        {
            _imageRepo = imageRepo;
            
        }
        public async Task<string> AddImage(IFormFile file)
        {
           var path= await UploadFile(file);
            Image image = new Image()
            {
                Path = path,
                Date = DateTime.Now
                
            };
            _imageRepo.AddImage(image);
            return path;
        }

        public IQueryable<Image> GetAllImages()
        {
            return _imageRepo.GetAllImages();
        }

        public Image GetImageById(int id)
        {
            throw new NotImplementedException();
        }

        public void ProfileSet(string path)
        {
            _imageRepo.ProfileSet(path);
        }

        public async Task<string> UploadFile(IFormFile file)
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
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    iscopied = true;

                    //pathEnd = path + "\\" + filename;
                    pathEnd =  filename;
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
    }
} 
