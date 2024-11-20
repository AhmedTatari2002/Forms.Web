using Forms.Web.Data;
using Forms.Web.Models;
using Forms.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.Where(x => !x.IsDelete).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            if(category == null)
            {
                return NotFound();
            }
            var vm = new UpdateCategoryViewModel();
            vm.Id = category.Id;
            vm.Name = category.Name;
            return View(vm);
        }


        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel input)
        {
            if (ModelState.IsValid)
            {
                var category = _db.Categories.SingleOrDefault(x => x.Id == input.Id && !x.IsDelete);
                if (category == null)
                {
                    return NotFound();
                }
                category.Name = input.Name;
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["msg"] = "s:Item Updated Succsfuly !";
                return RedirectToAction("Index");
            }
            return View(input);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            _db.SaveChanges();

            TempData["msg"] = "s:Item Deleted Succsfuly !";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel input)
        {
            if (ModelState.IsValid)
            {
                var category = new Category();
                category.Name = input.Name;
                category.CreatedAt = DateTime.Now;
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["msg"] = "Item Added Succsfuly !";
                return RedirectToAction("Index");
            }
            return View(input);
            //code to save in database
          
        }


    }
}
