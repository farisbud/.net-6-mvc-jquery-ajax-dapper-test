using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pusdafi_Dev.ViewModels.ContentViewModels
{
    public class ContentVM
    {
        [Key]
        public int Id { get; set; }
        public int categoryId { get; set; }
        public int subCategoryId { get; set; }
        public string? caption { get; set; }
        public string? judul { get; set; }
        public string? subContent { get; set; }
        public string? description { get; set; }
        [NotMapped]
        [Required]
        public IFormFile ImagePath { get; set; }
        public string? aksi { get; set; }
    }

    public class addContenVM
    {
        [Key]
        public int id { get; set; }
        public int categoryId { get; set; }
        public int subCategoryId { get; set; }
        public string? caption { get; set; }
        public string? judul { get; set; }
        //public string? subContent { get; set; }
        public string? description { get; set; }
        [NotMapped]
        [Required]
        public IFormFile ImagePath { get; set; }
       

    }
}
