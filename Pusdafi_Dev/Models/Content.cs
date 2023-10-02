using System.ComponentModel.DataAnnotations;

namespace Pusdafi_Dev.Models
{
    public class Content
    {
        [Key]
        public int id { get; set; }
        public int sub_category_id { get; set; }
        public string? caption { get; set; }
        public string? judul { get; set; }
        public string? sub_content { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
