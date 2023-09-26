using System.ComponentModel.DataAnnotations;

namespace Pusdafi_Dev.ViewModels.Category
{
    public class EditCategoryVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name_cat { get; set; }

    }
}
