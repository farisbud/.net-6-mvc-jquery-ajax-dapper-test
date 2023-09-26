using Pusdafi_Dev.Models;
using Pusdafi_Dev.ViewModels.Category;
using Pusdafi_Dev.ViewModels.SubCategoryVM;

namespace Pusdafi_Dev.Interface
{
    public interface SubCategoryIntf
    {
        Task<IList<SubCategoryDtVM>> getAll();
        
        Task<IEnumerable<SubCategory>> getAllById(int id);

        Task<IEnumerable<Category>> getCategory();

        Task<Category>getByCategoryId(int id);
    
        Task<SubCategory> getBySubId(int id);

        Task<SubCategory> getByIdAsync(int id);
        bool Add(SubCategory sub);
        bool Update(SubCategory sub);
        bool Delete(int id);

    }
}
