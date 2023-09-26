using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;

using Pusdafi_Dev.ViewModels.SubCategoryVM;
using System.Collections.Generic;

namespace Pusdafi_Dev.Controllers.Admin
{
    [Authorize]
    public class SubCategoryController : Controller
    {

        private readonly SubCategoryIntf _subCategoryIntf;
        private readonly SubCategoryDataIntf _subCategoryDataIntf;

        public SubCategoryController(SubCategoryIntf subCategoryIntf, SubCategoryDataIntf subCategoryDataIntf)
        {
            _subCategoryIntf = subCategoryIntf;
            _subCategoryDataIntf = subCategoryDataIntf;
        }


        [Route("admin/SubCategory")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //IEnumerable<Category> subCategories = await _subCategoryIntf.getAll();
            return View("~/Views/Admin/SubCategory/Index.cshtml");
        }

        [Route("admin/SubCategory/view/{id}")]
        [HttpGet]
        public async Task<IActionResult> IndexSubCategory(int id)
        {
            //var cat = await _subCategoryIntf.getCategory();
            //ViewBag.Category = new SelectList(cat, "Id", "Name_cat");

            Category category = await _subCategoryIntf.getByCategoryId(id);
            ViewBag.namaKategori = category;

            return View("~/Views/Admin/SubCategory/SubIndex.cshtml");
        }

        //get dropdown category
        [Route("admin/SubCategory/view/{id}/getCategory")]
        [HttpGet]
        public async Task<IActionResult> getCategory(int id)
        {
            
            var cat = await _subCategoryIntf.getCategory();

            return Json(new{ category = cat });
        }

        #region ambil data tabel
        //lewat folder repository
        //view di sub/index
        [Route("admin/SubCategory/indexDataTable")]
        [HttpGet]
        public async Task<IActionResult> iDataTable()
        {
            IList<SubCategoryDtVM> subCategories = await _subCategoryIntf.getAll();

            IList<SubCategoryDtVM> newSub = new List<SubCategoryDtVM>();

            foreach (var items in subCategories)
            {
                SubCategoryDtVM sub = new SubCategoryDtVM();

                string aksiHtml = "<div class=\"project-actions text-center\">" +
                                      "<a href=\"SubCategory/view/" + items?.id + " \" class=\"btn btn-info btn-sm\">" +
                                      "<i class=\"fas fa-folder\"></i> view</a>" +
                                      "</div>";


                sub.id = items.id;
                sub.nameCat = items.nameCat;
                sub.subCount = items.subCount;
                sub.aksi = aksiHtml.ToString();
                newSub.Add(sub);
            }



            return Json(new { data = newSub });
        }

        //view di sub/subindex
        [Route("admin/SubCategory/view/{id}/getSubCategory")]
        [HttpGet]
        public async Task<IActionResult> getSubCategory(int id)
        {

            IEnumerable<SubCategory> subCategories = await _subCategoryIntf.getAllById(id);

            //for new list
            IList<SubCategoryIdDtVM> newSubCategory = new List<SubCategoryIdDtVM>();

            foreach (var item in subCategories)
            {
                SubCategoryIdDtVM newSub = new SubCategoryIdDtVM();

                string aksiHtml = "<div class=\"project-actions text-center\">" +
                                      "<a id=\""+item?.Id+ "\" class=\"btn btn-danger btn-sm deleteSub\">" +
                                      "<i class=\"fas fa-trash\"></i> Delete</a>" +
                                      "&nbsp" +
                                      "<a id =\"" + item?.Id + "\" class=\"btn btn-info btn-sm editSub\">" +
                                      "<i class=\"fas fa-pencil-alt\"></i> Edit</a>" +
                                       "</div>";
                        

                newSub.id = item.Id;
                newSub.categoryId = item.Category_id;
                newSub.nameSub = item.Name_sub;
                newSub.aksi = aksiHtml.ToString();
                newSubCategory.Add(newSub);
            }


            return Json(new { data = newSubCategory });
        }
        #endregion

        #region ambil data dari service belum terpakai

        //[Route("admin/SubCategory/indexDataTable")]
        //[HttpGet]
        //public IActionResult iDataTable()
        //{
        //    try
        //    {
        //        var result = _subCategoryDataIntf.indexDataTable();//, headerDevice,headerVersion);

        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new
        //        {

        //            status = "0",
        //            message = "Get Sub Category Data Table Failed",
        //        });



        //    }


        //}

        #endregion

        [Route("admin/SubCategory/view/{id}/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateSubCategoryVM createSubCategoryVM)
        {
            
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = 400,
                    message = "Data gagal disimpan",
                });
            }

            var newData = new SubCategory
            {
                Category_id = createSubCategoryVM.categoryId,
                Name_sub = createSubCategoryVM.nameSub
            };

            try
            {
                _subCategoryIntf.Add(newData);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 400,
                    message = ex.Message,
                });

            }

            return Json(new
            {
                status = 200,
                message = "Data berhasil disimpan",
            });

        }

        [Route("admin/SubCategory/view/{id}/getEdit/{idsub}")]
        [HttpGet]
        public async Task<IActionResult> getEdit(int id, int idsub)
        {
            var cat = await _subCategoryIntf.getCategory();
            var subcategory= await _subCategoryIntf.getBySubId(idsub);
 
            return Json(new 
            { 
                category = cat,
                subCategory = subcategory
            });
        }

        [Route("admin/SubCategory/view/{id}/Edit/{idSub}")]
        [HttpPost]
        public async Task<IActionResult> Edit (int idSub,EditSubCategoryVM editSubCategoryVM)
        {

            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = 400,
                    message = "Data gagal disimpan",
                });
            }

            var newData = new SubCategory
            {
                Id = idSub,
                Category_id = editSubCategoryVM.eCategoryId,
                Name_sub = editSubCategoryVM.eNameSub
            };

            var cek = newData;
            try
            {
                _subCategoryIntf.Update(newData);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 400,
                    message = ex.Message,
                });

            }

            return Json(new
            {
                status = 200,
                message = "Data berhasil diperbarui",
            });
        }

        [Route("admin/SubCategory/view/{id}/Delete/{idSub}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int idSub)
        {
            if (idSub == null || idSub == 0)
            {
                return Json(new
                {
                    status = 400,
                    message = "id kosong",
                });
            }

            try
            {
                _subCategoryIntf.Delete(idSub);

            }catch(Exception ex)
            {
                return Json(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }

            return Json(new
            {
                status = 200,
                message = "Data berhasil dihapus",
            });
        }
    }
}
