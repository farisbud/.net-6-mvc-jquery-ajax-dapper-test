using Pusdafi_Dev.Models;

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
        public int eCategoryId { get; set; }
        public string nameSub { get; set; }
        public string eNameSub { get; set; }
        public string aksi { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

    }

    public class CreateSubCategoryVM
    {

        public int categoryId { get; set; }
        public string nameSub { get; set; }
    }
    public class EditSubCategoryVM
    {
       
        public int eCategoryId { get; set; }
        public string eNameSub { get; set; }
    }



}
