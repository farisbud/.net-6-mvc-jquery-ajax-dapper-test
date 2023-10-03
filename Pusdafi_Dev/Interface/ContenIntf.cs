using Pusdafi_Dev.Models;
using Pusdafi_Dev.ViewModels.ContentViewModels;
using Pusdafi_Dev.ViewModels.SubCategoryVM;

namespace Pusdafi_Dev.Interface
{
    public interface ContenIntf
    {
        Task<IEnumerable<Content>> getAll();
        Task<IEnumerable<SubCategory>> getSubCategory(int id);
        Task<IEnumerable<ContentVM>> getEditContent(int id);
    }
}
