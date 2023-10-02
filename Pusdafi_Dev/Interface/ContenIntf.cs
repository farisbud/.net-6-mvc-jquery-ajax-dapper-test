using Pusdafi_Dev.Models;
using Pusdafi_Dev.ViewModels.SubCategoryVM;

namespace Pusdafi_Dev.Interface
{
    public interface ContenIntf
    {
        Task<IEnumerable<Content>> getAll();
    }
}
