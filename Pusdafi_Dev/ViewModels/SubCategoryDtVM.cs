using Pusdafi_Dev.Models;
using System.ComponentModel.DataAnnotations;

namespace Pusdafi_Dev.ViewModels.SubCategoryVM
{
    public class SubCategoryDtVM
    {
        public int id { get; set; }
        public string nameCat { get; set; }
        public int subCount { get; set; }
        public string aksi { get; set; }
    }

    public class SubCategoryIdDtVM
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public string nameSub { get; set; }
        public string aksi { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

    }

    public class CreateSubCategoryVM
    {

        public int categoryId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string nameSub { get; set; }
    }
    public class EditSubCategoryVM
    {
        public int id { get; set; }
        public int eCategoryId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string eNameSub { get; set; }
    }



}
