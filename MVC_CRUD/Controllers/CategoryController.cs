using MVC_CRUD.Models.Context;
using MVC_CRUD.Models.DTO.CategoryDTO;
using MVC_CRUD.Models.Entities.Concrete;
using MVC_CRUD.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        DataContext db;
        public CategoryController()
        {
            db = new DataContext();
        }
        // GET: Category
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;
                db.Categories.Add(category);
                db.SaveChanges();
                return View();
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult List()
        {
            var categoryList = db.Categories.Where(x=>x.Status!=Status.Passive).ToList();
            return View(categoryList);
        }

        public JsonResult Delete(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            category.Status = Status.Passive;
            category.DeleteTime = DateTime.Now;
            db.SaveChanges();
            return Json("");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            UpdateCategoryDTO model = new UpdateCategoryDTO();
            model.Id = category.Id;
            model.Name = category.Name;
            model.Description = category.Description;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UpdateCategoryDTO model)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {
                category.Name = model.Name;
                category.Description = model.Description;
                category.UpdateDate = DateTime.Now;
                category.Status = Status.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }
    }
}