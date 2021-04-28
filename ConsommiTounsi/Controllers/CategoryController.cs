using ConsommiTounsi.Helper;
using ConsommiTounsi.Models;
using ConsommiTounsi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class CategoryController : Controller
    {



        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("");

        


        [HttpGet]
        public ActionResult updateCategorieModal(int id)
        {
            Category c = categoryService.getCategoryById(id);


            if(c != null)
            {
                return PartialView("_UpdateCategory",c);

            }
            return View();

        }



        //Injection service
        CategoryService categoryService = new CategoryService();
        // GET: Category
        public ActionResult ManageCategory()
        {
            IEnumerable<Category> categories = categoryService.ListCategory();
            ViewBag.categories = categories;
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public JsonResult CreateCategory(Category catJson)
        {
            var response = false;
            categoryService.createCategory(catJson);
                response = true;


            return new JsonResult
                {
                    Data = new
                    {
                        response = response
                    }
                };


        }
   

        [HttpGet]
    public ActionResult CreateCategoryModal()
    {
        return PartialView("_CreateCategory");
    }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //Update Category
        [HttpPost]
        public JsonResult Edit(Category Category)
        {


            int idCategory = Category.IdCategory;

            var response = false;
            if (categoryService.Update(Category, idCategory))
            {
                response = true;
            }
            return new JsonResult { Data = new { response = response } };
        }
        // GET: Category/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = false;
            System.Diagnostics.Debug.WriteLine("id= +" + id);

            if (categoryService.deleteCategoryById(id))
            {

                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}
