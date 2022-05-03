﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PictureShare_.Data;
using PictureShare_.Helpers;
using PictureShare_.Models;

namespace PictureShare_.Controllers
{
    [Authorize]
    public class PictureController : Controller
    {
        private readonly ApplicationDbContext _db;
        private Images _image;
        private IWebHostEnvironment _env;
        public PictureController(ApplicationDbContext db, Images image, IWebHostEnvironment env)
        {
            _db = db;
            _image = image;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var pictures = await _db.Pictures.Where(x => x.UserEmail == User.Identity.Name).ToListAsync();
            return View(pictures);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PictureViewModel pictureViewModel = new PictureViewModel()
            {
                Picture = new PictureModel(),
                CategoryList = _db.Categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(pictureViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(PictureViewModel model)
        {
            model.Picture.TimeStamp = DateTime.Now;
            model.Picture.UserEmail = User.Identity.Name;
            model.Picture.Public = false;
            var file = Request.Form.Files[0];

            Images images = new Images(_env);
            model.Picture.ImagePath = await images.Upload(file, "/Images/");

            await _db.Pictures.AddAsync(model);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Delete(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var picture = await _db.Pictures.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            if(picture == null)
            {
                return NotFound();
            }

            _db.Pictures.Remove(picture);
            await _db.SaveChangesAsync();   
            _image.Delete(picture.ImagePath);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> makePublic(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _db.Pictures.FirstOrDefaultAsync(p => p.Id == id);
            if (picture == null)
            {
                return NotFound();
            }

            picture.Public = !picture.Public;
            _db.Pictures.Update(picture);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
