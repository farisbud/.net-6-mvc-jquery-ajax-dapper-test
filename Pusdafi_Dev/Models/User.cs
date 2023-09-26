﻿

using System.ComponentModel.DataAnnotations;

namespace Pusdafi_Dev.Models
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set; }

    }
}
