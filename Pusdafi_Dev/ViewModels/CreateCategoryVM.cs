using System.ComponentModel.DataAnnotations;

namespace Pusdafi_Dev.ViewModels.Category
{
    public class CreateCategoryVM
    {
        [Required]
        public string Name_cat { get; set; }
    }
}
