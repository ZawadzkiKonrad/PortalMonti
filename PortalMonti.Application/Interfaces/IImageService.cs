using Microsoft.AspNetCore.Http;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.Interfaces
{
    public interface IImageService
    {
        Image GetImageById(int id);
        IQueryable<Image> GetAllImages();
        IQueryable<Image> GetUserImages(string appUserId);
        string AddImage(IFormFile file);
        void ProfileSet(string path);

    }
}
