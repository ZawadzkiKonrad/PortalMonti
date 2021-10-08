using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Infrastructure.Repositories
{
    public class ImageRepopsitory : IImageRepository
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        private readonly IPostRepository _postRepository;
        private readonly IFriendRepository _friendRepository;
        public ImageRepopsitory(Context context, UserManager<AppUser> userManager, IHttpContextAccessor accessor, IPostRepository postRepository,IFriendRepository friendRepository)
        {
            _context = context;
            _userManager = userManager;
            _accessor = accessor;
            _postRepository = postRepository;
            _friendRepository = friendRepository;
        }
        public string AddImage(Image image)
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            user.Images.Add(image);
            _context.SaveChanges();
            return image.Path;
        }

        public void DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Image> GetAllImages()
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;

            var images = _context.Images.Where(i => i.AppUserId == user.Id);
            return images;
            
        }

        public Friend GetImageById(int friendId)
        {
            throw new NotImplementedException();
        }

        public void ProfileSet(string path)
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            _postRepository.UpdateImage(path, user);
            _postRepository.UpdateImageCom(path, user);
            _friendRepository.UpdateImage(path, user);
            
            user.ImageProfile = path;
            _context.SaveChanges();
        }
    }
}
