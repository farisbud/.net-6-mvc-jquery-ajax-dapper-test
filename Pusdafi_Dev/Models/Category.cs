using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pusdafi_Dev.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name_cat { get; set; }

        [ForeignKey("SUB_CATEGORYS")]
        //public int subId { get; set; }
        public SubCategory? SubCategory { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
