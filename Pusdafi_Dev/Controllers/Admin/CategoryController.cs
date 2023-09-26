using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.ViewModels.Category;
using Pusdafi_Dev.ViewModels.Pager;

namespace Pusdafi_Dev.Controllers.Admin
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly CategoryIntf _categoryIntf;
       

        public CategoryController(CategoryIntf categoryIntf)
        {
            _categoryIntf = categoryIntf;
         
        }

        [Route("admin/category/")]
        [HttpGet]
        public async Task<IActionResult> Index(int pg=1)
        {
            IEnumerable<Category> categories = await _categoryIntf.getAll();

            #region pagination
            //default size page
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int reCount = categories.Count();

            var pager = new Pager(reCount, pg, pageSize);

            int reSkip = (pg - 1) * pageSize;

            var data = categories.Skip(reSkip).Take(pageSize).ToList();

            ViewBag.Pager = pager;

            #endregion

            //return View("~/Views/Admin/Category/Index.cshtml", categories);
            return View("~/Views/Admin/Category/Index.cshtml", data);
        }

        [Route("admin/category/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View("~/Views/Admin/Category/Create.cshtml");
        }

        [Route("admin/category/create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM createCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Category/Create.cshtml");
            }

            var category = new Category
            {
                Name_cat = createCategoryVM.Name_cat
            };

            _categoryIntf.Add(category);
            TempData["Icon"] = "success";
            TempData["SuccessMessage"] = "Data berhasil disimpan";
            return RedirectToAction("Index");
        }


        [Route("admin/category/edit")]
        // [HttpGet("admin/category/edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {


            Category category = await _categoryIntf.getByIdAsync(id);
            if (category == null) return View("Error");

            var editCategoryVM = new EditCategoryVM
            {
                Id = category.Id,
                Name_cat = category.Name_cat
            };

            return View("~/Views/Admin/Category/Edit.cshtml", editCategoryVM);

        }

        [HttpPost]
        [Route("admin/category/edit")]
        // [HttpGet("admin/category/edit/{id}")]
        public async Task<IActionResult> Edit(EditCategoryVM editCategoryVM)
        {


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed Edit Club");
                return View("~/Views/Admin/Category/Edit.cshtml", editCategoryVM);
            }



            var category = new Category
            {
                Id = editCategoryVM.Id,
                Name_cat = editCategoryVM.Name_cat

                //Club_Category = clubVM.Club_Category
            };


            _categoryIntf.Update(category);
            TempData["Icon"] = "warning";
            TempData["SuccessMessage"] = "The operation was updated!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
           
            //var cek = id;
            if (id == null || id == 0 )
            {
                return View("Error");
            }


            _categoryIntf.Delete(id);
            TempData["Icon"] = "error";
            TempData["SuccessMessage"] = "Delete Success!";
            return RedirectToAction("Index");
        }

    }

}

