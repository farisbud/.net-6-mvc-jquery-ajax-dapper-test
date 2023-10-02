using System.ComponentModel.DataAnnotations;

namespace Pusdafi_Dev.ViewModels.ContentVM
{
    public class ContentVM
    {
        [Key]
        public int Id { get; set; }
        public int subCategoryId { get; set; }
        public string? caption { get; set; }
        public string? judul { get; set; }
        public string? subContent { get; set; }
        public string? aksi { get; set; }
    }
}
