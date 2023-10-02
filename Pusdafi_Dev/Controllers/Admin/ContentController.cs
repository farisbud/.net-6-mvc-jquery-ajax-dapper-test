using Microsoft.AspNetCore.Mvc;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.ViewModels.ContentViewModels;

namespace Pusdafi_Dev.Controllers.Admin
{
    public class ContentController : Controller
    {
        private readonly ContenIntf _content;
        
        public ContentController(ContenIntf content)
        {
            _content = content;
        }
        [Route("admin/Content")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Admin/Content/Index.cshtml");
        }

        [Route("admin/Content/IndexContentAsync")]
        [HttpPost]
        public async Task<IActionResult> IndexContentAsync()
        {

            IEnumerable<Content> contents = await _content.getAll();

            IList<ContentVM> newContents = new List<ContentVM>();

            foreach (var item in contents)
            {
                ContentVM content = new ContentVM();

                string aksiHtml = "<div class=\"project-actions text-center\">" +
                                      "<a id=\"" + item?.id + "\" class=\"btn btn-danger btn-sm deleteSub\">" +
                                      "<i class=\"fas fa-trash\"></i> Delete</a>" +
                                      "&nbsp" +
                                      "<a id =\"" + item?.id + "\" class=\"btn btn-info btn-sm editSub\">" +
                                      "<i class=\"fas fa-pencil-alt\"></i> Edit</a>" +
                                       "</div>";
                content.Id = item.id;
                content.subCategoryId = item.sub_category_id;
                content.caption = item.caption;
                content.judul = item.judul;
                content.subContent = item.sub_content;
                content.aksi = aksiHtml.ToString();
                newContents.Add(content);
            }


            return Json(new { data = newContents });
        }
    }
}
