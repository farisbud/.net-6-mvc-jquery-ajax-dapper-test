using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pusdafi_Dev.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        
       
        public int Category_id { get; set; }
       
        public string? Name_sub { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
