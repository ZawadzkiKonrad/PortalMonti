using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Interfaces
{
    public interface IImageRepository
    {
        void DeleteImage(int id);

        string AddImage(Image image);

        IQueryable<Image> GetAllImages();

        Friend GetImageById(int friendId);
        void ProfileSet(string path);
    }
}
