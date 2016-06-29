using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using BLL.Interfacies.Infrastructure;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.ViewModels;

namespace MvcPL.Controllers
{
    [Authorize]
    public class PhotoController : Controller
    {
        private readonly IUserService userService;
        private readonly IPhotoService photoService;
        private readonly IRatingService ratingService;

        public PhotoController(IUserService userService, IPhotoService photoService, IRatingService ratingService)
        {
            this.userService = userService;
            this.photoService = photoService;
            this.ratingService = ratingService;
        }

        public ActionResult GetAll(int page = 1, string photoName = null )
        {
            if (!string.IsNullOrWhiteSpace(photoName))
            {
                return RedirectToAction("SearchPhotos", new {searchString = photoName, page = page});
            }
            var photosModel = GetPagePhotos(page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PhotoWithLinks", photosModel);
            }
            return View(photosModel);
        }
        
        public ActionResult SearchPhotos(string searchString, int page = 1)
        {
            var photosModel = GetPagePhotos(page, searchString);
            photosModel.SearchTag = searchString;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ShowImageGallery", photosModel);
            }
            return View("GetAll", photosModel);
        }

        [HttpGet]
        public ActionResult Add( int page = 1)
        {
            //ViewBag.PhotoName = photoName;
            ViewBag.CurrentPage = page;
            return View();
        }

        [HttpPost]
        public ActionResult Add(PhotoModel viewModel, HttpPostedFileBase uploadImage, string photoName, int page = 1)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage == null)
                {
                    ModelState.AddModelError("", "A photo is not selected.");
                    return View(viewModel);
                }

                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                viewModel.Image = imageData;
                viewModel.CreationDate = DateTime.Now;
                viewModel.UserId = userService.GetUserEntityByEmail(User.Identity.Name).Id;
                photoService.CreatePhoto(viewModel.ToBllPhoto());

                return RedirectToAction("Index","Home");
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(string photoName, int id = 0, int page = 1)
        {
            PhotoModel photo = photoService.GetPhotoEntityById(id).ToMvcPhoto();

            if (photo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.PhotoName = photoName;
            ViewBag.CurrentPage = page;
            return View(photo);
        }

        [HttpPost]
        public ActionResult Edit(PhotoModel viewModel, string photoName, int page = 1)
        {
            PhotoModel photo = photoService.GetPhotoEntityById(viewModel.Id).ToMvcPhoto();

            if (photo == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                photo.Name = viewModel.Name;
                photo.Description = viewModel.Description;
                photoService.UpdatePhoto(photo.ToBllPhoto());
                return RedirectToAction("Index", "Home");
            }
            return View(photo);
        }

        [HttpGet]
        public ActionResult Delete(string photoName, int id = 0, int page = 1)
        {
            PhotoModel photo = photoService.GetPhotoEntityById(id).ToMvcPhoto();

            if (photo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.PhotoName = photoName;
            ViewBag.CurrentPage = page;
            return View(photo);
        }

        [HttpPost]
        public ActionResult Delete(PhotoModel viewModel, string photoName, int page = 1)
        {
            photoService.DeletePhoto(viewModel.ToBllPhoto());
            return RedirectToAction("Index", "Home");
        }

        private PhotosViewModel GetPagePhotos(int page, string searchString = null){
            int pageSize = 10;
            var photos = photoService.GetAllPhotoEntities().Select(ph => ph.ToMvcPhoto());

            if (!String.IsNullOrEmpty(searchString))
            {
                photos = photos.Where(s => s.Description.Contains(searchString) || s.Name.Contains(searchString));
            }

            int totalItems = photos.Count();
            var resultPhotos = photos
                .OrderByDescending(ph => ph.CreationDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            foreach (var photo in resultPhotos)
            {
                photo.User = new UserModel();
                photo.User.Email = userService.GetUserEntityById(photo.UserId).Email;
            }
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems
            };

            return new PhotosViewModel
            {
                ChosenUser = null,
                Photos = resultPhotos,
                PageInfo = pageInfo
            };
        }
    }
}