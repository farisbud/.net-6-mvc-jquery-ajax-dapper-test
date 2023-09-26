using Pusdafi_Dev.Models;

namespace Pusdafi_Dev.Interface
{
    public interface CategoryIntf
    {
        Task<IEnumerable<Category>> getAll();
        Task<Category> getByIdAsync(int id);
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(int id);


    }
}
