﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost] //if it is a pasto action we need to write attribute httppost
        [ValidateAntiForgeryToken] //this aswell
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            { 
            _db.Categories.Add(obj);
            _db.SaveChanges(); //goes to the database and save the changes
            return RedirectToAction("Index");
            }   
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null) 
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost] //if it is a pasto action we need to write attribute httppost
        [ValidateAntiForgeryToken] //this aswell
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges(); //goes to the database and save the changes
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
