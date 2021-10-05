using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IImageRepository _imageRepo;
        

        public ImageController(IImageService imageService, IImageRepository imageRepo)
        {
            _imageService = imageService;
            _imageRepo = imageRepo;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Images = _imageRepo.GetAllImages();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(IFormFile file)
        {

            ViewBag.Images = _imageRepo.GetAllImages();
            var path=await _imageService.AddImage(file);
            return View();
        } 
        [HttpGet]
        public IActionResult ProfileSet(string path)
        {
            _imageService.ProfileSet(path);

           return RedirectToAction("Index");
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
        //            path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Upload"));
        //            using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
        //            {
        //                await file.CopyToAsync(filestream);
        //            }
        //            iscopied = true;

        //            pathEnd = path + "\\" + filename;
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

    }
}

