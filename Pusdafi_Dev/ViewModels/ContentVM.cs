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
        public string image {  get; set; }
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

    public class editContenVM
    {
        [Key]
        public int eId { get; set; }
        public int eCategoryId { get; set; }
        public int eSubCategoryId { get; set; }
        public string? eCaption { get; set; }
        public string? eJudul { get; set; }
        //public string? subContent { get; set; }
        public string? eDescription { get; set; }
        [NotMapped]
        [Required]
        public IFormFile eImagePath { get; set; }


    }


}
